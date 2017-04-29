using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MVVMStarter.ViewModels.App
{
    public class PropertyDependencyManager
    {
        private Dictionary<string, List<string>> _dependencyMap;

        public PropertyDependencyManager()
        {
            _dependencyMap = new Dictionary<string, List<string>>();
        }

        public void AddDependency(string property, string dependentProperty)
        {
            if (!_dependencyMap.ContainsKey(property))
            {
                _dependencyMap.Add(property, new List<string>());
            }

            _dependencyMap[property].Add(dependentProperty);
        }

        public List<string> Dependencies([CallerMemberName] string property = null)
        {
            return (_dependencyMap.ContainsKey(property) ? _dependencyMap[property] : new List<string>());
        }
    }
}
