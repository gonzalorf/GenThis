using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenThis.Generators.Base.Utils
{
    public class ZipFileHelper
    {
        Stream stream;
        ZipStorer z;

        static ZipFileHelper()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public ZipFileHelper(Stream stream)
        {
            this.stream = stream;
            z = ZipStorer.Create(stream);
        }

        public Stream Stream { get { return stream; } }

        public void AddFile(Stream stream, string fileName)
        {
            z.AddStream(ZipStorer.Compression.Store, fileName, stream, DateTime.Now);
        }
    }
}
