using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SpeechSynthesis.ClassLibrary;

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
        private readonly IStringLocalizer<VoicesController> _localizer;

        public VoicesController(ILogger<VoicesController> logger, IStringLocalizer<VoicesController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
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
