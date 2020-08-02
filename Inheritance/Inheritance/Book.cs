using System;

namespace Inheritance
{
    public sealed class Book : Publication
    {
        public Book(string title, string author, string publisher) :
        this(title, String.Empty, author, publisher)
        { }

        public Book(string title, string isbn, string author, string publisher) : base(title, publisher, PublicationType.Book)
        {
            // isbn argument must be a 10- or 13-character numeric string without "-" characters.
            // We could also determine whether the ISBN is valid by comparing its checksum digit
            // with a computed checksum.
            //
            if (!String.IsNullOrEmpty(isbn))
            {
                // Determine if ISBN length is correct.
                if (!(isbn.Length == 10 | isbn.Length == 13))
                    throw new ArgumentException("The ISBN must be a 10- or 13-character numeric string.");
                ulong nISBN = 0;
                if (!UInt64.TryParse(isbn, out nISBN))
                    throw new ArgumentException("The ISBN can consist of numeric characters only.");
            }
            ISBN = isbn;

            Author = author;
        }

        public string ISBN { get; }

        public string Author { get; }

        public decimal Price { get; private set; }

        // A three-digit ISO currency symbol.
        public string Currency { get; private set; }

        // Returns the old price, and sets a new price.
        public Decimal SetPrice(Decimal price, string currency)
        {
            if (price < 0)
                throw new ArgumentOutOfRangeException("The price cannot be negative.");
            Decimal oldValue = Price;
            Price = price;

            if (currency.Length != 3)
                throw new ArgumentException("The ISO currency symbol is a 3-character string.");
            Currency = currency;

            return oldValue;
        }

        public override bool Equals(object obj)
        {
            Book book = obj as Book;
            if (book==null)
            {
                return false;
            }
            else
            {
                return ISBN == book.ISBN;
            }
        }

        public override int GetHashCode()
        {
            return ISBN.GetHashCode();
        }

        public override string ToString()
        {
            return $"{(string.IsNullOrEmpty(Author) ? "" : Author + ", ")}{Title}";
        }
    }

    //public class Automobile
    //{
    //    public Automobile(string make, string model, int year)
    //    {
    //        if (make == null)
    //            throw new ArgumentNullException("The make cannot be null.");
    //        else if (String.IsNullOrWhiteSpace(make))
    //            throw new ArgumentException("make cannot be an empty string or have space characters only.");
    //        Make = make;
    //        if (model == null)
    //            throw new ArgumentNullException("The model cannot be null.");
    //        else if (String.IsNullOrWhiteSpace(model))
    //            throw new ArgumentException("model cannot be an empty string or have space characters only.");
    //        Model = model;

    //        if (year < 1857 || year > DateTime.Now.Year + 2)
    //            throw new ArgumentException("The year is out of range.");
    //        Year = year;
    //    }

    //    public string Make { get; }
    //    public string Model { get; }
    //    public int Year { get; }

    //    public override string ToString()
    //    {
    //        return $"{Year} {Make} {Model}";
    //    }
    //}

    //public class SimpleClass
    //{

    //}

}