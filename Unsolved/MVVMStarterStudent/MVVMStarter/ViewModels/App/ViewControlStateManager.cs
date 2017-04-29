using System.Collections.Generic;

namespace MVVMStarter.ViewModels.App
{
    public class ViewControlStateManager
    {
        private Dictionary<ViewControlState.ViewState, Dictionary<string, ViewControlState>> _viewControlStateMap;
        private List<string> _controlNames;

        public ViewControlStateManager()
        {
            _controlNames = new List<string>();
            _viewControlStateMap = new Dictionary<ViewControlState.ViewState, Dictionary<string, ViewControlState>>();
            _viewControlStateMap.Add(ViewControlState.ViewState.Create, new Dictionary<string, ViewControlState>());
            _viewControlStateMap.Add(ViewControlState.ViewState.Read, new Dictionary<string, ViewControlState>());
            _viewControlStateMap.Add(ViewControlState.ViewState.Update, new Dictionary<string, ViewControlState>());
            _viewControlStateMap.Add(ViewControlState.ViewState.Delete, new Dictionary<string, ViewControlState>());
        }

        public Dictionary<string, ViewControlState> GetViewControlStates(ViewControlState.ViewState viewState)
        {
            return _viewControlStateMap[viewState];
        }

        /// <summary>
        /// Call this version if the control state 
        /// is valid for all view states
        /// </summary>
        /// <param name="state"></param>
        public void AddViewControlState(ViewControlState state)
        {
            AddViewControlState(ViewControlState.ViewState.Create, state);
            AddViewControlState(ViewControlState.ViewState.Read, state);
            AddViewControlState(ViewControlState.ViewState.Update, state);
            AddViewControlState(ViewControlState.ViewState.Delete, state);
        }

        /// <summary>
        /// Call this version if the property state 
        /// is valid for a specific state
        /// </summary>
        /// <param name="viewState"></param>
        /// <param name="state"></param>
        public void AddViewControlState(ViewControlState.ViewState viewState, ViewControlState state)
        {
            // Add name, if not seen before
            if (!_controlNames.Contains(state.PropertyName))
            {
                _controlNames.Add(state.PropertyName);
            }

            _viewControlStateMap[viewState].Add(state.PropertyName, state);
        }

        public void AddPropertyDefaultStates(ViewControlState.PropertyType propertyType, string propertyName)
        {
            AddViewControlState(ViewControlState.ViewState.Create, new ViewControlState(propertyName, true));
            AddViewControlState(ViewControlState.ViewState.Read, new ViewControlState(propertyName, false));
            AddViewControlState(ViewControlState.ViewState.Delete, new ViewControlState(propertyName, false));

            if (propertyType == ViewControlState.PropertyType.Fixed)
            {
                AddViewControlState(ViewControlState.ViewState.Update, new ViewControlState(propertyName, false));
            }
            if (propertyType == ViewControlState.PropertyType.NonFixed)
            {
                AddViewControlState(ViewControlState.ViewState.Update, new ViewControlState(propertyName, true));
            }
        }

        public void AddPropertyDefaultStatesMultiple(ViewControlState.PropertyType propertyType, List<string> propertyNames)
        {
            foreach (var propertyName in propertyNames)
            {
                AddPropertyDefaultStates(propertyType, propertyName);
            }
        }

        public void AddFixedPropertiesDefaultStates(List<string> propertyNames)
        {
            AddPropertyDefaultStatesMultiple(ViewControlState.PropertyType.Fixed, propertyNames);
        }

        public void AddNonFixedPropertiesDefaultStates(List<string> propertyNames)
        {
            AddPropertyDefaultStatesMultiple(ViewControlState.PropertyType.NonFixed, propertyNames);
        }

        public void AddButtonDefaultStates()
        {
            AddViewControlState(new ViewControlState("Create"));
            AddViewControlState(new ViewControlState("Update"));
            AddViewControlState(new ViewControlState("Delete"));
        }
    }
}
