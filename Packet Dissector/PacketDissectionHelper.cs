using System;

namespace Packet_Dissector
{
    static class PacketDissectionHelper
    {
        public const int MAC_ADDRESS_BYTE_LENGTH = 6;
        public const int PROTOCOL_BYTE_LENGTH = 2;

        public static string GetMacAddressFromBytes(byte[] packet, uint startIndex)
        {
            string macAddress = "";
            byte[] macBytesSegment = new byte[MAC_ADDRESS_BYTE_LENGTH];
            Array.Copy(packet,startIndex,macBytesSegment,0,MAC_ADDRESS_BYTE_LENGTH);
            macAddress = BitConverter.ToString(macBytesSegment);
            return macAddress.Replace("-", ":");
        }

        public static string GetProtocolFromBytes(byte[] packet, uint startIndex)
        {
            string protocol = "0x";
            byte[] protocolBytesSegment = new byte[PROTOCOL_BYTE_LENGTH];
            Array.Copy(packet, startIndex, protocolBytesSegment, 0,PROTOCOL_BYTE_LENGTH);
            protocol += BitConverter.ToString(protocolBytesSegment);
            return protocol.Replace("-", "");
        }

    }
}
