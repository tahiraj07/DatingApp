﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace datingapp.API.Controllers
{ 
    // [Route("api/[controller]")]
    // [ApiController]
    // public class valuecontroller : ControllerBase
    // {
    //     public valuecontroller()
    //     {
    //     }

    //     // private static readonly string[] Summaries = new[]
    //     // {
    //     //     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    //     // };

    //     // private readonly ILogger<WeatherForecastController> _logger;

    //     // public WeatherForecastController(ILogger<WeatherForecastController> logger)
    //     // {
    //     //     _logger = logger;
    //     // }

    //     [HttpGet]
    //     public ActionResult<IEnumerable<string>> Get(){
    //         return new string[] {"value 1" , "value 2"};
    //     }

    //     [HttpGet("{id}")]

    //     public ActionResult<string> Get(int id)
    //     {
    //         return "value";
    //     }

    //     [HttpPost]
        
    //     public void Post([FromBody]  string value) 
    //     {

    //     }

    //     [HttpPut("{id}")]
    //     public void Put(int id,[FromBody] string value)
    //     {

    //     }

    //     [HttpDelete("{id}")]
    //     public void Delete(int id)
    //     {

    //     }
    //     // public IEnumerable<WeatherForecast> Get()
    //     // {
    //     //     var rng = new Random();
    //     //     return Enumerable.Range(1, 5).Select(index => new WeatherForecast
    //     //     {
    //     //         Date = DateTime.Now.AddDays(index),
    //     //         TemperatureC = rng.Next(-20, 55),
    //     //         Summary = Summaries[rng.Next(Summaries.Length)]
    //     //     })
    //     //     .ToArray();
    //     // }
    // }
}
