using System.ComponentModel.DataAnnotations;

namespace ConcertDB.DAL.Entities
{
    public class Entity
    {
        #region Properties
        [Key] //PRIMARY KEY
        [Required] //NOT NULL
        public Guid Id { get; set; }
        #endregion
    }
}
