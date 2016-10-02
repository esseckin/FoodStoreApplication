using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulaması
{
    abstract class DBIslemleri
    {
        //static Uye ilgiliUye;

        //internal static Uye IlgiliUye
        //{
        //    get { return DBIslemleri.ilgiliUye; }
        //    set { DBIslemleri.ilgiliUye = value; }
        //}
        public DBIslemleri()
        {

        }

        static ArrayList uyeList;//nesneye gore degısmeyecek.O yuzden static progun heryerınde aynı

        public static ArrayList UyeList
        {
            get { return uyeList; }
            set { uyeList = value; }
        }
        static ArrayList yemekList;

        public static ArrayList YemekList
        {
            get { return yemekList; }
            set { yemekList = value; }
        }
        static ArrayList restList;

        public static ArrayList RestList
        {
            get { return restList; }
            set { restList = value; }
        }

        public abstract void UyeEkle(Uye uye);
        public abstract void UyeGuncelle(Uye uye);
        public abstract void UyeSil(Uye uye);
        public abstract void YemekEkle(Yemek yemek);
        public abstract void RestEkle(Restaurant rest);
        public static void RestListele()
        {
            int sayac = 1;
            foreach (Restaurant item in RestList)
            {
                Console.WriteLine(sayac+"."+item.Ad);
                sayac++;
            }
        }
        public static void yemekListele()
        {
            int sayac = 1;
            foreach (Yemek item in YemekList)
            {
                Console.WriteLine(sayac + "." + item.Ad);
                sayac++;
            }
        }

       
        public abstract Yemek YemekAra(string yemek);
        public abstract Restaurant RestaurantAra(string restAd);
    }
}

