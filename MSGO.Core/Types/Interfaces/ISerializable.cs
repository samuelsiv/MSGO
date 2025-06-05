using Arrowgene.Buffers;

namespace MSGO.Core.Types.Interfaces;
interface ISerializable
{
    public IBuffer Serialize();
}
