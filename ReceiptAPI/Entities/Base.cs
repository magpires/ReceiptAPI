﻿using System;

namespace ReceiptAPI.Entities
{
    public class Base
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
