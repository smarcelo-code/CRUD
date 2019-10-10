using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoCrudeFInalAPI;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


    namespace ProjetoCrudeFInalAPI.Models
{
    public class Inventarios
    {
        [Key]
        [Display(Name ="Inventario")]
        public long InventarioId { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Itens> Itens { get; set; }
        
    }
}