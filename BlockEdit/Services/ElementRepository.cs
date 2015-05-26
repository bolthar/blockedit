using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlockEdit.Models;

namespace BlockEdit.Services
{
    public class ElementRepository
    {
        private readonly Note _note;

        public ElementRepository(Note note)
        {
            _note = note;
        }

        public Element Create(string json)
        {
            var newElement = new ElementFactory(_note.GetNewElementId()).Create(json);
            return newElement;
        }

        public Element Get(int elementId)
        {
            return _note.GetElements().FirstOrDefault(x => x.Id == elementId);
        }

        public Element Save(Element element)
        {
            _note.SetElement(element);
            return element;
        }
    }
}