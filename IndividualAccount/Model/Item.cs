using Microsoft.AspNetCore.Identity;

namespace IndividualAccount.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Traccia chi ha creato, modificato e eliminato l'item
        public string CreatedById { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ModifiedById { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public string DeletedById { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigazione verso gli utenti
        public virtual IdentityUser CreatedBy { get; set; }
        public virtual IdentityUser ModifiedBy { get; set; }
        public virtual IdentityUser DeletedBy { get; set; }
    }
}
