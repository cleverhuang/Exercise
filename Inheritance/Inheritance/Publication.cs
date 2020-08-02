using System;

namespace Inheritance
{
    public abstract class Publication
    {
        private bool published = false;
        private DateTime datePublished;
        private int totalPages;
        public Publication(string title, string publisher, PublicationType type)
        {
            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentException("The publisher is required.");
            }

            Publisher = publisher;

            if (String.IsNullOrWhiteSpace(title))
                throw new ArgumentException("The title is required.");
            Title = title;

            Type = type;
        }

        public string Publisher { get; }

        public string Title { get; }

        public PublicationType Type { get; }

        public string CopyrightName { get; private set; }

        public int CopyrightDate { get; private set; }

        public int Pages
        {
            get { return totalPages; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("The number of pages cannot be zero or negative.");
                }

                totalPages = value;
            }
        }

        public string GetPublicationDate()
        {
            if (!published)
            {
                return "NYP";
            }
            else
            {
                return datePublished.ToString("d");
            }
        }

        public void Publish(DateTime datePublished)
        {
            published = true;
            this.datePublished = datePublished;
        }

        public void Copyright(string copyrightName, int copyrightDate)
        {
            if (String.IsNullOrWhiteSpace(copyrightName))
                throw new ArgumentException("The name of the copyright holder is required.");
            CopyrightName = copyrightName;
            int currentYear = DateTime.Now.Year;
            if (copyrightDate < currentYear - 10 || copyrightDate > currentYear + 2)
                throw new ArgumentOutOfRangeException($"The copyright year must be between {currentYear - 10} and {currentYear + 1}");
            CopyrightDate = copyrightDate;
        }

        public override string ToString()
        {
            return Title;
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