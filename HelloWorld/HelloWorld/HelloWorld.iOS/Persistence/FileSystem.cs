using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(HelloWorld.iOS.FileSystem))]
namespace HelloWorld.iOS
{
    public class FileSystem : IFileSystem
    {
        public async Task WriteTextAsync(string fileName, string text)
        {
            var docsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(docsPath, fileName);

            using (var writer = File.CreateText(path))
            {
                await writer.WriteAsync(text);
            }
        }
    }
}