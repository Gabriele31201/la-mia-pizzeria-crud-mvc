using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaMiaPizzeria.Models
{
    
    public class PizzaModel
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Column(TypeName = "text")]
        public string Description { get; set; }
        
        [MaxLength(300)]
        public string Immagine { get; set; }


        public float Prezzo { get; set; }


        public PizzaModel(string name, string description, string immagine, float prezzo)
        {
            Name = name;

            Description = description;

            Immagine = immagine;

            Prezzo = prezzo;
        }
    }
}
