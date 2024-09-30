using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            ////
            ///
            ///  INSTACIAS DE SERVICES
            /// 
            ///
            services.AddScoped<IProdutosService, ProdutosService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddScoped<IPagamentoService, PagamentoService>();



            ////=======================================================================
            ///
            ///  INSTACIAS DE REPOSITORY
            /// 
            ///

            services.AddScoped<IClienteRepository, ClientesRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutosRepository, ProdutosRepository>();
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();


            ////=======================================================================
            ///
            ///  INSTACIAS DE CONTEXTO
            /// 
            ///

            //Console.WriteLine("bd");
            //Console.WriteLine(connectionsString);
            services.AddDbContext<FiapDbContext>(options =>
            {
                options.UseSqlServer(
                    Environment.GetEnvironmentVariable("DATABASE"),
                    sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });


        }
    }
}
