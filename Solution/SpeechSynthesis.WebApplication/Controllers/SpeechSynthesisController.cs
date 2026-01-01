using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Speech.Synthesis;

namespace SpeechSynthesis.WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpeechSynthesisController : ControllerBase
    {
        private static readonly string[] Voices = new[]
        {
            "Microsoft David Desktop", "Microsoft Zira Desktop", "Microsoft Helena Desktop", "Microsoft Hortense Desktop"
        };

        private readonly ILogger<SpeechSynthesisController> _logger;
        private readonly IStringLocalizer<VoicesController> _localizer;

        public SpeechSynthesisController(ILogger<SpeechSynthesisController> logger, IStringLocalizer<VoicesController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        [HttpPost(Name = "PostSpeechRecognition")]
        public string PostSpeechSynthesis(string voice, string text, int rate, int volume)
        {
            voice = voice.Trim();
            text = text.Trim();

            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                try
                {
                    synthesizer.Volume = volume;    // 0-100
                    synthesizer.Rate = rate;        // -10 to 10
                    synthesizer.SelectVoice(voice);

                    synthesizer.Speak(text);

                    return $"Text spoken: {text}";
                }
                catch (Exception ex)
                {
                    return $"Error: {ex.Message}";
                }
            }
        }
    }
}
