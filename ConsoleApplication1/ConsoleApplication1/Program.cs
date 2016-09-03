using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // create the collection
            List<FruitTable> lstFruitTable = new List<FruitTable>();
            lstFruitTable.Add(new FruitTable { FruitNames = "Apple" });
            lstFruitTable.Add(new FruitTable { FruitNames = "Apple" });
            lstFruitTable.Add(new FruitTable { FruitNames = "Guava" });
            lstFruitTable.Add(new FruitTable { FruitNames = "Mango" });
            lstFruitTable.Add(new FruitTable { FruitNames = "Watermelon" });

            // add the sequence number on the fly
            var simpleRowNumber = lstFruitTable
                    .Select((x, index) => new
                    {
                        SequentialNumber = index + 1
                        ,
                        FruitNames = x.FruitNames
                    }).ToList();

            //display the record
            foreach (var item in simpleRowNumber)
            {
                Console.WriteLine("SequentialNumber = {0}   FruitNames = {1}", item.SequentialNumber, item.FruitNames);
            }

            Console.ReadKey();



            // create the collection
            List<FruitTable> lstobjFruitTable = new List<FruitTable>();
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Apple" });
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Banana" });
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Guava" });
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Mango" });
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Watermelon" });
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Mango" });
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Guava" });
            lstobjFruitTable.Add(new FruitTable { FruitNames = "Guava" });

            var rowNumberWithPartitionBy = lstobjFruitTable
                        .OrderBy(o => o.FruitNames)
                        .GroupBy(g => g.FruitNames)
                        .Select(s => new { s, Count = s.Count() })
                        .SelectMany(sm => sm.s.Select(s => s)
                                          .Zip(Enumerable.Range(1, sm.Count), (fruitTable, index)
                                              => new { SequentialNumber = index, fruitTable.FruitNames })
                                    ).ToList();


            //display the record
            foreach (var item in rowNumberWithPartitionBy)
            {
                Console.WriteLine("SequentialNumber = {0}   FruitNames = {1}", item.SequentialNumber, item.FruitNames);
            }

            Console.ReadKey();
        }
    }
    class FruitTable
    {
        public string FruitNames { get; set; }
    }
}
