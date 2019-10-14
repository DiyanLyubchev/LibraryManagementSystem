using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.Models.BaseEntity
{
    public abstract class BaseIdEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
