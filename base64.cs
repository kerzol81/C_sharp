      static void ReadBinary_to_Base64txt(string input_exe, string output_base64_txt)
        {
            if (File.Exists(input_exe))
            {
                FileStream f = new FileStream(input_exe, FileMode.Open);
                BinaryReader reader = new BinaryReader(f);

                List<byte> data = new List<byte>();

                for (int i = 0; i < reader.BaseStream.Length; i++)
                {
                    data.Add(reader.ReadByte());
                }
                reader.Close();
                File.WriteAllText(output_base64_txt, Convert.ToBase64String(data.ToArray()));
            }
        }

        static void WriteBase64txt_2_binary(string input_base64_txt, string output_exe)
        {
            string program = File.ReadAllText(input_base64_txt);
            byte[] bin = Convert.FromBase64String(program);
            BinaryWriter writer = new BinaryWriter(new FileStream(output_exe, FileMode.CreateNew));
            for (int i = 0; i < bin.Length; i++)
            {
                writer.Write(bin[i]);
            }
            writer.Close();
        }
