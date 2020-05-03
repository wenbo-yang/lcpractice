using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC1352_ProductOfLastKNumbers
{
    [TestClass]
    public class ProduectOfLastKNumbersTests
    {
        [TestMethod]
        public void GivenProductOfNumbersClassAndAddNumber_GetProduct_ShouldReturnCorrectProduct()
        {
            var product = new ProductOfNumbers();

            product.Add(3);
            product.Add(0);
            product.Add(3);        
            product.Add(0);
            product.Add(2);        
            product.Add(5);        
            product.Add(4);

            var result = product.GetProduct(2);

            Assert.IsTrue(result == 20);
           
        }
    }

    internal class ProductOfNumbers
    {
        private List<int> _prefixProduct = new List<int>();
         
        public ProductOfNumbers()
        {
        }

        internal void Add(int number)
        {
            if (number == 0)
            {
                _prefixProduct.Clear();
            }
            else
            {
                if (_prefixProduct.Count == 0)
                {
                    _prefixProduct.Add(number);
                }
                else
                {
                    _prefixProduct.Add(_prefixProduct[_prefixProduct.Count - 1] * number);
                }
            }
        }

        internal int GetProduct(int last)
        {
            if (last > _prefixProduct.Count)
            {
                return 0;
            }

            return _prefixProduct[_prefixProduct.Count - 1] / _prefixProduct[_prefixProduct.Count - 1 - last];
        }
    }
    
}
