using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int Value { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Imagem")]
        public string Image { get; set; }

        [Display(Name = "Instagram Url")]
        public string InstagramUrl { get; set; }

        [Required]
        [Display(Name = "Slug")]
        [MaxLength(20, ErrorMessage = "Slug muito grande")]
        public string Slug { get; set; }

        public virtual IEnumerable<VisitResidencia> VisitResidencias { get; set; }

    }
}
