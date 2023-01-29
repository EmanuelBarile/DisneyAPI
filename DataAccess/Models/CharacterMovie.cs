using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class CharacterMovie
    {
        public int Id_Character { get; set; }
        public int Id_Movie { get; set; }

        [ForeignKey("Id_Character")]
        public Character Character { get; set; }

        [ForeignKey("Id_Movie")]
        public Movie Movie { get; set; }

    }
}
