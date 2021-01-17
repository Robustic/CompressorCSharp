using System;
using Compressor.DataStructures.ByteList;

namespace Compressor
{
    class Program
    {

        // Main Method 
        static public void Main(String[] args)
        {
            ByteList list = new ByteList();
            Console.WriteLine("koko: " + list.size());

            Console.WriteLine("Main Method\n");
        }
    }
}