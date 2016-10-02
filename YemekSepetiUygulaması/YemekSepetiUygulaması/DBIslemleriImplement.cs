using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulaması
{
    class DBIslemleriImplement:DBIslemleri
    {
        static DBIslemleriImplement()
        {
            UyeList = new ArrayList();
            YemekList = new ArrayList();
            RestList = new ArrayList();
        }

        public override void UyeEkle(Uye uye)
        {
            UyeList.Add(uye);
        }

        public override void UyeGuncelle(Uye uye)
        {
         
        }

        public override void UyeSil(Uye uye)
        {
           
        }

        public override void YemekEkle(Yemek yemek)
        {
            YemekList.Add(yemek);
        }

        public override void RestEkle(Restaurant rest)
        {
            RestList.Add(rest);
        }


        public override Yemek YemekAra(string yemek)
        {
            foreach (Yemek item in YemekList)
            {
                if (item.Ad.Equals(yemek))
                {
                    return item;
                }
            }
            return null;
        }

        public override Restaurant RestaurantAra(string restAd)
        {
            foreach (Restaurant item in RestList)
            {
                if (item.Ad.Equals(restAd))
              {
                  return item;
              }
            }
            return null;
        }
    }
}
