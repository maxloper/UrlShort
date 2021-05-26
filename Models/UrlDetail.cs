using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShort.Models
{
    public class UrlDetail
    {
        // url model for DBContext and database

        public int Id { get; set; }

        public string LongUrl { get; set; }

        public string ShortUrl { get; set; }


    }
}
