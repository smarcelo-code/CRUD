using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoCrudeFInalAPI;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCrudeFInalAPI.Models
{
    public class Personagens
    {
        [Display(Name = "Personages")]
        public long PersonagensId { get; set; }
        public string Nome { get; set; }

       public virtual ICollection<Itens> Itens { get; set; }
    }
}