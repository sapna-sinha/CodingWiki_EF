using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.Fluent_Models
{
    public class Fluent_BookAuthorMap
    {
        //[ForeignKey("Book")]
        public int Book_Id { get; set; }
        //[ForeignKey("Author")]
        public int Author_Id { get; set; }

        public virtual Fluent_Book Book { get; set; }
        public virtual Fluent_Author Author { get; set; }
    }
}
