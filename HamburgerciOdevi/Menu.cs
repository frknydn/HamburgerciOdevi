using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerciOdevi
{
    public class Menu
    {
        public string MenuAd { get; set; }
        public double MenuFiyat { get; set; }

        //Tostring metodunu ezdiğim için artık bana nesnemi oluşturup ekrana bastığım zaman HamburgerciÖdebi.Menu gibi bir ifade çıkartmayacak.
        public override string ToString()
        {
            return $"Menu : {MenuAd} , Fiyat : {MenuFiyat}";
        }
    }
}
