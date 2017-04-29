using Windows.UI.Xaml;

namespace MVVMStarter.ViewModels.App
{
    public class ViewControlState
    {
        public enum ViewState { Create, Read, Update, Delete }
        public enum ControlState { Enabled, Disabled, Collapsed }
        public enum PropertyType { Fixed, NonFixed }

        public const ControlState ListViewStateDefault = ControlState.Enabled;
        public const ControlState PropertyStateDefault = ControlState.Enabled;
        public const ControlState ButtonStateDefault = ControlState.Enabled;

        private string _propertyName;
        private string _description;
        private bool _enabled;
        private Visibility _visibilityState;

        public static bool DefaultEnabled = ControlStateToEnabled(PropertyStateDefault);
        public static Visibility DefaultVisible = ControlStateToVisibility(PropertyStateDefault);

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Enabled
        {
            get { return _enabled; }
            set { _enabled = value; }
        }

        public Visibility VisibilityState
        {
            get { return _visibilityState; }
            set { _visibilityState = value; }
        }

        public string PropertyName
        {
            get { return _propertyName; }
        }

        /// <summary>
        /// Description same as property name, 
        /// use default states
        /// </summary>
        public ViewControlState(string propertyName)
            : this(propertyName, propertyName)
        {
        }

        /// <summary>
        /// Use default states
        /// </summary>
        public ViewControlState(string propertyName, string description)
            : this(propertyName, description, DefaultEnabled, DefaultVisible)
        {
        }

        /// <summary>
        /// Description same as property name, use default visibility
        /// </summary>
        public ViewControlState(string propertyName, bool enabled)
            : this(propertyName, propertyName, enabled, DefaultVisible)
        {
        }

        /// <summary>
        /// Description same as property name
        /// </summary>
        public ViewControlState(string propertyName, bool enabled, Visibility visibilityState)
            : this(propertyName, propertyName, enabled, visibilityState)
        {          
        }

        /// <summary>
        /// Explicit specification of all properties
        /// </summary>
        public ViewControlState(string propertyName, string description, bool enabled, bool visible)
            : this (propertyName, description, enabled, VisibleToVisibility(visible))
        {
        }

        private ViewControlState(string propertyName, string description, bool enabled, Visibility visibilityState)
        {
            _propertyName = propertyName;
            _description = description;
            _enabled = enabled;
            _visibilityState = visibilityState;
        }

        #region Converters
        public static bool ControlStateToEnabled(ControlState controlState)
        {
            return (controlState == ControlState.Enabled);
        }

        public static bool VisibilityToVisible(Visibility visibilityState)
        {
            return (visibilityState == Visibility.Visible);
        }

        public static Visibility VisibleToVisibility(bool visible)
        {
            return (visible ? Visibility.Visible : Visibility.Collapsed);
        }

        public static Visibility ControlStateToVisibility(ControlState controlState)
        {
            if (controlState == ControlState.Collapsed)
            {
                return Visibility.Collapsed;
            }

            return Visibility.Visible;
        } 
        #endregion
    }
}
