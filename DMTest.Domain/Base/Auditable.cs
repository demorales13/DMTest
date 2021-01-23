using System;
using System.ComponentModel.DataAnnotations;

namespace DMTest.Domain.Base
{
    public class Auditable
    {
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
