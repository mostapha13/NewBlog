using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.ApplicationServices.Authors.Validation;
using Blog.ApplicationServices.Comments.Validation;
using Blog.ApplicationServices.Posts.Validation;
using Blog.ApplicationServices.Subjects.Validation;
using Blog.DataAccessCommand.Context;
using Blog.Domains.Authors.Entities;
using Blog.Domains.Comments.Entities;
using Blog.Domains.Posts.Entities;
using Blog.Domains.Subjects.Entities;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Blog.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            #region Validation

            services.AddMvc().AddFluentValidation();
            services.AddValidatorsFromAssembly(typeof(Startup).Assembly);


            services.AddTransient<IValidator<Author>, AuthorValidator>();
            services.AddTransient<IValidator<Subject>, SubjectValidator>();
            services.AddTransient<IValidator<Post>, PostValidator>();
            services.AddTransient<IValidator<Comment>, CommentValidator>();

            #endregion

            #region DBContext

            services.AddDbContext<NewBlogContext>(option =>
            {
                option.UseSqlServer(Configuration["ConnectionStrings:CommandConnection"]);

            });

            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
