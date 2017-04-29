using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteBook
{
    public class NoteSource
    {
        private FilePersistency<Note> _fileSource;

        public NoteSource()
        {
            _fileSource = new FilePersistency<Note>();
        }

        public async Task Load(NoteModel model)
        {
            model.Clear();
            List<Note> noteList = await _fileSource.Load();
            noteList.ForEach(model.Add);
        }

        public async Task Save(NoteModel model)
        {
            await _fileSource.Save(model.All);
        }
    }
}