using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Books
    {
        public string Tittle { get ; set ; }
        public string Author { get ; set ; }
        public int ISBN { get ; set ; }
        public int Copynum { get ; set; }

        public Books(string title, string author, int isbn)
        {
            Tittle = title;
            Author = author;
            ISBN = isbn;
        }

        public Books(string title, string author, int isbn, int copy)
        {
            Tittle = title;
            Author = author;
            ISBN = isbn;
            Copynum= copy;
        }

    }
}
