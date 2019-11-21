using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC399_EvaluateEquations
{
    [TestClass]
    public class EvaluationDivisionsTests
    {
        [TestMethod]
        public void GivenDivisionEquationValuesAndQuery_GetAnswers_ShouldReturnCorrectArray()
        {
            var equations = new List<Tuple<string, string>> { new Tuple<string, string>( "b", "c" ), new Tuple<string, string>( "a", "b")};
            var values = new double[] { 3.0, 2.0 };
            var queries = new string[][] { new string[] { "a", "c" }, new string[] { "b", "a" }, new string[] { "a", "e" }, new string[] { "a", "a" }, new string[] { "x", "x" } };

            var result = CalculateDivision(equations, values, queries);

            Assert.IsTrue(result.SequenceEqual(new double[] { 6.0, 0.5, -1.0, 1.0, -1.0 }));
        }

        private double[] CalculateDivision(List<Tuple<string, string>> equations, double[] values, string[][] queries)
        {
            var sortedMap = PrepareEquations(equations, values);
            var relationShipDictionary = new Dictionary<string, Tuple<string, double>>();

            foreach (var relation in sortedMap)
            {
                if (!relationShipDictionary.ContainsKey(relation.Key.Item1))
                {
                    relationShipDictionary.Add(relation.Key.Item1, new Tuple<string, double>(relation.Key.Item1, relation.Value == 0 ? 0 : 1.0));
                }
                else
                {
                    if (relationShipDictionary[relation.Key.Item1].Item2 == 0.0 && relation.Value != 0.0)
                    {
                        throw new Exception("Conflicting Value");
                    }
                }

                if (!relationShipDictionary.ContainsKey(relation.Key.Item2))
                {
                    relationShipDictionary.Add(relation.Key.Item2, new Tuple<string, double>(relation.Value == 0 ? relation.Key.Item2 : relationShipDictionary[relation.Key.Item1].Item1, relation.Value == 0 ? 1.0 : (1.0 / relation.Value) * relationShipDictionary[relation.Key.Item1].Item2));
                }
            }

            var result = new double[queries.Length];

            for (int i = 0; i < queries.Length; i++)
            {
                if (relationShipDictionary.ContainsKey(queries[i][0]) && relationShipDictionary.ContainsKey(queries[i][1]) &&
                    relationShipDictionary[queries[i][0]].Item1 == relationShipDictionary[queries[i][1]].Item1)
                {
                    result[i] = relationShipDictionary[queries[i][0]].Item2 / relationShipDictionary[queries[i][1]].Item2;
                }
                else
                {
                    result[i] = -1.0;
                }
            }

            return result;
        }

        private SortedDictionary<Tuple<string, string>, double> PrepareEquations(List<Tuple<string, string>> equations, double[] values)
        {
            var sortedMap = new SortedDictionary<Tuple<string, string>, double>();

            for (int i = 0; i < equations.Count; i++)
            {
                if (values[i] != 0)
                {
                    if (string.Compare(equations[i].Item1, equations[i].Item2) == 1)
                    {
                        equations[i] = new Tuple<string, string>(equations[i].Item2, equations[i].Item1);
                        values[i] = 1.0 / values[i];
                    }
                }

                sortedMap.Add(equations[i], values[i]);
            }

            return sortedMap;
        }
    }
}
