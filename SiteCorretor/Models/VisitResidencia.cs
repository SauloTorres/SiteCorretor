using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCorretor.Models
{
    public class VisitResidencia
    {
        [Key]
        public int ID { get; set; }

        public int ResidenciaId { get; set; }

        public DateTime Data { get; set; }

        public virtual Residencia Residencia { get; set; }
    }
}
