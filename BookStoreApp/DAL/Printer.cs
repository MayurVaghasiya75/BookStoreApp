using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.DAL
{
    public class Printer
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }
    }
}
