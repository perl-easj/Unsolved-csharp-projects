using System.Collections.Generic;
using System.Linq;

namespace NoteBook
{
    public class NoteModel
    {
        private Dictionary<string, Note> _notes;

        public NoteModel()
        {
            _notes = new Dictionary<string, Note>();
        }

        public List<Note> All
        {
            get { return _notes.Values.ToList(); }
        }

        public void Add(Note aNote)
        {
            if (!_notes.ContainsKey(aNote.Title))
            {
                _notes.Add(aNote.Title, aNote);
            }
        }

        public void Delete(string title)
        {
            _notes.Remove(title);
        }

        public Note Read(string title)
        {
            return _notes.ContainsKey(title) ? _notes[title] : null;
        }

        public void Clear()
        {
            _notes.Clear();
        }

        public bool ContainsTitle(string title)
        {
            return _notes.ContainsKey(title);
        }
    }
}
