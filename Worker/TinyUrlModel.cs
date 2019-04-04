using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Worker
{
    class TinyUrlModel
    {
        [Key]
        [MaxLength(6)]
        [MinLength(6)]
        public string ShortUrl { get; set; }
        public string LongUrl { get; set; }
    }
}
