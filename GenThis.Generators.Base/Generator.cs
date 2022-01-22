using GenThis.Models;
using System;
using System.Collections.Generic;

namespace GenThis.Generators.Base
{
    // https://localhost:44347/
    ///https://stackoverflow.com/questions/54272766/loading-an-external-net-standard-2-0-assembly-with-blazor
    ///https://docs.microsoft.com/en-us/dotnet/api/system.io.packaging.zippackage?view=dotnet-plat-ext-6.0&viewFallbackFrom=net-5.0
    public interface IGenerator
    {
        byte[] GenerateProject(Project project);
        byte[] GenerateNamespace(Project project, Guid namespaceId);
        byte[] GenerateClass(Project project, Guid classId);
        byte[] GenerateEnumeration(Project project, Guid enumerationId);
    }
}
