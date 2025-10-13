namespace SpeechSynthesis.ClassLibrary
{
    public class SpeechSynthesis
    {
        #region fields

        private string _testMe;

        #endregion

        #region constructors

        public SpeechSynthesis()
        {
            _testMe = "Testing";
        }

        #endregion

        #region public methods

        public static void MyPubicMethod()
        {

        }

        #endregion

        #region private methods

        private static void MyPrivateMethod()
        {

        }

        #endregion

        #region properties

        public string TestMe
        {
            get { return _testMe; }
            set { _testMe = value; }
        }

        #endregion

        #region deconstructors
        #endregion
    }
}
