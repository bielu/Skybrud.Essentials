﻿using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Skybrud.Essentials.Strings {

    public static partial class StringUtils {

        /// <summary>
        /// Gets whether the string matches an integer (<see cref="Int32"/>).
        /// </summary>
        /// <param name="str">The string to validate.</param>
        /// <returns><c>true</c> if <paramref name="str"/> matches a long; otherwise <c>false</c>.</returns>
        public static bool IsInt32(string str) {
            return int.TryParse(str, NumberStyles.Integer, CultureInfo.InvariantCulture, out _);
        }
        
        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Int32"/>. If the parsing fails,
        /// the default value of <see cref="Int32"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <returns>An instance of <see cref="Int32"/>.</returns>
        public static int ParseInt32(string str) {
            int.TryParse(str, out int value);
            return value;
        }

        /// <summary>
        /// Parses the specified <paramref name="str"/> into an instance of <see cref="Int32"/>. If the parsing fails,
        /// <paramref name="fallback"/> will be returned instead.
        /// </summary>
        /// <param name="str">The string to be parsed.</param>
        /// <param name="fallback">The fallback value that will be returned if the parsing fails.</param>
        /// <returns>An instance of <see cref="Int32"/>.</returns>
        public static int ParseInt32(string str, int fallback) {
            return int.TryParse(str, out int value) ? value : fallback;
        }

        /// <summary>
        /// Parses a string of integer values into an array of <see cref="Int32"/>. Supported separators are
        /// <c>,</c>, <c> </c>, <c>\r</c>, <c>\n</c> and <c>\t</c>. Values in the list
        /// that can't be converted to <see cref="Int32"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of integer values to be parsed.</param>
        /// <returns>An array of <see cref="Int32"/>.</returns>
        public static int[] ParseInt32Array(string str) {
            return ParseInt32Array(str, ',', ' ', '\r', '\n', '\t');
        }

        /// <summary>
        /// Parses a string of integer values into an array of <see cref="Int32"/>. Values in the list that can't be
        /// converted to <see cref="Int32"/> will be ignored.
        /// </summary>
        /// <param name="str">The string of integer values to be parsed.</param>
        /// <param name="separators">An array of supported separators.</param>
        /// <returns>An array of <see cref="Int32"/>.</returns>
        public static int[] ParseInt32Array(string str, params char[] separators) {
            return (
                from piece in (str ?? "").Split(separators, StringSplitOptions.RemoveEmptyEntries)
                where Regex.IsMatch(piece, "^(-|)[0-9]+$")
                select int.Parse(piece)
            ).ToArray();
        }

    }

}