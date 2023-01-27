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
    public class GenreDTO
    {
        [Required]
        [Column(TypeName = "VARCHAR(25)")]
        public string Image_Genre { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public List<MovieDTO> Movies { get; set; }
    }
}
