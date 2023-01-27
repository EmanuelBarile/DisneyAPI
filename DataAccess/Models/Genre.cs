using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Genre
    {
        [Key]     
        public int Id_Genre { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(25)")]
        public string Image_Genre { get; set; }

        [Required]
        public List<Movie> Movies { get; set; }


    }
}
