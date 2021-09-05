using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace GetVoid
{
    /// <summary>
    /// Provides the base class for obtaining an instance of <see cref="void"/>.
    /// </summary>
    public static class Void
    {
        /// <summary>
        /// Returns <see cref="void"/> boxed into an <see cref="object"/>.
        /// </summary>
        /// <returns>Instance of boxed <see cref="void"/>.</returns>
        public static object Get()
        {
            object @void = new VoidStub();
            GCHandle gcHandle = GCHandle.Alloc(@void, GCHandleType.Pinned);

            nint handleAddress = Unsafe.As<object, nint>(ref @void);
            nint voidHandle = typeof(void).TypeHandle.Value;
            Marshal.WriteIntPtr(handleAddress, voidHandle);

            gcHandle.Free();
            return @void;
        }

        // System.Void is an empty struct
        private struct VoidStub
        {
        }
    }
}
