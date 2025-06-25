# Kitap Satış API - Demo Proje

Bu proje .Net Core 8 Web API ile geliştirilen RESTful api uygulamasıdır.Uygulama modern Clean Architecture mimarisi ve prensiplerine bağlı kalınarak oluşturulmuştur.
## Kullanılan Teknoloji ve Araçlar

- .NET Core 8
- Entity Framework Core
- AutoMapper
- JWT Authentication
- Swagger UI
- Clean Architecture yaklaşımı
- Veritabanı : MSSQL (Code First) yaklaşımı

### 1. Projeyi Klonlayın

```bash
git clone https://github.com/omerserfice/KitapSatisApp.git
cd KitapSatisApp
```
### 2. Bağımlılıkları yükleyin.
```bash
dotnet restore
```
### 3. Veritabanını oluşturun.
```bash
cd KitapSatisApp.API
dotnet ef database update
```
### 4. Uygulamayı başlat.
```bash
dotnet run
```
API çalıştığında Swagger arayüzüne aşağıdaki adresten erişebilirsiniz.
````bash
http://localhost:5263/swagger/index.html
````
## Proje Özellikleri
- Book ve Category CRUD işlemleri
- Kimlik Doğrulama
    - /api/auth/register - Kullanıcı kaydı
    - /api/auth/login - JWT Token alımı ve login işlemi
- Middleware & Exception Handling
    -  Global Hata Yönetimi
- DTO & AutoMapper
    - Entityler ile DTO lar arası dönüşüm
-  Swagger UI
## Proje Yapısı
```
KitapSatisApp/
├── src/
│   ├── Core/
│   │   ├── KitapSatisApp.Application/     # Uygulama katmanı: DTO, servisler, arayüzler
│   │   └── KitapSatisApp.Domain/          # Domain katmanı: Entity'ler, temel modeller
│
│   ├── Infrastructure/
│   │   └── KitapSatisApp.Persistence/     # Veri erişim katmanı: DbContext, Repository
│
│   └── KitapSatisApp.API/                 # API katmanı
│       ├── Controllers/                   # Controller'lar (Books, Auth vs.)
│       ├── ExceptionHandler/              # Global hata yönetimi
│       ├── appsettings.json               # Konfigürasyon dosyası
│       └── Program.cs                     # Uygulama başlangıç noktası
│
├── test/                                  # Test
```
## JWT Kullanımı
Token almak için giriş yapın ve `Authorization` header'a ekleyin:
```
Bearer {token}
```
## Notlar

- Proje geliştirme süresi: **3 gün**
- Uygulama .NET Core 8 ve Clean Architecture mimarisi prensipleri ile geliştirilmiştir
- Değerlendirme amaçlı kullanıcı yönetimi ve kitap işlemleri yapılmıştır.

## Geliştirici

**Ömer Serfice**  
[LinkedIn](https://www.linkedin.com/in/omerserfice/)  

