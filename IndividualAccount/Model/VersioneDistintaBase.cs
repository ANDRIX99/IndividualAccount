using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualAccount.Model
{
    public class VersioneDistintaBase : CommonProperties
    {
        [Key]
        public int Id { get; set; }

        public int IdProduct { get; set; }
        public string Versione { get; set; }

        [ForeignKey("IdProduct")]
        public virtual Item Product { get; set; }
    }
}
