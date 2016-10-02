using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace YemekSepetiUygulaması
{
    class Program
    {
        static ArrayList sepetim = new ArrayList();
        static Uye ilgiliUye;
        static SystemControlImp control = new SystemControlImp();
        static string secim;
        static DBIslemleriImplement db = new DBIslemleriImplement();
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Thread.Sleep(500);
            Console.Clear();
            Console.WriteLine("1.Kaydol\n2.Uye Girisi\n3.Tanımlamalar\n4.Cıkıs\n5.Hesabı sil");
            Console.WriteLine("Lutfen secim yapınız.: ");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    KullaniciBilgiAl();
                    break;
                case "2":
                    UyeGiris();
                    break;
                case "3":
                    RestYemekMenu();
                    break;
                case "4":
                    Environment.Exit(1);
                    break;
                case "5":
                    HesabıKapat(ilgiliUye);
                    break;
                default:
                    Console.WriteLine("hatalı giriş yaptınız..");
                    break;
            }
        }

        static void HesabıKapat(Uye ilgiliUye)
        {
            Console.WriteLine("***********Uyeler**********");
            foreach (Uye item in DBIslemleriImplement.UyeList)
            {
                Console.WriteLine(item.AdSoyad1);
            }
            Console.WriteLine("Hesabınızı silmek istiyor musunuz?(E/H)");
            secim = Console.ReadLine();
            if (secim.ToUpper() == "E")
            {
                for (int i = 0; i < DBIslemleriImplement.UyeList.Count; i++)
                {
                    Uye uye = (Uye)DBIslemleriImplement.UyeList[i];


                    if (uye.Email.Equals(ilgiliUye.Email))
                    {
                        DBIslemleriImplement.UyeList.RemoveAt(i);
                        Console.WriteLine("Uye listeden silindi....");
                        Console.WriteLine("***********Listedeki Uyeler**********");
                        foreach (Uye item in DBIslemleriImplement.UyeList)
                        {
                            Console.WriteLine(item.AdSoyad1);
                        }
                        Thread.Sleep(1000);
                        Menu();

                    }

                    else
                    {
                        Console.WriteLine("Listede boyle bir uye bulunamadı");
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Güle Güle");
                Environment.Exit(0);
            }
        }

        static void UyeGiris()
        {
            Console.WriteLine("Mail:");
            string mail = Console.ReadLine();
            Console.WriteLine("Sifre:");
            string sifre = Console.ReadLine();
            ilgiliUye = control.IslemYapilanUye(DBIslemleri.UyeList, mail);
            if (ilgiliUye != null)
            {
                if (control.SifreMailUyusuyorMu(ilgiliUye, sifre))
                {
                    Console.WriteLine(ilgiliUye.AdSoyad1 + " Hosgeldiniz..");
                    AramaMenusu();

                }
                else
                {
                    AltMenu();
                }
            }
        }
        static void AramaMenusu()
        {
            Console.WriteLine("1-Restauranta göre arama\n2-Yemege göre arama\n3-Hesabımı sil");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    RestAra();
                    break;
                case "2":
                    YemekAraa();
                    break;
                case "3":
                    HesabıKapat(ilgiliUye);
                    break;
                default:
                    break;
            }
        }
        static void YemekAraa()
        {
            Console.WriteLine("henuz kullanılamıyor..");
            Menu();
        }
        static void RestAra()
        {
            string karar;
            double toplamTutar = 0;
            Console.WriteLine("restaurant adını giriniz..: ");
            string restAd = Console.ReadLine();
            Restaurant rest = db.RestaurantAra(restAd);
            if (rest != null)
            {
                rest.RestYemekList();
                Console.WriteLine("Siparisiniz beklenmektedir..Ltfen yemek seciniz..");

                do
                {

                    int yemekIndex = int.Parse(Console.ReadLine());
                    if (rest.YemekList.Count >= yemekIndex)
                    {
                        ilgiliUye.SiparisList.Add(rest.YemekList[yemekIndex - 1]);
                        toplamTutar += ((Yemek)rest.YemekList[yemekIndex - 1]).Fiyat;
                        if (toplamTutar >= 50)
                        {
                            ilgiliUye.IndirimKupon = ((int)toplamTutar / 50) * 10;
                            ilgiliUye.IndirimKuponGuncelle();
                            Console.WriteLine("indirim kuponunuz:" + ilgiliUye.IndirimKupon + " TL tutarındadır.");
                        }

                    }
                    else
                        Console.WriteLine("listede olmayan yemek girdiniz..");
                    Console.WriteLine("Devam mı?(E/H)");
                    karar = Console.ReadLine().ToUpper();
                } while (karar == "E");
                if (ilgiliUye.KuponVarMı)
                {
                    Console.WriteLine("indirim kuponunuzu kullanmak ister misiniz(E/H)");
                    karar = Console.ReadLine();
                    if (karar.ToUpper() == "E")
                    {
                        toplamTutar = (int)toplamTutar < ilgiliUye.IndirimKupon ? 0 : (int)toplamTutar - ilgiliUye.IndirimKupon;
                        ilgiliUye.IndirimKupon = (int)toplamTutar > ilgiliUye.IndirimKupon ? 0 : ilgiliUye.IndirimKupon - (int)toplamTutar;
                        ilgiliUye.IndirimKuponGuncelle();
                    }
                }
                Console.WriteLine("siparişiniz alınmıştır.");
                Console.WriteLine("Odenecek tutar: " + toplamTutar);
            }
        }

        static void AltMenu()
        {
            Console.WriteLine("1.Kaydol\n2.Sifremi Unuttum");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    KullaniciBilgiAl();
                    break;
                case "2":
                    Console.WriteLine("sifreniz..: " + ilgiliUye.Sifre);
                    break;
                default:
                    break;
            }

        }
        // static void SifremiUnuttum()
        //{
        //    //Console.WriteLine("Gmail adresiniz:");
        //    //string mail = Console.ReadLine();
        //    //if (!control.MailValidMi(DBIslemleri.UyeList, mail))
        //    //{
        //        Console.WriteLine("sifreniz..: " + ilgiliUye.Sifre);
        //    //}
        //    //else
        //    //{
        //    //    Console.WriteLine("Hatalı mail");
        //    //}
        //}
        static void KullaniciBilgiAl()
        {
            Uye uye = new Uye();
            Console.WriteLine("Ad soyad: ");
            string adSoyad = Console.ReadLine();
            Console.WriteLine("Cinsiyet(Kadın/Erkek): ");
            Cinsiyet cinsiyet = (Cinsiyet)Enum.Parse(typeof(Cinsiyet), Console.ReadLine(), true);
            Console.WriteLine("Lütfen gmail adresinizi giriniz : ");
            string mail = Console.ReadLine();

            if (control.MailSyntaxUygunMu(mail))
            {
                if (control.MailValidMi(DBIslemleri.UyeList, mail))
                {
                    uye.Email = mail;
                    Console.WriteLine("sifre giriniz..: ");
                    string sifre = Console.ReadLine();
                    if (control.SifreSyntaxUygunMu(sifre))
                    {
                        Console.WriteLine("Dogrulama sifresini giriniz..: ");
                        string dSifre = Console.ReadLine();
                        if (control.SifrelerUyusuyorMu(sifre, dSifre))
                        {
                            uye.AdSoyad1 = adSoyad;
                            uye.Cinsiyet = cinsiyet;
                            uye.Sifre = sifre;
                            db.UyeEkle(uye);
                        }
                        else
                        {
                            Console.WriteLine("Sifreler uyusmuyor..");
                            Menu();
                        }
                    }
                }
                else
                {
                    Console.WriteLine("bu adres daha onceden kullanılmıstır.");
                    Menu();
                }
            }
            else
            {
                Console.WriteLine("Lütfen dogru formatta gmail adresi giriniz..");
                Menu();
            }
            Menu();

        }

        static void RestYemekMenu()
        {
            Console.WriteLine("1.Restaurant tanımla\n2.Yemek tanımla\n3.Reste yemek gir");
            Console.WriteLine("Lutfen secim yapınız.: ");
            secim = Console.ReadLine();
            switch (secim)
            {
                case "1":
                    Console.WriteLine("Restaurant adı giriniz..: ");
                    String restAd = Console.ReadLine();
                    //   Console.WriteLine("Restaurant kurulus tarihi giriniz..: ");
                    //  DateTime kurTarih = Convert.ToDateTime(Console.ReadLine());
                    Restaurant rest = new Restaurant(restAd);
                    db.RestEkle(rest);
                    Menu();
                    break;
                case "2":
                    Yemek yemek = new Yemek();
                    Console.WriteLine("Yemek adı giriniz..:");
                    yemek.Ad = Console.ReadLine();
                    Console.WriteLine("Fiyat giriniz..:");
                    yemek.Fiyat = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Kampanyalı mı (1/0)");
                    yemek.KampanyaDurum = Convert.ToBoolean(Console.ReadLine());
                    db.YemekEkle(yemek);
                    Menu();
                    break;
                case "3":
                    ResteYemekGiris();
                    break;
                default:
                    Console.WriteLine("hatalı giriş yaptınız..");
                    Menu();
                    break;
            }
        }

        static void ResteYemekGiris()
        {
            DBIslemleri.RestListele();
            Console.WriteLine("hangi restoran:");
            int index = int.Parse(Console.ReadLine());
            Restaurant restt = (Restaurant)DBIslemleri.RestList[index - 1];
            Console.WriteLine("yemek secin:");
            restt.YemekList = new ArrayList();
            do
            {
                Console.Clear();
                Console.WriteLine("---yemekler---");
                DBIslemleri.yemekListele();
                Console.WriteLine("yemek secin:");
                index = int.Parse(Console.ReadLine());
                restt.YemekList.Add(DBIslemleri.YemekList[index - 1]);
                Console.WriteLine("devam mı?(E/H)");
                secim = Console.ReadLine();
            } while (secim.ToUpper() == "E");
            Menu();
        }
    }
}
