using System;

namespace Packet_Dissector
{
    class Program
    {
        static void Main(string[] args)
        {
            Packet packet1 = new Packet(@"../../PacketsToRead/dissectionQuestion1");
            Console.Write("Question 1\n" + packet1.ToString());
            Packet packet2 = new Packet(@"../../PacketsToRead/dissectionQuestion2A");
            Console.Write("Question 2A\n" + packet2.ToString());
            Packet packet3 = new Packet(@"../../PacketsToRead/dissectionQuestion2B");
            Console.Write("Question 2B\n" + packet3.ToString());
            Packet packet4 = new Packet(@"../../PacketsToRead/dissectionQuestion2C");
            Console.Write("Question 2C\n" + packet4.ToString());
            Console.ReadLine();
        }
    }
}
