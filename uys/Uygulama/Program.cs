// See https://aka.ms/new-console-template for more information

using System;
using System.ComponentModel;


class Program
{
   
    static void Main()
    {

        
        Console.WriteLine("Üniversite Yönetim Sistemi Kullanıcı Giriş Ekranı\n");

        bool kcheck = false;
        bool scheck = false;

        while (!kcheck)
        {
            Console.WriteLine("Kullanıcı adınızı giriniz: ");
            string kullanici = Console.ReadLine();
            if (kullanici == "yusuf")
            {
                while (!scheck)
                {
                    Console.WriteLine("Kullanıcı şifrenizi giriniz: ");
                    string parola = SifreliOku(); // SifreliOku fonksiyonu ile şifreyi yıldızlı al
                    if (parola == "12345")
                    {
                        kcheck = true;
                        scheck = true;
                        Console.WriteLine("\nKullanıcı adı ve şifre doğru. Giriş başarılı\n");
                    }
                    else
                    {
                        kcheck = true;
                        scheck = false;
                        Console.WriteLine("\nŞifre yanlış. Lütfen tekrar giriniz");
                    }
                }
            }
            else
            {
                Console.WriteLine("Kullanıcı adınız hatalı! Lütfen tekrar deneyiniz.");
                kcheck = false;
            }
        }

        // Kullanıcının şifresini yıldızlı bir şekilde okuyan fonksiyon
         string SifreliOku()
        {
            string pass = "";
            do
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        break;
                    }
                }
            } while (true);
            return pass;
        }
        
        


        while (true)
        {
           
            Console.WriteLine("****** Kullanıcı Menüsü ******\n");
            Console.WriteLine("1- Öğrenci Girişi");
            Console.WriteLine("2- Öğretmen Girişi");
            Console.WriteLine("3- İdare Girişi");
            Console.WriteLine("4- Çıkış");


            Console.Write("Seçenek girin (1-4): ");
            string secim = Console.ReadLine();
            Console.WriteLine("\n");


            switch (secim)
            {
                case "1":
                    OgrenciGirisi();
                    break;

                case "2":
                    OgretmenGirisi();
                    break;

                case "3":
                    IdareGirisi();
                    break;

                case "4":
                    Console.WriteLine("Programdan çıkılıyor...");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçenek. Lütfen 1-4 arasında bir değer girin.");
                    break;
            }
        
        }
    
    
    }
    
    static void OgrenciGirisi()
    {

        LisansOgrenci lOgrenci = new LisansOgrenci();
        Console.WriteLine("***** Öğrenci Girişi *****\n");


        do
        {
            Console.Write("Öğrenci Adı: ");
            lOgrenci.ogrenciAd = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lOgrenci.ogrenciAd))
            {
                Console.WriteLine("Hata: Öğrenci adı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(lOgrenci.ogrenciAd));


        do
        {
            Console.Write("Öğrenci Soyadı: ");
            lOgrenci.ogrenciSoyad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lOgrenci.ogrenciSoyad))
            {
                Console.WriteLine("Hata: Öğrenci soyadı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(lOgrenci.ogrenciSoyad));


        int ogrenciNumara;

        while (true)
        {
            Console.Write("Öğrenci Numarası: ");

            if (int.TryParse(Console.ReadLine(), out ogrenciNumara))
            {
                string ogrenciNumaraStr = ogrenciNumara.ToString();

                if (ogrenciNumaraStr.Length == 9)
                {
                    // 9 haneli doğru bir giriş yapılmış
                    break;
                }
                else
                {
                    Console.WriteLine("Hatalı giriş! Öğrenci numarası 9 haneli olmalıdır. Tekrar deneyin.");
                }
            }
            else
            {
                Console.WriteLine("Hatalı giriş! Lütfen bir sayı girin.");
            }
        }

        lOgrenci.ogrenciNumara = ogrenciNumara;


        do
        {
            Console.Write("Öğrenci Bölümü: ");
            lOgrenci.ogrenciBolum = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lOgrenci.ogrenciBolum))
            {
                Console.WriteLine("Hata: Öğrenci bölümü boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(lOgrenci.ogrenciBolum));

        int ogrenciSinif;
        Console.Write("Öğrenci Sınıf: ");
        


        while (!int.TryParse(Console.ReadLine(), out ogrenciSinif))
        {
            Console.WriteLine("Hatalı giriş! Lütfen bir sayı girin.");
            Console.Write("Öğrenci Sınıf: ");
        }
        

        lOgrenci.ogrenciSınıf = ogrenciSinif;


        double vizeNotu;
        Console.Write("Vize Notu: ");

        while (!double.TryParse(Console.ReadLine(), out vizeNotu) || vizeNotu < 0 || vizeNotu > 100)
        {
            Console.WriteLine("Hatalı giriş! Lütfen 0 ile 100 arasında bir sayı girin.");
            Console.Write("Vize Notu: ");
        }

        lOgrenci.Vize = vizeNotu;

        double finalNotu;
        Console.Write("Final Notu: ");

        while (!double.TryParse(Console.ReadLine(), out finalNotu) || finalNotu < 0 || finalNotu > 100)
        {
            Console.WriteLine("Hatalı giriş! Lütfen 0 ile 100 arasında bir sayı girin.");
            Console.Write("Final Notu: ");
        }

        lOgrenci.Final = finalNotu;


        do
        {
            Console.Write("Proje Konusu: ");
            lOgrenci.ProjeKonu = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(lOgrenci.ProjeKonu))
            {
                Console.WriteLine("Hata: Proje konusu boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(lOgrenci.ProjeKonu));


        lOgrenci.BilgileriYazdir();

        Console.Write("Değiştirmek istediğiniz bir yer var mı? (Ad/Soyad/Numara/Bolum/Sınıf/Vize/Final/Proje/Hiçbiri): ");
        string secim = Console.ReadLine();

        string[] secimler = secim.Split(',');

        
        
        //Geçici bir nesne oluşturup orijinal bilgileri saklar

        LisansOgrenci geciciOgrenci = new LisansOgrenci();
        geciciOgrenci.ogrenciAd = lOgrenci.ogrenciAd;
        geciciOgrenci.ogrenciSoyad = lOgrenci.ogrenciSoyad;
        geciciOgrenci.ogrenciNumara = lOgrenci.ogrenciNumara;
        geciciOgrenci.ogrenciBolum = lOgrenci.ogrenciBolum;
        geciciOgrenci.ogrenciSınıf = lOgrenci.ogrenciSınıf;
        geciciOgrenci.Vize = lOgrenci.Vize;
        geciciOgrenci.Final = lOgrenci.Final;
        geciciOgrenci.ProjeKonu = lOgrenci.ProjeKonu;




        foreach (var item in secimler)
        {
            switch (item.Trim().ToLower())
            {
                case "ad":
                    Console.Write("Yeni Öğrenci Adı: ");
                    lOgrenci.ogrenciAd = Console.ReadLine();
                    break;

                case "soyad":
                    Console.Write("Yeni Öğrenci Soyadı: ");
                    lOgrenci.ogrenciSoyad = Console.ReadLine();
                    break;

                case "numara":
                    Console.Write("Yeni Öğrenci Numarası: ");
                    lOgrenci.ogrenciSoyad = Console.ReadLine();
                    break;

                case "bölüm":
                    Console.Write("Yeni Öğrenci Bölümü: ");
                    lOgrenci.ogrenciSoyad = Console.ReadLine();
                    break;

                case "sınıf":
                    Console.Write("Yeni Öğrenci Sınıfı: ");
                    lOgrenci.ogrenciSoyad = Console.ReadLine();
                    break;

                case "vize":
                    Console.Write("Yeni Vize Notu: ");
                    lOgrenci.ogrenciSoyad = Console.ReadLine();
                    break;

                case "final":
                    Console.Write("Yeni Final Notu: ");
                    lOgrenci.ogrenciSoyad = Console.ReadLine();
                    break;

                case "proje konusu":
                    Console.Write("Yeni Proje Konusu: ");
                    lOgrenci.ogrenciSoyad = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine($"Geçersiz seçim: {item.Trim()}. İlgili alan değiştirilmeyecek.");
                    break;
            }
        }

        Console.Clear();
 
        lOgrenci.BilgileriYazdir();
        lOgrenci.NotHesapla();


    }


    static void OgretmenGirisi()
    {

        Ogretmen ogretmen = new Ogretmen();
        Console.WriteLine("***** Öğretmen Girişi *****\n");


        do
        {
            Console.Write("Öğretmen Adı: ");
            ogretmen.ogretmenAd = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ogretmen.ogretmenAd))
            {
                Console.WriteLine("Hata: Öğretmen adı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(ogretmen.ogretmenAd));

        do
        {
            Console.Write("Öğretmen Soyadı: ");
            ogretmen.ogretmenSoyad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ogretmen.ogretmenSoyad))
            {
                Console.WriteLine("Hata: Öğretmen soyadı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(ogretmen.ogretmenSoyad));

        do
        {
            Console.Write("Öğretmen Branş: ");
            ogretmen.ogretmenBrans = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(ogretmen.ogretmenBrans))
            {
                Console.WriteLine("Hata: Öğretmen branşı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(ogretmen.ogretmenBrans));


        ogretmen.BilgileriYazdir();


        Console.Write("Değiştirmek istediğiniz alanları virgülle ayırarak girin (Ad,Soyad,Branş): ");
        string alanlar = Console.ReadLine().ToLower();

        string[] secilenAlanlar = alanlar.Split(',');

       

        // Geçici bir öğretmen nesnesi oluşturup orijinal bilgileri sakla
        Ogretmen geciciOgretmen = new Ogretmen();
        geciciOgretmen.ogretmenAd = ogretmen.ogretmenAd;
        geciciOgretmen.ogretmenSoyad = ogretmen.ogretmenSoyad;
        geciciOgretmen.ogretmenBrans = ogretmen.ogretmenBrans;
        
        
        
        foreach (var secilenAlan in secilenAlanlar)
        {
            switch (secilenAlan.Trim())
            {
                case "ad":
                    Console.Write("Yeni Öğretmen Adı: ");
                    ogretmen.ogretmenAd = Console.ReadLine();
                    break;

                case "soyad":
                    Console.Write("Yeni Öğretmen Soyadı: ");
                    ogretmen.ogretmenSoyad = Console.ReadLine();
                    break;

                case "branş":
                    Console.Write("Yeni Öğretmen Branşı: ");
                    ogretmen.ogretmenBrans = Console.ReadLine();
                    break;

                default:
                    Console.WriteLine($"Geçersiz alan: {secilenAlan.Trim()}. İlgili alan değiştirilmeyecek.");
                    break;
            }
        }


        Console.Clear();
        // Yeni bilgileri ekrana yazdır
       
        ogretmen.BilgileriYazdir();

    }


    static void IdareGirisi()
    {

        Idareci idare = new Idareci();
        Console.WriteLine("***** İdare Girişi *****\n");


        do
        {
            Console.Write("İdareci Adı: ");
            idare.idareciAd = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idare.idareciAd))
            {
                Console.WriteLine("Hata: İdareci adı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(idare.idareciAd));

        do
        {
            Console.Write("İdareci Soyadı: ");
            idare.idareciSoyad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idare.idareciSoyad))
            {
                Console.WriteLine("Hata: İdareci soyadı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(idare.idareciSoyad));

        do
        {
            Console.Write("Personel Adı: ");
            idare.Personelad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idare.Personelad))
            {
                Console.WriteLine("Hata: Personel adı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(idare.Personelad));

        do
        {
            Console.Write("Personel Soyadı: ");
            idare.Personelsoyad = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(idare.Personelsoyad))
            {
                Console.WriteLine("Hata: Personel soyadı boş bırakılamaz. Lütfen tekrar deneyin.");
            }

        } while (string.IsNullOrWhiteSpace(idare.Personelsoyad));


        int devamsizlik;

        Console.Write("Devamsızlık: ");
        
        while (!int.TryParse(Console.ReadLine(), out devamsizlik))
        {
            Console.WriteLine("Hatalı giriş! Lütfen bir sayı girin.");
            Console.Write("Devamsızlık: ");
        }

        idare.Devamsizlik = devamsizlik;

        
        idare.BilgileriYazdir();


       
        Console.Write("Değiştirmek istediğiniz alanları virgülle ayırarak girin (Ad,Soyad,PersonelAd,PersonelSoyad,Devamsizlik): ");
        string alanlar = Console.ReadLine().ToLower();

        string[] secilenAlanlar = alanlar.Split(',');

        // Geçici bir idareci nesnesi oluşturup orijinal bilgileri sakla
        Idareci geciciIdareci = new Idareci();
        geciciIdareci.idareciAd = idare.idareciAd;
        geciciIdareci.idareciSoyad = idare.idareciSoyad;
        geciciIdareci.Personelad = idare.Personelad;
        geciciIdareci.Personelsoyad = idare.Personelsoyad;
        geciciIdareci.Devamsizlik = idare.Devamsizlik;

        foreach (var secilenAlan in secilenAlanlar)
        {
            switch (secilenAlan.Trim())
            {
                case "ad":
                    Console.Write("Yeni İdareci Adı: ");
                    idare.idareciAd = Console.ReadLine();
                    break;

                case "soyad":
                    Console.Write("Yeni İdareci Soyadı: ");
                    idare.idareciSoyad = Console.ReadLine();
                    break;

                case "personelad":
                    Console.Write("Yeni Personel Adı: ");
                    idare.Personelad = Console.ReadLine();
                    break;

                case "personelsoyad":
                    Console.Write("Yeni Personel Soyadı: ");
                    idare.Personelsoyad = Console.ReadLine();
                    break;

                case "devamsizlik":
                    Console.Write("Yeni Devamsızlık: ");
                    while (!int.TryParse(Console.ReadLine(), out devamsizlik))
                    {
                        Console.WriteLine("Hatalı giriş! Lütfen bir sayı girin.");
                        Console.Write("Devamsızlık: ");
                    }
                    idare.Devamsizlik = devamsizlik;
                    break;

                default:
                    Console.WriteLine($"Geçersiz alan: {secilenAlan.Trim()}. İlgili alan değiştirilmeyecek.");
                    break;
            }
        }

        Console.Clear();
       
        idare.BilgileriYazdir();

    }



}



// Temel Ogrenci sınıfı 
class Ogrenci
{
    public string ogrenciAd { get; set; }
    public string ogrenciSoyad { get; set; }
    public int ogrenciNumara { get; set; }
    public string ogrenciBolum { get; set; }
    public int ogrenciSınıf {  get; set; }
    public double Vize { get; set; }
    public double Final { get; set; }


    // Temel bilgileri ekrana yazdıran metod
    public virtual void BilgileriYazdir()
    {

        Console.WriteLine("_________________________");
        Console.WriteLine($"Öğrenci Adı: {ogrenciAd} ");
        Console.WriteLine($"Öğrenci Soyadı: {ogrenciSoyad} ");
        Console.WriteLine($"Öğrenci Numarası: {ogrenciNumara} ");
        Console.WriteLine($"Öğrenci Bölümü: { ogrenciBolum} ");
        Console.WriteLine($"Öğrenci Sınıf: {ogrenciSınıf} " );
        Console.WriteLine($"Vize Notu: {Vize} ");
        Console.WriteLine($"Final Notu: {Final} ");


    }


    // Temel not hesaplamayı yapan metod
    public virtual void NotHesapla()
    {
  
        double ortalama = (Vize * 0.4) + (Final * 0.6);


        if (ortalama < 40)
        {

            Console.WriteLine("Üzgünüm, kaldınız.");
        }

        else
        {

            Console.WriteLine("Tebrikler, geçtiniz.");
        }
        Console.WriteLine($"Not Ortalaması: {ortalama:F2}");
       

    }

}


// Lisans Ogrenci sınıfı, Temel Ogrenci sınıfından miras alır
class LisansOgrenci : Ogrenci
{
    public string ProjeKonu { get; set; }

    // Miras alınan metodları override ederek özelleştirme yapar
    public override void BilgileriYazdir()
    {
        base.BilgileriYazdir();
        Console.WriteLine($"Proje Konusu: {ProjeKonu}  \n");
    }

    public override void NotHesapla()  
    {
        base.NotHesapla();
        if (Final < 40 || Vize * 0.4 + Final * 0.6 < 40)
        {
            Console.WriteLine("Butünleme hakkınız var. Butünleme notunuzu girin:");

            double butunlemeNotu;
            while (!double.TryParse(Console.ReadLine(), out butunlemeNotu) || butunlemeNotu < 0 || butunlemeNotu > 100)
            {
                Console.WriteLine("Hatalı giriş! Lütfen 0 ile 100 arasında bir sayı girin.");
                Console.Write("Butünleme Notu: ");
            }

            // Butunleme notunu final notu yerine kullanarak notu tekrar hesapla
            double yeniOrtalama = (Vize * 0.4) + (butunlemeNotu * 0.6);

            if (yeniOrtalama >= 40)
            {
                Console.WriteLine("Tebrikler, butünleme sınavını geçtiniz.\n");
            }
            else
            {
                Console.WriteLine("Üzgünüm, butünleme sınavını geçemediniz.\n");
            }
        }
    }

}

class Ogretmen
{
    public string ogretmenAd { get; set; }
    public string ogretmenSoyad { get; set; }
    public string ogretmenBrans { get; set; }

    public virtual void BilgileriYazdir()
    {
        Console.WriteLine("_________________________");
        Console.WriteLine($"Öğretmen Adı: {ogretmenAd}");
        Console.WriteLine($"Öğretmen Soyadı: {ogretmenSoyad}");
        Console.WriteLine($"Öğretmen Branş: {ogretmenBrans}");
  
    }
}

class Idareci
{
    public string idareciAd { get; set; }
    public string idareciSoyad { get; set; }
    public string Personelad { get; set; }
    public string Personelsoyad { get; set; }
    public int Devamsizlik { get; set; }

    public virtual void BilgileriYazdir()
    {

        Console.WriteLine("_________________________");
        Console.WriteLine($"İdareci Adı: {idareciAd}");
        Console.WriteLine($"İdareci Soyadı: {idareciSoyad}");
        Console.WriteLine($"Personel Adı:  {Personelad}");
        Console.WriteLine($"Personel Soyadı: {Personelsoyad}");
        Console.WriteLine($"Devamsızlık: {Devamsizlik}");
    }

}
