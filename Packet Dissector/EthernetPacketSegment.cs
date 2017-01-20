using System;

namespace Packet_Dissector
{
    class EthernetPacketSegment : Layer2PacketSegment
    {

        private string destinationMACAddress;

        private string sourceMACAddress;

        private string layer3Protocol;

        //La couche ethernet est composée de 2 adresses MAC et d'un protocol.
        public const uint ETHERNET_LAYER_BYTE_LENGTH = PacketDissectionHelper.MAC_ADDRESS_BYTE_LENGTH*2
                                                     + PacketDissectionHelper.PROTOCOL_BYTE_LENGTH;

        public EthernetPacketSegment(byte[] ethernetPacket)
        {
            destinationMACAddress = PacketDissectionHelper.GetMacAddressFromBytes(ethernetPacket,0);
            sourceMACAddress = PacketDissectionHelper.GetMacAddressFromBytes(ethernetPacket,PacketDissectionHelper.MAC_ADDRESS_BYTE_LENGTH);
            layer3Protocol = PacketDissectionHelper.GetProtocolFromBytes(ethernetPacket, PacketDissectionHelper.MAC_ADDRESS_BYTE_LENGTH * 2);
        }

        public override string ToString()
        {
            return "MAC Destination: " + this.destinationMACAddress + "\n" + "MAC Source: " + this.sourceMACAddress 
                                       + "\n" + "Protocol Type: " + this.layer3Protocol + "\n";
        }
    }
}
