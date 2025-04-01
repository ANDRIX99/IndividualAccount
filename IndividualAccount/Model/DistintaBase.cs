using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndividualAccount.Model
{
    public class DistintaBase : CommonProperties
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdVersione { get; set; }

        [Required]
        public int IdFiglio { get; set; }

        public int Quantita { get; set; }

        [ForeignKey("IdVersione")]
        public virtual VersioneDistintaBase Versione { get; set; }

        [ForeignKey("IdFiglio")]
        public virtual Item Figlio { get; set; }
    }
}
