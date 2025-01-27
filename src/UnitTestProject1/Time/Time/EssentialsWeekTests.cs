﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Skybrud.Essentials.Time;

namespace UnitTestProject1.Time.Time {

    [TestClass]
    public class EssentialsWeekTests {

        public const string Format = "yyyy-MM-dd HH:mm:ss:fff K";

        [TestMethod]
        public void ConstructorOffset() {

            // Note: offset doesn't take daylight savings into account

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, TimeSpan.Zero);
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, TimeSpan.Zero);
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, TimeSpan.Zero);

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, TimeSpan.FromHours(1));
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, TimeSpan.FromHours(1));
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, TimeSpan.FromHours(1));
            EssentialsWeek week7 = new EssentialsWeek(2019, 14, TimeSpan.FromHours(2));

            Assert.AreEqual(12, week1.Week, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-24 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(13, week2.Week, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(14, week3.Week, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-04-07 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(12, week4.Week, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-24 23:59:59:999 +01:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(13, week5.Week, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-03-31 23:59:59:999 +01:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(14, week6.Week, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-04-01 00:00:00:000 +01:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-04-07 23:59:59:999 +01:00", week6.End.ToString(Format), "#6");

            Assert.AreEqual(14, week7.Week, "#7");
            Assert.AreEqual(2019, week7.Year, "#7");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", week7.Start.ToString(Format), "#7");
            Assert.AreEqual("2019-04-07 23:59:59:999 +02:00", week7.End.ToString(Format), "#7");

        }

        [TestMethod]
        public void ConstructorTimeZoneInfo() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, utc);
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, utc);
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, utc);

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, romance);
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, romance);
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, romance);

            Assert.AreEqual(12, week1.Week, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-24 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(13, week2.Week, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(14, week3.Week, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-04-07 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(12, week4.Week, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-24 23:59:59:999 +01:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(13, week5.Week, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-03-31 23:59:59:999 +02:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(14, week6.Week, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-04-07 23:59:59:999 +02:00", week6.End.ToString(Format), "#6");

        }

        [TestMethod]
        public void GetPreviousWeek() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, utc).GetPreviousWeek();
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, utc).GetPreviousWeek();
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, utc).GetPreviousWeek();

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, romance).GetPreviousWeek();
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, romance).GetPreviousWeek();
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, romance).GetPreviousWeek();

            Assert.AreEqual(11, week1.Week, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-11 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-17 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(12, week2.Week, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-03-18 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-03-24 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(13, week3.Week, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(11, week4.Week, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-11 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-17 23:59:59:999 +01:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(12, week5.Week, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-03-18 00:00:00:000 +01:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-03-24 23:59:59:999 +01:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(13, week6.Week, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-03-31 23:59:59:999 +02:00", week6.End.ToString(Format), "#6");

        }

        [TestMethod]
        public void GetNextWeek() {

            TimeZoneInfo utc = TimeZoneInfo.FindSystemTimeZoneById("UTC");
            TimeZoneInfo romance = TimeZoneInfo.FindSystemTimeZoneById("Romance Standard Time");

            EssentialsWeek week1 = new EssentialsWeek(2019, 12, utc).GetNextWeek();
            EssentialsWeek week2 = new EssentialsWeek(2019, 13, utc).GetNextWeek();
            EssentialsWeek week3 = new EssentialsWeek(2019, 14, utc).GetNextWeek();

            EssentialsWeek week4 = new EssentialsWeek(2019, 12, romance).GetNextWeek();
            EssentialsWeek week5 = new EssentialsWeek(2019, 13, romance).GetNextWeek();
            EssentialsWeek week6 = new EssentialsWeek(2019, 14, romance).GetNextWeek();

            Assert.AreEqual(13, week1.Week, "#1");
            Assert.AreEqual(2019, week1.Year, "#1");
            Assert.AreEqual("2019-03-25 00:00:00:000 +00:00", week1.Start.ToString(Format), "#1");
            Assert.AreEqual("2019-03-31 23:59:59:999 +00:00", week1.End.ToString(Format), "#1");

            Assert.AreEqual(14, week2.Week, "#2");
            Assert.AreEqual(2019, week2.Year, "#2");
            Assert.AreEqual("2019-04-01 00:00:00:000 +00:00", week2.Start.ToString(Format), "#2");
            Assert.AreEqual("2019-04-07 23:59:59:999 +00:00", week2.End.ToString(Format), "#2");

            Assert.AreEqual(15, week3.Week, "#3");
            Assert.AreEqual(2019, week3.Year, "#3");
            Assert.AreEqual("2019-04-08 00:00:00:000 +00:00", week3.Start.ToString(Format), "#3");
            Assert.AreEqual("2019-04-14 23:59:59:999 +00:00", week3.End.ToString(Format), "#3");

            Assert.AreEqual(13, week4.Week, "#4");
            Assert.AreEqual(2019, week4.Year, "#4");
            Assert.AreEqual("2019-03-25 00:00:00:000 +01:00", week4.Start.ToString(Format), "#4");
            Assert.AreEqual("2019-03-31 23:59:59:999 +02:00", week4.End.ToString(Format), "#4");

            Assert.AreEqual(14, week5.Week, "#2");
            Assert.AreEqual(2019, week5.Year, "#2");
            Assert.AreEqual("2019-04-01 00:00:00:000 +02:00", week5.Start.ToString(Format), "#5");
            Assert.AreEqual("2019-04-07 23:59:59:999 +02:00", week5.End.ToString(Format), "#5");

            Assert.AreEqual(15, week6.Week, "#6");
            Assert.AreEqual(2019, week6.Year, "#6");
            Assert.AreEqual("2019-04-08 00:00:00:000 +02:00", week6.Start.ToString(Format), "#6");
            Assert.AreEqual("2019-04-14 23:59:59:999 +02:00", week6.End.ToString(Format), "#6");

        }

    }

}