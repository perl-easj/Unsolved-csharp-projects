namespace NoteBook
{
    public class Note
    {
        private string _title;
        private string _content;

        public static string DefaultTitle = "New Note";
        public static string DefaultContent = "Type your content here";


        public Note(string title, string content)
        {
            _title = title;
            _content = content;
        }

        public Note()
        {
            _title = DefaultTitle;
            _content = DefaultContent;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
