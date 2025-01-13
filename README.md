# .NET OpenAI API Integration: Text-to-Speech (TTS) Example

Bu repository, OpenAI'nin Text-to-Speech (TTS) API'sini .NET 8 Console Uygulaması içinde entegre eden basit bir örnektir. Bu proje, OpenAI API'sini .NET ortamında nasıl kullanabileceğinizi ve metinleri doğal bir sesle nasıl sese dönüştürebileceğinizi göstermeyi amaçlamaktadır. Kod, `AudioClient` sınıfı ve OpenAI'nin Text-to-Speech modeline dayanmaktadır.

## Özellikler

- OpenAI API'si ile text-to-speech (TTS) işlevselliği entegrasyonu
- Metin girdisinden ses dosyası üretme
- Oluşturulan sesin MP3 formatında kaydedilmesi
- API anahtarının güvenli bir şekilde .NET User Secrets ile yapılandırılması

## Başlarken

### Gereksinimler

- .NET 8 SDK veya daha yeni bir sürüm
- OpenAI API anahtarı (OpenAI web sitesine kaydolarak alabilirsiniz)
- GitHub hesabı (repository'yi klonlamak için)

### Kurulum

1. **Repository'yi klonlayın**:
    ```bash
    git clone https://github.com/nurselaltin/.NetOpenAI.git
    ```

2. **Proje dizinine gidin**:
    ```bash
    cd .NetOpenAI
    ```

3. **Bağımlılıkları yükleyin**:
    ```bash
    dotnet restore
    ```

4. **OpenAI API anahtarınızı güvenli bir şekilde ayarlayın** (`.NET User Secrets` kullanarak):
    ```bash
    dotnet user-secrets init
    dotnet user-secrets set "OpenAI:APIKey" "your-api-key-here"
    ```

5. **Uygulamayı çalıştırın**:
    ```bash
    dotnet run
    ```

   Uygulama, metin girişi alacak, bunu sesli hale getirecek ve çıktıyı MP3 dosyası olarak kaydedecektir.

### Örnek Kod

Projedeki `AudioClient` sınıfının nasıl kullanıldığını gösteren bir örnek:

```csharp
AudioClient client = new AudioClient("tts-1", apiKey);
string input = "Sesli hale getirilmesini istediğiniz metin.";
BinaryData speech = client.GenerateSpeech(input, GeneratedSpeechVoice.Nova);

using FileStream stream = File.OpenWrite($"{Guid.NewGuid()}.mp3");
speech.ToStream().CopyTo(stream);
