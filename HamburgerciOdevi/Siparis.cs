using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciOdevi
{
   

    public class Siparis
    {
        public Siparis()
        {
            EkstraMalzemes = new List<EkstraMalzeme>();
        }
        public Menu SecilenMenu { get; set; }
        public List<EkstraMalzeme> EkstraMalzemes { get; set; }
        public Boyut Boyut { get; set; }
        public int Adet { get; set; }
        public double ToplamTutar { get; set; }

        public void Hesapla()
        {
            ToplamTutar = 0;
            ToplamTutar += SecilenMenu.MenuFiyat;
            //küçük ise hiçbirşey yapma //orta ise 1.1 ile çarp // büyük ise 1.2 le çarp
            switch (Boyut)
            {
              
                case Boyut.Orta:
                    ToplamTutar += ToplamTutar * 0.1;
                    break;
                case Boyut.Büyük:
                    ToplamTutar += ToplamTutar * 0.2;
                    break;
                
            }
            foreach    (var ekstra in EkstraMalzemes)
            {
                ToplamTutar += ekstra.Fiyati;
            }
            ToplamTutar *= Adet;
        }


        //Listboxa seçilen siparişi ekrana düzgün formatta yazmak için ToString metodu override edip metot  gövdesi değiştirildi.Artık aşağıda vermiş olduğumz gibi ekrana basacaktır.
        public override string ToString()
        {
            if (EkstraMalzemes.Count < 1)
                return $"Menu : {SecilenMenu} , Adet : {Adet} , Boy : {Boyut} , Toplam Tutar : {ToplamTutar} ";
            else
            {
                string ekstraMalzemeler = null;
                foreach (EkstraMalzeme ekstra in EkstraMalzemes)
                {
                    ekstraMalzemeler += ekstra.EkstraAdi + ","; 
                }
                ekstraMalzemeler = ekstraMalzemeler.Trim(',');//En son eklenen virgülü temizler.
                return $"Menu : {SecilenMenu} , Adet : {Adet} , Boy : {Boyut} , Toplam Tutar : {ToplamTutar} , Ekstra Malzemeler : {ekstraMalzemeler} ";
            }

        }
    }
}
