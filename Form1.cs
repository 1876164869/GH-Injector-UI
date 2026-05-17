using System.Diagnostics;

namespace Injector;

public partial class Form1 : Form
{
    private const string DefaultInjectorPath = @"C:\Users\MIT\source\repos\TestInjector\GH Injector - x86.dll";
    private const string DefaultPayloadPath = @"C:\Users\MIT\source\repos\RenderHook\Release\RenderHook.dll";

    private readonly List<ProcessRow> _processes = [];
    private readonly List<FlagItem> _flagItems =
    [
        new("Erase header", InjectionFlags.EraseHeader),
        new("Fake header", InjectionFlags.FakeHeader),
        new("Unlink from PEB", InjectionFlags.UnlinkFromPeb),
        new("Thread create cloaked", InjectionFlags.ThreadCreateCloaked),
        new("Scramble DLL name", InjectionFlags.ScrambleDllName),
        new("Load DLL copy", InjectionFlags.LoadDllCopy),
        new("Hijack handle", InjectionFlags.HijackHandle),
        new("MM clean data dir", InjectionFlags.MmCleanDataDir),
        new("MM resolve imports", InjectionFlags.MmResolveImports),
        new("MM resolve delay imports", InjectionFlags.MmResolveDelayImports),
        new("MM execute TLS", InjectionFlags.MmExecuteTls),
        new("MM enable exceptions", InjectionFlags.MmEnableExceptions),
        new("MM set page protections", InjectionFlags.MmSetPageProtections),
        new("MM init security cookie", InjectionFlags.MmInitSecurityCookie),
        new("MM run DllMain", InjectionFlags.MmRunDllMain),
        new("MM run under loader lock", InjectionFlags.MmRunUnderLdrLock),
        new("MM shift module base", InjectionFlags.MmShiftModuleBase)
    ];

    private ProcessRow? SelectedProcess =>
        processesListView.SelectedItems.Count == 0
            ? null
            : processesListView.SelectedItems[0].Tag as ProcessRow;

    public Form1()
    {
        InitializeComponent();
        BuildRuntimeLayout();
        InitializeDefaults();
        RefreshProcessList();
    }

    private void BuildRuntimeLayout()
    {
        rootLayout.Controls.Remove(logTextBox);

        var rightLayout = new TableLayoutPanel
        {
            ColumnCount = 2,
            RowCount = 5,
            Dock = DockStyle.Fill,
            Margin = new Padding(3),
        };
        rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        rightLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 160F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 34F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
        rightLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

        flagsCheckedListBox.Dock = DockStyle.Fill;
        rightLayout.Controls.Add(flagsCheckedListBox, 0, 0);
        rightLayout.SetColumnSpan(flagsCheckedListBox, 2);

        mmDefaultButton.Text = "MM 默认";
        mmDefaultButton.Dock = DockStyle.Fill;
        mmDefaultButton.Margin = new Padding(0, 4, 4, 4);
        mmDefaultButton.Click += MmDefaultButton_Click;
        rightLayout.Controls.Add(mmDefaultButton, 0, 1);

        clearFlagsButton.Text = "清空 Flags";
        clearFlagsButton.Dock = DockStyle.Fill;
        clearFlagsButton.Margin = new Padding(4, 4, 0, 4);
        clearFlagsButton.Click += ClearFlagsButton_Click;
        rightLayout.Controls.Add(clearFlagsButton, 1, 1);

        downloadProgressBar.Dock = DockStyle.Fill;
        downloadProgressBar.Margin = new Padding(0, 3, 0, 3);
        downloadProgressBar.Maximum = 1000;
        rightLayout.Controls.Add(downloadProgressBar, 0, 2);
        rightLayout.SetColumnSpan(downloadProgressBar, 2);

        prepareButton.Text = "准备符号";
        prepareButton.Dock = DockStyle.Fill;
        prepareButton.Margin = new Padding(0, 4, 4, 4);
        prepareButton.Click += PrepareButton_Click;
        rightLayout.Controls.Add(prepareButton, 0, 3);

        injectButton.Text = "注入";
        injectButton.Dock = DockStyle.Fill;
        injectButton.Margin = new Padding(4, 4, 0, 4);
        injectButton.Click += InjectButton_Click;
        rightLayout.Controls.Add(injectButton, 1, 3);

        logTextBox.Dock = DockStyle.Fill;
        rightLayout.Controls.Add(logTextBox, 0, 4);
        rightLayout.SetColumnSpan(logTextBox, 2);

        rootLayout.Controls.Add(rightLayout, 1, 1);
    }

    private void InitializeDefaults()
    {
        injectorPathTextBox.Text = File.Exists(DefaultInjectorPath) ? DefaultInjectorPath : "";
        dllPathTextBox.Text = File.Exists(DefaultPayloadPath) ? DefaultPayloadPath : "";

        modeComboBox.DataSource = Enum.GetValues<InjectionMode>();
        methodComboBox.DataSource = Enum.GetValues<LaunchMethod>();
        modeComboBox.SelectedItem = InjectionMode.LdrLoadDll;
        methodComboBox.SelectedItem = LaunchMethod.NtCreateThreadEx;

        foreach (var item in _flagItems)
        {
            flagsCheckedListBox.Items.Add(item);
        }

        AppendLog("就绪。当前程序按 x86 编译，请选择 GH Injector - x86.dll 和 32 位目标进程。");
    }

    private void BrowseInjectorButton_Click(object? sender, EventArgs e)
    {
        BrowseDllInto(injectorPathTextBox, "选择 GH Injector DLL");
    }

    private void BrowseDllButton_Click(object? sender, EventArgs e)
    {
        BrowseDllInto(dllPathTextBox, "选择要注入的 DLL");
    }

    private static void BrowseDllInto(TextBox textBox, string title)
    {
        using var dialog = new OpenFileDialog
        {
            Title = title,
            Filter = "DLL 文件 (*.dll)|*.dll|所有文件 (*.*)|*.*",
            CheckFileExists = true
        };

        if (File.Exists(textBox.Text))
        {
            dialog.InitialDirectory = Path.GetDirectoryName(textBox.Text);
            dialog.FileName = Path.GetFileName(textBox.Text);
        }

        if (dialog.ShowDialog() == DialogResult.OK)
        {
            textBox.Text = dialog.FileName;
        }
    }

    private void RefreshProcessesButton_Click(object? sender, EventArgs e)
    {
        RefreshProcessList();
    }

    private void ProcessFilterTextBox_TextChanged(object? sender, EventArgs e)
    {
        RenderProcesses();
    }

    private void ProcessesListView_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var selected = SelectedProcess;
        selectedProcessLabel.Text = selected is null
            ? "未选择进程"
            : $"已选择：{selected.Name}.exe  PID {selected.Pid}";
    }

    private void ProcessesListView_DoubleClick(object? sender, EventArgs e)
    {
        if (injectButton.Enabled)
        {
            _ = InjectAsync();
        }
    }

    private void MmDefaultButton_Click(object? sender, EventArgs e)
    {
        SetFlags(InjectionFlags.MmDefault);
    }

    private void ClearFlagsButton_Click(object? sender, EventArgs e)
    {
        SetFlags(InjectionFlags.None);
    }

    private async void PrepareButton_Click(object? sender, EventArgs e)
    {
        await PrepareSymbolsAsync();
    }

    private async void InjectButton_Click(object? sender, EventArgs e)
    {
        await InjectAsync();
    }

    private void RefreshProcessList()
    {
        _processes.Clear();

        foreach (var process in Process.GetProcesses().OrderBy(p => p.ProcessName))
        {
            using (process)
            {
                try
                {
                    _processes.Add(new ProcessRow(
                        process.ProcessName,
                        (uint)process.Id,
                        TryGetProcessPath(process)));
                }
                catch
                {
                    // Some protected processes can disappear or reject metadata access while enumerating.
                }
            }
        }

        RenderProcesses();
        AppendLog($"已刷新进程列表：{_processes.Count} 个。");
    }

    private void RenderProcesses()
    {
        var filter = processFilterTextBox.Text.Trim();
        var rows = string.IsNullOrWhiteSpace(filter)
            ? _processes
            : _processes.Where(p =>
                p.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                p.Pid.ToString().Contains(filter, StringComparison.OrdinalIgnoreCase) ||
                p.Path.Contains(filter, StringComparison.OrdinalIgnoreCase));

        processesListView.BeginUpdate();
        processesListView.Items.Clear();

        foreach (var row in rows)
        {
            var item = new ListViewItem(row.Name)
            {
                Tag = row
            };
            item.SubItems.Add(row.Pid.ToString());
            item.SubItems.Add(row.Path);
            processesListView.Items.Add(item);
        }

        processesListView.EndUpdate();
    }

    private async Task PrepareSymbolsAsync()
    {
        if (!ValidateInjectorPath(out var injectorPath))
        {
            return;
        }

        SetBusy(true);
        try
        {
            using var injection = new NativeInjection(injectorPath);
            await PrepareSymbolsAsync(injection);
        }
        catch (Exception ex)
        {
            AppendLog($"准备符号失败：{ex.Message}");
            MessageBox.Show(this, ex.Message, "准备符号失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetBusy(false);
        }
    }

    private async Task PrepareSymbolsAsync(NativeInjection injection)
    {
        if (!injection.SupportsSymbolDownload)
        {
            AppendLog("当前 GH Injector DLL 不提供完整的符号下载接口，跳过准备步骤。");
            downloadProgressBar.Value = downloadProgressBar.Maximum;
            return;
        }

        AppendLog("开始准备符号和导入信息...");
        await Task.Delay(500);
        injection.StartDownload();

        while (injection.GetDownloadProgress(0, false) < 1.0f)
        {
            SetProgress(injection.GetDownloadProgress(0, false));
            await Task.Delay(30);
        }

        SetProgress(1.0f);
        while (injection.GetSymbolState() != 0)
        {
            await Task.Delay(30);
        }

        while (injection.GetImportState() != 0)
        {
            await Task.Delay(30);
        }

        AppendLog("符号和导入信息已准备完成。");
    }

    private async Task InjectAsync()
    {
        if (!ValidateInjectorPath(out var injectorPath) ||
            !ValidatePayloadPath(out var payloadPath) ||
            !ValidateTarget(out var target))
        {
            return;
        }

        var request = new InjectionRequest(
            payloadPath,
            target.Pid,
            (InjectionMode)modeComboBox.SelectedItem!,
            (LaunchMethod)methodComboBox.SelectedItem!,
            (uint)GetSelectedFlags(),
            (uint)timeoutNumericUpDown.Value,
            (uint)handleNumericUpDown.Value,
            generateLogCheckBox.Checked);

        SetBusy(true);
        try
        {
            using var injection = new NativeInjection(injectorPath);

            if (waitSymbolsCheckBox.Checked)
            {
                await PrepareSymbolsAsync(injection);
            }

            AppendLog($"正在注入 {Path.GetFileName(payloadPath)} -> {target.Name}.exe ({target.Pid})");
            var result = await Task.Run(() => injection.Inject(request));
            AppendLog($"InjectA 返回：0x{result.ErrorCode:X8}，模块基址：0x{result.DllBase.ToInt64():X}");

            if (result.ErrorCode == 0)
            {
                MessageBox.Show(this, "注入完成。", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(this, $"InjectA 返回错误码：0x{result.ErrorCode:X8}", "注入失败", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            AppendLog($"注入失败：{ex.Message}");
            MessageBox.Show(this, ex.Message, "注入失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            SetBusy(false);
        }
    }

    private bool ValidateInjectorPath(out string path)
    {
        path = injectorPathTextBox.Text.Trim();
        return ValidateExistingFile(path, "请选择 GH Injector DLL。");
    }

    private bool ValidatePayloadPath(out string path)
    {
        path = dllPathTextBox.Text.Trim();
        return ValidateExistingFile(path, "请选择要注入的 DLL。");
    }

    private bool ValidateTarget(out ProcessRow target)
    {
        target = SelectedProcess!;
        if (target is not null)
        {
            return true;
        }

        MessageBox.Show(this, "请先选择目标进程。", "缺少目标进程", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }

    private bool ValidateExistingFile(string path, string message)
    {
        if (File.Exists(path))
        {
            return true;
        }

        MessageBox.Show(this, message, "文件不存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
    }

    private InjectionFlags GetSelectedFlags()
    {
        var flags = InjectionFlags.None;
        foreach (var item in flagsCheckedListBox.CheckedItems.OfType<FlagItem>())
        {
            flags |= item.Value;
        }

        return flags;
    }

    private void SetFlags(InjectionFlags flags)
    {
        for (var i = 0; i < flagsCheckedListBox.Items.Count; i++)
        {
            var item = (FlagItem)flagsCheckedListBox.Items[i];
            flagsCheckedListBox.SetItemChecked(i, flags.HasFlag(item.Value));
        }
    }

    private void SetBusy(bool busy)
    {
        prepareButton.Enabled = !busy;
        injectButton.Enabled = !busy;
        refreshProcessesButton.Enabled = !busy;
        browseInjectorButton.Enabled = !busy;
        browseDllButton.Enabled = !busy;
        UseWaitCursor = busy;
    }

    private void SetProgress(float value)
    {
        var clamped = Math.Clamp(value, 0.0f, 1.0f);
        downloadProgressBar.Value = (int)(clamped * downloadProgressBar.Maximum);
    }

    private void AppendLog(string message)
    {
        logTextBox.AppendText($"[{DateTime.Now:HH:mm:ss}] {message}{Environment.NewLine}");
    }

    private static string TryGetProcessPath(Process process)
    {
        try
        {
            return process.MainModule?.FileName ?? "";
        }
        catch
        {
            return "";
        }
    }

    private sealed record ProcessRow(string Name, uint Pid, string Path);

    private sealed record FlagItem(string Text, InjectionFlags Value)
    {
        public override string ToString() => Text;
    }
}
