using Blog.ApplicationServices.Authors.Commands.Behaviors;
using Blog.ApplicationServices.Authors.Validations;
using Blog.ApplicationServices.Behaviors;
using Blog.ApplicationServices.Comments.Validations;
using Blog.ApplicationServices.Posts.Validations;
using Blog.ApplicationServices.Subjects.Validations;
using Blog.DataAccessCommands.Context;
using Blog.DataAccessCommands.Authors.Repositories;
using Blog.DataAccessCommands.Commons;
using Blog.DataAccessCommands.Subjects.Repositories;
using Blog.DataAccessQueries.Authors.Repositories;
using Blog.DataAccessQueries.Subjects.Repositories;
using Blog.Domains.Authors.Commands;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Authors.Repositories;
using Blog.Domains.Comments.Entities;
using Blog.Domains.Commons;
using Blog.Domains.Enums;
using Blog.Domains.Posts.Entities;
using Blog.Domains.Subjects.Entities;
using Blog.Domains.Subjects.Repositories;
using Blog.Presentation.Middleware;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

namespace Blog.Presentation
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            #region SeriLog

            Log.Logger = new LoggerConfiguration()

                .ReadFrom.Configuration(Configuration)
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
                .CreateLogger();
            #endregion

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            #region DBContext

            services.AddDbContext<NewBlogContext>(option =>
            {
                option.UseSqlServer(Configuration["ConnectionStrings:CommandConnection"]);

            });

            #endregion

            #region MediatR

            var assembly = AppDomain.CurrentDomain.Load("Blog.ApplicationServices");
            services.AddMediatR(assembly);


            #endregion



            #region IOC

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            #region Command

            services.AddScoped<IAuthorRepositoryCommand, AuthorRepositoryCommand>();
            services.AddScoped<ISubjectRepositoryCommand, SubjectRepositoryCommand>();

            #endregion

            #region Query

            services.AddScoped<IAuthorRepositoryQuery, AuthorRepositoryQuery>();
            services.AddScoped<ISubjectRepositoryQuery, SubjectRepositoryQuery>();

            #endregion



            #endregion

            #region Validation

            services.AddMvc().AddFluentValidation();
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);


            services.AddTransient<IValidator<Author>, AuthorValidator>();
            services.AddTransient<IValidator<Subject>, SubjectValidator>();
            services.AddTransient<IValidator<Post>, PostValidator>();
            services.AddTransient<IValidator<Comment>, CommentValidator>();

            #endregion

            #region Behavior

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<AddAuthorCommand, ResultStatus>), typeof(AddAuthorBehavior<AddAuthorCommand, ResultStatus>));

            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();


            loggerFactory.AddSerilog();


            app.UseRouting();

            app.UseAuthorization();


            #region Middleware

            app.UseMiddleware(typeof(ErrorHandling));

            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
