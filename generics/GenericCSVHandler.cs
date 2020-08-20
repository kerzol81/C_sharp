  // Code is inspired by Tim Corey's generics tutorial

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Planets_Generics
{
    static class CSVHandlerEntity<T> where T : ICSVFormat, new()
    {
        public static void WriteWithHeaders(List<T> items, string path)
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
                foreach (var column in columns)
                {
                    line.Append(column.GetValue(row));
                    line.Append(';');
                }
                csvlines.Add(line.ToString().Substring(0, line.Length - 1)); // 1 line, and ; removed from the end
            }
            File.WriteAllLines(path, csvlines);
        }
        public static List<T> ReadWithHeaders(string path)
        {

            var lines = File.ReadAllLines(path).ToList();
            if (lines.Count < 2)
            {
                throw new IndexOutOfRangeException("The input file is empty");
            }
            List<T> objects = new List<T>();
            var template = new T();
            var columns = template.GetType().GetProperties(); // reflexion 

            var header = lines[0].Split(';');
            lines.RemoveAt(0);                  // remove the header

            foreach (var row in lines)
            {
                template = new T();
                var properties = row.Split(';');

                for (int i = 0; i < header.Length; i++)
                {
                    foreach (var column in columns)
                    {
                        if (column.Name == header[i])
                        {
                            column.SetValue(template, Convert.ChangeType(properties[i], column.PropertyType));
                        }
                    }
                }
                objects.Add(template);
            }
            return objects;
        }
        public static void WriteHeaderless(List<T> items, string path)
        {
            StreamWriter s = new StreamWriter(path);
            foreach (var item in items)
            {
                s.WriteLine(item.CSVFormat());
            }
            s.Close();
        }
    }
}

