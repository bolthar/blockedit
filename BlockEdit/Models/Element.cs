using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BlockEdit.Models
{
    public class Element
    {
        public int Id { get; private set; }

        public string Text { get; private set; }

        private Element(int id, string text)
        {
            Id = id;
            Text = text;
        }

        public static Element FromJson(int id, string json)
        {
            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            return new Element(id, data["Text"]);
        }
    }
}