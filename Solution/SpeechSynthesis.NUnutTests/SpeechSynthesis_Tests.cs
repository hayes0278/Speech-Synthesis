using SpeechSynthesis.ClassLibrary;

namespace SpeechSynthesis.NUnutTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            SpeechSynthesisApp speechApp = new SpeechSynthesisApp();
        }

        [Test]
        public void SpeakTextInput_Test()
        {
            SpeechSynthesisApp speechApp = new SpeechSynthesisApp();
            bool expectedResult = true;
            bool actualResult = speechApp.SpeakTextInput("Testing the speech synthesis app.");
            if (actualResult == expectedResult) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void ChangeVolumeLevel_Test()
        {
            SpeechSynthesisApp speechApp = new SpeechSynthesisApp();
            speechApp.Volume = 20;
            int expectedResult = 20;
            int actualResult = speechApp.Volume;
            if (actualResult == expectedResult) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void ChangeRateLevel_Test()
        {
            SpeechSynthesisApp speechApp = new SpeechSynthesisApp();
            speechApp.Rate = -3;
            int expectedResult = -3;
            int actualResult = speechApp.Rate;
            if (actualResult == expectedResult) { Assert.Pass(); } else { Assert.Fail(); }
        }

        [Test]
        public void ChangeSpeakerVoice_Test()
        {
            SpeechSynthesisApp speechApp = new SpeechSynthesisApp();
            string expectedResult = "male";
            string actualResult = speechApp.SpeakerVoice;
            if (actualResult == expectedResult) { Assert.Pass(); } else { Assert.Fail(); }
            Assert.Pass();
        }
    }
}