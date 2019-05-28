using System.IO;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using SelfServiceMachine.Filter;
using SelfServiceMachine.Logger;
using SelfServiceMachine.SwaggerHelp;
using Swashbuckle.AspNetCore.Swagger;

namespace SelfServiceMachine
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// log4net 仓储库
        /// </summary>
        public static ILoggerRepository repository { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            //log4net
            repository = LogManager.CreateRepository("SelfServiceMachine");//需要获取日志的仓库名，也就是你的当然项目名

            //指定配置文件
            XmlConfigurator.Configure(repository, new FileInfo("log4net.config"));//配置文件
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region Swagger
            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new Info
                  {
                      Version = "v1.1.0",
                      Title = "SelfService WebAPI",
                      Description = "框架集合",
                      TermsOfService = "None",
                      Contact = new Contact { Name = "Jeff Pu", Email = "514771858@qq.com", Url = "" }
                  });
                  //添加注释服务
                  var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                  var xmlPath = Path.Combine(basePath, "APIHelp.xml");
                  c.IncludeXmlComments(xmlPath);
                  //添加对控制器的标签(描述)
                  c.DocumentFilter<SwaggerDocTag>();
              });

            #endregion

            #region CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowAnyOrigin", policy =>
                {
                    policy.AllowAnyOrigin() //允许任何源
                    .AllowAnyMethod() //运行任何方式
                    .AllowAnyHeader() //运行任何头
                    .AllowCredentials(); //运行cookie
                });
                c.AddPolicy("AllowSpecificOrigin", policy =>
                {
                    policy.WithOrigins("http://localhost:8083").WithMethods("GET", "POST", "PUT", "DELETE").WithHeaders("authorization");
                });
            });
            #endregion

            #region log日志注入
            services.AddSingleton<ILoggerHelper, LoggerHelper>();

            services.AddMvc(o =>
            {
                o.Filters.Add(typeof(GlobalExceptionsFilter));
            }).AddXmlSerializerFormatters().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            #endregion
        }
    }
}
