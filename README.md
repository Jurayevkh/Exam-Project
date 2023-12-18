# 🚀 Exam - Project

Bu imtihon loyihasida General Motors va QRCode servislarini tayyorlandi.

## Mavzular

- [📖 Loyiha haqida](#loyiha-haqida)
- [💻 Ishlatilgan texnologiyalar](#ishlatilgan-texnologiyalar)
- [🏗 Loyiha arxitekturasi](#loyiha-arxitekturasi)
- [🛢 Ma'lumotlar bazasi](#malumotlar-bazasi)
- [🚀 Ishlatish uchun](#ishlatish-uchun)
  - [🛠 O'rnatish](#ornatish)
  - [⚙️ Konfiguratsiyalar](#konfiguratsiyalar)
- [🔧 Ishlatilinish](#ishlatish)
  - [🛣 Routlar](#routlar)


## 📖 Loyiha haqida

Bu loyihada 2 ta servis mavjud bo'lib General Motors va QRCode lar hisoblanadi. General Motors servisi mashina servisi hisoblanadi , QRCode esa ma'lumotlar bazasidan kelgan ma'lumotlarni id bo'yicha va barcha ma'lumotlarni QR Code ga o'tkazib beradi. Har ikkala servisda ma'lumotlarni olayotgan paytimiz keshlanadi agar ma'lumotlar avval keshlangan bo'lsa hamda LifeTime vaqti tugamagan bo'lsa ma'lumotlarni keshdan olib keladi.

## 💻 Loyihada ishlatildi:

- ✅CQRS Design Pattern
- ✅Caching
- ✅Clean Architecture
- ✅Background Service
- ✅Database Trigger
- ✅Fluent API
- ✅Microservice
- ✅Entity Framework Core
- ✅API Gateway

## 🏗 Loyiha arxitekturasi

Bu loyiha Mikroservis arxitekturasiga tayangan holda tuzildi.

## 🛢 Ma'lumotlar bazasi
    General Motors:
![Снимок экрана 2023-12-11 в 06 08 45](https://github.com/Jurayevkh/Exam-Project/assets/123798965/501ea785-2e9c-4a07-8e2d-7f8ec65f0f45)
    QR Code:
    QR Code loyihasi asosan kelgan ma'lumotlarni QR Code ko'rinishiga o'tkazib berish bo'lganligi uchun Databazasiga katta ahamiyat berilmadi:
![Снимок экрана 2023-12-11 в 06 12 45](https://github.com/Jurayevkh/Exam-Project/assets/123798965/482ccbbc-26ed-42a0-8d8a-84e45d402627)

## 🚀 Ishlatish uchun
  ## 🛠 O'rnatish:
      Reddis
      (Loyihadagi NuGet package lar avtomatik o'rnatiladi)
  ## ⚙️ Konfiguratsiyalar:
      Loyihamizning 2 servisi ham Clean Architecture da yozilgan shuni inobatga olgan holda ikkala loyihamizning ham bir xil joylarini o'zingiznikiga to'g'irlab olishingiz lozim:
      1.Servislarimizning Infrastructure layeridagi Dependency.cs ichida bazamiz bazasini ulab o'tganmiz agar siz Postgresql ishlatayotgan bo'lsangiz Connection String nomi "Default"   tursin aks holda agar siz SQL Server ishlatayotgan bo'lsangiz Connection String nomi "ConnectionStringForSQLServer" turishi kerak.
      2.Connection Stringlardagi ma'lumotlarni o'zingizga to'g'irlab olishingiz kerak ya'ni sizning bazangiz turgan server, Database Name, Port , Password va shu kabi konfiguratsiyalarni o'zingizniki bilan to'g'rilab chiqishingiz kerak

## 🔧 Ishlatilinish:
  ❗️Loyiha local ishlayotgani uchun loyihalarni Multiple Project ko'rinishiga o'tkazib Run qilishingiz kerak
  ##  🛣 Routlar:
    Base Url: https://localhost:24020
      1.Cars:
        /GetAllCar - barcha mashinalarni olish uchun
        /GetByIdCar/{id} - berilgan Id bo'yicha mashina ma'lumotlarini qaytaradi
        /CreateCar - mashina yaratish uchun shu ko'rinishda ma'lumot yuborasiz:
                              {
                                  "name":"Mercedes-Benz",
                                  "model":"G-Class",
                                  "price":56000,
                                  "color":"black",
                                  "fuel_type":"5",
                                  "features":"looks good",
                                  "description":"so good",
                                  "cartypeid":2,
                                  "carimage":"imageOfGClass"
                              }
        /UpdateCar -  biror mashina ma'lumotlarni yangilamoqchi bo'lsangiz quyidagi ko'rinishda ma'lumot yuborasiz:
                              {
                                  "id":6,
                                  "name":"Toyota",
                                  "model":"Supra",
                                  "price":45000,
                                  "color":"red",
                                  "fuel_type":"5",
                                  "features":"Supra is so fast car",
                                  "description":"so many",
                                  "cartypeid":1,
                                  "carimage":"imageOfSupra"
                              }
        /DeleteCar/{id} - berilgan Id bo'yicha mashinani o'chiradi
      
      
      2.Car Type:
        /GetAllCarType - barcha mashina turlarini qaytaradi
        /GetByIdCarType/{id} - berilgan ID bo'yicha mashina turini qaytaradi

      3.Car Client:
        /GetAllCarClient - barcha mashina va uning xaridorlarini qaytaradi
        /GetByIdCarClient/{id} - berilgan id bo'yicha mashina va uning xaridorini qaytaradi
        /CreateCarClient -  mashina va uning xaridorini yaratish uchun :
                              {
                                  "carid":7,
                                  "username":"thereIsNothingWeCanDo"
                              }              

      4.Dillers:
        /GetByIdDiller/{id} - berilgan ID bo'yicha barcha dillerlarni  qaytaradi
        /GetAllDiller - barcha dillerlarni qaytaradi
        /CreateDiller - Diller yaratish uchun :
                              {
                                  "region":"regionName",
                                  "contact":"contact"
                              }
        /UpdateDiller - biror Diller ma'lumotlarini yangilash uchun:
                              {
                                  "id":2,
                                  "region":"Tashkent",
                                  "contact":"+998 99 777 11 11"
                              }  
        /DeleteDiller/{id} - berilgan Id bo'yicha Dillerni o'chiradi                    
        
      5.Client:
        /GetAllClients - barcha xaridorlarni olish uchun
        /GetByIdClients/{id} - berilgan id bo'yicha xaridor ma'lumotlarini olish
        /CreateClient - xaridor yaratish uchun:
                              {
                                  "fullname":"Fred",
                                 "contact":"+1 998 12 34",
                                 "username":"FredNashville",
                                 "password":"Nashvilee",
                                 "email":"fred@gmail.com",
                                 "address":"USA , Nashville"
                              }
        /UpdateClient - xaridor ma'lumotlarini yangilash uchun:
                              {
                                 "id":12,
                                 "fullname":"Napaleon",
                                 "contact":"+1 998 12 34",
                                 "username":"thereIsNothingWeCanDo",
                                 "password":"france",
                                 "email":"littleleader@gmail.com",
                                 "address":"France , Paris",
                                 "role":"client"
                              }
        /DeleteClient/{id} - berilgan ID bo'yicha xaridorni o'chirish
    
    6.Users:
        /GetAllUsers - barcha userlarni olish uchun
        /GetByIdUser/{id} - berilgan ID bo'yicha user ma'lumotlarini olish
        /CreateUser -  user yaratish uchun:
                              {
                                  "firstname":"Johny",
                                  "lastname":"Deep",
                                  "middlename":"Johnson",
                                  "age":45,
                                  "email":"jonhy@gmail.com"
                              }
       /UpdateUser -  user ma'lumotlarini yangilash uchun:
                              {
                                  "id":3,
                                  "firstname":"Jim",
                                  "lastname":"Carrey",
                                  "middlename":"Brown",
                                  "age":60,
                                  "email":"jim@gmail.com"
                              }
      /DeleteUser/{id} - berilgan ID bo'yicha userni o'chirish
    
    7.QRCode:
      /GetQRCode -  umumiy ma'lumotlarning QR Code ko'rinishi
      /GetQRCodeById/{id} - berilgan id bo'yicha ma'lumotlarning QR Code ko'rinishi
      
