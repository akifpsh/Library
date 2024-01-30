using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    internal class Lib 
    {
        List<Books> bookList = new List<Books>();

        int choosen;
   
        public void Switch()
        {
            Console.WriteLine();
            Console.WriteLine("Ne yapmak istersiniz ?" + '\n' + "1-Kitap ekle" + '\n' + "2-Kitapları listele" + '\n' + "3-Kitap ara "
                + '\n' + "4-Kitap odunc al" + '\n' + "5-Kitap iade et" + '\n' + "6-Cikis");
            try
            {
                choosen = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Hatali giris yapildi");
                Switch();
            }

            switch (choosen)
            {
                case 1:
                    Add();
                    break;
                case 2:
                    List();
                    break;
                case 3:
                    Search();
                    break;
                case 4:
                    Borrow();
                    break;
                case 5:
                    GiveBack();
                    break;
                case 6:
                    break;
            }
        }

        private void Add()
        {
            Console.WriteLine("Kitap Basligi : ");
            string tittle = Console.ReadLine();
            Console.WriteLine("Kitap Yazari : ");
            string author = Console.ReadLine();
            Console.WriteLine("Kitap ISBN : ");
            int isbn =Convert.ToInt32( Console.ReadLine());
            bookList.Add(new Books(tittle, author, isbn));
            Copy(tittle, author, isbn);
            Console.WriteLine("Kitap basariyla eklendi");
            Switch();
        }

        private void Copy(string title, string author, int isbn)
        {
            foreach (var book in bookList)
            {
                if (title.Equals(book.Tittle) && author.Equals(book.Author) && isbn.Equals(book.ISBN))
                {
                    book.Copynum++;
                    Console.WriteLine("mevcut kita kopya sayısı :" +book.Copynum);
                    break;
                }
                else
                    Console.WriteLine("Kitap bulunamadı ");
            }
        }

        private void List()
        {
            Console.Clear();
            Console.WriteLine("         Mevcut kitaplar         ");
            foreach (var book in bookList)
            {
              if(book.Copynum!=0)
                Console.WriteLine($"Title: {book.Tittle}, Author: {book.Author}, ISBN: {book.ISBN},Copy: {book.Copynum}");
            }
            Switch();
        }

        private void Search()
        {
            Console.Clear();

            Console.WriteLine("Aranacak bilgiyi giriniz :");
            var info=Console.ReadLine();
            Console.WriteLine("         Aranan Kitaplar         ");

            foreach (var book in bookList)
            {
                if (info.Equals(book.Author) || info.Equals(book.Tittle))
                    if (book.Copynum != 0)
                        Console.WriteLine($"Title: {book.Tittle}, Author: {book.Author}, ISBN: {book.ISBN},Copy: {book.Copynum}");
                else
                    Console.WriteLine("Kitap bulunamadı ");
            }
            Switch();
        }

        private void Borrow()
        {
            Console.Clear();

            Console.WriteLine("Hangi kitabi almak istersiniz :");
            var remove = Console.ReadLine();

            foreach (var book in bookList.ToList())
            {
                if (remove.Equals(book.Tittle))
                {
                    book.Copynum--;
                    Console.WriteLine("Kitap odunc verildi");
                    break;
                }
            }
            Switch();
        }

        private void GiveBack()
        {
            Console.Clear();

            Console.WriteLine("Hangi kitabi iade etmek istersiniz :");
            Add();
        }
        
    }
}
