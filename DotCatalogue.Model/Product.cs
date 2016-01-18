using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCatalogue.Model
{
    public class Product
    {
        /// <summary>
        /// Product id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product's category id
        /// </summary>
        public int CategoryId { get; set; }

        /// <summary>
        /// Product's Category
        /// </summary>
        public Category Category { get; set; }
    }
}
