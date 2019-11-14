using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LC65_ValidNumber
{
    [TestClass]
    public class ValidNumberTests
    {
        [TestMethod]
        public void GivenValidInputWithoutExponentialStrings_IsValidNumber_ShouldReturnTrue()
        {
            var input = "0";
            var result = IsValidNumber(input);
            Assert.IsTrue(result);

            input = "0.1";
            result = IsValidNumber(input);
            Assert.IsTrue(result);

            input = "+2.1";
            result = IsValidNumber(input);
            Assert.IsTrue(result);

            input = "-0.1";
            result = IsValidNumber(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenInvalidInputWithoutExponentialStrings_IsValidNumber_ShouldReturnFalse()
        {
            var input = "00";
            var result = IsValidNumber(input);
            Assert.IsFalse(result);

            input = "0..1";
            result = IsValidNumber(input);
            Assert.IsFalse(result);

            input = ".1";
            result = IsValidNumber(input);
            Assert.IsFalse(result);

            input = "+-1";
            result = IsValidNumber(input);
            Assert.IsFalse(result);

            input = "1a";
            result = IsValidNumber(input);
            Assert.IsFalse(result);
        }


        [TestMethod]
        public void GivenValidInputStringsWithExponentials_IsValidNumber_ShouldReturnTrue()
        {
            var input = "0.1e-10";
            var result = IsValidNumber(input);
            Assert.IsTrue(result);

            input = "0.1e10";
            result = IsValidNumber(input);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GivenInvalidInputStringsWithExponentials_IsValidNumber_ShouldReturnFalse()
        {
            var input = "0.1e+10";
            var result = IsValidNumber(input);
            Assert.IsFalse(result);

            input = "0.1e1a";
            result = IsValidNumber(input);
            Assert.IsFalse(result);

            input = "0.1e1.0";
            result = IsValidNumber(input);
            Assert.IsFalse(result);
        }

        private bool IsValidNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            input = input.Trim();

            var parts = input.Split('e');

            if (!ValidateParts(parts))
            {
                return false;
            }

            if (!ValidatePreExponentPart(parts[0]))
            {
                return false;
            }

            if (parts.Length == 2 && !ValidatePostExponentPart(parts[1]))
            {
                return false;
            }

            return true;
        }

        private bool ValidatePostExponentPart(string postExponentSign)
        {
            if (string.IsNullOrWhiteSpace(postExponentSign))
            {
                return false;
            }

            for (int i = 0; i < postExponentSign.Length; i++)
            {
                if (!CheckRulePostExponentRule(postExponentSign[i], i))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckRulePostExponentRule(char c, int i)
        {
            if (i == 0)
            {
                if (c == '-') return true;
                if (c == '0') return false;
            } 

            return c >= '0' && c <= '9';
        }

        private bool ValidatePreExponentPart(string preExponentSign)
        {
            if (string.IsNullOrWhiteSpace(preExponentSign))
            {
                return false;
            }

            if (preExponentSign.StartsWith("."))
            {
                return false;
            }

            var preExponentRules = new PreExponentRules();
            for (int i = 0; i < preExponentSign.Length; i++)
            {
                if (!CheckRulePreExponentRule(preExponentSign[i], i, ref preExponentRules))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckRulePreExponentRule(char c, int i, ref PreExponentRules preExponentRules)
        {
            if (i == 0)
            {
                if (c == '-' || c == '+') return true;
                if (c == '.') return false;
                if (c == '0') { preExponentRules.IsSmallerThan1 = true; return true; }
            }

            if (i == 1 && c == '0' && preExponentRules.IsSmallerThan1) return false;

            if (c == '-' || c == '+') return false;
            if (c == '.')
            {
                if (preExponentRules.IsDecimal) return false;
                if (!preExponentRules.IsDecimal) { preExponentRules.IsDecimal = true; return true; }
                if (preExponentRules.IsSmallerThan1 && i != 1) return false;
            }

            return c >= '0' && c <= '9';
        }

        private bool ValidateParts(string[] parts)
        {
            return parts.Length < 3;
        }

        public class PreExponentRules
        {
            public bool IsDecimal { get; set; }
            public bool IsSmallerThan1 { get; set; }
        }

        public class PostExponentRules
        {
            

        }

    }
}
