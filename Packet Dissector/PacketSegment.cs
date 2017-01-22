namespace Packet_Dissector
{
    abstract class PacketSegment
    {
        protected uint startingPoint;

        abstract public string ToString();
    }
}
