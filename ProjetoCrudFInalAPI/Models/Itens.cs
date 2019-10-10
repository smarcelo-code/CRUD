using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoCrudeFInalAPI;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoCrudeFInalAPI.Models
{
    public class Itens
    {
        [Display(Name = "Itens")]
        public long? ItensId { get; set; }
        public string Nome { get; set; }
        [Display(Name = "Inventario")]
        public long? InventarioId { get; set; }
        public long? PersonagensId { get; set; }

        public Personagens Personagens { get; set; }
        public Inventarios Inventario { get; set; }
    }
}