using System;

namespace Packet_Dissector
{
    static class PacketDissectionHelper
    {
        public const int MAC_ADDRESS_BYTE_LENGTH = 6;
        public const int IPV4_ADDRESS_BYTE_LENGTH = 4;
        public const int PROTOCOL_BYTE_LENGTH = 2;
        public const int OPCODE_BYTE_LENGTH = 2;

        public static string GetMacAddressFromBytes(byte[] packet, ref uint startIndex)
        {
            string macAddress = "";
            byte[] macBytesSegment = new byte[MAC_ADDRESS_BYTE_LENGTH];
            Array.Copy(packet,startIndex,macBytesSegment,0,MAC_ADDRESS_BYTE_LENGTH);
            macAddress = BitConverter.ToString(macBytesSegment);
            startIndex += MAC_ADDRESS_BYTE_LENGTH;
            return macAddress.Replace("-", ":");
        }

        public static string GetProtocolFromBytes(byte[] packet, ref uint startIndex)
        {
            string protocol = "0x";
            byte[] protocolBytesSegment = new byte[PROTOCOL_BYTE_LENGTH];
            Array.Copy(packet, startIndex, protocolBytesSegment, 0,PROTOCOL_BYTE_LENGTH);
            protocol += BitConverter.ToString(protocolBytesSegment);
            startIndex += PROTOCOL_BYTE_LENGTH;
            return protocol.Replace("-", "");
        }

        public static string GetIpv4AddressFromBytes(byte[] packet, ref uint startIndex)
        {
            string ipAddress = "";
            byte[] ipAddressBytesSegment = new byte[IPV4_ADDRESS_BYTE_LENGTH];
            Array.Copy(packet, startIndex, ipAddressBytesSegment, 0, IPV4_ADDRESS_BYTE_LENGTH);
            for (int i = 0; i < ipAddressBytesSegment.Length; i++)
            {
                ipAddress += ipAddressBytesSegment[i] + ".";
            }
            startIndex += IPV4_ADDRESS_BYTE_LENGTH;
            return ipAddress.Remove(ipAddress.Length - 1);
        }

        public static ushort BytesToShort(byte[] packet, ref uint startIndex)
        {
            ushort convertedValue = 0;
            byte[] shortInArray = new byte[2];
            Array.Copy(packet, startIndex, shortInArray, 0, PROTOCOL_BYTE_LENGTH);
            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(shortInArray);
            }
            startIndex += OPCODE_BYTE_LENGTH;
            return (ushort)BitConverter.ToInt16(shortInArray, 0);
        }
    }
}
