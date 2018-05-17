using System;
using System.Collections.ObjectModel;
using BioDemo.Data.Domain;
using BioDemo.Models.App;
using BioDemo.ViewModels.Base;

namespace BioDemo.ViewModels.Data
{
    /// <summary>
    /// Data view model class for Show objects. Mainly provides
    /// properties for single-object Data Binding in the Show view.
    /// This class is a bit more complex, due to the use of combo-boxes
    /// in the Show view, to display lists of movies and theaters.
    /// </summary>
    public class ShowDataViewModel : DataViewModelAppBase<Show>
    {
        #region Instance fields
        private MovieDataViewModel _selectedMovie;
        private TheaterDataViewModel _selectedTheater;

        private ObservableCollection<MovieDataViewModel> _movies;
        private ObservableCollection<TheaterDataViewModel> _theaters;
        #endregion

        #region Constructor
        public ShowDataViewModel(Show obj) : base(obj)
        {
            _movies = GenerateMovieList();
            _theaters = GenerateTheaterList();
            _selectedMovie = FindSelectedMovie(_movies, obj.MovieKey);
            _selectedTheater = FindSelectedTheater(_theaters, obj.TheaterKey);
        }
        #endregion

        #region Properties
        public ObservableCollection<MovieDataViewModel> Movies
        {
            get { return _movies; }
        }

        public ObservableCollection<TheaterDataViewModel> Theaters
        {
            get { return _theaters; }
        }

        public MovieDataViewModel SelectedMovie
        {
            get { return _selectedMovie; }
            set
            {
                if (value != null)
                {
                    _selectedMovie = value;
                    DataObject.MovieKey = _selectedMovie.DataObject.Key;
                }
                OnPropertyChanged();
            }
        }

        public TheaterDataViewModel SelectedTheater
        {
            get { return _selectedTheater; }
            set
            {
                if (value != null)
                {
                    _selectedTheater = value;
                    DataObject.TheaterKey = _selectedTheater.DataObject.Key;
                }
                OnPropertyChanged();
            }
        }

        public DateTimeOffset DateForShow
        {
            get { return DataObject.DateForShow; }
            set
            {
                DataObject.DateForShow = value.Date;
                OnPropertyChanged();
            }
        }

        public TimeSpan TimeForShow
        {
            get { return DataObject.TimeForShow; }
            set
            {
                DataObject.TimeForShow = value;
                OnPropertyChanged();
            }
        }

        public override string HeaderText
        {
            get { return $"{DataObject.MovieForShow?.Title} in {DataObject.TheaterForShow?.Description}"; }
        }

        public override string ContentText
        {
            get { return $"{DateForShow.Date.ToLongDateString()} @ {TimeForShow.Hours:00}:{TimeForShow.Minutes:00}"; }
        }
        #endregion

        #region Methods
        public override string ToString()
        {
            return HeaderText;
        }

        private ObservableCollection<MovieDataViewModel> GenerateMovieList()
        {
            ObservableCollection<MovieDataViewModel> movies = new ObservableCollection<MovieDataViewModel>();

            foreach (var item in DomainModel.Instance.Movies.All)
            {
                movies.Add(new MovieDataViewModel(item));
            }

            return movies;
        }

        private ObservableCollection<TheaterDataViewModel> GenerateTheaterList()
        {
            ObservableCollection<TheaterDataViewModel> theaters = new ObservableCollection<TheaterDataViewModel>();

            foreach (var item in DomainModel.Instance.Theaters.All)
            {
                theaters.Add(new TheaterDataViewModel(item));
            }

            return theaters;
        }

        private MovieDataViewModel FindSelectedMovie(ObservableCollection<MovieDataViewModel> movies, int key)
        {
            foreach (var item in movies)
            {
                if (item.DataObject.Key == key)
                {
                    return item;
                }
            }

            return null;
        }

        private TheaterDataViewModel FindSelectedTheater(ObservableCollection<TheaterDataViewModel> theaters, int key)
        {
            foreach (var item in theaters)
            {
                if (item.DataObject.Key == key)
                {
                    return item;
                }
            }

            return null;
        }
        #endregion
    }
}