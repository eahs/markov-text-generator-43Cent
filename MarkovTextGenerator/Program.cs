using System;
using System.Collections.Generic;

namespace MarkovTextGenerator
{
    public class Chain
    {
        Dictionary<string, List<string>> words = new Dictionary<string, List<string>>();
        Random rng = new Random();

        public void AddSentence(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return;

            string[] split = line.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < split.Length - 1; i++)
            {
                if (!words.ContainsKey(split[i]))
                {
                    words[split[i]] = new List<string>();
                }
                words[split[i]].Add(split[i + 1]);
            }
        }

        public void UpdateProbabilities()
        {
        }

        public string GetNextWord(string word)
        {
            string key = word.ToLower().Trim();

            if (words.ContainsKey(key))
            {
                List<string> options = words[key];
                return options[rng.Next(options.Count)];
            }

            return "something I haven't learned yet";
        }
    }
}