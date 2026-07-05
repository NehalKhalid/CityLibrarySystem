using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    public class Librarian : LibraryUser
    {
        public Librarian(string librarianId, string name , decimal salary, string phone , DateOnly hireDate) : base(name , phone)
        {
            LibrarianId = librarianId;
            Salary = salary;
            HireDate = hireDate;
        }
        public string LibrarianId { get; private set; }
        public decimal Salary { get; private set; }
        public DateOnly HireDate { get; private set; }

        public override string ToDisplay()
            => $@"ID      : {LibrarianId}
Name    : {Name}
Phone   : {Phone}
Salary  : {Salary:C}
Hired   : {HireDate:dd/MM/yyyy}";
    }
}
