using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaleApi.Models
{
    public class Localization
    {
        public int Id { get; set; }
        public int Platform { get; set; }
        public string Key { get; set; }
        public string En_us { get; set; }
        public string Es_mx { get; set; }
    }
}
