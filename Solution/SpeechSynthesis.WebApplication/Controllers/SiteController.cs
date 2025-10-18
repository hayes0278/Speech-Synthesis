using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpeechSynthesis.ClassLibrary;
using SpeechSynthesis.WebApplication.Models;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Xml.Linq;

namespace SpeechSynthesis.WebApplication.Controllers
{
    public class SiteController : Controller
    {
        private readonly ILogger<SiteController> _logger;

        public SiteController(ILogger<SiteController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string formProcessed = Request.Query["btnSubmit"];

            if (formProcessed != null && formProcessed.ToLower() == "synthesise")
            {
                string testText = "Testing the speech synthesis app.";
                string inputText = Request.Query["selVoice"];
                string selectVoice = Request.Query["txtInput"];

                if (string.IsNullOrEmpty(inputText))
                {
                    inputText = testText;
                }

                if (!string.IsNullOrEmpty(selectVoice))
                {
                    selectVoice = selectVoice;
                }

                SpeechSynthesisApp speechApp = new SpeechSynthesisApp();

                if (int.TryParse(Request.Query["selVolume"].ToString(), out int voiceVolume))
                {
                    speechApp.Volume = voiceVolume;
                    ViewBag.Volume = voiceVolume;
                }

                if (int.TryParse(Request.Query["selSpeed"].ToString(), out int voiceSpeed))
                {
                    speechApp.Rate = voiceSpeed;
                    ViewBag.Rate = voiceSpeed;
                }

                bool isSuccessful = speechApp.SpeakTextInput(inputText);

                ViewBag.InputText = inputText;

            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Help()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
