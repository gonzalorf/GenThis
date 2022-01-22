using GenThis.Generators.Base;
using GenThis.Generators.Base.Utils;
using GenThis.Models;
using System;
using System.IO;

namespace GenThis.Generators.BlazorApp
{
    public class BlazorWasmWithApiGenerator : IGenerator
    {
        public BlazorWasmWithApiGenerator() { }

        public byte[] GenerateProject(Project project)
        {
            using (var zipStream = new MemoryStream())
            {
                var zip = new ZipFileHelper(zipStream);

                using (var ms = new MemoryStream())
                {
                    TextWriter tw = new StreamWriter(ms);
                    tw.Write("public class Program");
                    tw.Flush();
                    ms.Position = 0;

                    zip.AddFile(ms, "Program.cs");
                }

                return zipStream.ToArray();
            }
        }

        public byte[] GenerateClass(Project project, Guid classId)
        {
            throw new NotImplementedException();
        }

        public byte[] GenerateEnumeration(Project project, Guid enumerationId)
        {
            throw new NotImplementedException();
        }

        public byte[] GenerateNamespace(Project project, Guid namespaceId)
        {
            throw new NotImplementedException();
        }

    }
}
