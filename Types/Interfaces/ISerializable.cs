using Arrowgene.Buffers;

namespace MSGO.Server.Types.Interfaces;
interface ISerializable
{
    public IBuffer Serialize();
}
