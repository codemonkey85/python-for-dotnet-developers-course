using Ch7_Db.Data;

namespace Ch7_Db;

public class Program
{
    public static void Main(string[] args)
    {
        DataLoader.LoadIfNeeded();
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}
