using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

namespace CommonManager
{
    public class CommonProcess
    {
        public class CSVReader
        {
            static string SPLITRE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
            static string LINESPLITRE = @"\r\n|\n\r|\n|\r";
            static char[] TRIMCHARS = { '\"' };

            public static List<Dictionary<string, object>> Read(string file)
            {
                var list = new List<Dictionary<string, object>>();
                TextAsset data = Resources.Load(file) as TextAsset;

                var lines = Regex.Split(data.text, LINESPLITRE);

                if (lines.Length <= 1) return list;

                var header = Regex.Split(lines[0], SPLITRE);
                for (var i = 1; i < lines.Length; i++)
                {

                    var values = Regex.Split(lines[i], SPLITRE);
                    if (values.Length == 0 || values[0] == "") continue;

                    var entry = new Dictionary<string, object>();
                    for (var j = 0; j < header.Length && j < values.Length; j++)
                    {
                        string value = values[j];
                        value = value.TrimStart(TRIMCHARS).TrimEnd(TRIMCHARS).Replace("\\", "");
                        object finalvalue = value;
                        int n;
                        float f;
                        if (int.TryParse(value, out n))
                        {
                            finalvalue = n;
                        }
                        else if (float.TryParse(value, out f))
                        {
                            finalvalue = f;
                        }
                        entry[header[j]] = finalvalue;
                    }
                    list.Add(entry);
                }
                return list;
            }
        }
    }
}
