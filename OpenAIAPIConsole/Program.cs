// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using OpenAI.Audio;

Console.WriteLine("Hello, World!");

var conf = new ConfigurationBuilder().
    AddUserSecrets<Program>() //User Secret aktifleştiriyorum.
    .Build();

string apiKey = conf["OpenAI:ApiKey"];

AudioClient client = new AudioClient("tts-1", apiKey);

string input = "Dune evreni, sırlarla dolu hikâyeler ve karmaşık topluluklarla zenginleşen bir bilim kurgu şaheseridir. Bu evrene ilk adım attığımda, Bene Gesserit tarikatının bir üyesi olan Leydi Jessica’nın “Korku Duası”nı okuyarak kendini sakinleştirmesi beni derinden etkilemişti. Bu sahne, Dune dünyasına giriş yapmamın başlıca sebeplerinden biriydi ve Bene Gesserit’in gizemli ve güçlü doğasını keşfetmeye olan merakımı ateşledi.";

BinaryData speech = client.GenerateSpeech(input, GeneratedSpeechVoice.Nova);

using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.mp3");
speech.ToStream().CopyTo(stream);

Console.ReadLine();