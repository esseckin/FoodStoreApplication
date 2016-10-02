using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulaması
{
    class Restaurant:RestaurantOzellikleri
    {

        string ad;
        DateTime kurTarih;
        public Restaurant()
        {

        }
        public Restaurant(string ad)
        {
            Ad = ad;
           
        }

        public override string Ad
        {
            get
            {
                return ad;   
            }
            set
            {
                ad = value;
            }
        }

        public override DateTime KurulusTarihi
        {
            get
            {
                return kurTarih;
            }
            set
            {
                kurTarih = value;
            }
        }

        public override ArrayList YemekList
        {
            get;
            set;

        }

        public override void SiparisVer()
        {
           
        }

        public override void RestYemekList()
        {
            int sayac = 1;
            Console.WriteLine("---Restaurant Adı:{0}---",Ad);
            foreach (Yemek item in YemekList)
            {
                Console.WriteLine(sayac+"."+item.ToString());
                sayac++;
            }
        }

    }
}
