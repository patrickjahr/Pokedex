using System;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using PokeDex.Core.Services;

namespace Pokedex.UWP.Services
{
    public class PackageStorageService : IPackageStorageService
    {
        public async Task<BitmapImage> GetImageAsync(string relativePath)
        {
            var file = await GetFileAsync(relativePath);
            var stream = await file.OpenAsync(FileAccessMode.Read);
            var image = await GetBitmapImageFromStreamAsync(stream);

            return image;
        }

        public async Task<BitmapImage> GetImageAsync(Uri uri)
        {
            var file = await GetFileAsync(uri);
            var stream = await file.OpenAsync(FileAccessMode.Read);
            var image = await GetBitmapImageFromStreamAsync(stream);

            return image;
        }

        public async Task<IRandomAccessStream> GetIRandomAccessStreamAsync(string relativePath)
        {
            var storageFile = await Package.Current.InstalledLocation.GetFileAsync(relativePath);
            var stream = await storageFile.OpenAsync(FileAccessMode.Read);
            return stream;
        }

        public async Task<String> GetStringAsync(string relativePath)
        {
            var storageFile = await GetFileAsync(relativePath);
            return await FileIO.ReadTextAsync(storageFile);
        }

        public async Task<String> GetStringAsync(Uri uri)
        {
            var storageFile = await GetFileAsync(uri);
            return await FileIO.ReadTextAsync(storageFile);
        }

        public async Task<StorageFile> GetFileAsync(string relativePath)
        {
            return await Package.Current.InstalledLocation.GetFileAsync(relativePath);
        }

        public async Task<byte[]> GetBinaryAsync(string relativePath)
        {
            var file = await Package.Current.InstalledLocation.GetFileAsync(relativePath);
            var bytes = await ReadFileAsync(file);

            return bytes;
        }

        public async Task<StorageFile> GetFileAsync(Uri uri)
        {
            return await StorageFile.GetFileFromApplicationUriAsync(uri);
        }

        private async Task<BitmapImage> GetBitmapImageFromStreamAsync(IRandomAccessStream stream)
        {
            var bitmapImage = new BitmapImage();
            await bitmapImage.SetSourceAsync(stream);
            return bitmapImage;
        }

        private async Task<byte[]> ReadFileAsync(StorageFile file)
        {
            byte[] bytes;

            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {
                bytes = new byte[stream.Size];
                using (var reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(bytes);
                }
            }

            return bytes;
        }
    }
}