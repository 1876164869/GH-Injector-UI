namespace Injector
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            var missingFile = AppBuild.RequiredNativeFiles
                .FirstOrDefault(fileName => !File.Exists(Path.Combine(AppContext.BaseDirectory, fileName)));

            if (missingFile is not null)
            {
                MessageBox.Show(
                    $"程序目录下没有找到 {missingFile}。\r\n\r\n请把该文件放到以下目录后重新启动：\r\n{AppContext.BaseDirectory}",
                    "缺少 Injector 依赖",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            Application.Run(new Form1());
        }
    }
}
