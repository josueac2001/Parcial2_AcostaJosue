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
        public List<string> EntranceGateOptions { get; } = new List<string>
        {
            "Norte",
            "Sur",
            "Oriental",
            "Occidental",
        };
        #endregion
    }
}
