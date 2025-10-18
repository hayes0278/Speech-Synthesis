using System;
using System.Speech.Synthesis;

namespace SpeechSynthesis.ClassLibrary
{
    public class SpeechSynthesisApp
    {
        #region fields

        private string _inputText;
        private string _speakerVoice = "Microsoft David Desktop";
        private string[] _speakerVoiceOptions;
        private int _volume = 50;
        private int _rate = 0;

        #endregion

        #region constructors

        #endregion

        #region public methods
        public bool SpeakTextInput(string input)
        {
            _inputText = input.Trim();

            using (SpeechSynthesizer synthesizer = new SpeechSynthesizer())
            {
                try
                {
                    foreach (InstalledVoice voice in synthesizer.GetInstalledVoices())
                    {
                        int i = 0;
                        VoiceInfo info = voice.VoiceInfo;
                        //_speakerVoiceOptions[i] = info.Name;  // for dropdown list
                        Console.WriteLine(info.Name);
                        i++;
                    }  

                    synthesizer.SetOutputToDefaultAudioDevice();

                    synthesizer.Volume = _volume;   // 0-100
                    synthesizer.Rate = _rate;       // -10 to 10
                    synthesizer.SelectVoice(_speakerVoice);

                    // Speak the text
                    synthesizer.Speak(_inputText);

                    return true;
                }
                catch (Exception ex) {
                    return false;
                }   
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

        public int Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public int Rate
        {
            get { return _rate; }
            set { _rate = value; }
        }

        public string SpeakerVoice
        {
            get { return _speakerVoice; }
            set { _speakerVoice = value; }
        }

        #endregion

        #region deconstructors
        #endregion
    }
}
