using System;
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
            var stub = new VoidStub();
            object @void = stub;

            // Pin object to obtain its address
            GCHandle gcHandle = GCHandle.Alloc(@void, GCHandleType.Pinned);
            nint objectHandleAddress = gcHandle.AddrOfPinnedObject() - IntPtr.Size;

            // Rewrite object handle to void's type handle
            nint voidTypeHandle = typeof(void).TypeHandle.Value;
            Marshal.WriteIntPtr(objectHandleAddress, voidTypeHandle);

            gcHandle.Free();
            return @void;
        }

        // System.Void is an empty struct
        private struct VoidStub
        {
        }
    }
}
