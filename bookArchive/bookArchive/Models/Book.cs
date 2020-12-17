using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookArchive.Models
{
    public class Book
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string bookName { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string author { get; set; }
        [Column(TypeName = "Varchar(500)")]
        public string description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
