先至nuget安裝 microsoft speech依賴  
[解鎖不同語音](https://github.com/jonelo/unlock-win-tts-voices/blob/main/unlock-win-tts-voices.bat)
```csharp
// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Speech.Synthesis;
SpeechSynthesizer synth = new SpeechSynthesizer();

// Configure the audio output.
synth.SetOutputToDefaultAudioDevice();

var a = synth.GetInstalledVoices();
foreach (var item in a)
{
    if(item.VoiceInfo.Culture.Name == "ja-JP" && item.Enabled && !item.VoiceInfo.Name.Contains("Desktop"))
    {

        Console.WriteLine(item.VoiceInfo.Name);
        synth.SelectVoice(item.VoiceInfo.Name);
        synth.Speak("こんにちは、世界！");
    }
}

synth.Speak("Hello, World!");
//synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 0, new CultureInfo("ja-JP"));

// Speak a string, synchronously

Console.WriteLine("Hello, World!");
```
