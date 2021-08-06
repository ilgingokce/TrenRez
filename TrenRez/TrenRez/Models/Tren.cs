using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrenRez.Models
{
    public class Tren
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public List<Vagon> Vagonlar { get; set; }
    }
}