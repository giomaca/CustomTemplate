using System.Reflection;

namespace CustomTemplate.Application;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
