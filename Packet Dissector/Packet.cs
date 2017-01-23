using System;
using System.IO;

namespace Packet_Dissector
{
    class Packet
    {
        private byte[] packetData;

        public Layer2PacketSegment EthernetPacket{ get; set; }

        public Packet(string fileName)
        {
            try
            {
                packetData = File.ReadAllBytes(fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            EthernetPacket = new EthernetPacketSegment(packetData);
        }

        public override string ToString()
        {
            return EthernetPacket.ToString();
        }
    }
}
