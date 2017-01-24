namespace Packet_Dissector
{
    class ArpPacketSegment : Layer3PacketSegment
    {
        private uint opCode;

        private string senderMacAddress;

        private string senderIPAddress;

        private string targetMacAddress;

        private string targetIPAddress;

        private const int START_OF_OPCODE = 6;

        public ArpPacketSegment(byte[] ethernetPacket, uint startingPoint)
        {
            startingPoint += START_OF_OPCODE;
            opCode = PacketDissectionHelper.BytesToShort(ethernetPacket, ref startingPoint);
            senderMacAddress = PacketDissectionHelper.GetMacAddressFromBytes(ethernetPacket, ref startingPoint);
            senderIPAddress = PacketDissectionHelper.GetIpv4AddressFromBytes(ethernetPacket, ref startingPoint);
            targetMacAddress = PacketDissectionHelper.GetMacAddressFromBytes(ethernetPacket, ref startingPoint);
            targetIPAddress = PacketDissectionHelper.GetIpv4AddressFromBytes(ethernetPacket, ref startingPoint);
        }

        public override string ToString()
        {
            return "Address Resolution Protocol\nSender MAC: " + senderMacAddress + "\n" + "Sender IP: " + senderIPAddress 
                   + "\n" + "Target MAC: " + targetMacAddress + "\n" + "Target IP: " + targetIPAddress 
                   + "\n" + "Protocol Type: " + opCode.ToString() + "\n";
        }
    }
}
