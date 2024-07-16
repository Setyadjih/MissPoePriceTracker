using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MissPoeAnalysis.Core.Models
{
    public class Item
    {
        [Key]
        public string Name { get; set; } = null!;

        public string Vendor { get; set; } = null!;

        [Column(TypeName = "decimal(6,2)")]
        public decimal Price { get; set; }

        public DateOnly Date { get; set; }
    }
}
