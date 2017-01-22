namespace Packet_Dissector
{
    class EthernetPacketSegment : Layer2PacketSegment
    {

        private string destinationMACAddress;

        private string sourceMACAddress;

        private string layer3Protocol;

        public const string IP_PROTOCOL_CODE = "0x0800";
        public const string ARP_PROTOCOL_CODE = "0x0806";

        private Layer3PacketSegment layer3PacketSegment;

        public EthernetPacketSegment(byte[] ethernetPacket)
        {
            startingPoint = 0;
            destinationMACAddress = PacketDissectionHelper.GetMacAddressFromBytes(ethernetPacket, ref startingPoint);
            sourceMACAddress = PacketDissectionHelper.GetMacAddressFromBytes(ethernetPacket, ref startingPoint);
            layer3Protocol = PacketDissectionHelper.GetProtocolFromBytes(ethernetPacket, ref startingPoint);
            if (layer3Protocol == IP_PROTOCOL_CODE)
            {
                layer3PacketSegment = new Ipv4PacketSegment(ethernetPacket, startingPoint);
            }
            //Le "else-if" laisse place à une continuation du travail pratique, autrement il y aurait un "else"
            else if (layer3Protocol == ARP_PROTOCOL_CODE)
            {
                layer3PacketSegment = new ArpPacketSegment(ethernetPacket,startingPoint);
            }
        }

        public override string ToString()
        { 
            if (layer3PacketSegment == null)
            {
                return "MAC Destination: " + destinationMACAddress + "\n" + "MAC Source: " + sourceMACAddress
                           + "\n" + "Protocol Type: " + layer3Protocol + "\n";
            }
            else
            {
                return "MAC Destination: " + destinationMACAddress + "\n" + "MAC Source: " + sourceMACAddress
                           + "\n" + "Protocol Type: " + layer3Protocol + "\n" + layer3PacketSegment.ToString();
            }
        }
    }
}
