using System;

namespace Packet_Dissector
{
    class Program
    {
        static void Main(string[] args)
        {
            Packet packet = new Packet(@"../../PacketsToRead/extract12");
            Console.Write(packet.ToString());
            Console.ReadLine();
        }
    }
}
