static class CSVHandlerEntity<T> where T: ICSVFormat
    {
        public static void Write(List<T> items, string path)
        {
            StreamWriter s = new StreamWriter(path);
            foreach (var item in items)
            {
                s.WriteLine(item.CSVFormat());
            }
            s.Close();
        }      
    }
