namespace Injector
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TableLayoutPanel rootLayout;
        private GroupBox pathsGroup;
        private TableLayoutPanel pathsLayout;
        private Label dllLabel;
        private TextBox dllPathTextBox;
        private Button browseDllButton;
        private GroupBox targetGroup;
        private TableLayoutPanel targetLayout;
        private TextBox processFilterTextBox;
        private Button refreshProcessesButton;
        private ListView processesListView;
        private ColumnHeader processNameColumn;
        private ColumnHeader pidColumn;
        private ColumnHeader processArchitectureColumn;
        private ColumnHeader processPathColumn;
        private Label selectedProcessLabel;
        private GroupBox optionsGroup;
        private TableLayoutPanel optionsLayout;
        private Label modeLabel;
        private ComboBox modeComboBox;
        private Label methodLabel;
        private ComboBox methodComboBox;
        private Label timeoutLabel;
        private NumericUpDown timeoutNumericUpDown;
        private Label handleLabel;
        private NumericUpDown handleNumericUpDown;
        private CheckBox generateLogCheckBox;
        private CheckBox waitSymbolsCheckBox;
        private CheckedListBox flagsCheckedListBox;
        private Button mmDefaultButton;
        private Button clearFlagsButton;
        private ProgressBar downloadProgressBar;
        private Button prepareButton;
        private Button injectButton;
        private TextBox logTextBox;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            rootLayout = new TableLayoutPanel();
            pathsGroup = new GroupBox();
            pathsLayout = new TableLayoutPanel();
            dllLabel = new Label();
            dllPathTextBox = new TextBox();
            browseDllButton = new Button();
            targetGroup = new GroupBox();
            targetLayout = new TableLayoutPanel();
            processFilterTextBox = new TextBox();
            refreshProcessesButton = new Button();
            processesListView = new ListView();
            processNameColumn = new ColumnHeader();
            pidColumn = new ColumnHeader();
            processArchitectureColumn = new ColumnHeader();
            processPathColumn = new ColumnHeader();
            selectedProcessLabel = new Label();
            optionsGroup = new GroupBox();
            optionsLayout = new TableLayoutPanel();
            modeLabel = new Label();
            modeComboBox = new ComboBox();
            methodLabel = new Label();
            methodComboBox = new ComboBox();
            timeoutLabel = new Label();
            timeoutNumericUpDown = new NumericUpDown();
            handleLabel = new Label();
            handleNumericUpDown = new NumericUpDown();
            generateLogCheckBox = new CheckBox();
            waitSymbolsCheckBox = new CheckBox();
            logTextBox = new TextBox();
            flagsCheckedListBox = new CheckedListBox();
            mmDefaultButton = new Button();
            clearFlagsButton = new Button();
            downloadProgressBar = new ProgressBar();
            prepareButton = new Button();
            injectButton = new Button();
            rootLayout.SuspendLayout();
            pathsGroup.SuspendLayout();
            pathsLayout.SuspendLayout();
            targetGroup.SuspendLayout();
            targetLayout.SuspendLayout();
            optionsGroup.SuspendLayout();
            optionsLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeoutNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)handleNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // rootLayout
            // 
            rootLayout.ColumnCount = 2;
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 58F));
            rootLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 42F));
            rootLayout.Controls.Add(pathsGroup, 0, 0);
            rootLayout.Controls.Add(targetGroup, 0, 1);
            rootLayout.Controls.Add(optionsGroup, 1, 0);
            rootLayout.Controls.Add(logTextBox, 1, 1);
            rootLayout.Dock = DockStyle.Fill;
            rootLayout.Location = new Point(0, 0);
            rootLayout.Margin = new Padding(2, 3, 2, 3);
            rootLayout.Name = "rootLayout";
            rootLayout.Padding = new Padding(9, 10, 9, 10);
            rootLayout.RowCount = 2;
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 121F));
            rootLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            rootLayout.Size = new Size(874, 579);
            rootLayout.TabIndex = 0;
            // 
            // pathsGroup
            // 
            pathsGroup.Controls.Add(pathsLayout);
            pathsGroup.Dock = DockStyle.Fill;
            pathsGroup.Location = new Point(11, 13);
            pathsGroup.Margin = new Padding(2, 3, 2, 3);
            pathsGroup.Name = "pathsGroup";
            pathsGroup.Padding = new Padding(8, 8, 8, 8);
            pathsGroup.Size = new Size(492, 115);
            pathsGroup.TabIndex = 0;
            pathsGroup.TabStop = false;
            pathsGroup.Text = "文件";
            // 
            // pathsLayout
            // 
            pathsLayout.ColumnCount = 3;
            pathsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 82F));
            pathsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pathsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 72F));
            pathsLayout.Controls.Add(dllLabel, 0, 0);
            pathsLayout.Controls.Add(dllPathTextBox, 1, 0);
            pathsLayout.Controls.Add(browseDllButton, 2, 0);
            pathsLayout.Dock = DockStyle.Fill;
            pathsLayout.Location = new Point(8, 24);
            pathsLayout.Margin = new Padding(2, 3, 2, 3);
            pathsLayout.Name = "pathsLayout";
            pathsLayout.RowCount = 1;
            pathsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pathsLayout.Size = new Size(476, 83);
            pathsLayout.TabIndex = 0;
            // 
            // dllLabel
            // 
            dllLabel.Anchor = AnchorStyles.Left;
            dllLabel.AutoSize = true;
            dllLabel.Location = new Point(2, 33);
            dllLabel.Margin = new Padding(2, 0, 2, 0);
            dllLabel.Name = "dllLabel";
            dllLabel.Size = new Size(57, 17);
            dllLabel.TabIndex = 3;
            dllLabel.Text = "注入 DLL";
            // 
            // dllPathTextBox
            // 
            dllPathTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dllPathTextBox.Location = new Point(84, 30);
            dllPathTextBox.Margin = new Padding(2, 3, 2, 3);
            dllPathTextBox.Name = "dllPathTextBox";
            dllPathTextBox.Size = new Size(318, 23);
            dllPathTextBox.TabIndex = 4;
            // 
            // browseDllButton
            // 
            browseDllButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            browseDllButton.Location = new Point(406, 28);
            browseDllButton.Margin = new Padding(2, 3, 2, 3);
            browseDllButton.Name = "browseDllButton";
            browseDllButton.Size = new Size(68, 26);
            browseDllButton.TabIndex = 5;
            browseDllButton.Text = "浏览";
            browseDllButton.UseVisualStyleBackColor = true;
            browseDllButton.Click += BrowseDllButton_Click;
            // 
            // targetGroup
            // 
            targetGroup.Controls.Add(targetLayout);
            targetGroup.Dock = DockStyle.Fill;
            targetGroup.Location = new Point(11, 134);
            targetGroup.Margin = new Padding(2, 3, 2, 3);
            targetGroup.Name = "targetGroup";
            targetGroup.Padding = new Padding(8, 8, 8, 8);
            targetGroup.Size = new Size(492, 432);
            targetGroup.TabIndex = 1;
            targetGroup.TabStop = false;
            targetGroup.Text = "目标进程";
            // 
            // targetLayout
            // 
            targetLayout.ColumnCount = 2;
            targetLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            targetLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 78F));
            targetLayout.Controls.Add(processFilterTextBox, 0, 0);
            targetLayout.Controls.Add(refreshProcessesButton, 1, 0);
            targetLayout.Controls.Add(processesListView, 0, 1);
            targetLayout.Controls.Add(selectedProcessLabel, 0, 2);
            targetLayout.Dock = DockStyle.Fill;
            targetLayout.Location = new Point(8, 24);
            targetLayout.Margin = new Padding(2, 3, 2, 3);
            targetLayout.Name = "targetLayout";
            targetLayout.RowCount = 3;
            targetLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            targetLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            targetLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            targetLayout.Size = new Size(476, 400);
            targetLayout.TabIndex = 0;
            // 
            // processFilterTextBox
            // 
            processFilterTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            processFilterTextBox.Location = new Point(2, 6);
            processFilterTextBox.Margin = new Padding(2, 3, 2, 3);
            processFilterTextBox.Name = "processFilterTextBox";
            processFilterTextBox.PlaceholderText = "按进程名或 PID 过滤";
            processFilterTextBox.Size = new Size(394, 23);
            processFilterTextBox.TabIndex = 0;
            processFilterTextBox.TextChanged += ProcessFilterTextBox_TextChanged;
            // 
            // refreshProcessesButton
            // 
            refreshProcessesButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            refreshProcessesButton.Location = new Point(400, 5);
            refreshProcessesButton.Margin = new Padding(2, 3, 2, 3);
            refreshProcessesButton.Name = "refreshProcessesButton";
            refreshProcessesButton.Size = new Size(74, 26);
            refreshProcessesButton.TabIndex = 1;
            refreshProcessesButton.Text = "刷新";
            refreshProcessesButton.UseVisualStyleBackColor = true;
            refreshProcessesButton.Click += RefreshProcessesButton_Click;
            // 
            // processesListView
            // 
            processesListView.Columns.AddRange(new ColumnHeader[] { processNameColumn, pidColumn, processArchitectureColumn, processPathColumn });
            targetLayout.SetColumnSpan(processesListView, 2);
            processesListView.Dock = DockStyle.Fill;
            processesListView.FullRowSelect = true;
            processesListView.GridLines = true;
            processesListView.Location = new Point(2, 39);
            processesListView.Margin = new Padding(2, 3, 2, 3);
            processesListView.MultiSelect = false;
            processesListView.Name = "processesListView";
            processesListView.Size = new Size(472, 331);
            processesListView.TabIndex = 2;
            processesListView.UseCompatibleStateImageBehavior = false;
            processesListView.View = View.Details;
            processesListView.SelectedIndexChanged += ProcessesListView_SelectedIndexChanged;
            processesListView.DoubleClick += ProcessesListView_DoubleClick;
            // 
            // processNameColumn
            // 
            processNameColumn.Text = "名称";
            processNameColumn.Width = 180;
            // 
            // pidColumn
            // 
            pidColumn.Text = "PID";
            pidColumn.Width = 80;
            // 
            // processArchitectureColumn
            // 
            processArchitectureColumn.Text = "架构";
            processArchitectureColumn.Width = 80;
            // 
            // processPathColumn
            // 
            processPathColumn.Text = "路径";
            processPathColumn.Width = 260;
            // 
            // selectedProcessLabel
            // 
            selectedProcessLabel.Anchor = AnchorStyles.Left;
            selectedProcessLabel.AutoSize = true;
            targetLayout.SetColumnSpan(selectedProcessLabel, 2);
            selectedProcessLabel.Location = new Point(2, 378);
            selectedProcessLabel.Margin = new Padding(2, 0, 2, 0);
            selectedProcessLabel.Name = "selectedProcessLabel";
            selectedProcessLabel.Size = new Size(68, 17);
            selectedProcessLabel.TabIndex = 3;
            selectedProcessLabel.Text = "未选择进程";
            // 
            // optionsGroup
            // 
            optionsGroup.Controls.Add(optionsLayout);
            optionsGroup.Dock = DockStyle.Fill;
            optionsGroup.Location = new Point(507, 13);
            optionsGroup.Margin = new Padding(2, 3, 2, 3);
            optionsGroup.Name = "optionsGroup";
            optionsGroup.Padding = new Padding(8, 8, 8, 8);
            optionsGroup.Size = new Size(356, 115);
            optionsGroup.TabIndex = 2;
            optionsGroup.TabStop = false;
            optionsGroup.Text = "注入选项";
            // 
            // optionsLayout
            // 
            optionsLayout.ColumnCount = 4;
            optionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 56F));
            optionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            optionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 67F));
            optionsLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            optionsLayout.Controls.Add(modeLabel, 0, 0);
            optionsLayout.Controls.Add(modeComboBox, 1, 0);
            optionsLayout.Controls.Add(methodLabel, 2, 0);
            optionsLayout.Controls.Add(methodComboBox, 3, 0);
            optionsLayout.Controls.Add(timeoutLabel, 0, 1);
            optionsLayout.Controls.Add(timeoutNumericUpDown, 1, 1);
            optionsLayout.Controls.Add(handleLabel, 2, 1);
            optionsLayout.Controls.Add(handleNumericUpDown, 3, 1);
            optionsLayout.Controls.Add(generateLogCheckBox, 0, 2);
            optionsLayout.Controls.Add(waitSymbolsCheckBox, 2, 2);
            optionsLayout.Dock = DockStyle.Fill;
            optionsLayout.Location = new Point(8, 24);
            optionsLayout.Margin = new Padding(2, 3, 2, 3);
            optionsLayout.Name = "optionsLayout";
            optionsLayout.RowCount = 3;
            optionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            optionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            optionsLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            optionsLayout.Size = new Size(340, 83);
            optionsLayout.TabIndex = 0;
            // 
            // modeLabel
            // 
            modeLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modeLabel.Location = new Point(2, 3);
            modeLabel.Margin = new Padding(2, 3, 2, 3);
            modeLabel.Name = "modeLabel";
            modeLabel.Size = new Size(52, 21);
            modeLabel.TabIndex = 0;
            modeLabel.Text = "模式";
            modeLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // modeComboBox
            // 
            modeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            modeComboBox.FormattingEnabled = true;
            modeComboBox.Location = new Point(58, 3);
            modeComboBox.Margin = new Padding(2, 3, 2, 3);
            modeComboBox.Name = "modeComboBox";
            modeComboBox.Size = new Size(104, 25);
            modeComboBox.TabIndex = 1;
            // 
            // methodLabel
            // 
            methodLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            methodLabel.Location = new Point(166, 3);
            methodLabel.Margin = new Padding(2, 3, 2, 3);
            methodLabel.Name = "methodLabel";
            methodLabel.Size = new Size(63, 21);
            methodLabel.TabIndex = 2;
            methodLabel.Text = "启动方式";
            methodLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // methodComboBox
            // 
            methodComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            methodComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            methodComboBox.FormattingEnabled = true;
            methodComboBox.Location = new Point(233, 3);
            methodComboBox.Margin = new Padding(2, 3, 2, 3);
            methodComboBox.Name = "methodComboBox";
            methodComboBox.Size = new Size(105, 25);
            methodComboBox.TabIndex = 3;
            // 
            // timeoutLabel
            // 
            timeoutLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timeoutLabel.Location = new Point(2, 30);
            timeoutLabel.Margin = new Padding(2, 3, 2, 3);
            timeoutLabel.Name = "timeoutLabel";
            timeoutLabel.Size = new Size(52, 21);
            timeoutLabel.TabIndex = 4;
            timeoutLabel.Text = "超时(ms)";
            timeoutLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // timeoutNumericUpDown
            // 
            timeoutNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            timeoutNumericUpDown.Location = new Point(58, 30);
            timeoutNumericUpDown.Margin = new Padding(2, 3, 2, 3);
            timeoutNumericUpDown.Maximum = new decimal(new int[] { 600000, 0, 0, 0 });
            timeoutNumericUpDown.Name = "timeoutNumericUpDown";
            timeoutNumericUpDown.Size = new Size(104, 23);
            timeoutNumericUpDown.TabIndex = 5;
            timeoutNumericUpDown.Value = new decimal(new int[] { 10000, 0, 0, 0 });
            // 
            // handleLabel
            // 
            handleLabel.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            handleLabel.Location = new Point(166, 30);
            handleLabel.Margin = new Padding(2, 3, 2, 3);
            handleLabel.Name = "handleLabel";
            handleLabel.Size = new Size(63, 21);
            handleLabel.TabIndex = 6;
            handleLabel.Text = "句柄值";
            handleLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // handleNumericUpDown
            // 
            handleNumericUpDown.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            handleNumericUpDown.Location = new Point(233, 30);
            handleNumericUpDown.Margin = new Padding(2, 3, 2, 3);
            handleNumericUpDown.Maximum = new decimal(new int[] { -1, 0, 0, 0 });
            handleNumericUpDown.Name = "handleNumericUpDown";
            handleNumericUpDown.Size = new Size(105, 23);
            handleNumericUpDown.TabIndex = 7;
            // 
            // generateLogCheckBox
            // 
            generateLogCheckBox.Anchor = AnchorStyles.Left;
            generateLogCheckBox.AutoSize = true;
            generateLogCheckBox.Checked = true;
            generateLogCheckBox.CheckState = CheckState.Checked;
            optionsLayout.SetColumnSpan(generateLogCheckBox, 2);
            generateLogCheckBox.Location = new Point(2, 58);
            generateLogCheckBox.Margin = new Padding(2, 3, 2, 3);
            generateLogCheckBox.Name = "generateLogCheckBox";
            generateLogCheckBox.Size = new Size(99, 21);
            generateLogCheckBox.TabIndex = 8;
            generateLogCheckBox.Text = "生成错误日志";
            generateLogCheckBox.UseVisualStyleBackColor = true;
            // 
            // waitSymbolsCheckBox
            // 
            waitSymbolsCheckBox.Anchor = AnchorStyles.Left;
            waitSymbolsCheckBox.AutoSize = true;
            waitSymbolsCheckBox.Checked = true;
            waitSymbolsCheckBox.CheckState = CheckState.Checked;
            optionsLayout.SetColumnSpan(waitSymbolsCheckBox, 2);
            waitSymbolsCheckBox.Location = new Point(166, 58);
            waitSymbolsCheckBox.Margin = new Padding(2, 3, 2, 3);
            waitSymbolsCheckBox.Name = "waitSymbolsCheckBox";
            waitSymbolsCheckBox.Size = new Size(135, 21);
            waitSymbolsCheckBox.TabIndex = 9;
            waitSymbolsCheckBox.Text = "注入前等待符号准备";
            waitSymbolsCheckBox.UseVisualStyleBackColor = true;
            // 
            // logTextBox
            // 
            logTextBox.Dock = DockStyle.Fill;
            logTextBox.Font = new Font("Consolas", 9F);
            logTextBox.Location = new Point(507, 134);
            logTextBox.Margin = new Padding(2, 3, 2, 3);
            logTextBox.Multiline = true;
            logTextBox.Name = "logTextBox";
            logTextBox.ReadOnly = true;
            logTextBox.ScrollBars = ScrollBars.Vertical;
            logTextBox.Size = new Size(356, 432);
            logTextBox.TabIndex = 4;
            // 
            // flagsCheckedListBox
            // 
            flagsCheckedListBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flagsCheckedListBox.CheckOnClick = true;
            flagsCheckedListBox.FormattingEnabled = true;
            flagsCheckedListBox.Location = new Point(663, 171);
            flagsCheckedListBox.Name = "flagsCheckedListBox";
            flagsCheckedListBox.Size = new Size(436, 136);
            flagsCheckedListBox.TabIndex = 3;
            // 
            // mmDefaultButton
            // 
            mmDefaultButton.Location = new Point(0, 0);
            mmDefaultButton.Name = "mmDefaultButton";
            mmDefaultButton.Size = new Size(75, 23);
            mmDefaultButton.TabIndex = 0;
            // 
            // clearFlagsButton
            // 
            clearFlagsButton.Location = new Point(0, 0);
            clearFlagsButton.Name = "clearFlagsButton";
            clearFlagsButton.Size = new Size(75, 23);
            clearFlagsButton.TabIndex = 0;
            // 
            // downloadProgressBar
            // 
            downloadProgressBar.Location = new Point(0, 0);
            downloadProgressBar.Name = "downloadProgressBar";
            downloadProgressBar.Size = new Size(100, 23);
            downloadProgressBar.TabIndex = 0;
            // 
            // prepareButton
            // 
            prepareButton.Location = new Point(0, 0);
            prepareButton.Name = "prepareButton";
            prepareButton.Size = new Size(75, 23);
            prepareButton.TabIndex = 0;
            // 
            // injectButton
            // 
            injectButton.Location = new Point(0, 0);
            injectButton.Name = "injectButton";
            injectButton.Size = new Size(75, 23);
            injectButton.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(874, 579);
            Controls.Add(rootLayout);
            Margin = new Padding(2, 3, 2, 3);
            MinimumSize = new Size(766, 550);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GH Injector UI";
            rootLayout.ResumeLayout(false);
            rootLayout.PerformLayout();
            pathsGroup.ResumeLayout(false);
            pathsLayout.ResumeLayout(false);
            pathsLayout.PerformLayout();
            targetGroup.ResumeLayout(false);
            targetLayout.ResumeLayout(false);
            targetLayout.PerformLayout();
            optionsGroup.ResumeLayout(false);
            optionsLayout.ResumeLayout(false);
            optionsLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeoutNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)handleNumericUpDown).EndInit();
            ResumeLayout(false);
        }
    }
}
