using System.ComponentModel.DataAnnotations;


namespace LaMiaPizzeria.Models
{
    [Key]
    public class menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ingredienti { get; set; }

        public string immagine { get; set; }

        public float prezzo { get; set; }


        public menu
    }
}
