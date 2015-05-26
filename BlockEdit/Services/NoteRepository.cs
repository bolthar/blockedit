using BlockEdit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlockEdit.Services
{
    public class NoteRepository
    {
        private static ICollection<Note> _storage = new List<Note>();

        public Note Create(string name)
        {
            var id = (_storage.Any() ? _storage.Max(x => x.Id) : 0) + 1;
            var note = new Note(id, name);
            _storage.Add(note);
            return note;
        }

        public Note Get(int id)
        {
            return _storage.First(x => x.Id == id);
        }
    }
}