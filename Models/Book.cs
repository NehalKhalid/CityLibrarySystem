using CityLibrarySystem.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityLibrarySystem.Models
{
    public class Book : IDisplayable
    {
        public Book(string iSBN, string title, string authorName, string category, int publicationYear)
        {
            ISBN = iSBN;
            Title = title;
            AuthorName = authorName;
            Category = category;
            PublicationYear = publicationYear;
        }
        public Book(string iSBN, string title) : this(iSBN , title ,"Unknown" ,"General" , 0) { }
        
        public string ISBN { get; private set; }
        public string Title { get; private set; }
        public string AuthorName { get; private set; }
        public string Category { get; private set; }
        public int PublicationYear { get; set; }

        public string ToDisplay() => $"[{ISBN}] \"{Title}\" by {AuthorName} ({PublicationYear}) — {Category}";
    }
}
