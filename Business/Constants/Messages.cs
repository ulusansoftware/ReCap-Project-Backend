using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarDeleted = "Araç Silindi";
        public static string CarListed = "Araçlar Listelendi";


        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";


        public static string ColorListed = "Renk Listelendi";
        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";


        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerUpdated = "Müşteri Güncellendi";
        public static string CustomerListed = "Müşteri Listelendi";


        public static string RentalAdded = "Kiralama Sisteme Tanımlandı";
        public static string RentalDeleted = "Kiralama Sistemden Silindi";
        public static string RentalUpdated = "Kiralama Sistemde Güncellendi";
        public static string RentalListed = "Kiralamalar Listelendi";
        

        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageDeleted = "Araç resmi silindi";
        public static string CarImagesLimitExceeded = "Araç başına yüklenecek fotoğraf sayısını aştınız";


        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserAdded = "Kullanıcı Eklendi";


        public static string CarCountOfBrandError = "Bir Araç türünde en fazla 15 ürün olabilir ";
        public static string CarNameAlreadyExists = "Böyle bir araba ismi zaten var";
       

        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string UserRegistered = "Kullanıcı Kayıt Oldu";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        public static string PasswordError = "Parola Hatası";
        public static string SuccessfulLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Böyle bir kullanıcı Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";
        public static string UserCanRegister = "Kullanıcı Kayıt Olabilir";


        public static string MaintenanceTime = "Sistem Bakımda";

        public static string CarUpdated = "Araba güncellendi";

        public static string UserListed { get; internal set; }
    }
}