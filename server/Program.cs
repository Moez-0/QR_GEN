using PDF;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", builder =>
    {
        
        builder.WithOrigins("http://localhost:3000") // Replace with your React app's domain
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp"); // Enable CORS with the policy for your React app


app.MapGet("/generate", () => 
{

    var pdf = new GeneratePDF();
    var bytes = pdf.getBytes();
    return Results
        .File(bytes, "application/pdf", "output.pdf");

})
.WithName("GetPDF")
.WithOpenApi();




app.Run();
