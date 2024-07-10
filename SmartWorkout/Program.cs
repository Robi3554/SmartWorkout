using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Plk.Blazor.DragDrop;
using SmartWorkout.Components;
using SmartWorkout.DataAccess;
using SmartWorkout.DataAccess.Repositories;
using SmartWorkout.DBAccess.Entities;
using SmartWorkout.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddAuthorizationCore();

builder.Services.AddDbContext<SmartWorkoutContext>();

builder.Services.AddMudServices();

builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<IGenericRepository<Exercise>, ExerciseRepository>();
builder.Services.AddScoped<IGenericRepository<Workout>, WorkoutRepository>();
builder.Services.AddScoped<IGenericRepository<ExerciseLog>, ExerciseLogRepository>();

builder.Services.AddBlazorDragDrop();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider => provider.GetRequiredService<CustomAuthenticationStateProvider>());

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAntiforgery();

app.UseAuthorization();

// Map your Razor Components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
