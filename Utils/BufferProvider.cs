using Arrowgene.Buffers;

namespace MSGO.Server.Utils;

public class BufferProvider
{
    private static readonly IBufferProvider _provider = new StreamBuffer();
    public static IBuffer Provide() => _provider.Provide();
    public static IBuffer Provide(byte[] data) => _provider.Provide(data);
}