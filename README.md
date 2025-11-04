# HayatCase

**HayatCase**, Hayat Kimya için hazırlanmış bir yazılım vaka (case) projesidir.  
Amaç; sensör verilerini işleyip, eşik değerlerini izleyen, anomali tespiti ve simülasyon işlemleri yapan bir sistem geliştirmektir.

## Kullanılan Teknolojiler

- **.NET 9 / C#**
- **Entity Framework Core**
- **ASP.NET MVC / Razor**
- **Dependency Injection (DI)**
- **Background Services (Worker)**
- **Bootstrap 5**
- **SQL Server** (veritabanı)

## Mimari Yapı

Proje, katmanlı mimari yaklaşımıyla geliştirilmiştir:
- **Domain**: Temel entity sınıfları ve modeller.
- **Application**: İş mantığı, MediatR handler'ları ve servis arayüzleri.
- **Persistance**: Entity Framework Core context, repository ve migration yapısı.
- **WebUI**: MVC tabanlı web arayüzü (Dashboard, Alerts, History sayfaları).
- **SimulationWorker**: Sensör verilerini belirli aralıklarla üreten background servis.


##  Kurulum ve Çalıştırma

Projeyi yerel ortamında çalıştırmak için aşağıdaki adımları izle:
```
### 1️ Reponun klonlanması
git clone https://github.com/hhsanal/HayatCase.git
```
proje visual studio 2026 ile geliştirildiği için solution dosyasının uzantısı .sln yerine .slnx olarak gelmektedir.
Bu farktan dolayı visual studio nun daha alt sürümleri ile açılırken bir uyarı almanız doğaldır.

### 2 Bağımlılıkların yüklenmesi
```
dotnet restore
```
### 3 Veritabanı bağlantısını güncelle
WebUI katmanında ki appsettings.json dosyasında ve Persistance katmanında ki ApplicationDbContextFactory
içerisinde bulunan veritabanı bağlantılarını kendine göre güncelle

### 4 Migration

soluiton içerisinde başlangıç projesini WebUI olarak seçili olmasına dikkat et
daha sonra package manager console aracılığı ile migration işlemini Persistance 
katmanında başlat ve tamamla

### 5 Default verilerin Yüklenmesi

default verilerin yüklenebilmesi için WebUI projesini 1 kere çalıştır ki başlangıç koşulundaki fonksiyonlar çalışsın
ve veriler (sensör bilgileri) database ye yüklensin 

### 6 Simülasyon projesini başlatma 
bu solutionda bulunan SimulationWorker projesidir. bu proje background service olarak çalışır ve sensör gibi hareket eder.
5 saniye aralıklarla sisteme API aracılığı ile dummy sensör verileri gönderir. Worker service projesini çalıştırmadan önce
workerda ki istek atılacak endpointin portlarının WebUI projesinin çalıştığı port olup olmadığını kontrol et değilse aynı
port olacak şekilde değiştir. Visual studioda solutionun başlangıç seçeneklerini Multiple olarak seçebilirsin bu sayede hem
WebUI projesini hemde Worker serviceyi aynı anda daha kolay çalıştırabilirsin.
