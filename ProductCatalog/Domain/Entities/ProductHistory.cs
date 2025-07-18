﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductHistory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public string CreatedByUserId { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public TimeSpan Duration { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; } = string.Empty;

        // Navigation
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public bool IsCurrentlyVisible =>
            DateTime.UtcNow >= StartDate && DateTime.UtcNow <= StartDate.Add(Duration);

        public ICollection<ProductHistory> History { get; set; } = new List<ProductHistory>();
    }
}
