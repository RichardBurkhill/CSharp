
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// 🏗️ Step 1: Add services to the dependency injection container.
// This is where you register services your app will use. These can be framework services
// (like controllers, logging, database contexts) or your own custom services.

// Connection string for SQLite database file in project folder
var connectionString = builder.Configuration.GetConnectionString("EmployeeDatabase") ?? "Data Source=employees.db";
builder.Services.AddDbContext<EmployeeApi.Data.EmployeeContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddControllers(); 
// 👆 This tells ASP.NET Core to use the built-in controller system for routing HTTP requests.

builder.Services.AddEndpointsApiExplorer(); 
// 👆 Enables minimal API metadata (used by tools like Swagger for describing your API endpoints)

builder.Services.AddSwaggerGen();
// 👆 Adds Swagger/OpenAPI generation. This allows you to visualize and test your API in the browser
// at /swagger when running locally.

//Whenever something needs an EmployeeService, here’s how to supply it.
builder.Services.AddScoped<EmployeeApi.Services.EmployeeService>();
// 👆 Registers the EmployeeService as a scoped service, meaning a new instance is created for each request.

var app = builder.Build();
// 🏗️ Step 2: Build the app. This creates an instance of the app based on the configuration you've provided.

// 🚦 Step 3: Configure the HTTP request pipeline.
// This is where middleware components are added.
// Middleware is software that handles requests and responses as they flow through the pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    // 👆 Enables the Swagger generator middleware (only in development by default)
    app.UseSwaggerUI(); 
    // 👆 Adds a nice web-based UI to interact with your API (at /swagger)
}

// 🔐 Enables HTTPS redirection. If someone sends an HTTP request, it redirects to HTTPS.
app.UseHttpsRedirection();

app.UseAuthorization();
// 👆 Enables authorization middleware, allowing you to restrict access to endpoints if needed.
// You can skip this if you're not using roles/claims for now.

app.MapControllers();
// 👆 This tells the app to look for controller classes and map routes to them (like `api/employees`).

app.Run();
// 🚀 This starts the app and begins listening for incoming HTTP requests.
