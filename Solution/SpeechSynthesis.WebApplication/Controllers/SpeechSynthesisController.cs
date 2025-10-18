using System.Diagnostics;
using SpeechSynthesis.ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using SpeechSynthesis.WebApplication.Models;

namespace SpeechSynthesis.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeechSynthesisController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<SpeechSynthesisController> _logger;

        public SpeechSynthesisController(ILogger<SpeechSynthesisController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSpeechSynthesis")]
        public IEnumerable<Speech> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Speech
            {
                InputText = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
