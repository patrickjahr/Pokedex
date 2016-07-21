using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Storage;
using PokeDex.Core.Services;

namespace PokeDex.UWP.Utils
{
    public class WinRTStorageFile : IPortableStorageFile
    {
        public string Path => _baseFile.Path;

        public string Name => _baseFile.Name;

        private readonly IStorageFile _baseFile;
        public object BaseFile { get { return _baseFile; } }

   
        public WinRTStorageFile(IStorageFile baseFile)
        {
            if (baseFile == null) throw new ArgumentNullException("baseFile");
            _baseFile = baseFile;
        }

        public async Task RenameAsync(string newName)
        {
            Debug.WriteLine("WinRTStorageFile.cs | RenameAsync | ");
            await _baseFile.RenameAsync(newName, NameCollisionOption.ReplaceExisting);
        }
     

        public async Task<IPortableFileBasicProperties> GetBasicPropertiesAsync()
        {
            return (await _baseFile.GetBasicPropertiesAsync()).AsPortableBasicProperties();
        }


    }
}
