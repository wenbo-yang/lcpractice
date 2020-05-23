using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1410_HTMLParser
{
    [TestClass]
    public class HtmlParserTests
    {
        [TestMethod]
        public void GivenStringExpression_Parse_ShouldReturnParsedString()
        {
            var text = "and I quote: &quot;...&quot;";
            var result = Parse(text);

            Assert.IsTrue(result == "and I quote: \"...\"");
        }

        private string Parse(string text)
        {
            var target = new List<(string s, char symbol)> {("&quot;", '\"' ),
                                                            ("&apos;", '\''),
                                                            ("&amp;", '&' ),
                                                            ("&gt;", '>'),
                                                            ("&lt;", '<' ),
                                                            ("&frasl;", '/' ) };

            var index = 0;
            var sb = new StringBuilder();
            while (index < text.Length)
            {
                if (text[index] == '&')
                {
                    var matching = FindMatching(text, index, target);

                    if (matching.s == "")
                    {
                        sb.Append(text[index]);
                    }
                    else
                    {
                        sb.Append(matching.symbol);
                        index += matching.s.Length - 1;
                    }
                }
                else
                {
                    sb.Append(text[index]);
                }
                index++;
            }

            return sb.ToString();
        }

        private (string s, char symbol) FindMatching(string text, int index, List<(string s, char symbol)> target)
        {
            var end = index + 7;
            var matching = new bool[] { true, true, true, true, true, true };
            for (int i = index; i < end; i++)
            {
                var targetIndex = i - index;
                for (int j = 0; j < target.Count; j++)
                {
                    if (targetIndex < target[j].s.Length)
                    {
                        if (matching[j])
                        {
                            matching[j] = matching[j] && (target[j].s[targetIndex] == text[i]);
                        }
                    }
                    else
                    {
                        if (matching[j])
                        {
                            return target[j];
                        }
                    }
                }
            }

            return matching[matching.Length - 1] ? target[target.Count - 1] : ("", ' ');
        }
    }
}
