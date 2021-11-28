﻿using Abc.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Entity.Concrete
{
    public class Product :IEntity
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }
    }
}
