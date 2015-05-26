using System.Collections.Generic;
using System.Linq;

namespace BlockEdit.Models
{
    public class Note
    {

        public int Id { get; private set; }

        public string Name { get; private set; }

        private ICollection<Element> _elements = new List<Element>();

        public Note(int id, string name)
        {
            Id = id;
            Name = name;
        }
        
        public void SetElement(Element element)
        {
            _elements.Remove(_elements.FirstOrDefault(x => x.Id == element.Id));
            _elements.Add(element);
            // hack
            _elements = _elements.OrderBy(x => x.Id).ToList();
        }

        public ICollection<Element> GetElements()
        {
            return _elements;
        }

        public int GetNewElementId()
        {
            var lastElement = GetElements().OrderBy(x => x.Id).LastOrDefault();
            return (lastElement != null ? lastElement.Id : 0) + 1;
        }
    }
}