namespace NoteBook
{
    public class NoteItemViewModel
    {
        public Note DomainObject;

        public NoteItemViewModel(Note obj)
        {
            DomainObject = obj;
        }

        public string Description
        {
            get { return DomainObject.Title; }
        }
    }
}