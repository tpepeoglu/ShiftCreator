using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShiftCreator.Core.Entities
{
    public class Person
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        [Required, StringLength(50)]
        public int PersonCode { get; set; }

        [Required,StringLength(50)]
        public string? Name { get; set; }

        [Required, StringLength(50)]
        public string? Surname { get; set; }

        [Required, StringLength(50)]
        public string? PersonUserName { get; set; }

        [Required, StringLength(50)]
        public string? EmailAdress { get; set; }

        [Required, StringLength(20)]
        public string? PhoneNumber { get; set; }

        [Required, StringLength(100)]
        public string? Adress { get; set; }

        [Required, StringLength(50)]
        public string? PersonTitle { get; set; }

        [Required]
        public bool Status { get; set; }
        public bool IsAdmin { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
        [NotMapped]
        public int? TeamLeaderOfTeamId { get; set; }
        [NotMapped]
        public Team TeamLeaderOfTeam { get; set; }
    }
}
