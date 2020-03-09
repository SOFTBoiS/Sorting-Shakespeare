﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.RegularExpressions;

namespace Miniproject_1_Sorting_Shakespeare
{
    public class TextProcessor
    {
        public string ReadText(string file_path)
        {
            try
            {
                return System.IO.File.ReadAllText(file_path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public string[] Sanitize(string text)
        {
            text = text.ToLower();
            string pattern = @"[a-z'-]+";


            MatchCollection sanitized = Regex.Matches(text, pattern);

            var arr = Regex.Matches(text, pattern)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();

            return arr;
        }
    }
}