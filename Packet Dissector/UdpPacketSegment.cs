namespace Packet_Dissector
{
    class UdpPacketSegment : Layer4PacketSegment
    {
        private ushort sourcePort;

        private ushort destinationPort;

        private string protocolNameLayer7;

        private ushort packetLength;

        public UdpPacketSegment(byte[] packet, uint startingPoint)
        {
            sourcePort = PacketDissectionHelper.BytesToShort(packet, ref startingPoint);
            destinationPort = PacketDissectionHelper.BytesToShort(packet, ref startingPoint);
            packetLength = PacketDissectionHelper.BytesToShort(packet, ref startingPoint);
        }

        public override string ToString()
        {
            return "Source Port: " + sourcePort.ToString() + "\n" + "Destination Port: " + destinationPort.ToString() 
                   + "\n" + "Protocole(Layer 7): " + protocolNameLayer7 + "\n" + "Length: " + packetLength.ToString() + "\n";
        }
    }
}
