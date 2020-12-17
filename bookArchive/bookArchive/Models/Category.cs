using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace bookArchive.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Column(TypeName = "Varchar(20)")]
        public string categoryName { get; set; }
    }
}
