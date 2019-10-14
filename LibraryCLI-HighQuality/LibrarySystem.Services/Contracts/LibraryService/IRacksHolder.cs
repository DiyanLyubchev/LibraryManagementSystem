using System.Collections.Generic;

namespace LibrarySystem
{
    public interface IRacksHolder
    {
        IList<IRack> Racks { get; }

        void FillRacks();
    }

}
