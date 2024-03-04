using System.ComponentModel.DataAnnotations;

namespace ValhallaVaultCyberAwareness.Data.Models
{
    //En vanlig modell som gör absolut ingenting.
    public class DefaultModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
    }
}
