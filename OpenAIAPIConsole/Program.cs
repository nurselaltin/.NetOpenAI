// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using OpenAI.Audio;

Console.WriteLine("Hello, World!");

var conf = new ConfigurationBuilder().
    AddUserSecrets<Program>() //User Secret aktifleştiriyorum.
    .Build();

string apiKey = conf["OpenAI:ApiKey"];

AudioClient client2 = new AudioClient("tts-1", apiKey);

string input = "Euro 2024, Avrupa Futbol Şampiyonası'nın 2024 yılında Almanya'da düzenlenecek olan 17. turnuvasıdır.";

BinaryData speech = client2.GenerateSpeech(input, GeneratedSpeechVoice.Alloy);

using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.mp3");
speech.ToStream().CopyTo(stream);

Console.ReadLine();