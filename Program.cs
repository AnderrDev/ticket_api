try
{
    // Mensaje de bienvenida
    Console.WriteLine("Bienvenido al sistema de tickets de soporte técnico");
    // Validar que existe el archivo datos.json su no existe se crea
    if (!File.Exists("datos.json"))
    {
        // Crear el archivo datos.json
        File.Create("datos.json").Close();

        // Escribir el contenido del archivo datos.json
        File.WriteAllText("datos.json", "[]");
    }

    // Leer el contenido del archivo datos.json
    string json = File.ReadAllText("datos.json");
    // imprimir el contenido del archivo datos.json
    Console.WriteLine(json);
    // Imprmir la ruta absoluta del archivo datos.json
    Console.WriteLine(Path.GetFullPath("datos.json"));
}
catch (Exception ex)
{
    // Si hay algún error al leer o deserializar el archivo, lanzar una excepción con un mensaje de error
    throw new Exception("Error al cargar los tickets: " + ex.Message);
}

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
