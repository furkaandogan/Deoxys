using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Deoxys
{

    /// <summary>
    /// enum tipleri için yarcımcı methodları barındırır
    /// </summary>
    /// <typeparam name="T">enum tipi</typeparam>
    public static class EnumHelpers<T>
    {

        /// <summary>
        /// enum da display attribute unde verilen name göre kendisini bulur
        /// </summary>
        /// <param name="name">display name</param>
        /// <returns></returns>
        public static T GetValueFromName(string name)
        {
            Type type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            foreach (FieldInfo field in type.GetFields())
            {
                DisplayAttribute attribute = Attribute.GetCustomAttribute(field,
                    typeof(DisplayAttribute)) as DisplayAttribute;
                if (attribute != null)
                {
                    if (attribute.Name == name)
                    {
                        return (T)field.GetValue(null);
                    }
                }
                else
                {
                    if (field.Name == name)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentOutOfRangeException("name");
        }

        /// <summary>
        /// enum da display attribute unde verilen name göre kendisini bulur
        /// </summary>
        /// <param name="name">display name</param>
        /// <returns></returns>
        public static string GetName(T value)
        {
            Type type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();

            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

            DisplayAttribute attribute = Attribute.GetCustomAttribute(fieldInfo,
                   typeof(DisplayAttribute)) as DisplayAttribute;
            if (attribute != null)
            {
                return attribute.Name;
            }

            throw new ArgumentOutOfRangeException("value");
        }
    }
}