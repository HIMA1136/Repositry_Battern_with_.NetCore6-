using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositry_Pattern.core
{
    public  class Author
    {
        public int id { set; get; }
        [Required ,MaxLength(150)]
        public string name { set; get; }

    }
}
