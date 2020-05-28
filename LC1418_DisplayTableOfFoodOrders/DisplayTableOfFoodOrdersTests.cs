using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1418_DisplayTableOfFoodOrders
{
    [TestClass]
    public class DisplayTableOfFoodOrdersTests
    {
        [TestMethod]
        public void GivenFoodOrders_DisplayTableOrders_ShouldReturnFoodOrders()
        {
            var foodOrders = new List<List<string>>() {
                new List<string> { "David", "3", "Ceviche"},
                new List<string> { "David", "3", "Fried Chicken"},
                new List<string> { "Corina", "10", "Beef Burrito"},
                new List<string> { "Carla", "5", "Ceviche"},
                new List<string> { "Carla", "5", "Water"},
                new List<string> { "Rous", "3", "Ceviche"}};

            var tableOrders = DisplayTableOrders(foodOrders);

            Assert.IsTrue(tableOrders[0].Contains("Table") && tableOrders[0].Count == 5);
        }

        private List<List<string>> DisplayTableOrders(List<List<string>> foodOrders)
        {
            var tableToOrderMaping = new Dictionary<int, Dictionary<string, int>>();
            var dishToTableMapping = new Dictionary<string, HashSet<int>>();

            GenerateTableAndDishMappings(tableToOrderMaping, dishToTableMapping, foodOrders);

            var displayOrderGrid = GenerateDisplayOrderArray(tableToOrderMaping, dishToTableMapping);

            var tableToIndexMapping = InitializeTable(displayOrderGrid, tableToOrderMaping, dishToTableMapping);

            FillInGrid(displayOrderGrid, tableToIndexMapping, tableToOrderMaping, dishToTableMapping);

            return ConvertGridToList(displayOrderGrid);
        }

        private List<List<string>> ConvertGridToList(string[][] displayOrderGrid)
        {
            var result = new List<List<string>>();

            for (int i = 0; i < displayOrderGrid.Length; i++)
            {
                var row = new List<string>();
                row.AddRange(displayOrderGrid[i]);
                result.Add(row);
            }

            return result;
        }

        private void FillInGrid(string[][] displayOrderGrid, Dictionary<int, int> tableToIndexMapping, Dictionary<int, Dictionary<string, int>> tableToOrderMaping, Dictionary<string, HashSet<int>> dishToTableMapping)
        {
            for (int i = 1; i < displayOrderGrid[0].Length; i++)
            {
                var tables = dishToTableMapping[displayOrderGrid[0][i]];
                foreach (var table in tables)
                {
                    var row = tableToIndexMapping[table];
                    displayOrderGrid[row][i] = tableToOrderMaping[table][displayOrderGrid[0][i]].ToString();
                }
            }
        }

        private Dictionary<int, int> InitializeTable(string[][] displayOrderGrid, Dictionary<int, Dictionary<string, int>> tableToOrderMaping, Dictionary<string, HashSet<int>> dishToTableMapping)
        {
            var sortedList = tableToOrderMaping.Keys.AsEnumerable().ToList();
            sortedList.Sort();
            var tableToIndexMapping = new Dictionary<int, int>();
            for (int i = 0; i < sortedList.Count; i++)
            {
                tableToIndexMapping.Add(sortedList[i], i + 1);
            }

            displayOrderGrid[0][0] = "Table";
            for (int i = 1; i < displayOrderGrid.Length; i++)
            {
                displayOrderGrid[i][0] = sortedList[i - 1].ToString();
            }

            var dishes = dishToTableMapping.Keys.AsEnumerable().ToList();
            for (int i = 1; i < displayOrderGrid[0].Length; i++)
            {
                displayOrderGrid[0][i] = dishes[i - 1];
            }

            return tableToIndexMapping;
        }

        private string[][] GenerateDisplayOrderArray(Dictionary<int, Dictionary<string, int>> tableToOrderMaping, Dictionary<string, HashSet<int>> dishToTableMapping)
        {
            var display = new string[tableToOrderMaping.Count + 1][];

            for (int i = 0; i < display.Length; i++)
            {
                display[i] = new string[dishToTableMapping.Count + 1];
                for (int j = 0; j < display[i].Length; j++)
                {
                    display[i][j] = "0";
                }
            }

            return display;
        }

        private void GenerateTableAndDishMappings(Dictionary<int, Dictionary<string, int>> tableToOrderMaping, Dictionary<string, HashSet<int>> dishToTableMapping, List<List<string>> foodOrders)
        {
            for (int i = 0; i < foodOrders.Count; i++)
            {
                var tableNum = Convert.ToInt32(foodOrders[i][1]);

                if (!dishToTableMapping.ContainsKey(foodOrders[i][2]))
                {
                    dishToTableMapping.Add(foodOrders[i][2], new HashSet<int>());
                }
                dishToTableMapping[foodOrders[i][2]].Add(tableNum);

                if (!tableToOrderMaping.ContainsKey(tableNum))
                {
                    tableToOrderMaping.Add(tableNum, new Dictionary<string, int>());
                }

                if (!tableToOrderMaping[tableNum].ContainsKey(foodOrders[i][2]))
                {
                    tableToOrderMaping[tableNum].Add(foodOrders[i][2], 0);
                }

                tableToOrderMaping[tableNum][foodOrders[i][2]]++;
            }
        }
    }
}
