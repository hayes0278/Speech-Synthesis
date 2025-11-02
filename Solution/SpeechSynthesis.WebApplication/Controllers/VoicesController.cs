using System.Diagnostics;
using SpeechSynthesis.ClassLibrary;
using Microsoft.AspNetCore.Mvc;
using SpeechSynthesis.WebApplication.Models;

namespace SpeechSynthesis.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VoicesController : ControllerBase
    {
        private static readonly string[] Voices = new[]
        {
            "Microsoft David Desktop", "Microsoft Zira Desktop", "Microsoft Helena Desktop", "Microsoft Hortense Desktop"
        };

        private readonly ILogger<VoicesController> _logger;

        public VoicesController(ILogger<VoicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetVoices")]
        public IEnumerable<Voice> Get()
        {
            return Enumerable.Range(1, Voices.Length).Select(index => new Voice
            {
                Name = Voices[Random.Shared.Next(Voices.Length)]
            })
            .ToArray();
        }
    }
}
