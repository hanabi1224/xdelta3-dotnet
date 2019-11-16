using System;
using System.Linq;

namespace xdelta3.net
{
    public static unsafe class Xdelta3Lib
    {
        public static ReadOnlyMemory<byte> Encode(ReadOnlyMemory<byte> source, ReadOnlyMemory<byte> target)
        {
            var estimatedOutputLength = Math.Max(16, (source.Length + target.Length) * 2);
            int ret = 0;
            for (var i = 0; i < 3; i++)
            {
                uint outputSize = 0;
                var output = new byte[estimatedOutputLength];
                ret = NativeMethods.EncodeMemory(
                    input: (byte*)target.Pin().Pointer,
                    input_size: (uint)target.Length,
                    source: (byte*)source.Pin().Pointer,
                    source_size: (uint)source.Length,
                    output_buffer: (byte*)output.AsMemory().Pin().Pointer,
                    output_size: ref outputSize,
                    avail_output: (uint)output.Length,
                    flags: 0);

                if (ret == 28)
                {
                    estimatedOutputLength *= 2;
                    continue;
                }
                else if (ret != 0)
                {
                    throw new InvalidOperationException($"Return value: {ret}");
                }

                return output.Take((int)outputSize).ToArray();
            }

            throw new InvalidOperationException($"Return value: {ret}");
        }

        public static ReadOnlyMemory<byte> Decode(ReadOnlyMemory<byte> source, ReadOnlyMemory<byte> delta)
        {
            var estimatedOutputLength = Math.Max(16, (source.Length + delta.Length) * 2);
            int ret = 0;
            for (var i = 0; i < 3; i++)
            {
                uint outputSize = 0;
                var output = new byte[estimatedOutputLength];

                ret = NativeMethods.DecodeMemory(
                    input: (byte*)delta.Pin().Pointer,
                    input_size: (uint)delta.Length,
                    source: (byte*)source.Pin().Pointer,
                    source_size: (uint)source.Length,
                    output_buffer: (byte*)output.AsMemory().Pin().Pointer,
                    output_size: ref outputSize,
                    avail_output: (uint)output.Length,
                    flags: 0);

                if (ret == 28)
                {
                    estimatedOutputLength *= 2;
                    continue;
                }
                else if (ret != 0)
                {
                    throw new InvalidOperationException($"Return value: {ret}");
                }

                return output.Take((int)outputSize).ToArray();
            }

            throw new InvalidOperationException($"Return value: {ret}");
        }
    }
}
