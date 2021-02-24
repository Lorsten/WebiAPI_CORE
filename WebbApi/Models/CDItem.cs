using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebbApi.Models
{
    public class CDItem
    {
        public int ID { get; set; }

        [Required]
        public string Artist { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }
        [Required]
        public int Length { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
