using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.DTO
{
    public class MovieDTO
    {
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

 
        [ForeignKey("Genre")]
        [Required]
        public int Genre_Id { get; set; }

        [Required]
        public List<CharacterDTO> Characters { get; set; }


    }
}
