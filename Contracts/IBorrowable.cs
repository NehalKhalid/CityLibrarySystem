using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Contracts
{
    public interface IBorrowable
    {
        void Borrow();
        decimal Return();
        bool IsAvaiable();
    }
}
