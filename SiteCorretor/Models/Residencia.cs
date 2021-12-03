using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCorretor.Models
{
    public class Residencia
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Título")]
        public string Title { get; set; }

        [Display(Name = "Valor")]
        [Required]
        public decimal Value { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Imagem")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "Slug")]
        [MaxLength(10, ErrorMessage = "Slug muito grande")]
        public string Slug { get; set; }

        public virtual IEnumerable<VisitResidencia> VisitResidencias { get; set; }
    }
}
