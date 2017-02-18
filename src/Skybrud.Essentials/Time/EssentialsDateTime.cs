﻿using System;
using System.Globalization;
using Newtonsoft.Json;
using Skybrud.Essentials.Json.Converters.Time;

namespace Skybrud.Essentials.Time {

    // ReSharper disable InconsistentNaming
    
    /// <summary>
    /// Class wrapping an instance of <see cref="DateTimeOffset"/> (as an alternative to using <see cref="Nullable{DateTimeOffset}"/>).
    /// </summary>
    [JsonConverter(typeof(EssentialsDateTimeConverter))]
    public class EssentialsDateTime : IComparable, IComparable<EssentialsDateTime>, IComparable<DateTime> {

        #region Properties

        /// <summary>
        /// Gets a <see cref="EssentialsDateTime"/> object that is set to the current date and time on this computer,
        /// expressed as the local time.
        /// </summary>
        public static EssentialsDateTime Now {
            get { return new EssentialsDateTime(DateTime.Now); }
        }

        /// <summary>
        /// Gets the current UNIX timestamp (amount of seconds since the start of the Unix Epoch).
        /// </summary>
        public static long CurrentUnixTimestamp {
            get { return TimeUtils.GetUnixTimeFromDateTime(DateTime.Now); }
        }

        /// <summary>
        /// Gets an instance of <see cref="EssentialsDateTime"/> representing the start of the Unix Epoch (AKA <code>0</code> seconds).
        /// </summary>
        public static EssentialsDateTime Zero {
            get { return FromUnixTimestamp(0); }
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        public static EssentialsDateTime Today {
            get { return new EssentialsDateTime(DateTime.Today); }
        }

        /// <summary>
        /// Gets a <see cref="EssentialsDateTime"/> object that is set to the current date and time on this computer,
        /// expressed as the Coordinated Universal Time (UTC).
        /// </summary>
        public static EssentialsDateTime UtcNow {
            get { return new EssentialsDateTime(DateTime.UtcNow); }
        }

        /// <summary>
        /// Gets the wrapped <see cref="DateTime"/>.
        /// </summary>
        public DateTime DateTime { get; private set; }

        /// <summary>
        /// Returns the day-of-month part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>31</code>.
        /// </summary>
        public int Day {
            get { return DateTime.Day; }
        }

        /// <summary>
        /// Returns the day-of-week part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>6</code>, where <code>0</code> indicates <strong>Sunday</strong>, <code>1</code>
        /// indicates <strong>Monday</strong>, <code>2</code> indicates <strong>Tuesday</strong>, <code>3</code>
        /// indicates <strong>Wednesday</strong>, <code>4</code> indicates <strong>Thursday</strong>, <code>5</code>
        /// indicates <strong>Friday</strong>, and <code>6</code> indicates <strong>Saturday</strong>.
        /// </summary>
        public DayOfWeek DayOfWeek {
            get { return DateTime.DayOfWeek; }
        }

        /// <summary>
        /// Gets the day-of-year part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>366</code>.
        /// </summary>
        public int DayOfYear {
            get { return DateTime.DayOfYear; }
        }

        /// <summary>
        /// Gets the hour part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>23</code>.
        /// </summary>
        public int Hour {
            get { return DateTime.Hour; }
        }

        /// <summary>
        /// Gets the kind of the underlying <see cref="DateTime"/>.
        /// </summary>
        public DateTimeKind Kind {
            get { return DateTime.Kind; }
        }

        /// <summary>
        /// Gets the millisecond part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>999</code>.
        /// </summary>
        public int Millisecond {
            get { return DateTime.Millisecond; }
        }

        /// <summary>
        /// Gets the minute part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>59</code>.
        /// </summary>
        public int Minute {
            get { return DateTime.Minute; }
        }

        /// <summary>
        /// Gets the month part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>12</code>.
        /// </summary>
        public int Month {
            get { return DateTime.Month; }
        }

        /// <summary>
        /// Gets the second part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>0</code> and <code>59</code>.
        /// </summary>
        public int Second {
            get { return DateTime.Second; }
        }

        /// <summary>
        /// Gets the tick count for this <see cref="EssentialsDateTime"/>. The returned value is the number of
        /// 100-nanosecond intervals that have elapsed since <code>1/1/0001 12:00am</code>.
        /// </summary>
        public long Ticks {
            get { return DateTime.Ticks; }
        }

        /// <summary>
        /// Gets the time-of-day part of this <see cref="EssentialsDateTime"/>. The returned value is a
        /// <see cref="TimeSpan"/> that indicates the time elapsed since midnight.
        /// </summary>
        public TimeSpan TimeOfDay {
            get { return DateTime.TimeOfDay; }
        }
        
        /// <summary>
        /// Returns the year part of this <see cref="EssentialsDateTime"/>. The returned value is an integer between
        /// <code>1</code> and <code>9999</code>.
        /// </summary>
        public int Year {
            get { return DateTime.Year; }
        }

        /// <summary>
        /// Gets the UNIX timestamp (amount of seconds since the start of the Unix Epoch) for this <see cref="EssentialsDateTime"/>.
        /// </summary>
        public long UnixTimestamp {
            get { return TimeUtils.GetUnixTimeFromDateTime(DateTime); }
        }

        /// <summary>
        /// Gets whether the year of this <see cref="EssentialsDateTime"/> is a leap year.
        /// </summary>
        public bool IsLeapYear {
            get { return TimeUtils.IsLeapYear(DateTime); }
        }

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDateTime"/> is within a weekend.
        /// </summary>
        public bool IsWeekend {
            get { return TimeUtils.IsLeapYear(DateTime); }
        }

        /// <summary>
        /// Gets whether the day of this <see cref="EssentialsDateTime"/> is a weekday.
        /// </summary>
        public bool IsWeekday {
            get { return TimeUtils.IsWeekday(DateTime); }
        }

        /// <summary>
        /// Gets the week number the ISO8601 week of this <see cref="EssentialsDateTime"/>.
        /// </summary>
        public int WeekNumber {
            get { return TimeUtils.GetIso8601WeekNumber(DateTime); }
        }

        /// <summary>
        /// Gets a reference to an instance of <see cref="EssentialsDateWeek"/> representing the ISO8601 week of this
        /// <see cref="EssentialsDateTime"/>.
        /// </summary>
        public EssentialsDateWeek Week {
            get { return new EssentialsDateWeek(DateTime); }
        }

        /// <summary>
        /// Gets the amount of days in the month.
        /// </summary>
        public int DaysInMonth {
            get { return DateTime.DaysInMonth(Year, Month); }
        }

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTime"/> is <code>0</code>.
        /// </summary>
        public bool IsZero {
            get { return UnixTimestamp == 0; }
        }

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTime"/> is less than <code>0</code>.
        /// </summary>
        public bool IsNegative {
            get { return UnixTimestamp < 0; }
        }

        /// <summary>
        /// Gets whether the Unix timestamp of this <see cref="EssentialsDateTime"/> is greater than <code>0</code>.
        /// </summary>
        public bool IsPositive {
            get { return UnixTimestamp > 0; }
        }

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>ISO 8601</strong> format.
        /// </summary>
        public string ToIso8601 {
            get { return TimeUtils.ToIso8601(this); }
        }

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 822</strong> format.
        /// </summary>
        public string Rfc822 {
            get { return TimeUtils.ToRfc822(this); }
        }

        /// <summary>
        /// Gets a string representation of the instance as specified by the <strong>RFC 2822</strong> format.
        /// </summary>
        public string ToRfc2822 {
            get { return TimeUtils.ToRfc2822(this); }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on <see cref="System.DateTime.MinValue"/>.
        /// </summary>
        public EssentialsDateTime() {
            DateTime = DateTime.MinValue;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>dt</code>.
        /// </summary>
        /// <param name="dt">The an instance <see cref="DateTime"/> the instance should be based on.</param>
        public EssentialsDateTime(DateTime dt) {
            DateTime = dt;
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <code>ticks</code>.
        /// </summary>
        /// <param name="ticks">The amount ticks the instance should be based on.</param>
        public EssentialsDateTime(long ticks) {
            DateTime = new DateTime(ticks);
        }

        /// <summary>
        /// Initializes a new instance based on the specified amount of <code>ticks</code> and <code>kind</code>.
        /// </summary>
        /// <param name="ticks">The amount ticks the instance should be based on.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(long ticks, DateTimeKind kind) {
            DateTime = new DateTime(ticks, kind);
        }    

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code> and
        /// <code>day</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        public EssentialsDateTime(int year, int month, int day) {
            DateTime = new DateTime(year, month, day);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code> and
        /// <code>day</code> for the specified <code>calendar</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public EssentialsDateTime(int year, int month, int day, Calendar calendar) {
            DateTime = new DateTime(year, month, day, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>,
        /// <code>day</code>, <code>hour</code>, <code>minute</code> and <code>second</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second) {
            DateTime = new DateTime(year, month, day, hour, minute, second);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>,
        /// <code>day</code>, <code>hour</code>, <code>minute</code>, <code>second</code> and <code>kind</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, kind);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code> and <code>second</code> for the specified  <code>calendar</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code> and <code>millisecond</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code>, <code>millisecond</code> and <code>kind</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, kind);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code> and <code>millisecond</code> for the specified
        /// <code>calendar</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar);
        }

        /// <summary>
        /// Initializes a new instance based on the specified <code>year</code>, <code>month</code>, <code>day</code>,
        /// <code>hour</code>, <code>minute</code>, <code>second</code> and <code>millisecond</code> for the specified<code>calendar</code> and <code>kind</code>.
        /// </summary>
        /// <param name="year">The year (<code>1</code> through <code>9999</code>).</param>
        /// <param name="month">The month (<code>1</code> through <code>12</code>).</param>
        /// <param name="day">The day (<code>1</code> through the number of days in month).</param>
        /// <param name="hour">The hours (<code>0</code> through <code>23</code>).</param>
        /// <param name="minute">The minutes (<code>0</code> through <code>59</code>).</param>
        /// <param name="second">The seconds (<code>0</code> through <code>59</code>).</param>
        /// <param name="millisecond">The milliseconds (<code>0</code> through <code>999</code>).</param>
        /// <param name="calendar">The calendar that is used to interpret year, month, and day.</param>
        /// <param name="kind">One of the enumeration values that indicates whether ticks specifies a local time,
        /// Coordinated Universal Time (UTC), or neither.</param>
        public EssentialsDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, Calendar calendar, DateTimeKind kind) {
            DateTime = new DateTime(year, month, day, hour, minute, second, millisecond, calendar, kind);
        }

        #endregion

        #region Member methods
        
        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation. 
        /// </summary>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object.</returns>
        public override string ToString() {
            return DateTime.ToString(DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation
        /// using the specified <code>provider</code>.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object as specified by
        /// <code>provider</code>.</returns>
        public string ToString(IFormatProvider provider) {
            return DateTime.ToString(provider);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation using
        /// the specified <code>format</code>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object as specified by
        /// <code>format</code>.</returns>
        public string ToString(string format) {
            return DateTime.ToString(format, DateTimeFormatInfo.CurrentInfo);
        }

        /// <summary>
        /// Converts the value of the current <see cref="EssentialsDateTime"/> to its equivalent string representation using
        /// the specified <code>format</code> and <code>provider</code>.
        /// </summary>
        /// <param name="format">A standard or custom date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns>A string representation of value of the current <see cref="EssentialsDateTime"/> object as specified by
        /// <code>format</code> and <code>provider</code>.</returns>
        public string ToString(string format, IFormatProvider provider) {
            return DateTime.ToString(format, provider);
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the value of the specified
        /// <see cref="System.TimeSpan"/> to the value of this instance.
        /// </summary>
        /// <param name="value">A positive or negative time interval.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// interval represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less than
        /// <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime Add(TimeSpan value) {
            return new EssentialsDateTime(DateTime.Add(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of days to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of days represented by value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less than
        /// <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddDays(double value) {
            return new EssentialsDateTime(DateTime.AddDays(value));
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime"/> that adds the specified number of hours to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional hours. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of hours represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddHours(double value) {
            return new EssentialsDateTime(DateTime.AddHours(value));
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime"/> that adds the specified number of milliseconds to the value of
        /// this instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional milliseconds. The value parameter can be negative or
        /// positive. Note that this value is rounded to the nearest integer.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of milliseconds represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddMilliseconds(double value) {
            return new EssentialsDateTime(DateTime.AddMilliseconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="System.DateTime"/> that adds the specified number of minutes to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional minutes. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of minutes represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddMinutes(double value) {
            return new EssentialsDateTime(DateTime.AddMinutes(value));
        }

        /// <summary>
        /// Returns a new System.DateTime that adds the specified number of months to the value of this instance.
        /// </summary>
        /// <param name="months">A number of months. The months parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and months.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>. Or
        /// <code>months</code> is less than <code>-120000</code> or greater than <code>120000</code>.</exception>
        public EssentialsDateTime AddMonths(int months) {
            return new EssentialsDateTime(DateTime.AddMonths(months));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of seconds to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of whole and fractional seconds. The value parameter can be negative or
        /// positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of seconds represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddSeconds(double value) {
            return new EssentialsDateTime(DateTime.AddSeconds(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of ticks to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of 100-nanosecond ticks. The value parameter can be positive or negative.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the time
        /// represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddTicks(long value) {
            return new EssentialsDateTime(DateTime.AddTicks(value));
        }

        /// <summary>
        /// Returns a new <see cref="EssentialsDateTime"/> that adds the specified number of years to the value of this
        /// instance.
        /// </summary>
        /// <param name="value">A number of years. The value parameter can be negative or positive.</param>
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number
        /// of years represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime AddYears(int value) {
            return new EssentialsDateTime(DateTime.AddYears(value));
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="DateTime"/> value and returns an integer that
        /// indicates whether this instance is earlier than, the same as, or later than the specified
        /// <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <code>value</code> parameter.</returns>
        public int CompareTo(DateTime value) {
            return DateTime.CompareTo(value);
        }

        /// <summary>
        /// Compares the value of this instance to a specified <see cref="EssentialsDateTime"/> value and returns an
        /// integer that indicates whether this instance is earlier than, the same as, or later than the specified
        /// <see cref="EssentialsDateTime"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <code>value</code> parameter.</returns>
        public int CompareTo(EssentialsDateTime value) {
            return DateTime.CompareTo(value == null ? default(object) : value.DateTime);
        }

        /// <summary>
        /// Compares the value of this instance to a specified object that contains a specified <see cref="DateTime"/>
        /// value, and returns an integer that indicates whether this instance is earlier than, the same as, or later
        /// than the specified <see cref="DateTime"/> value.
        /// </summary>
        /// <param name="value">The value to compare to the current instance.</param>
        /// <returns>A signed number indicating the relative values of this instance and the <code>value</code> parameter.</returns>
        public int CompareTo(object value) {
            return DateTime.CompareTo(value);
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the standard date and
        /// time format specifiers.
        /// </summary>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with one of the standard date and time format specifiers.</returns>
        public string[] GetDateTimeFormats() {
            return DateTime.GetDateTimeFormats();
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the standard date and
        /// time format specifiers and the specified culture-specific formatting information.
        /// </summary>
        /// <param name="provider">An object that supplies culture-specific formatting information about this instance.</param>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with one of the standard date and time format specifiers.</returns>
        public string[] GetDateTimeFormats(IFormatProvider provider) {
            return DateTime.GetDateTimeFormats(provider);
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the specified standard
        /// date and time format specifier.
        /// </summary>
        /// <param name="format">A standard date and time format string.</param>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with the format standard date and time format specifier.</returns>
        public string[] GetDateTimeFormats(char format) {
            return DateTime.GetDateTimeFormats(format);
        }

        /// <summary>
        /// Converts the value of this instance to all the string representations supported by the specified standard
        /// date and time format specifier and culture-specific formatting information.
        /// </summary>
        /// <param name="format">A date and time format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information about this instance.</param>
        /// <returns>A string array where each element is the representation of the value of this instance formatted
        /// with one of the standard date and time format specifiers.</returns>
        public string[] GetDateTimeFormats(char format, IFormatProvider provider) {
            return DateTime.GetDateTimeFormats(format, provider);
        }

        /// <summary>
        /// Indicates whether the internal instance of <see cref="System.DateTime"/> is within the daylight saving time
        /// range for the current time zone.
        /// </summary>
        /// <summary>
        /// Returns <code>true</code> if <see cref="System.DateTime.Kind"/> is <see cref="System.DateTimeKind.Local"/>
        /// or <see cref="System.DateTimeKind.Unspecified"/> and the value of the internal instance of
        /// <see cref="System.DateTime"/> is within the daylight saving time range for the current time zone. Returns
        /// <code>false</code> if <see cref="System.DateTime.Kind"/> is <see cref="System.DateTimeKind.Utc"/>.
        /// </summary>
        public bool IsDaylightSavingTime() {
            return DateTime.IsDaylightSavingTime();
        }

        /// <summary>
        /// Serializes the internal <see cref="System.DateTime"/> object to a 64-bit binary value that subsequently can
        /// be used to recreate the <see cref="System.DateTime"/> object.
        /// </summary>
        /// <returns>A 64-bit signed integer that encodes the <see cref="System.DateTime.Kind"/> and
        /// <see cref="System.DateTime.Ticks"/> properties.</returns>
        public long ToBinary() {
            return DateTime.ToBinary();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to a Windows file time.
        /// </summary>
        /// <returns>The value of the internal <see cref="System.DateTime"/> object expressed as a Windows file time.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting file time would represent a date and
        /// time before 12:00 midnight January 1, 1601 C.E. UTC.</exception>
        public long ToFileTime() {
            return DateTime.ToFileTime();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to a Windows file time.
        /// </summary>
        /// <returns>The value of the internal <see cref="System.DateTime"/> object expressed as a Windows file time.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting file time would represent a date and
        /// time before 12:00 midnight January 1, 1601 C.E. UTC.</exception>
        public long ToFileTimeUtc() {
            return DateTime.ToFileTimeUtc();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to local time.
        /// </summary>
        /// <returns>An object whose <see cref="System.DateTime.Kind"/> property is
        /// <see cref="System.DateTimeKind.Local"/>, and whose value is the local time equivalent to the value of the
        /// internal <see cref="System.DateTime"/> object, or <see cref="System.DateTime.MaxValue"/> if the converted
        /// value is too large to be represented by a <see cref="System.DateTime"/> object, or
        /// <see cref="System.DateTime.MinValue"/> if the converted value is too small to be represented as a
        /// <see cref="System.DateTime"/> object.</returns>
        public EssentialsDateTime ToLocalTime() {
            return DateTime.ToLocalTime();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent long date string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the long date string representation of the current System.DateTime object.</returns>
        public string ToLongDateString() {
            return DateTime.ToLongDateString();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent long time string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the long time string representation of the current System.DateTime object.</returns>
        public string ToLongTimeString() {
            return DateTime.ToLongTimeString();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to the equivalent OLE Automation
        /// date.
        /// </summary>
        /// <returns>A double-precision floating-point number that contains an OLE Automation date equivalent to the
        /// value of this instance.</returns>
        /// <exception cref="System.OverflowException">The value of this instance cannot be represented as an OLE
        /// Automation Date.</exception>
        public double ToOADate() {
            return DateTime.ToOADate();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent short date string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the short date string representation of the internal
        /// <see cref="System.DateTime"/> object.</returns>
        public string ToShortDateString() {
            return DateTime.ToShortDateString();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to its equivalent short time string
        /// representation.
        /// </summary>
        /// <returns>A string that contains the short time string representation of the internal
        /// <see cref="System.DateTime"/> object.</returns>
        public string ToShortTimeString() {
            return DateTime.ToShortTimeString();
        }

        /// <summary>
        /// Converts the value of the internal <see cref="System.DateTime"/> object to Coordinated Universal Time (UTC).
        /// </summary>
        /// <returns>An object whose <code>System.DateTime.Kind</code> property is <code>System.DateTimeKind.Utc</code>,
        /// and whose value is the UTC equivalent to the value of the internal <see cref="System.DateTime"/> object, or
        /// <see cref="System.DateTime.MaxValue"/> if the converted value is too large to be represented by a
        /// <see cref="System.DateTime"/> object, or <see cref="System.DateTime.MinValue"/> if the converted value is
        /// too small to be represented by a <see cref="System.DateTime"/> object.</returns>
        public EssentialsDateTime ToUniversalTime() {
            return DateTime.ToUniversalTime();
        }
        
        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(DateTime value) {
            return DateTime.Subtract(value);
        }

        /// <summary>
        /// Subtracts the specified date and time from this instance.
        /// </summary>
        /// <param name="value">The date and time value to subtract.</param>
        /// <returns>A time interval that is equal to the date and time represented by this instance minus the date
        /// and time represented by value.</returns>
        public TimeSpan Subtract(EssentialsDateTime value) {
            if (value == null) throw new ArgumentNullException(null);
            return DateTime.Subtract(value.DateTime);
        }

        /// <summary>
        /// Subtracts the specified duration from this instance.
        /// </summary>
        /// <param name="value">The time interval to subtract.</param>
        /// <returns>An object that is equal to the date and time represented by this instance minus the time interval
        /// represented by value.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">The resulting <see cref="EssentialsDateTime"/> is less
        /// than <see cref="System.DateTime.MinValue"/> or greater than <see cref="System.DateTime.MaxValue"/>.</exception>
        public EssentialsDateTime Subtract(TimeSpan value) {
            return new EssentialsDateTime(DateTime.Subtract(value));
        }

        /// <summary>
        /// Gets the first day of the month based on this <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="DateTime"/> representing the first day of the month.</returns>
        public EssentialsDateTime GetFirstDayOfMonth() {
            return new EssentialsDateTime(TimeUtils.GetFirstDayOfMonth(DateTime));
        }

        /// <summary>
        /// Gets the last day of the month based on this <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <returns>Returns an instance of <see cref="EssentialsDateTime"/> representing the last day of the month.</returns>
        public EssentialsDateTime GetLastDayOfMonth() {
            return new EssentialsDateTime(TimeUtils.GetLastDayOfMonth(DateTime));
        }

        /// <summary>
        /// Gets the first day of the week based on this <see cref="EssentialsDateTime"/>. <code>Monday</code> is
        /// considered the first day of the week.
        /// </summary>
        /// <returns>Returns an instance of <see cref="EssentialsDateTime"/> representing the first day of the week.</returns>
        public EssentialsDateTime GetFirstDayOfWeek() {
            return new EssentialsDateTime(TimeUtils.GetFirstDayOfWeek(DateTime));
        }

        /// <summary>
        /// Gets the first day of the week based on this <see cref="EssentialsDateTime"/> and <code>startOfWeek</code>.
        /// </summary>
        /// <param name="startOfWeek">The first day of the week (eg. <code>Monday</code> or <code>Sunday</code>).</param>
        /// <returns>Returns an instance of <see cref="EssentialsDateTime"/> representing the first day of the week.</returns>
        public EssentialsDateTime GetFirstDayOfWeek(DayOfWeek startOfWeek) {
            return new EssentialsDateTime(TimeUtils.GetFirstDayOfWeek(DateTime, startOfWeek));
        }

        /// <summary>
        /// Gets the last day of the week based on this <see cref="EssentialsDateTime"/>. <code>Monday</code> is considered
        /// the first day of the week.
        /// </summary>
        /// <returns>Returns an instance of <see cref="EssentialsDateTime"/> representing the last day of the week.</returns>
        public EssentialsDateTime GetLastDayOfWeek() {
            return new EssentialsDateTime(TimeUtils.GetLastDayOfWeek(DateTime));
        }

        /// <summary>
        /// Gets the last day of the week based on this <see cref="EssentialsDateTime"/> and <code>startOfWeek</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="startOfWeek">The first day of the week (eg. <code>Monday</code> or <code>Sunday</code>).</param>
        /// <returns>Returns an instance of <see cref="EssentialsDateTime"/> representing the last day of the week.</returns>
        public EssentialsDateTime GetLastDayOfWeek(DateTime date, DayOfWeek startOfWeek) {
            return new EssentialsDateTime(TimeUtils.GetLastDayOfWeek(DateTime, startOfWeek));
        }

        /// <summary>
        /// Gets the English name of the day.
        /// </summary>
        /// <returns>Returns the English name of the day.</returns>
        public string GetDayName() {
            return TimeUtils.GetDayName(DateTime);
        }

        /// <summary>
        /// Gets the name of the day according to <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <returns>Returns the local name of the day.</returns>
        public string GetLocalDayName() {
            return TimeUtils.GetLocalDayName(DateTime);
        }

        /// <summary>
        /// Gets the name of the day according to <code>culture</code>.
        /// </summary>
        /// <param name="culture">The culture to be used.</param>
        /// <returns>Returns the local name of the day.</returns>
        public string GetLocalDayName(CultureInfo culture) {
            return TimeUtils.GetLocalDayName(DateTime, culture);
        }

        /// <summary>
        /// Gets the English name of the month.
        /// </summary>
        /// <returns>Returns the English name of the month.</returns>
        public string GetMonthName() {
            return TimeUtils.GetMonthName(DateTime);
        }

        /// <summary>
        /// Gets the name of the month according to <see cref="CultureInfo.CurrentCulture"/>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>Returns the local name of the month.</returns>
        public string GetLocalMonthName(DateTime date) {
            return TimeUtils.GetLocalMonthName(DateTime);
        }

        /// <summary>
        /// Gets the name of the month according to <code>culture</code>.
        /// </summary>
        /// <param name="culture">The culture to be used.</param>
        /// <returns>Returns the local name of the month.</returns>
        public string GetLocalMonthName(CultureInfo culture) {
            return TimeUtils.GetLocalMonthName(DateTime, culture);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified string into an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime Parse(string str) {
            return String.IsNullOrWhiteSpace(str) ? null : new EssentialsDateTime(DateTime.Parse(str));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromUnixTimestamp(int timestamp) {
            return new EssentialsDateTime(TimeUtils.GetDateTimeFromUnixTime(timestamp));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromUnixTimestamp(long timestamp) {
            return new EssentialsDateTime(TimeUtils.GetDateTimeFromUnixTime(timestamp));
        }

        /// <summary>
        /// Initialize a new instance from the specified UNIX timestamp.
        /// </summary>
        /// <param name="timestamp">The UNIX timestamp specified in seconds.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromUnixTimestamp(double timestamp) {
            return new EssentialsDateTime(TimeUtils.GetDateTimeFromUnixTime(timestamp));
        }

        /// <summary>
        /// Convert the specified <strong>ISO 8601</strong> string to an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The <strong>ISO 8601</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromIso8601(string str) {
            return new EssentialsDateTime(TimeUtils.Iso8601ToDateTime(str));
        }

        /// <summary>
        /// Convert the specified <strong>RFC 822</strong> string to an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromRfc822(string str) {
            return new EssentialsDateTime(TimeUtils.Rfc822ToDateTime(str));
        }

        /// <summary>
        /// Convert the specified <strong>RFC 2822</strong> string to an instance of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="str">The <strong>RFC 2822</strong> string to be converted.</param>
        /// <returns>An instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime FromRfc2822(string str) {
            return new EssentialsDateTime(TimeUtils.Rfc822ToDateTime(str));
        }

        #endregion

        #region Operator overloading

        /// <summary>
        /// Initializes a new instance of <see cref="EssentialsDateTime"/> from the specified <code>timestamp</code>.
        /// </summary>
        /// <param name="timestamp">An instance of <see cref="DateTime"/>.</param>
        /// <returns>Returns an instance of <see cref="EssentialsDateTime"/>.</returns>
        public static implicit operator EssentialsDateTime(DateTime timestamp) {
            return new EssentialsDateTime(timestamp);
        }

        /// <summary>
        /// Adds <code>date</code> and <code>timeSpan</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeSpan">The time that should be added to <code>date</code>.</param>
        /// <returns>Returns the result as a new instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime operator +(EssentialsDateTime date, TimeSpan timeSpan) {
            return new EssentialsDateTime(date.DateTime + timeSpan);
        }

        /// <summary>
        /// Subtracts <code>timeSpan</code> from <code>date</code>.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <param name="timeSpan">The time that should be subtracted from <code>date</code>.</param>
        /// <returns>Returns the result as a new instance of <see cref="EssentialsDateTime"/>.</returns>
        public static EssentialsDateTime operator -(EssentialsDateTime date, TimeSpan timeSpan) {
            return new EssentialsDateTime(date.DateTime - timeSpan);
        }
        
        /// <summary>
        /// Subtracts two instances of <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns the result as an instance of <see cref="TimeSpan"/>.</returns>
        public static TimeSpan operator -(EssentialsDateTime d1, EssentialsDateTime d2) {
            return d1.DateTime - d2.DateTime;
        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsDateTime"/> are equal.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns <code>true</code> if the two instances represent the same date and time, otherwise <code>false</code>.</returns>
        public static bool operator ==(EssentialsDateTime d1, EssentialsDateTime d2) {

            // Check for NULL conditions
            object value1 = d1;
            object value2 = d2;
            if (value1 == null) return value2 == null;
            if (value2 == null) return false;

            // Pass the comparison on the the == operator of DateTime
            return d1.DateTime == d2.DateTime;
        
        }

        /// <summary>
        /// Gets whether the timestamps represented by two instances of <see cref="EssentialsDateTime"/> are different from each other.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns <code>true</code> if the two instances represents a different date and time, otherwise <code>false</code>.</returns>
        public static bool operator !=(EssentialsDateTime d1, EssentialsDateTime d2) {
            return !(d1 == d2);
        }

        /// <summary>
        /// Gets whether <code>d1</code> is less than <code>d2</code>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns <code>true</code> if <code>d1</code> is less than <code>d2</code>, otherwise <code>false</code>.</returns>
        public static bool operator <(EssentialsDateTime d1, EssentialsDateTime d2) {

            // Check for NULL conditions
            if (d1 == null) return d2 != null;
            if (d2 == null) return false;

            // Pass the comparison on the the < operator of DateTime
            return d1.DateTime < d2.DateTime;
        
        }

        /// <summary>
        /// Gets whether <code>d1</code> is less than or equal to <code>d2</code>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns <code>true</code> if <code>d1</code> is less than or equal to <code>d2</code>, otherwise <code>false</code>.</returns>
        public static bool operator <=(EssentialsDateTime d1, EssentialsDateTime d2) {
            return d1 < d2 || d1 == d2;
        }

        /// <summary>
        /// Gets whether <code>d1</code> is greater than <code>d2</code>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns <code>true</code> if <code>d1</code> is greater than <code>d2</code>, otherwise <code>false</code>.</returns>
        public static bool operator >(EssentialsDateTime d1, EssentialsDateTime d2) {

            // Check for NULL conditions
            if (d2 == null) return d1 != null;
            if (d1 == null) return false;

            // Pass the comparison on the the > operator of DateTime
            return d1.DateTime > d2.DateTime;

        }

        /// <summary>
        /// Gets whether <code>d1</code> is greater than or equal to <code>d2</code>.
        /// </summary>
        /// <param name="d1">The first instance of <see cref="EssentialsDateTime"/>.</param>
        /// <param name="d2">The second instance of <see cref="EssentialsDateTime"/>.</param>
        /// <returns>Returns <code>true</code> if <code>d1</code> is greater than or equal to <code>d2</code>, otherwise <code>false</code>.</returns>
        public static bool operator >=(EssentialsDateTime d1, EssentialsDateTime d2) {
            return d1 > d2 || d1 == d2;
        }

        /// <summary>
        /// Gets whether this <see cref="EssentialsDateTime"/> equals the specified <code>obj</code>.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>Returns whether this <see cref="EssentialsDateTime"/> equals the specified <code>obj</code>.</returns>
        public override bool Equals(Object obj) {
            EssentialsDateTime time = obj as EssentialsDateTime;
            return time != null && (this == time);
        }

        /// <summary>
        /// Gets the hash code for this <see cref="EssentialsDateTime"/>.
        /// </summary>
        /// <returns>Returns the hash code of the object.</returns>
        public override int GetHashCode() {
            return DateTime.GetHashCode();
        }

        /// <summary>
        /// Returns the <see cref="System.TypeCode"/> for value type <see cref="DateTime"/>.
        /// </summary>
        /// <returns>The enumerated constant, <see cref="System.TypeCode.DateTime"/>.</returns>
        public TypeCode GetTypeCode() {
            return DateTime.GetTypeCode();
        }
 
        #endregion

    }
    
    // ReSharper restore InconsistentNaming

}