using System.Collections;
namespace Packet_Dissector
{
    class Ipv4PacketSegment : Layer3PacketSegment
    {
        private int headerLength;

        private int dataLength;

        private int timeToLive;

        private string protocolLayer4;

        private string sourceIP;

        private string destinationIP;

        private const int LENGTH_STARTING_BYTE = 2;
        //Taille en octet d'un short = 2
        private const int BYTES_BETEWEEN_LENGTH_AND_TTL = 8 - LENGTH_STARTING_BYTE -2;

        private const int HEADER_CHECKSUM_BYTE_LENGTH = 2;

        private Layer4PacketSegment layer4PacketSegment;

        public Ipv4PacketSegment(byte[] packet, uint startingPoint)
        {
            uint startingPointBeforeIncreasing = startingPoint;
            BitArray bits = new BitArray(new byte[] { packet[startingPoint] });
            for (int i = bits.Length/2; i<bits.Length; i++)
            {
                bits[i] = false;
            }
            byte[] convertedBits = new byte[1];
            bits.CopyTo(convertedBits, 0);
            headerLength = convertedBits[0];
            startingPoint += LENGTH_STARTING_BYTE;
            dataLength = PacketDissectionHelper.BytesToShort(packet, ref startingPoint);
            startingPoint += BYTES_BETEWEEN_LENGTH_AND_TTL;
            timeToLive = packet[startingPoint];
            startingPoint++;
            protocolLayer4 = packet[startingPoint].ToString();
            startingPoint += HEADER_CHECKSUM_BYTE_LENGTH + 1;
            sourceIP = PacketDissectionHelper.GetIpv4AddressFromBytes(packet, ref startingPoint);
            destinationIP += PacketDissectionHelper.GetIpv4AddressFromBytes(packet, ref startingPoint);
            startingPoint = (uint)(startingPointBeforeIncreasing + headerLength * 4);
            if (protocolLayer4 == "17") 
            {
                layer4PacketSegment = new UdpPacketSegment(packet, startingPoint);
            }
            else if (protocolLayer4 == "6")
            {

            }
        }

        public override string ToString()
        {
            if (layer4PacketSegment != null)
            {
                return "Header Lenght: " + headerLength.ToString() + "\n" + "Data Lenght: "
                       + dataLength.ToString() + "\n" + "Time-To-Live: " + timeToLive.ToString() + "\n"
                       + "Protocole(Layer 4): " + protocolLayer4 + "\n" + "Source IP: " + sourceIP + "\n" + "Destination IP "
                       + destinationIP + "\n" + layer4PacketSegment.ToString();
            }
            else
            {
                return "Header Lenght: " + headerLength.ToString() + "\n" + "Data Lenght: "
                       + dataLength.ToString() + "\n" + "Time-To-Live: " + timeToLive.ToString() + "\n"
                       + "Protocole(Layer 4): " + protocolLayer4 + "\n" + "Source IP: " + sourceIP + "\n" + "Destination IP "
                       + destinationIP + "\n";
            }
        }
    }
}
