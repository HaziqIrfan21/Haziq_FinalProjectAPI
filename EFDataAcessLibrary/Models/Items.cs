using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EFDataAcessLibrary.Models
{
    public class Items
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string ItemCategory { get; set; }

        [MaxLength(100)]
        public string ItemName { get; set; }

        [MaxLength(255)]
        public string ItemDescription { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ItemPrice { get; set; }


    }
}
