using System.Text.Json;

namespace KTITSLive
{
    public class Program
    {
        static string HWPath = @"C:\Users\Mimm\Projects\VIsualStudioProjects\KTITSTimetableApp\KTITSLive\hw.json";
        static Timer saveTimer;
        public static Homework HWController;
        public static void Main(string[] args)
        {
            if (File.Exists(HWPath))
            {
                var hwStr = File.ReadAllText(HWPath);
                HWController = new Homework() { HW = JsonSerializer.Deserialize<Dictionary<DateTime, string[]>>(hwStr) };
            }
            else
            {
                HWController = new Homework();
            }
            var builder = WebApplication.CreateBuilder(args);
            saveTimer = new Timer(new TimerCallback((o) => { HWController.Save(HWPath); }), new object(), 500, 60000);
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}