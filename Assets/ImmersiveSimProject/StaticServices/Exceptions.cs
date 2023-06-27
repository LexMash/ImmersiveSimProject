using System;

namespace ImmersiveSimProject.StaticServices
{
    public static class Exceptions
    {
        public static void ArgumentValueIsZero(string operation, Type inClass)
            => new ArgumentException($"[Argument Value Is Zero] - Amount cannot be 0 in {inClass} -{operation}-");

        public static void ArgumentValueIsNull(string operation, Type inClass, string argumentName)
            => new NullReferenceException($"[Argument Value Is Null] - {argumentName} cannot be null in {inClass} -{operation}-");
    }
}
