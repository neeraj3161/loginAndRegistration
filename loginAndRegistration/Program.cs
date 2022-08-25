using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



//connecting to postgre sql using npgsql
//first install npgsql using nuget package manager
var conn_string = "Host = localhost; Username = postgres; Password = aaa@111;Database=MVC; Port = 5432";

await using var conn = new NpgsqlConnection(conn_string);

//opening the connection
await conn.OpenAsync();

var Createquery = "Create table if not exists mvc.user (user_id serial primary key, name varchar(50) not null, surname varchar(50), city varchar(500) not null,zip_code varchar(50) not null, phone_number varchar (50) unique not null)";

//var to create a table

var cmd = new NpgsqlCommand(Createquery, conn);

//creating the table
Console.WriteLine(await cmd.ExecuteNonQueryAsync());




Console.WriteLine(conn.State);

if (conn.State == System.Data.ConnectionState.Open) {
    Console.WriteLine("Successfully connected to the database!!");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();







