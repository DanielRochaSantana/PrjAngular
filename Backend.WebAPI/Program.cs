using Backend.Application.Interfaces;
using Backend.Application.Services;
using Backend.Domain.Models.Entity;
using Backend.Infrastructure.CommandSide;
using Backend.Infrastructure.Context;
using Backend.Infrastructure.Interfaces.CommandSide;
using Backend.Infrastructure.Interfaces.Context;
using Backend.Infrastructure.Interfaces.QuerySide;
using Backend.Infrastructure.QuerySide;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IRepositorioGenerico<Usuario>, RepositorioGenerico<Usuario>>();
builder.Services.AddScoped<IConsultaGenerica<Usuario>, ConsultaGenerica<Usuario>>();

builder.Services.AddScoped<IAtividadeService, AtividadeService>();
builder.Services.AddScoped<IRepositorioGenerico<Atividade>, RepositorioGenerico<Atividade>>();
builder.Services.AddScoped<IConsultaGenerica<Atividade>, ConsultaGenerica<Atividade>>();

builder.Services.AddScoped<IDespesaService, DespesaService>();
builder.Services.AddScoped<IRepositorioGenerico<Despesa>, RepositorioGenerico<Despesa>>();
builder.Services.AddScoped<IConsultaGenerica<Despesa>, ConsultaGenerica<Despesa>>();

builder.Services.AddScoped<IContext, Context>();

builder.Services.AddCors(
                opcoes => opcoes.AddDefaultPolicy(
                               builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                        )

                );

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
