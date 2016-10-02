using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YemekSepetiUygulaması
{
    class Uye
    {
       
        string AdSoyad;

        public string AdSoyad1
        {
            get { return AdSoyad; }
            set { AdSoyad = value; }
        }
        string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        string sifre;

        public string Sifre
        {
            get { return sifre; }
            set { sifre = value; }
        }
        int indirimKupon;

        public int IndirimKupon
        {
            get { return indirimKupon; }
            set { indirimKupon = value; }
        }
        bool kuponVarMı;

        public bool KuponVarMı
        {
            get { return kuponVarMı; }
            set { kuponVarMı = value; }
        }
        Cinsiyet cinsiyet;

        internal Cinsiyet Cinsiyet
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }
        ArrayList siparisList;

        public ArrayList SiparisList
        {
            get { return siparisList; }
            set { siparisList = value; }
        }
        public Uye()
        {
            siparisList = new ArrayList();
        }
        public void IndirimKuponGuncelle() 
        {
            KuponVarMı = IndirimKupon != 0 ? true : false;
        }
    }
}
