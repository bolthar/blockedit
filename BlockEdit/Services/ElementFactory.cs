using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlockEdit.Models;

namespace BlockEdit.Services
{
    public class ElementFactory
    {
        private readonly int _elementId;

        public ElementFactory(int elementId)
        {
            _elementId = elementId;
        }

        public Element Create(string json)
        {
            return Element.FromJson(_elementId, json);
        }
    }
}