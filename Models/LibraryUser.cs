using CityLibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    public abstract class LibraryUser : IDisplayable
    {
        //static protected private int counter = 1;
        protected LibraryUser(string name, string phone)
        {
            Name = name;
            Phone = phone;
        }
        public string Name { get; protected set; } 
        public string Phone { get; protected set; }
        public abstract string ToDisplay();
    }
}
