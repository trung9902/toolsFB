using System;
using System.Buffers;

namespace LushCare.Support
{
    /// <summary>
    /// Thread-safe buffer pool wrapping ArrayPool to reduce GC pressure and LOH allocations.
    /// </summary>
    public static class BufferPool
    {
        public const int DefaultBufferSize = 16384;

        public static byte[] Rent(int minimumLength = DefaultBufferSize)
        {
            return ArrayPool<byte>.Shared.Rent(minimumLength);
        }

        public static void Return(byte[] array, bool clearArray = false)
        {
            if (array != null)
            {
                ArrayPool<byte>.Shared.Return(array, clearArray);
            }
        }
    }
}
