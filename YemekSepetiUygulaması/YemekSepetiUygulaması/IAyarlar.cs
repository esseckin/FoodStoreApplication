using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulaması
{
    interface IAyarlar
    {
        void ProfilGoruntule(Uye uye);
        //void BilgiGuncelle(Uye uye);//db islemlerinde var
        //void HesapKapat(Uye uye);
        void SiparisList(Uye uye);
        void İndirimKuponList(Uye uye);

    }
}
