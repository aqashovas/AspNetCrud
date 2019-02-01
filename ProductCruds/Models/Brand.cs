using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCruds.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad bölməsi boş olmamalıdır")]
        [StringLength(50)]
        public string Name { get; set; }

        public List<Product> Products { get; set; }
    }
}