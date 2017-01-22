using System;
using System.Collections;
namespace Packet_Dissector
{
    class Ipv4PacketSegment :Layer3PacketSegment
    {
        private int headerLength;

        private int dataLength;

        private int timeToLive;

        private string protocolLayer4;

        private string sourceIP;

        private string destinationIP;

        private const int LENGTH_STARTING_BYTE = 2;
        //Taille en octet d'un short = 2
        private const int BYTES_BETEWEEN_LENGTH_AND_TTL = 8 - LENGTH_STARTING_BYTE - 2;

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
            startingPoint++;
            sourceIP = PacketDissectionHelper.GetIpv4AddressFromBytes(packet, ref startingPoint);
            destinationIP += PacketDissectionHelper.GetIpv4AddressFromBytes(packet, ref startingPoint);
        }

        public override string ToString()
        {
            return "Header Lenght: " + headerLength.ToString() + "\n" + "Data Lenght: " 
                   + dataLength.ToString() + "\n" + "Time-To-Live: " + timeToLive.ToString() + "\n" 
                   + "Protocole(Layer 4): " + protocolLayer4 + "\n" + "Source IP: " + sourceIP + "\n" + "Destination IP " 
                   + destinationIP + "\n";
        }
    }
}
