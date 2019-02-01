using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductCruds.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Məhsulun adı")]
        [Required(ErrorMessage = "Məhsulun adı boş olmamalıdır"), StringLength(200, ErrorMessage = "Məhsulun adı maksimum 200 ola bilər")]
        public string Name { get; set; }


        [Display(Name = "Marka")]
        [Required]
        public int BrandId { get; set; }

        [Display(Name = "Kateqoriya")]
        [Required]
        public int CategoryId { get; set; }

        [Display(Name = "Şəkil")]
        [Required(ErrorMessage = "Şəkil bölməsi boş olmamalıdır")]
        public string Photo { get; set; }

        [Display(Name = "Qiymət"), Column(TypeName = "money")]
        [Required(ErrorMessage = "Qiymət bölməsi boş olmamalıdır")]
        public int Price { get; set; }

        [Display(Name = "Say")]
        [Required(ErrorMessage = "Say bölməsi boş olmamalıdır")]
        public decimal Count { get; set; }

        [Display(Name = "Haqqında"), Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Haqqında bölməsi boş olmamalıdır"), MinLength(200, ErrorMessage = "Haqqında bölməsi minimum 200 xarakter olmalıdır")]
        public string About { get; set; }

        public Category Category { get; set; }

        public Brand Brand { get; set; }
    }
}