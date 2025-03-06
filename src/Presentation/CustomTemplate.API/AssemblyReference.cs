using System.Reflection;

namespace CustomTemplate.API;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
