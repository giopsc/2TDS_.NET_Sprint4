using Doracorde.API.Configuration;
using Doracorde.API.UseCases;
using Doracorde.Database;
using Doracorde.Database;
using Doracorde.Database.Models;
using Doracorde.Repository;
using Doracorde.Repository.MongoDB;
using Doracorde.Repository.Oracle;
using Doracorde.Services.CEP;
using Doracorde.Services.MLRecommendation;
using Doracorde.API.Configuration;
using Doracorde.API.UseCases;
using Doracorde.Database.Context;
using Doracorde.Database.Models;
using Doracorde.Repository;
using Doracorde.Services.CEP;
using Doracorde.Services.MLRecommendation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Doracorde.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICEPService, CEPService>();
            services.AddScoped<RecommendationEngine>();

            return services;
        }

        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<UserUseCase>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<User>, MongoDBRepository<User>>();

            services.AddScoped<IRepository<UserLike>, MongoDBRepository<UserLike>>();

            services.AddScoped<IRepository<Course>, MongoDBRepository<Course>>();

            return services;
        }

        public static IServiceCollection AddContext(this IServiceCollection services, APIConfiguration apiConfiguration)
        {
            //Oracle
            services.AddDbContext<FIAPDbContext>(options =>
            {
                options.UseOracle(apiConfiguration.OracleFIAP.ConnectionString);
            });

            services.AddDbContext<MongoDBContext>(options =>
                options.UseMongoDB(apiConfiguration.MongoSettings.URL, apiConfiguration.MongoSettings.Database)
             );


            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, APIConfiguration apiConfiguration)
        {

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = $"{apiConfiguration.Swagger.Title} {DateTime.Now.Year} ",
                    Version = "v1",
                    Description = apiConfiguration.Swagger.Description,
                    Contact = new OpenApiContact() { Name = apiConfiguration.Swagger.Name, Email = apiConfiguration.Swagger.Email }
                });
                x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                x.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });


                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";  //2TDSPJ.API.xml
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile); /*C:/dev/2tdspj/2TDSPJ.API.xml*/

                //incluir os comentarios no SWAGGER
                x.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
