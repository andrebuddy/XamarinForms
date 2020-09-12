using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    public interface IFileSystem
    {
        Task WriteTextAsync(string fileName, string text);
    }
}
