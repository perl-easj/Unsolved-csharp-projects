using System;
using BioDemo.Data.Base;
using BioDemo.Models.App;

namespace BioDemo.Data.Domain
{
    /// <summary>
    /// Class defining a "show", being defined as a single showing
    /// of a single movie in a single theater, at a specific time.
    /// A Show object will refer to a Movie and a Theater object
    /// through a key value; properties for converting a key value
    /// into an object reference are also included.
    /// </summary>
    public class Show : DomainAppBase
    {
        #region Instance fields
        private int _movieKey;
        private int _theaterKey;
        private DateTime _showDate;
        private TimeSpan _showTime;
        #endregion

        #region Properties
        public Movie MovieForShow
        {
            get { return DomainModel.Instance.Movies.Read(_movieKey); }
        }

        public Theater TheaterForShow
        {
            get { return DomainModel.Instance.Theaters.Read(_theaterKey); }
        }

        public DateTime DateForShow
        {
            get { return _showDate; }
            set { _showDate = value; }
        }

        public TimeSpan TimeForShow
        {
            get { return _showTime; }
            set { _showTime = value; }
        }

        public int MovieKey
        {
            get { return _movieKey; }
            set { _movieKey = value; }
        }

        public int TheaterKey
        {
            get { return _theaterKey; }
            set { _theaterKey = value; }
        }
        #endregion

        #region Methods
        public override void SetDefaultValues()
        {
            _movieKey = NullKey;
            _theaterKey = NullKey;
            _showDate = DateTime.Now;
            _showTime = DateTime.Now.TimeOfDay;
        } 
        #endregion
    }
}