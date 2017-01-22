using System;

namespace Packet_Dissector
{
    class Program
    {
        static void Main(string[] args)
        {
            Packet packet = new Packet(@"../../PacketsToRead/extract8");
            Console.Write(packet.ToString());
            Console.ReadLine();
        }
    }
}
