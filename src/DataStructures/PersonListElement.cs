using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class PersonListElement
    {
        // the data
        public Person Person { get; set; }
        
        // link to the next element, or null if this is the last element
        public PersonListElement NextElement { get; set; } = null;
    }
}
