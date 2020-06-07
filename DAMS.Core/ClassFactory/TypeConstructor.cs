using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAMS.Core.ClassFactory
{
    public class TypeConstructor
    {
        private Type type;
        private object[] constructorParameters;

        public TypeConstructor(Type type, params object[] constructorParameters)
        {
            this.type = type;
            this.constructorParameters = constructorParameters;
        }
        public TypeConstructor(Type type)
            : this(type, null)
        {

        }
        public Type Type
        {
            get
            {
                return type;
            }
        }
        public object[] ConstructorParameters
        {
            get
            {
                return constructorParameters;
            }
        }
    }
}
