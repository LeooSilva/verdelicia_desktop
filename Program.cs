using ElectronNET.API;
using ElectronNET.API.Entities;
using System;
using System.Threading.Tasks;

class Program
{
    public static async Task Main(string[] args)
    {
        // Inicializa o Electron
        var host = CreateHostBuilder(args).Build();
        ElectronBootstrap(); // Inicia o Electron
        await host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });

    public static async void ElectronBootstrap()
    {
        // Cria a janela principal do Electron
        var options = new BrowserWindowOptions
        {
            Width = 800,
            Height = 600
        };

        var window = await Electron.WindowManager.CreateWindowAsync(options);
        window.OnClosed += () => Electron.App.Quit();
    }
}