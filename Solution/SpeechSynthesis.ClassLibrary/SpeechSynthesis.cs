using System;
using System.Speech.Synthesis;

namespace SpeechSynthesis.ClassLibrary
{
    public class SpeechSynthesis
    {
        #region fields

        private string _inputText;

        #endregion

        #region constructors

        public SpeechSynthesis()
        {
            
        }

        #endregion

        #region public methods
        public static void SpeakTextInput(string input)
        {
            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                synthesizer.GetInstalledVoices();

                // Configure the output to the default audio device (win only)
                synthesizer.SetOutputToDefaultAudioDevice();

                synthesizer.Volume = 60; // 0-100

                synthesizer.Rate = 1; // -10 to 10

                // Speak the text
                synthesizer.Speak(input);

                Console.WriteLine("Speech synthesis complete. Press any key to exit.");
                Console.ReadKey();
            }
        }
        #endregion

        #region private methods

        

        #endregion

        #region properties

        public string InputText
        {
            get { return _inputText; }
            set { _inputText = value; }
        }

        #endregion

        #region deconstructors
        #endregion
    }
}
