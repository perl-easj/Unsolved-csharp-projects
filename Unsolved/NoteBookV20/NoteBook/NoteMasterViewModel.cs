using System.Collections.ObjectModel;

namespace NoteBook
{
    public class NoteMasterViewModel
    {
        public ObservableCollection<NoteItemViewModel> createItemViewModelCollection(NoteModel model)
        {
            ObservableCollection<NoteItemViewModel> items = new ObservableCollection<NoteItemViewModel>();

            foreach (Note aNote in model.All)
            {
                items.Add(new NoteItemViewModel(aNote));
            }

            return items;
        }
    }
}