using SpeechSynthesis.ClassLibrary;

Console.WriteLine("Welcome to the Speech Synthesis App");
Console.WriteLine("Please enter some text to begin. Exit to enter.");

bool isRunning = true;

while (isRunning)
{
    string? textToSpeak = Console.ReadLine();
    if (textToSpeak.ToLower().Trim() == "exit")
    {
        isRunning = false;
    }
    else
    {
        SpeechSynthesisApp synthesis = new SpeechSynthesisApp();
        bool? result = synthesis.SpeakTextInput(textToSpeak, "Microsoft David Desktop");
    }
}