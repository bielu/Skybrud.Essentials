﻿using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;
// ReSharper disable ExpressionIsAlwaysNull

#pragma warning disable 618

namespace UnitTestProject1.Time {

    [TestClass]
    public class EssentialsDateTests {

        [TestMethod]
        public void TryParse() {

            bool success1 = EssentialsDate.TryParse("2019-08-17", out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParse("08/17/2019", out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(false, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.IsNull(result2);

        }

        [TestMethod]
        public void TryParseProvider() {

            CultureInfo culture = new CultureInfo("en-US");

            bool success1 = EssentialsDate.TryParse("2019-08-17", culture, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParse("08/17/2019", culture, DateTimeStyles.None, out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(true, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

        }

        [TestMethod]
        public void TryParseExact() {

            bool success1 = EssentialsDate.TryParseExact("2019-08-17", "yyyy-MM-dd", null, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParseExact("08/17/2019", "MM/dd/yyyy", null, DateTimeStyles.None, out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(true, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

        }

        [TestMethod]
        public void TryParseExactArray() {

            bool success1 = EssentialsDate.TryParseExact("2019-08-17", new [] { "yyyy-MM-dd" }, null, DateTimeStyles.None, out EssentialsDate result1);
            bool success2 = EssentialsDate.TryParseExact("08/17/2019", new [] { "MM/dd/yyyy" }, null, DateTimeStyles.None, out EssentialsDate result2);

            Assert.AreEqual(true, success1);
            Assert.AreEqual(true, success2);

            Assert.AreEqual(2019, result1.Year);
            Assert.AreEqual(8, result1.Month);
            Assert.AreEqual(17, result1.Day);

            Assert.AreEqual(2019, result2.Year);
            Assert.AreEqual(8, result2.Month);
            Assert.AreEqual(17, result2.Day);

        }

        [TestMethod]
        public void CompareTo() {


            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = b, Expected = 1.CompareTo(2) },
                new { Left = a, Right = a, Expected = 2.CompareTo(2) },
                new { Left = b, Right = a, Expected = 2.CompareTo(1) },
                new { Left = a, Right = c, Expected = 1 }
            };

            foreach (var sample in samples) {

                int result = sample.Left.CompareTo(sample.Right);

                Assert.AreEqual(sample.Expected, result);

            }

        }

        [TestMethod]
        public void Equals() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = a, Right = c, Expected = false }
            };

            foreach (var sample in samples) {

                bool result = sample.Left.Equals(sample.Right);

                Assert.AreEqual(sample.Expected, result);

            }

        }

        [TestMethod]
        public void OperatorEquals() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = c, Right = a, Expected = false },
                new { Left = c, Right = c, Expected = true }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left == sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorLessThan() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = false },
                new { Left = a, Right = b, Expected = true },
                new { Left = b, Right = a, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = c, Right = a, Expected = true },
                new { Left = c, Right = c, Expected = false }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left < sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorLessThanOrEqualTo() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = true },
                new { Left = b, Right = a, Expected = false },
                new { Left = a, Right = c, Expected = false },
                new { Left = c, Right = a, Expected = true },
                new { Left = c, Right = c, Expected = true }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left <= sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorGreatorThan() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = false },
                new { Left = a, Right = b, Expected = false },
                new { Left = b, Right = a, Expected = true },
                new { Left = a, Right = c, Expected = true },
                new { Left = c, Right = a, Expected = false },
                new { Left = c, Right = c, Expected = false }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left > sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

        [TestMethod]
        public void OperatorGreaterThanOrEqualTo() {

            EssentialsDate a = new EssentialsDate(2012, 7, 30);
            EssentialsDate b = new EssentialsDate(2019, 8, 17);
            EssentialsDate c = null;

            var samples = new[] {
                new { Left = a, Right = a, Expected = true },
                new { Left = a, Right = b, Expected = false },
                new { Left = b, Right = a, Expected = true },
                new { Left = a, Right = c, Expected = true },
                new { Left = c, Right = a, Expected = false },
                new { Left = c, Right = c, Expected = true }
            };

            int i = 1;
            foreach (var sample in samples) {
                bool result = sample.Left >= sample.Right;
                Assert.AreEqual(sample.Expected, result, "#" + i++);
            }

        }

    }

}

#pragma warning restore 618