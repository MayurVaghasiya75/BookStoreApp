using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.DAL
{
    public class Book
    {
        public int ID { get; set; }

        public string Name { get; set; }
    }
}
