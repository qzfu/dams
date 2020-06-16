using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Interface;

namespace DAMS.Core.ClassFactory
{
    public class ObjectFactory : ITypeMap
    {
        private Dictionary<Type, TypeConstructor> dictionary = new Dictionary<Type, TypeConstructor>();
        public static readonly ITypeMap Instance;

        /// <summary> 
        /// Singleton 
        /// </summary> 
        private ObjectFactory() { }
        static ObjectFactory()
        {
            ObjectFactory singleton = new ObjectFactory();
            // 注册抽象类型需要使用的实体类型 
            // 该类型实体具有构造参数，实际的配置信息可以从外层机制获得。 
            singleton.dictionary.Add(typeof(IUserService), new TypeConstructor(typeof(UserService)));
            singleton.dictionary.Add(typeof(IResourceService), new TypeConstructor(typeof(ResourceService)));
            //新接口注入在下面增加
            Instance = singleton;
        }

        /// <summary> 
        /// 根据注册的目标抽象类型，返回一个实体类型及其构造参数数组
        /// </summary> 
        /// <param name="type"></param> 
        /// <returns></returns> 
        public TypeConstructor this[Type type]
        {
            get
            {
                TypeConstructor result;
                if (!dictionary.TryGetValue(type, out result))
                    return null;
                else
                    return result;
            }
        }
    }

    public class Assembler<T> where T : class
    {
        /// <summary> 
        /// 其实TypeMap工程上本身就是个需要注入的类型，可以通过访问配置系统获得
        /// </summary> 
        private static ITypeMap map = ObjectFactory.Instance;
        public static T Create()
        {
            TypeConstructor constructor = map[typeof(T)];
            if (constructor != null)
            {
                if (constructor.ConstructorParameters == null)
                    return (T)Activator.CreateInstance(constructor.Type);
                else
                    return (T)Activator.CreateInstance(constructor.Type, constructor.ConstructorParameters);
            }
            else
                return null;
        }
    }
}
