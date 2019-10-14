using LibrarySystem.Models.BaseEntity;
using LibrarySystem.Models.Contracts.Racks;

namespace LibrarySystem.Models.Racks
{
    public class RackLocation : BaseIdEntity, IRackLocation // Single Responsibility
    {
        public int Row { get; set; }
        public int Col { get; set; }
    }
}