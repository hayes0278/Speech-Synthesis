using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;
using SpeechSynthesis.ClassLibrary;
using SpeechSynthesis.WebApplication.Models;
using System.Diagnostics;
using System.Resources;
using System.Speech.Synthesis;
using System.Xml.Linq;

namespace SpeechSynthesis.WebApplication.Controllers
{
    public class SiteController : Controller
    {
        private readonly IStringLocalizer<SiteController> _localizer;

        public SiteController(IStringLocalizer<SiteController> localizer)
        {
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            string formProcessed = Request.Query["btnSubmit"];

            if (formProcessed != null && formProcessed.ToLower() == "synthesise")
            {
                string testText = "Testing the speech synthesis app.";
                string inputText = Request.Query["txtInput"];
                string selectVoice = Request.Query["selVoice"];
                string selectOutput = Request.Query["selOuput"];

                if (string.IsNullOrEmpty(selectOutput))
                {
                    selectOutput = "Default Output Device";
                }

                if (string.IsNullOrEmpty(inputText))
                {
                    inputText = testText;
                }
                
                ViewBag.InputText = inputText;

                if (!string.IsNullOrEmpty(selectVoice))
                {
                    selectVoice = selectVoice;
                }

                SpeechSynthesisApp speechApp = new SpeechSynthesisApp();

                if (int.TryParse(Request.Query["selVolume"].ToString(), out int voiceVolume))
                {
                    speechApp.Volume = voiceVolume;
                    ViewBag.Volume = voiceVolume;
                } else
                {
                    ViewBag.Volume = 50;
                }

                if (int.TryParse(Request.Query["selSpeed"].ToString(), out int voiceSpeed))
                {
                    speechApp.Rate = voiceSpeed;
                    ViewBag.Rate = voiceSpeed;
                } else
                {
                    ViewBag.Rate = 0;
                }

                bool isSuccessful = speechApp.SpeakTextInput(inputText, selectVoice, selectOutput);
                
                ViewBag.AllRightsReserved = _localizer["All rights reserved"];
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
