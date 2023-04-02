using System.ComponentModel.DataAnnotations;

namespace ConcertDB.DAL.Entities
{
    public class Tickets : Entity
    {
        #region Properties
        [Display(Name = "Fecha de uso")]
        public DateTime? UseDate { get; set; }
        [Display(Name = "Fue Usada?")]
        public Boolean IsUsed { get; set; }
        [Display(Name = "Porteria")]
        public String? EntranceGate { get; set; }
        #endregion

        #region Methods
        public List<String> EntranceGateOptions { get; } = new List<String>
        {
            "Norte",
            "Sur",
            "Oriental",
            "Occidental",
        };
        #endregion
    }
}
