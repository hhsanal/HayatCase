# HayatCase

**HayatCase**, Hayat Kimya için hazırlanmış bir yazılım vaka (case) projesidir.  
Amaç; sensör verilerini işleyip, eşik değerlerini izleyen, anomali tespiti ve simülasyon işlemleri yapan bir sistem geliştirmektir.

## Kullanılan Teknolojiler

- **.NET 8 / C#**
- **Entity Framework Core**
- **ASP.NET MVC / Razor**
- **Dependency Injection (DI)**
- **Background Services (Worker)**
- **Bootstrap 5**
- **SQL Server** (veritabanı)


##  Kurulum ve Çalıştırma

Projeyi yerel ortamında çalıştırmak için aşağıdaki adımları izle:

### 1️ Reponun klonlanması
git clone https://github.com/hhsanal/HayatCase.git
cd HayatCase

### 2 Bağımlılıkların yüklenmesi
dotnet restore

### 3 Veritabanı bağlantısını güncelle
WebUI katmanında ki appsettings.json dosyasında ve Persistance katmanında ki ApplicationDbContextFactory
içerisinde bulunan veritabanı bağlantılarını kendine göre güncelle


