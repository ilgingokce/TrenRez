using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TrenRez.Models;

namespace TrenRez.Controllers
{
    public class VagonController : ApiController
    {
        

        //public List<Tren> GetTrenList()
        //{
        //    List<Vagon> vagonlarModel = new List<Vagon>
        //    {
        //        new Vagon {Id=1, Ad= "Dogu Vagon 1", Kapasite=100, DoluKoltukAdet=50},
        //        new Vagon {Id=2, Ad= "Dogu Vagon 2", Kapasite=90, DoluKoltukAdet=80},
        //        new Vagon {Id=3, Ad= "Dogu Vagon 3", Kapasite=80, DoluKoltukAdet=80},
        //    };
        //    List<Vagon> vagonlarModel2 = new List<Vagon>
        //    {
        //        new Vagon {Id=4, Ad= "Baskent Vagon 1", Kapasite=100, DoluKoltukAdet=75},
        //        new Vagon {Id=5, Ad= "Baskent Vagon 2", Kapasite=90, DoluKoltukAdet=85},
        //        new Vagon {Id=6, Ad= "Baskent Vagon 3", Kapasite=80, DoluKoltukAdet=60},
        //    };

        //    List<Tren> trenModel = new List<Tren> {
        //     new Tren { Id=1, Ad= "Dogu Ekspress", Vagonlar=vagonlarModel.ToList()},
        //     new Tren { Id=2, Ad= "Baskent Ekspress", Vagonlar=vagonlarModel2.ToList()},
        //     };
        //    return trenModel.ToList();
        //}

        public RezervasyonSonucu GetSonuc()
        {
            List<Vagon> vagonlarModel = new List<Vagon>
            {
                new Vagon {Id=1, Ad= "Dogu Vagon 1", Kapasite=100, DoluKoltukAdet=68},
                new Vagon {Id=2, Ad= "Dogu Vagon 2", Kapasite=90, DoluKoltukAdet=80},
                new Vagon {Id=3, Ad= "Dogu Vagon 3", Kapasite=80, DoluKoltukAdet=20},
            };
            var tren = new Tren
            {
                Ad = "Dogu Ekspress",
                Vagonlar = vagonlarModel.ToList(),
            };
           return RezervasyonYap(tren,3,false);
        }
        
        public RezervasyonSonucu RezervasyonYap(Tren model,int rezervasyonyapilacakkisiSayisi,bool farklivagonlaraYerlestirilsinMi)
        {
            var oran = 0;
            RezervasyonSonucu resultModel = new RezervasyonSonucu();
            List<YerlesimAyrinti> asd = new List<YerlesimAyrinti>();
            int toplamSayi = 0;
            foreach (var item in model.Vagonlar)
            {
                oran = item.Kapasite * 70 / 100;
                if ( oran>= item.DoluKoltukAdet)
                {
                    if(!farklivagonlaraYerlestirilsinMi && oran - item.DoluKoltukAdet >= rezervasyonyapilacakkisiSayisi)
                    {
                        if (toplamSayi == rezervasyonyapilacakkisiSayisi)
                            break;
                        else
                        {
                            resultModel.RezervasyonYapilabilir = true;
                            asd.Add(new YerlesimAyrinti
                            {
                                VagonAdi = item.Ad,
                                KisiSayisi = rezervasyonyapilacakkisiSayisi
                            });
                            resultModel.YerlesimAyrinti = asd;
                            toplamSayi++;
                        }
                        
                    }
                }
            }
            return resultModel;
        }
    }

    public class RezervasyonSonucu
    {
        public bool RezervasyonYapilabilir { get; set; }
        public List<YerlesimAyrinti> YerlesimAyrinti { get; set; }
    }
    public class YerlesimAyrinti
    {
        public string VagonAdi { get; set; }
        public int KisiSayisi { get; set; }
    }
}
