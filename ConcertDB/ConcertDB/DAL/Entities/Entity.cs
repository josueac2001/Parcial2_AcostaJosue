using System.ComponentModel.DataAnnotations;

namespace ConcertDB.DAL.Entities
{
    public class Entity
    {
        #region Properties
        [Key] //PRIMARY KEY
        [Required] //NOT NULL
        public Guid Id { get; set; }

        [Display(Name = "Fecha de uso")]
        public DateTime? UseDate { get; set; }
        [Display(Name = "Fue Usada?")]
        public Boolean IsUsed { get; set; }
        [Display(Name = "Porteria")]
        public String EntranceGate { get; set; }
        #endregion
    }
}
