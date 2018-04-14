using AdapterExample.Implementations;
using AdapterExample.Interfaces;

namespace AdapterExample.ConfigAndTest
{
    public class Configurator
    {
        public static IIndexedCollection<T> Configure<T>(IArrayCollection<T> iac)
        {
            return new AdapterICAC<T>(iac);
        }
    }
}