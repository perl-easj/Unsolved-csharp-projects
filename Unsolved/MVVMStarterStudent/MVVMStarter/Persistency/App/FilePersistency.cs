using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using MVVMStarter.Models.Base;
using Newtonsoft.Json;

namespace MVVMStarter.Persistency.App
{
    /// <summary>
    /// This class provides file-based persistency for domain models.
    /// The in-memory collection is serialised from/to a JSON string,
    /// which is read/written to a text file.
    /// </summary>
    /// <typeparam name="TDomainClass"></typeparam>
    public static class FilePersistency<TDomainClass> where TDomainClass : DomainClassBase
    {
        /// <summary>
        /// Save model collection to file.
        /// </summary>
        /// <param name="collection">
        /// Domain object collection to save.
        /// </param>
        /// <param name="fileName">
        /// Data is saved to this text file.
        /// </param>
        public static async void Save(CollectionBase<TDomainClass> collection, string fileName)
        {
            var saveFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
            string modelAsString = JsonConvert.SerializeObject(collection.All);
            await FileIO.WriteTextAsync(saveFile, modelAsString);
        }

        /// <summary>
        /// Read model collection from file. 
        /// The collection is returned by the method.
        /// </summary>
        /// <param name="fileName">
        /// Data is read from this text file.
        /// </param>
        public static async Task<CollectionBase<TDomainClass>> Load(string fileName)
        {
            string modelAsString = await LoadFromFileAsync(fileName);
            CollectionBase<TDomainClass> collection = new CollectionBase<TDomainClass>();
            if (modelAsString != null)
            {
                List<TDomainClass> list = (List<TDomainClass>)JsonConvert.DeserializeObject(modelAsString, typeof(List<TDomainClass>));
                foreach (TDomainClass e in list)
                {
                    collection.Insert(e,false); // Do not overwrite Key
                }
            }
            return collection;
        }

        /// <summary>
        /// Performs the actual read from the specified file.
        /// Note that if no file is found (first attempt to load),
        /// a new file is created.
        /// </summary>
        /// <param name="fileName">
        /// Data is read from this file.
        /// </param>
        /// <returns>
        /// The raw string read from the text file.
        /// </returns>
        private static async Task<string> LoadFromFileAsync(string fileName)
        {
            {
                try
                {
                    StorageFile localFile = await ApplicationData.Current.LocalFolder.GetFileAsync(fileName);
                    return await FileIO.ReadTextAsync(localFile);
                }
                catch (FileNotFoundException)
                {
                    var saveFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists);
                    await FileIO.WriteTextAsync(saveFile, "");
                    return null;
                }
            }
        }
    }
}
