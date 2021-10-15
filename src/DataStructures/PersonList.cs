using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class PersonList
    {
        private PersonListElement _firstElement = null;

        public bool IsEmpty()
        {
            return _firstElement == null;
        }

        public int Count()
        {
            PersonListElement currentElement = _firstElement;
            var count = 0;

            while (currentElement != null)
            {
                currentElement = currentElement.NextElement;
                count++;
            }

            return count;
        }

        public PersonListElement Add(Person person)
        {
            var addedElement = new PersonListElement()
            {
                Person = person,
                NextElement = null
            };

            // first?
            if (_firstElement == null)
            {
                _firstElement = addedElement;
            }
            else
            {
                var nextElement = _firstElement;
                while (nextElement.NextElement != null)
                {
                    nextElement = nextElement.NextElement;
                }
                nextElement.NextElement = addedElement;
            }
            
            return addedElement;
        }

        public PersonListElement GetAt(int index)
        {
            var count = Count();
            if (index < 0 || index >= count)
            {
                return null;
            }

            var elementIndex = 0;
            var element = _firstElement;
            while (elementIndex != index)
            {
                element = element.NextElement;
                elementIndex++;
            }

            return element;
        }

        public PersonListElement InsertAt(int index, Person person)
        {
            var count = Count();
            if (index < 0 || index >= count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Invalid index: {index}");
            }

            var insertElement = new PersonListElement()
            {
                Person = person,
                NextElement = null
            };
            
            if (index == 0)
            {
                insertElement.NextElement = _firstElement;
                _firstElement = insertElement;
            }
            else
            {
                var elementIndex = 0;
                var nextElement = _firstElement;
                PersonListElement previousElement = null;
                while (elementIndex != index)
                {
                    previousElement = nextElement;
                    nextElement = nextElement.NextElement;
                    elementIndex++;
                }
                if(previousElement != null)
                {
                    previousElement.NextElement = insertElement;
                }
                insertElement.NextElement = nextElement;
            }

            return insertElement;
        }

    }
}
