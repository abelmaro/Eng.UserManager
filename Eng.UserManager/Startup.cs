using Eng.UserManager.Business.Interfaces;
using Eng.UserManager.Business.Services;
using Eng.UserManager.DataAccess;
using Eng.UserManager.DataAccess.Interfaces;
using Eng.UserManager.DataAccess.Repositories;
using Eng.UserManager.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace Eng.UserManager.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepositoryService<>), typeof(RepositoryService<>));

            var connString = Configuration.GetConnectionString("DataContext");
            services.AddDbContext<UserManagerDataContext>(options => options.UseSqlServer(connString))
                            .AddOptions();
        }

        public void Configure(IApplicationBuilder app, UserManagerDataContext dataContext)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MVP v1");
            });

            app.UseHttpsRedirection();

            if (dataContext.Database.GetPendingMigrations().Count() > 0){
                dataContext.Database.Migrate();
            }

            app.UseRouting();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
