var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Bu apini basqa projelerde istifade etmek ucun konfiqurasiyamizi yazaq
//On my own start for Using Api
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("TraversalApiCors", opts =>
    {
        opts.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
//On my own end then i make same changes on Progam.cs before Authorization

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//On my own start for Using Api
app.UseCors("TraversalApiCors");
//On my own end then i should call this in controllers

app.UseAuthorization();

app.MapControllers();

app.Run();
