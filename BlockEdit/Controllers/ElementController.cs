using System.Collections.Generic;
using System.Web.Http;
using BlockEdit.Models;
using BlockEdit.Services;

namespace BlockEdit.Controllers
{
    [RoutePrefix("api/note/{noteId}/elements")]
    public class ElementController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Element> Get(int noteId)
        {
            var note = new NoteRepository().Get(noteId);
            return note.GetElements();
        }

        [HttpPost]
        [Route("")]
        public Element Post(int noteId, [FromBody]string json)
        {
            var note = new NoteRepository().Get(noteId);
            var element = new ElementRepository(note).Create(json);
            note.SetElement(element);
            return element;
        }
        
        [HttpPost]
        [Route("{elementId}")]
        public IEnumerable<Element> Put(int noteId, int elementId, [FromBody]string json)
        {
            var note = new NoteRepository().Get(noteId);
            new ElementRepository(note).Save(new ElementFactory(elementId).Create(json));
            return note.GetElements();
        }
    }
}
