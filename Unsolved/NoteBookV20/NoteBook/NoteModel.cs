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
            _notes.Add(aNote.Title, aNote);
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

        public void UpdateTitle(string oldTitle, string newTitle)
        {
            // The title is updated by:
            // 1) Deleting the note with the existing title
            // 2) Adding a new note with the new title AND the existing content
            Note aNote = Read(oldTitle);
            if (aNote != null)
            {
                string content = aNote.Content;
                Delete(oldTitle);
                Add(new Note(newTitle, content));
            }
        }
    }
}
