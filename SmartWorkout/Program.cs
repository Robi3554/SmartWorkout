using SmartWorkout.Components;
using SmartWorkout.DataAccess;
using MudBlazor.Services;
using SmartWorkout.DataAccess.Repositories;
using SmartWorkout.DBAccess.Entities;
using Plk.Blazor.DragDrop;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<SmartWorkoutContext>();

builder.Services.AddMudServices();

builder.Services.AddScoped<IGenericRepository<User>, UserRepository>();
builder.Services.AddScoped<IGenericRepository<Exercise>, ExerciseRepository>();

builder.Services.AddBlazorDragDrop();

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

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
