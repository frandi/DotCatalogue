using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotCatalogue.Model
{
    public class Category
    {
        /// <summary>
        /// Category Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Parent category id
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// Parent category
        /// </summary>
        public Category Parent { get; set; }
    }
}
