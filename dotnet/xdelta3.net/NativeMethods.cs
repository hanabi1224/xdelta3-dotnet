using System.Runtime.InteropServices;

namespace xdelta3.net
{
    internal static unsafe class NativeMethods
    {
        private const string libName = @"xdelta3";

        [DllImport(libName, EntryPoint = "xd3_encode_memory_rs", CharSet = CharSet.Ansi)]
        internal static extern int EncodeMemory(
            [In]byte* input,
            [In]uint input_size,
            [In]byte* source,
            [In]uint source_size,
            [In, Out] byte* output_buffer,
            [In, Out] ref uint output_size,
            [In]uint avail_output,
            [In]int flags);

        [DllImport(libName, EntryPoint = "xd3_decode_memory_rs", CharSet = CharSet.Ansi)]
        internal static extern int DecodeMemory(
            [In]byte* input,
            [In]uint input_size,
            [In]byte* source,
            [In]uint source_size,
            [In, Out]byte* output_buffer,
            [In, Out]ref uint output_size,
            [In]uint avail_output,
            [In]int flags);

        internal static void Init() { }
    }
}
