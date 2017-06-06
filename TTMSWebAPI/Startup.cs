using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;

namespace TTMSWebAPI
{
    /// <summary>
    /// 启动类
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 启动方法
        /// </summary>
        /// <param name="env"></param>
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        /// <summary>
        /// 启动属性
        /// </summary>
        public IConfigurationRoot Configuration { get; }

        /// <summary>
        /// 配置启动属性
        /// </summary>
        /// <param name="services"></param>
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

	        // Adds a default in-memory implementation of IDistributedCache.
//	        services.AddDistributedMemoryCache();
	        services.AddDistributedSqlServerCache(options =>
	        {
		        options.ConnectionString = Configuration.GetConnectionString("sqlserverCacheConnection");
		        options.SchemaName = "dbo";
		        options.TableName = "session";
		        options.SystemClock = new SystemClock();
	        });
	        
	        // session 设置
	        services.AddSession(options =>
	        {
		        // 设置 Session 过期时间
		        options.CookieName = ".TTMS.Session";
		        options.IdleTimeout = TimeSpan.FromDays(15);
		        options.CookieHttpOnly = false;
		        options.CookieDomain = ".ksgin.online";
		        options.CookiePath = "/";
	        });
	        
	        //doc
	        // Add our repository type
	        services.AddSingleton<HttpGetAttribute, HttpGetAttribute>();

	        // Register the Swagger generator, defining one or more Swagger documents
	        services.AddSwaggerGen(c =>
	        {
		        c.SwaggerDoc("v1.1", new Info { Title = "TTMS API", Version = "v1.1" });
	            c.IncludeXmlComments(Path.Combine(PlatformServices.Default.Application.ApplicationBasePath,
	                "TTMSAPI.XML"));
            });

			// ********************
			// Setup CORS
			// ********************
			var corsBuilder = new CorsPolicyBuilder();
	        //corsBuilder.WithOrigins("http://localhost:63342" , "http://wwww.ksgin.online");
			corsBuilder.AllowAnyHeader();
			corsBuilder.AllowAnyMethod();
			corsBuilder.AllowAnyOrigin();
			corsBuilder.AllowCredentials();

			services.AddCors(options =>
			{
				options.AddPolicy("mCors", corsBuilder.Build());
			});

        }

        /// <summary>
        /// 配置启动属性
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
	        //使用Session
	        app.UseSession();
	        
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

			app.UseForwardedHeaders(new ForwardedHeadersOptions
			{
				ForwardedHeaders = ForwardedHeaders.XForwardedFor |
								   ForwardedHeaders.XForwardedProto
			});

			app.UseCors("mCors");

	        //读取连接字符串
	        Servers.Server.SqlConString = Configuration.GetConnectionString("DefaultConnection");

	        //
	        // Enable middleware to serve generated Swagger as a JSON endpoint.
	        app.UseSwagger();

	        // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
	        app.UseSwaggerUI(c =>
	        {
		        c.SwaggerEndpoint( "v1.1/swagger.json", "TTMS API v1.1");
	        });

        }
    }
}
