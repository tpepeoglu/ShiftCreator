using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Entities
{
    public class Team
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string TeamName { get; set; }
        public int? TeamLeaderId { get; set; }
        public Person TeamLeader { get; set; }

        // Bir takımın birden fazla personeli olabilir
        public List<Person> People { get; set; } = new List<Person>();

        // Bir takımın birden fazla vardiyası olabilir
        public List<Shift> Shifts { get; set; } = new List<Shift>();
    }
}
