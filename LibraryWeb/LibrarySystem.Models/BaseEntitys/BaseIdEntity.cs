using System.ComponentModel.DataAnnotations;

namespace LibrarySystem.BaseEntitys
{
    public abstract class BaseIdEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
