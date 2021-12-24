using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EFDataAcessLibrary.Models
{
    public class Orders
    {
        public int Id { get; set; }

        public int ItemsId { get; set; }

        public int UsersId { get; set; }

        [Required]
        [MaxLength(100)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(100)]
        public string ItemName { get; set; }
        [Required]
        public int Qty { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public virtual Users Users { get; set; }

        public virtual Items Items { get; set; }
    }
}
