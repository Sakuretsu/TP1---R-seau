namespace Packet_Dissector
{
    class TcpPacketSegment : Layer4PacketSegment
    {
        private ushort sourcePort;

        private ushort destinationPort;

        private uint sequenceNumber;

        private uint acknowledgementNumber;

        private string protocolNameLayer7;

        public TcpPacketSegment(byte[] packet, uint startingPoint)
        {
            sourcePort = PacketDissectionHelper.BytesToShort(packet, ref startingPoint);
            destinationPort = PacketDissectionHelper.BytesToShort(packet, ref startingPoint);
            sequenceNumber = PacketDissectionHelper.BytesToInt(packet, ref startingPoint);
            acknowledgementNumber = PacketDissectionHelper.BytesToInt(packet, ref startingPoint);
            protocolNameLayer7 = PacketDissectionHelper.DetermineLayer7Identity(sourcePort, destinationPort);
        }

        public override string ToString()
        {
            if (protocolNameLayer7 != null && protocolNameLayer7 != string.Empty)
            {
                return "Transfer Control Protocol\nSource Port: " + sourcePort.ToString() + "\n" + "Destination Port: " + destinationPort.ToString()
                       + "\n" + "Sequence Number: " + sequenceNumber.ToString() + "\n" + "Acknowledgement Number: " + acknowledgementNumber.ToString()
                       + "\n" + "Protocole(Layer 7): " + protocolNameLayer7 + "\n";
            }
            else
            {
                return "Transfer Control Protocol\nSource Port: " + sourcePort.ToString() + "\n" + "Destination Port: " + destinationPort.ToString()
                       + "\n" + "Sequence Number: " + sequenceNumber.ToString() + "\n" + "Acknowledgement Number: " + acknowledgementNumber.ToString()
                       + "\n";
            }
        }
    }
}
