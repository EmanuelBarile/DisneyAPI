using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Movie
    {
        [Key]
        public int Id_Movie { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Image_Movie { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Title { get; set; }

        [Required]
        [Column(TypeName = "DATE")]
        public DateTime Creation_Date { get; set; }

        [Required]
        public int Rating { get; set; }

        [Required]
        public List<Character> Characters { get; set;}

        [ForeignKey("Genre")]
        [Required]
        public int Genre_Id { get; set; }

        public Genre Genre { get; set; }

    }
}




