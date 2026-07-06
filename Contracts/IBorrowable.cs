using CityLibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Contracts
{
    public interface IBorrowable
    {
        void Borrow(Member member , int loanDays = 14);
        decimal Return();
        bool IsAvailable();
    }
}
