using System;
using MVVMEx05.Data.Domain;
using MVVMEx05.ViewModels.Base;

namespace MVVMEx05.ViewModels.Domain
{
    /// <summary>
    /// Data view model class for studios.
    /// </summary>
    public class StudioDataViewModel : DataViewModelAppBase<Studio>
    {
        #region Constructor
        public StudioDataViewModel(Studio obj) : base(obj)
        {
        } 
        #endregion

        #region Properties for Data Binding
        public string Name
        {
            get { return DataObject.Name; }
            set
            {
                DataObject.Name = value;
                OnPropertyChanged();
            }
        }

        public string HQCity
        {
            get { return DataObject.HQCity; }
            set
            {
                DataObject.HQCity = value;
                OnPropertyChanged();
            }
        }

        public string NoOfEmployees
        {
            get { return DataObject.NoOfEmployees.ToString(); }
            set
            {
                if (int.TryParse(value, out var noOfEmp))
                {
                    DataObject.NoOfEmployees = noOfEmp;
                    OnPropertyChanged();
                }
                else
                {
                    throw new ArgumentException("Illegal value in No. of Employees field");
                }
            }
        }

        public override string HeaderText
        {
            get { return HQCity; }
        }

        public override string ContentText
        {
            get { return $"({NoOfEmployees} emp.)"; }
        }
        #endregion
    }
}