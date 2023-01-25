using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Character
    {
        [Key]
        public int Id_Character { get; set; }
     
        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Image_Character { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR(50)")]
        public string Name { get; set; }

        public int? Age { get; set; }
                
        public int? Weight { get; set; }
      
        [Column(TypeName = "VARCHAR(500)")]        
        public string? History { get; set; }

        [Required]
        public List<Movie> Movies { get; set;}

    }
}

