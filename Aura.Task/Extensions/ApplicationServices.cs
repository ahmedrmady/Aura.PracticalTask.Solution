using Aura.PracticalTask.Data;
using Aura.PracticalTask.Services;

namespace Aura.PracticalTask.Extensions
{
    public  static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRecordRepository), typeof(RecordRepository));
            services.AddScoped(typeof(IRecordService), typeof(RecordService));

            //services.AddScoped<IRecodRepository, RecordRepository>();
            //services.AddScoped<IRecordService, RecordService>();
            return services;
        }
    }
}
