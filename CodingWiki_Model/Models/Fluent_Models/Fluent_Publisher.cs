﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.Fluent_Models
{
    public class Fluent_Publisher
    {
        //[Key]
        public int Publisher_Id { get; set; }
       // [Required]
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual List<Fluent_Book> Books { get; set; }
    }
}
