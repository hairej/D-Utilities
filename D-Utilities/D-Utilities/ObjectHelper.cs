using System;
using System.Collections.Generic;
using System.Reflection;
namespace D_Utilities
{
    public class ObjectHelper
    {
        /// <summary>
        /// Determines if two specified object's properties are equal to each other.
        /// </summary>
        /// <param name="Object1"></param>
        /// <param name="Object2"></param>
        /// <returns></returns>
        public static bool Equals(object Object1, object Object2)
        {
            if (Object1.ToString() != Object2.ToString())
            {
                return false;
            }
            else
            {
                try
                {
                    List<bool> comparisonResults = new List<bool>();

                    foreach (PropertyInfo propertyInfo in Object1.GetType().GetProperties())
                    {
                        var currentValue = propertyInfo.GetValue(Object1);

                        var newValue = propertyInfo.GetValue(Object2);

                        if (newValue.ToString() != currentValue.ToString())
                        {
                            comparisonResults.Add(false);
                        }
                        else
                        {
                            comparisonResults.Add(true);
                        }
                    }

                    if (comparisonResults.Contains(false))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Compares two specified objects of the same class.
        /// Returns Dictionary with property names and a bool.
        /// True means the properties in both ojects were equal. False means they were not equal.
        /// </summary>
        /// <param name="Object1"></param>
        /// <param name="Object2"></param>
        /// <returns> </returns>
        public static Dictionary<string, bool> Compare(object Object1, object Object2)
        {
            Dictionary<string, bool> CompareObjects = new Dictionary<string, bool>();

            if (Object1.ToString() != Object2.ToString())
            {
                return null;
            }
            else
            {
                try
                {
                    foreach (PropertyInfo propertyInfo in Object1.GetType().GetProperties())
                    {
                        var currentValue = propertyInfo.GetValue(Object1);

                        var newValue = propertyInfo.GetValue(Object2);

                        var propertyName = propertyInfo.Name;

                        if (newValue.ToString() != currentValue.ToString())
                        {
                            CompareObjects.Add(propertyName, false);
                        }
                        else
                        {
                            CompareObjects.Add(propertyName, true);
                        }
                    }
                    return CompareObjects;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}

