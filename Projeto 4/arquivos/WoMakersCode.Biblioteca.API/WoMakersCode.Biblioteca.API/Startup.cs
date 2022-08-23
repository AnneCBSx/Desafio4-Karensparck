using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoMakersCode.Biblioteca.Application.Mappings;
using WoMakersCode.Biblioteca.Application.Models.AdicionarAutor;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.Models.AtualizarDevolucaoLivro;
using WoMakersCode.Biblioteca.Application.Models.DevolucoesEmAtraso;
using WoMakersCode.Biblioteca.Application.Models.ExcluirEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.ListarLivros;
using WoMakersCode.Biblioteca.Application.Models.LivrosDisponiveis;
using WoMakersCode.Biblioteca.Application.Models.LivrosEmEmprestimo;
using WoMakersCode.Biblioteca.Application.UseCases;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.Database;
using WoMakersCode.Biblioteca.Infra.Repositories;

namespace WoMakersCode.Biblioteca.API
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
            services.AddTransient<ILivroRepository, LivroRepository>();
            services.AddTransient<IEmprestimoRepository, EmprestimoRepositoy>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IRelatorioRepository, RelatorioRepository>();
            services.AddTransient<IUseCaseAsync<AdicionarUsuarioRequest, AdicionarUsuarioResponse>, AdicionarUsuarioUseCase>();
            services.AddTransient<IUseCaseAsync<AdicionarAutorRequest, AdicionarAutorResponse>, AdicionarAutorUseCase>();
            services.AddTransient<IUseCaseAsync<ListarLivrosRequest, List<ListarLivrosResponse>>, ListarLivrosUseCase>();
            services.AddTransient<IUseCaseAsync<AtualizarDevolucaoLivroRequest, AtualizarDevolucaoLivroResponse>, AtualizarDevolucaoLivroUseCase>();
            services.AddTransient<IUseCaseAsync<ExcluirEmprestimoRequest, ExcluirEmprestimoResponse>, ExcluirEmprestimoUseCase>();
            services.AddTransient<IUseCaseAsync<DevolucoesEmAtrasoFiltroRequest, List<DevolucoesEmAtrasoResponse>>, RelatorioDevolucoesEmAtrasoUseCase>();
            services.AddTransient<IUseCaseAsync<LivrosEmEmprestimoRequest, List<LivrosEmEmprestimoResponse>>, RelatorioLivrosEmEmprestimoUseCase>();
            services.AddTransient<IUseCaseAsync<LivrosDisponiveisRequest, List<LivrosDisponiveisResponse>>, RelatorioLivrosDisponiveisUseCase>();
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
             );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WoMakersCode.Biblioteca.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WoMakersCode.Biblioteca.API v1"));
            }

            context.Database.Migrate();

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
