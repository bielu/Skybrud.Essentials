﻿using System;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Boolean"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).</returns>
        public static bool ParseBoolean(string str) {
            return ParseBoolean(str, false);
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Boolean"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>, or <c>false</c>
        /// if it matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case insensitive.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>,
        /// <c>false</c> if <paramref name="str"/> matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. For
        /// all other values, <paramref name="fallback"/> is returned instead.</returns>
        public static bool ParseBoolean(string str, bool fallback) {

            switch ((str ?? string.Empty).ToLower()) {

                case "true":
                case "1":
                case "t":
                case "on":
                    return true;

                case "false":
                case "0":
                case "f":
                case "off":
                    return false;

                default:
                    return fallback;

            }

        }

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <see cref="Boolean"/>. The value
        /// is considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c> (case insensitive).</returns>
        public static bool ParseBoolean(object value) {
            return ParseBoolean(value + string.Empty);
        }

        /// <summary>
        /// Parses the specified <paramref name="value"/> into an instance of <see cref="Boolean"/>. The string is
        /// considered <c>true</c> if it matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>, or <c>false</c>
        /// if it matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. All comparisons are case insensitive.
        /// </summary>
        /// <param name="value">The value to be parsed.</param>
        /// <param name="fallback">The fallback value.</param>
        /// <returns><c>true</c> if <paramref name="value"/> matches either <c>true</c>, <c>1</c>, <c>t</c> or <c>on</c>,
        /// <c>false</c> if <paramref name="value"/> matches either <c>false</c>, <c>0</c>, <c>f</c> or <c>off</c>. For
        /// all other values, <paramref name="fallback"/> is returned instead.</returns>
        public static bool ParseBoolean(object value, bool fallback) {
            return ParseBoolean(value + string.Empty, fallback);
        }

    }

}