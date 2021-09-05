using System;
using System.Collections.Generic;
using System.Text;

namespace AppMailMVVM.Models
{
    public class mail
    {
        public mail(string title, string description, string from, string photoPath)
        {
            Title = title;
            Description = description;
            From = from;
            PhotoPath = photoPath;
        }

        public mail(string title, string description, string from, string to, string image)
        {
            Title = title;
            Description = description;
            From = from;
            To = to;
            date = DateTime.Now;
            Image = image;
        }

        public string Title { get; set; }
        public string Description {get; set;}
        public string From { get; set; }
        public string To { get; set; }
        public DateTime date { get; set; }
        public string Image { get; set; }
        public string PhotoPath { get; }
    }
}
