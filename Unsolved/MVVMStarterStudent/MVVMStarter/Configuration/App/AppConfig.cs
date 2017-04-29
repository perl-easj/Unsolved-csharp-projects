namespace MVVMStarter.Configuration.App
{
    /// <summary>
    /// Contains application-wide configuration values
    /// (This could be a suitable point for dependency-injection)
    /// </summary>
    public static class AppConfig
    {
        /// <summary>
        /// Application-wide constants
        /// </summary>
        public const string ImageFilePrefix = "..\\..\\..\\Assets\\Domain\\";
        public const string ImageFilePostfix = ".jpg";

        public delegate void SourceDelegate();
        public static SourceDelegate LoadModels = null;
        public static SourceDelegate SaveModels = null;

        /// <summary>
        /// Sets up all models to be included in Load and Save operations
        /// </summary>
        public static void Setup()
        {
            // Add Load and Save methods for new domain classes here
            //
            // LoadModels += Models.Domain._REPLACEME_.DomainModel.Instance.Load;
            // SaveModels += Models.Domain._REPLACEME_.DomainModel.Instance.Save;
        }

        /// <summary>
        /// Loads all models from persistent storage.
        /// </summary>
        public static void Load()
        {
            LoadModels?.Invoke();
        }

        /// <summary>
        /// Saves all models to persistent storage.
        /// </summary>
        public static void Save()
        {
            SaveModels?.Invoke();
        }
    }
}
