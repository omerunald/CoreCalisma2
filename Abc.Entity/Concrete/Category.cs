using Abc.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Entity.Concrete
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
