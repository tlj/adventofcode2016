using System.Collections.Generic;
using System.Text.RegularExpressions;
using System;
using System.Linq;

namespace AdventOfCode2016.Solutions
{

    public class Day10 : Base
    {
        Dictionary<string, Dictionary<string, List<int>>> results;
        Dictionary<string, List<int>> botResponsibilities;

        public Day10(string inputString)
        {
            Init(inputString);
            Setup();
        }

        public Day10(bool isTest)
        {
            if (isTest)
            {
                Init(Inputs.Day10.testData);
            }
            else
            {
                Init(Inputs.Day10.realData);
            }
            Setup();
        }

        public void Setup()
        {
            results = new Dictionary<string, Dictionary<string, List<int>>>();
            results.Add("bot", new Dictionary<string, List<int>>());
            results.Add("output", new Dictionary<string, List<int>>());

            botResponsibilities = new Dictionary<string, List<int>>();
        }

        public void InitBots()
        {
            foreach (var line in inputs) {
                var words = line.Split(' ');
                if (words[0] == "value") {
                    if (!results["bot"].ContainsKey(words[5])) {
                        results["bot"].Add(words[5], new List<int>());
                    }
                    results["bot"][words[5]].Add(int.Parse(words[1]));
                }
            }
        }

        public override void Run()
        {
            base.Run();

            InitBots();
            ProcessInstructions();

            firstResult = FindBotWithValues(61, 17);

            if (results["output"].ContainsKey("0") && results["output"].ContainsKey("1") && results["output"].ContainsKey("2")) {
                secondResult = (results["output"]["0"].First() * results["output"]["1"].First() * results["output"]["2"].First()).ToString();
            } 
        }

        public string ProcessInstructions()
        {
            string pattern = @"bot ([0-9]+) gives (.*?) and (.*)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(input);

            string innerPattern = @"(?<type>low|high) to (?<receiver>bot|output) (?<receiverNum>[0-9]+)";
            Regex innerRgx = new Regex(innerPattern);

            var matchCount = 1;
            var botWithValues = "";
        
            while (matchCount > 0) {
                matchCount = 0; 
                foreach (Match m in matches) {
                    var botNumber = m.Groups[1].Value;
                    if (results["bot"].ContainsKey(botNumber) && results["bot"][botNumber].Count == 2) {
                        matchCount++;
                        var botValues = from entry in results["bot"][botNumber] orderby entry descending select entry;

                        for (var i = 2; i <= 3; i++) {
                            Match mc = innerRgx.Match(m.Groups[i].Value);
                            var valueToGive = botValues.First();
                            if (mc.Groups["type"].Value == "low") {
                                valueToGive = botValues.Last();
                            }
                            if (!results[mc.Groups["receiver"].Value].ContainsKey(mc.Groups["receiverNum"].Value)) {
                                results[mc.Groups["receiver"].Value].Add(mc.Groups["receiverNum"].Value, new List<int>());
                            }
                            results[mc.Groups["receiver"].Value][mc.Groups["receiverNum"].Value].Add(valueToGive);
                        }
                        
                        results["bot"][botNumber].Clear();
                    }
                    StoreResponsibilities();
                }
            }

            return botWithValues;
        }

        public void StoreResponsibilities()
        {
            foreach (var bot in results["bot"]) {
                if (!botResponsibilities.ContainsKey(bot.Key) && bot.Value.Count == 2) {
                    botResponsibilities.Add(bot.Key, bot.Value.GetRange(0, bot.Value.Count));
                }
            }
        }

        public string FindBotWithValues(int val1, int val2)
        {
            var botWithValues = "";
            foreach (var bot in botResponsibilities) {
                if (bot.Value.Contains(val1) && bot.Value.Contains(val2)) {
                    botWithValues = bot.Key;
                    break;
                }
            }
            return botWithValues;
        }

    }
}