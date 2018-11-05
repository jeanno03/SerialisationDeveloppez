using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationDeveloppez.Models
{
    [Flags]
    public enum AddressType
    {
        None = 0,
        Ship = 1,
        Bill = 2
    }
}
