static class CSVHandlerEntity<T> where T : ICSVFormat, new()
    {
        public static void Write(List<T> items, string path)
        {
            List<string> csvlines = new List<string>();
            StringBuilder line = new StringBuilder();

            // csv header
            var columns = items[0].GetType().GetProperties().ToList();
            foreach (var column in columns)
            {
                line.Append(column.Name);
                line.Append(';');
            }
            csvlines.Add(line.ToString().Substring(0, line.Length - 1));
            foreach (var row in items)
            {
                line = new StringBuilder();
                foreach (var col in columns)
                {
                    line.Append(col.GetValue(row));
                    line.Append(';');
                }
                csvlines.Add(line.ToString().Substring(0, line.Length - 1)); // 1 line, and ; removed from the end
            }
            File.WriteAllLines(path, csvlines);            
        }
        //public static List<T> Read(string path)
        //{
        //    List<T> objects = new List<T>();
        //    var lines = File.ReadAllLines(path).ToList();
        //    var v = new T();
        //    var attributes = v.GetType().GetProperties(); // reflexion
        //    if (lines.Count > 0)
        //    {
        //        foreach (var row in lines)
        //        {
        //            v = new T();
        //            var props = row.Split(';');
        //            //         
        //        }
        //    }
        //    else
        //    {
        //        throw new IndexOutOfRangeException("not rows in the file");
        //    }
        //}
    }
