using SistemaFinch.Forms;
using System.Globalization;

namespace SistemaFinch
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CultureInfo culture = new("en-US");

            // Configura a cultura padrão para toda a aplicação
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

            // Assine o evento AppDomain.CurrentDomain.ProcessExit
            AppDomain.CurrentDomain.ProcessExit += (sender, args) => {
                // Ao sair do aplicativo, reverta a cultura para a cultura original do sistema
                CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CurrentCulture;
                CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CurrentUICulture;
            };

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
    }
}