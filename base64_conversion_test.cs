using System;
using System.Collections.Generic;
using System.IO;

namespace base64
{
    class Program
    {
        
        static void Main(string[] args)
        {
            /*
            List<byte> data = new List<byte>();

            BinaryReader reader = new BinaryReader(new FileStream("Hi.exe", FileMode.Open));

            for (int i = 0; i < reader.BaseStream.Length; i++)
            {
                data.Add(reader.ReadByte());
            }

            File.WriteAllText("base64.txt", Convert.ToBase64String(data.ToArray()));
            */

            string program = File.ReadAllText("base64.txt");

            byte[] bin = Convert.FromBase64String(program);

            BinaryWriter writer = new BinaryWriter(new FileStream("hi_mod.exe", FileMode.CreateNew));

            for (int i = 0; i < bin.Length; i++)
            {
                writer.Write(bin[i]);
            }
            writer.Close();


        }
    } 
}
