# 🍔 ASP.NET Core & MongoDB Restoran Yönetim Sistemi

![.NET Core](https://img.shields.io/badge/.NET%20Core-512BD4?style=flat-square&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=flat-square&logo=c-sharp&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-47A248?style=flat-square&logo=mongodb&logoColor=white)
![AutoMapper](https://img.shields.io/badge/AutoMapper-8A2BE2?style=flat-square&logo=nuget&logoColor=white)
![FluentValidation](https://img.shields.io/badge/FluentValidation-42A5F5?style=flat-square&logo=nuget&logoColor=white)
![MailKit](https://img.shields.io/badge/MailKit-D14836?style=flat-square&logo=gmail&logoColor=white)
![PagedList](https://img.shields.io/badge/PagedList-239120?style=flat-square&logo=nuget&logoColor=white)
![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=flat-square&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=flat-square&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black)
![Bootstrap](https://img.shields.io/badge/Bootstrap-563D7C?style=flat-square&logo=bootstrap&logoColor=white)


## 📖 Proje Hakkında

Bu proje, **ASP.NET Core** ve **MongoDB** kullanarak geliştirmiş olduğum kapsamlı bir **Full Stack Restoran Yönetim Sistemi**dir.
Projem fiziksel olarak tek katmanlı bir yapıda olsa da, **Clean Code** prensiplerine sadık kalarak mantıksal katmanlara (Entities, DTOs, Services, Managers) ayrılmıştır. Veri tutarlılığı ve kodun sürdürülebilirliği için **Repository Design Pattern** ve validasyon yapıları kullandım.

## 🏗️ Mimari ve Teknik Detaylar

Projede modüler, genişletilebilir ve temiz bir kod yapısı hedeflenmiştir.

| Kategori | Teknoloji / Kütüphane | Kullanım Amacı |
|----------|-----------------------|----------------|
| **Framework** | ASP.NET Core 6.0 | Ana uygulama çatısı |
| **Veritabanı** | MongoDB | NoSQL veri depolama |
| **ORM / Desen** | Repository Pattern | Veri erişim soyutlaması |
| **Mapping** | AutoMapper | Entity ve DTO nesne eşlemeleri |
| **Validasyon** | FluentValidation | Sunucu taraflı veri doğrulama |
| **İletişim** | MailKit (SMTP/IMAP) | Mail gönderme **ve** okuma (Inbox/Sent) |
| **Güvenlik** | Cookie Authentication | Admin paneli giriş güvenliği |
| **Sayfalama** | PagedList | Veri listeleme performansı |
| **Frontend** | HTML5, CSS3, Bootstrap | Kullanıcı arayüzü tasarımı |

### 🔧 Geliştirme Prensipleri
* **Repository Design Pattern:** Veritabanı işlemlerini soyutlayarak kod tekrarını önledim ve test edilebilirliği artırdım.
* **Service Layer:** Her varlık (Entity) için ayrı servisler (örneğin; `ProductService`, `CategoryService`) yazarak iş mantığı controller'dan ayrıştırdım.
* **DTO (Data Transfer Objects):** `Result`, `Create` ve `Update` işlemleri için ayrı DTO'lar kullanılarak veri güvenliğini sağladım.
* **ViewComponents & Partial Views:** UI kod tekrarını önlemek ve temiz bir HTML yapısı için component bazlı geliştirme yaptım.
* **Dependency Injection:** Bağımlılıkları yönetmek ve gevşek bağlı bir yapı kurmak için aktif olarak kullandım.

## ✨ Özellikler

### 👨‍🍳 Kullanıcı Arayüzü (Public)
* **Menü ve Ürünler:** Kategorize edilmiş menü, ürün detayları, fiyatlar ve içerik bilgileri.
* **Etkileşim:** Kullanıcılar ürünlere yorum yapabilir ve **yıldız (rating)** verebilir.
* **Blog:** Restoran ile ilgili haberler ve makaleler (Yorum yapma özelliği ile).
* **Rezervasyon:** Müşteriler online masa rezervasyonu oluşturabilir.
* **İletişim & Bülten:** İletişim formu ve e-bülten aboneliği.
* **Şefler:** Mutfak ekibi ve şef detay sayfaları.

### 🔒 Yönetim Paneli (Admin Dashboard)
* **Dashboard:** Anlık istatistikler, metrikler ve özet veriler.
* **Ürün Yönetimi:** Ürün ekleme, silme, güncelleme, kategori yönetimi ve ürün yorumlarını denetleme.
* **Rezervasyon Yönetimi:** Gelen rezervasyonları görüntüleme, onaylama veya iptal etme (Bekleyen/Onaylanan/İptal).
* **Gelişmiş Mesajlaşma Sistemi:**
    * **SMTP & MailKit Entegrasyonu:** Admin paneli üzerinden sadece mail gönderme değil, **gelen mailleri okuma (Inbox)**, giden kutusu ve yıldızlı mesajlar gibi özellikler bir webmail istemcisi gibi çalışır.
* **İçerik Yönetimi:** Blog yazıları, şefler, referanslar, galeri, tanıtım videoları ve özel tekliflerin yönetimi.
* **Ayarlar:** SMTP ayarları ve **Dark Mode** (Karanlık Mod) desteği.
* **Güvenlik:** Cookie tabanlı güvenli giriş sistemi.

## 📂 Klasör Yapısı (Özet)

Proje yapısı mantıksal ayrımı net bir şekilde yansıtmaktadır:

```text
MongoDB-RestaurantProject
├── Areas (Admin Paneli)
├── Context (Veritabanı Modelleri ve Veritabanı Bağlantısı)
├── Services (İş Mantığı Katmanı)
├── DTOs (Data Transfer Objects)
├── Extensions (Program.cs için extension metotları)
├── FluentValidation (Doğrulama Kuralları)
├── Mapping (AutoMapper Profili)
├── ViewComponents (UI Bileşenleri)
├── Controllers
└── Views
```

# 👨‍💻 Kullanıcı Paneli

Aşağıda kullanıcı arayüzüne ait sayfa görüntüleri kategorilere ayrılmış şekilde listelenmiştir.


## 🏠 Anasayfa

<img width="1901" src="https://github.com/user-attachments/assets/5cb7eb2b-c64a-45e3-a59f-66079956eba9" />
<img width="1899" src="https://github.com/user-attachments/assets/2a177eb1-8922-4e14-bb06-b276675eeb3c" />
<img width="1903" src="https://github.com/user-attachments/assets/b1a42d2c-746f-41af-908f-b76af288ecfa" />
<img width="1886" src="https://github.com/user-attachments/assets/7510da47-7eb9-4db6-9dbf-c55e6b2f2f3f" />
<img width="1893" src="https://github.com/user-attachments/assets/301c824c-0af9-4c1e-a97e-4242d1561d94" />
<img width="1899" src="https://github.com/user-attachments/assets/627354f0-bd2e-4664-a73a-4db0551f4c6a" />
<img width="1895" src="https://github.com/user-attachments/assets/e98d8d6e-b439-41be-ad4d-5fcea5583a88" />
<img width="1897" src="https://github.com/user-attachments/assets/07b81777-1d31-4487-8ae3-3a0742d2a106" />
<img width="1894" src="https://github.com/user-attachments/assets/3621e0bb-9ced-47f2-98f1-2ed830a23d8f" />
<img width="1900" src="https://github.com/user-attachments/assets/1481e6d2-a6a2-4205-9c19-f12101f0e6b7" />

---

## 🍽️ Menü ve Ürün Detayı

<img width="1920" src="https://github.com/user-attachments/assets/43990a38-3aa3-4221-b03f-7c4d751fea98" />
<img width="1920" src="https://github.com/user-attachments/assets/08bbe376-cb10-4414-864f-e7cea619f0ce" />

---

## 👨‍🍳 Şefler ve Şef Detayları

<img width="1920" src="https://github.com/user-attachments/assets/ea37e742-e34c-4eb0-a14f-b5daa5640a50" />
<img width="1920" src="https://github.com/user-attachments/assets/1b09ccfa-38f8-43b3-815d-e9f0f72c0b20" />

---

## 🏢 Hakkımızda

<img width="1920" src="https://github.com/user-attachments/assets/a0c6dfba-1b4b-490a-b8b5-21b1f6597931" />

---

## 📝 Blog Yazıları ve Detayları

<img width="1920" src="https://github.com/user-attachments/assets/5db3845b-5bad-4fd6-a4d4-bdb2a81794a9" />
<img width="1920" src="https://github.com/user-attachments/assets/3d7b0297-a5f3-4c1e-b43f-4b294bf2200b" />

---

## 📬 İletişim

<img width="1920" src="https://github.com/user-attachments/assets/6d0838d4-a8f1-4d4c-9e09-ed1ffe4c3517" />

---

## 📅 Rezervasyon

<img width="1920" src="https://github.com/user-attachments/assets/390abff2-a86b-4310-bf9d-2e0e3a95752b" />

---

# 🔐 Login Paneli

<img width="1920" src="https://github.com/user-attachments/assets/e02405da-a150-42dd-88d2-ff323e7f1b89" />

---

# 🛠️ Admin Paneli

<img width="1911" src="https://github.com/user-attachments/assets/fa8b9f31-208c-4f6c-8e95-4aa85eb6c699" />
<img width="1912" src="https://github.com/user-attachments/assets/ff106e7c-4f2a-433e-89a9-bd2db357f104" />
<img width="1910" src="https://github.com/user-attachments/assets/55a7447b-9bf3-4f4b-a36c-8de1647e1603" />
<img width="1912" src="https://github.com/user-attachments/assets/09429e16-6d05-4c16-afa6-3eb790349183" />
<img width="1909" src="https://github.com/user-attachments/assets/32ee6fd8-8ca1-42ca-948e-8909b026ed66" />
<img width="1911" src="https://github.com/user-attachments/assets/c89fac1b-f5e2-4f6f-8e00-6f29960c3a44" />
<img width="1913" src="https://github.com/user-attachments/assets/dc4bb771-1d15-4d16-91a3-f5791e0a9843" />
<img width="1913" src="https://github.com/user-attachments/assets/858dad46-00be-4844-9a0b-0bc761130991" />
