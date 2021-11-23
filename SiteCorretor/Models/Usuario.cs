using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiteCorretor.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Nescessário informar o Login.")]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required(ErrorMessage = "Nescessário informar a senha")]
        [DataType(DataType.Password)]
        [MaxLength(60)]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Nescessário informar o nome")]
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}
