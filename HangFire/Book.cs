﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HangFire
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string Price { get; set; }
    }

    public class BookPurchaseVM : Book
    {
        public string Nonce { get; set; }
    }
}
