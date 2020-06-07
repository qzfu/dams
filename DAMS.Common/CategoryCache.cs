using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Common
{
    public class CategoryCache
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="value"></param>
        /// <param name="expireMinutes">过期时间（分钟）</param>
        /// <param name="name"></param>
        public static void Set(object value, int expireMinutes, params string[] name)
        {
            if (name == null)
            {
                return;
            }
            ObjectCache cache = MemoryCache.Default;
            string key = string.Join("_", name);
            if (cache.Contains(key))
            {
                cache.Remove(key);
            }
            cache.Set(key, value, DateTimeOffset.Now.AddMinutes(expireMinutes));
        }

        /// <summary>
        /// 级联删除缓存
        /// </summary>
        /// <param name="name"></param>
        public static void DeleteCascade(params string[] name)
        {
            if (name == null)
            {
                return;
            }
            string key = string.Join("_", name);
            ObjectCache cache = MemoryCache.Default;
            var caches = cache.Where(c => Match(key, c.Key));
            string[] keys = caches.Select(c => c.Key).ToArray();
            foreach (string s in keys)
            {
                cache.Remove(s);
            }
        }

        /// <summary>
        /// 获取缓存内容
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static Object Get(params string[] name)
        {
            if (name == null)
            {
                return null;
            }
            string key = string.Join("_", name);
            ObjectCache cache = MemoryCache.Default;
            if (!cache.Contains(key))
            {
                return null;
            }
            return cache[key];
        }
        /// <summary>
        /// 匹配字符串
        /// </summary>
        /// <param name="parentStr"></param>
        /// <param name="childStr"></param>
        /// <returns></returns>
        private static bool Match(string parentStr, string childStr)
        {
            string[] parentArr = parentStr.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);
            string[] childArr = childStr.Split(new string[] { "_" }, StringSplitOptions.RemoveEmptyEntries);

            if (parentArr.Length > childArr.Length)
            {
                return false;
            }
            for (int i = 0; i < parentArr.Length; i++)
            {
                string pStr = parentArr[i];
                string cStr = childArr[i];
                if (!pStr.Equals(cStr))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
