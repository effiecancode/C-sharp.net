// Iporting necessary namespaces for entity framework core, OpenAPI and the custome code
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebAPI_Test;

var builder = WebApplication.CreateBuilder(args);//sets up the infrastructure for your API application
builder.Services.AddEndpointsApiExplorer(); //Adding an API  explorere to help with generating documentation

//Adding SwaggerGen to generate Swagger documentation
builder.Services.AddSwaggerGen(options =>
{
    //Defining the API documentation for version "v1"
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Effiecancode API",
        Description = "An ASP.NET Core Web API for managing Effie items",
        TermsOfService = new Uri("https://Effie.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Effiecancode Contact",
            Url = new Uri("https://effie.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Effiecancode License",
            Url = new Uri("https://Effie.com/license")
        }
    });
});
//Adding a database context to the services and configuring it to use SQL server
var serverVersion = ServerVersion.AutoDetect(builder.Configuration["DbConnection"]);
builder.Services.AddDbContext<SchoolDBContext>(options => options.UseMySql(builder.Configuration["DbConnection"], serverVersion));
//Add a cross Origin Resource sharing policy
builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
//Building the API application
var app = builder.Build();
//handling API endpoints for handling requests
app.MapPost("student", (Student student, SchoolDBContext db) =>
{
    //Code to Add Student to the database
    db.Add(student);
    db.SaveChanges();
    return student;
});

app.MapGet("student", (SchoolDBContext db) =>
{
    //Code to fetch a list of all students from the database
    return db.Students.ToList();
});

app.MapGet("student/{id}", (int id, SchoolDBContext db) =>
{
    //Code to fetch a specific student by ID  from the database
    return db.Students.FirstOrDefault(x => x.Id == id);
});

app.MapPut("student/{id}", (int id, Student student, SchoolDBContext db) =>
{
    var std = db.Students.Find(id);
    if (std is null)
        return Results.NotFound();
    std.DateOfBirth = student.DateOfBirth;
    std.Name = student.Name;
    db.SaveChanges();
    return Results.Ok(std); //ok 200 accepted 404 not found
});

app.MapDelete("student/{id}", (int id, SchoolDBContext db) =>
{
    var std = db.Students.Find(id);
    if (std is null)
        return Results.NotFound();
    db.Students.Remove(std);
    db.SaveChanges();
    return Results.Ok(std); //ok 200 accepted 404 not found
});

//Adding Swagger middleware to the API pipeline
app.UseSwagger();
app.UseSwaggerUI();
//Applying the CORS policy to the API
app.UseCors("corsapp");


app.Run(); //Running the API , final