using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Common
{
    /// <summary>
    /// 枚举信息
    /// </summary>
    public class EnumInfo
    {
        internal EnumInfo() { }

        /// <summary>
        /// 枚举的键，通常是枚举类型的成员名
        /// </summary>
        public string Key { get; internal set; }

        /// <summary>
        /// 枚举的值，通常是枚举类型成员的int值
        /// </summary>
        public int Value { get; internal set; }

        /// <summary>
        /// 枚举的描述，通常是枚举类型成员的 Description 特性的值，未定义 Description 成员取成员名称
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// 枚举的枚举类型值
        /// </summary>
        public object EnumValue { get; internal set; }

        /// <summary>
        /// 枚举的枚举类型值
        /// </summary>
        public int Sort { get; internal set; }

        public bool IsEmpty { get; private set; }

        internal List<string> PrefixList { get; set; }

        private static EnumInfo empty;
        public static EnumInfo Empty
        {
            get
            {
                return empty ?? (empty = new EnumInfo
                {
                    IsEmpty = true,
                    Description = string.Empty,
                    EnumValue = null,
                    Key = string.Empty,
                });
            }
        }
    }

    /// <summary>
    /// 枚举个工具类
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// 强转为枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static T Parse<T>(string text)
        {
            return (T)System.Enum.Parse(typeof(T), text);
        }

        /// <summary>
        /// 尝试转换为枚举类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool TryParse<T>(string text, out T value)
        {
            value = default(T);
            var type = typeof(T);
            if (type.IsEnum)
            {
                try
                {
                    value = (T)System.Enum.Parse(type, text);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 根据枚举的Key去枚举信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static EnumInfo GetByKey<T>(string key)
        {
            var infos = GetEnumDictionary<T>();
            return infos.FirstOrDefault(x => x.Key == key) ?? EnumInfo.Empty;
        }

        /// <summary>
        /// 根据枚举值取枚举信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="returnWhenMore">如果同一个枚举类型中某值对应多个枚举项，是否返回枚举信息，默认返回</param>
        /// <returns></returns>
        public static EnumInfo GetByValue<T>(int value, bool returnWhenMore = true)
        {
            var infos = GetEnumDictionary<T>();
            if (!returnWhenMore)
            {
                var count = infos.Count(x => x.Value == value);
                if (count > 1) return EnumInfo.Empty;
            }
            return infos.FirstOrDefault(x => x.Value == value) ?? EnumInfo.Empty;
        }

        /// <summary>
        /// 根据枚举项返回枚举信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static EnumInfo GetByValue<T>(T enumValue)
        {
            return GetByValue((object)enumValue);
        }

        /// <summary>
        /// 根据枚举项返回枚举信息
        /// </summary>
        /// <param name="enumValue"></param>
        /// <returns></returns>
        public static EnumInfo GetByValue(object enumValue)
        {
            Type enumType = enumValue.GetType();

            if (!enumType.IsEnum)
                throw new Exception("类型(" + enumType.FullName + ")不是枚举类型。");

            var propertyInfo = enumType.GetField(enumValue.ToString(), BindingFlags.Public | BindingFlags.Static);
            if (propertyInfo == null)
            {
                return EnumInfo.Empty;
            }
            return GetEnumInfo(propertyInfo);
        }

        private static EnumInfo GetEnumInfo(FieldInfo propertyInfo, object enumValue = null, bool calPrefix = false)
        {
            if (enumValue == null)
            {
                enumValue = propertyInfo.GetValue(null);
            }
            var value = (int)enumValue;
            var key = propertyInfo.Name;
            var rtn = new EnumInfo
            {
                Key = key,
                Value = value,
                EnumValue = enumValue,
                PrefixList = new List<string>()
            };

            var attr = propertyInfo.GetCustomAttribute<DescriptionAttribute>();
            if (attr != null)
            {
                var desc = attr.Description;
                rtn.Description = desc;

            }
            else
            {
                rtn.Description = rtn.Key;
            }

            return rtn;
        }

        /// <summary>
        /// 根据描述返回枚举信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="description"></param>
        /// <param name="returnWhenMore">如果同一个枚举类型中某值对应多个枚举项，是否返回枚举信息，默认返回</param>
        /// <returns></returns>
        public static EnumInfo GetByDescription<T>(string description, bool returnWhenMore = true)
        {
            var infos = GetEnumDictionary<T>();
            if (!returnWhenMore)
            {
                var count = infos.Count(x => x.Description == description);
                if (count > 1) return EnumInfo.Empty;
            }
            return infos.FirstOrDefault(x => x.Description == description) ?? EnumInfo.Empty;
        }

        /// <summary>
        /// 返回枚举字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<EnumInfo> GetEnumDictionary<T>()
        {
            return GetEnumDictionary(typeof(T));
        }

        /// <summary>
        /// 返回枚举字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static List<EnumInfo> GetEnumDictionary(Type enumType)
        {
            return GetEnumDictionary(enumType, false);
        }

        /// <summary>
        /// 返回枚举字典
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="calPrefix"></param>
        /// <returns></returns>
        internal static List<EnumInfo> GetEnumDictionary(Type enumType, bool calPrefix)
        {
            if (!enumType.IsEnum)
                throw new Exception("类型(" + enumType.FullName + ")不是枚举类型。");

            var ps = enumType.GetFields(BindingFlags.Public | BindingFlags.Static);
            return ps.Select(propertyInfo => GetEnumInfo(propertyInfo, null, calPrefix)).Where(x => x != null && !x.IsEmpty).ToList();
        }
    }
}
