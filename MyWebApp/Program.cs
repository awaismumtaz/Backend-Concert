using MyConsoleApp;
using System;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/form", static async (HttpRequest request) =>
{
    var form = await request.ReadFormAsync();

    var strId = int.TryParse(form["id"], out int id);
    var venue = form["venue"];
    var performer = form["performer"];
    var strCap = int.TryParse(form["capacity"], out int capacity);


    //  string dateString = form[key: "specificDate"];

    DateTime specificDate = DateTime.Now;
/*
    if (DateTime.TryParse(dateString, out DateTime date))
    {
        Console.WriteLine(date); // Output: 12/12/2023 12:00:00 AM
    }
    else
    {
        Console.WriteLine("Invalid date format");
    }*/


    Concert concert = new(id,venue,performer,capacity,specificDate);

    return $"Concert details are added. \n id : {concert.Id}, Venue : {concert.Venue}, Performer : {concert.Performer}, Capacity: {concert.Capacity}, Date : {concert.SpecificTime}";

});

app.MapGet("/", () => "Hello World!");

app.Run();
