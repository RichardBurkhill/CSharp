using EmployeeApi.Services;

var builder = WebApplication.CreateBuilder(args);

// 🏗️ Step 1: Add services to the dependency injection container.
// This is where you register services your app will use. These can be framework services
// (like controllers, logging, database contexts) or your own custom services.

builder.Services.AddControllers(); 
// 👆 This tells ASP.NET Core to use the built-in controller system for routing HTTP requests.

builder.Services.AddEndpointsApiExplorer(); 
// 👆 Enables minimal API metadata (used by tools like Swagger for describing your API endpoints)

builder.Services.AddSwaggerGen(); 
// 👆 Adds Swagger/OpenAPI generation. This allows you to visualize and test your API in the browser
// at /swagger when running locally.

builder.Services.AddSingleton<EmployeeService>();
// 👆 This registers your custom EmployeeService as a singleton.
// Singleton means the same instance is reused throughout the lifetime of the app.
// It's perfect for simple in-memory storage like your `_employees` list.

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
