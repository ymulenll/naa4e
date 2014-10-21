using System;
using System.Linq;

namespace WaterpoloScoring.Framework.Utils
{
    public static class StringExtensions
    {

        /// <summary>
        /// Indicate whether a given string equals any of the specified substrings. 
        /// </summary>
        /// <param name="theString">String to process</param>
        /// <param name="args">List of possible matches</param>
        /// <returns>True/False</returns>
        public static Boolean EqualsAny(this String theString, params String[] args)
        {
            return args.Any(token => theString.Equals(token, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}