using BlockEdit.Models;
using BlockEdit.Services;
using System.Web.Http;

namespace BlockEdit.Controllers
{
    public class NoteController : ApiController
    {
        public Note Post([FromBody]string name)
        {
            var newNote = new NoteRepository().Create(name);
            return newNote;
        }
    }
}
