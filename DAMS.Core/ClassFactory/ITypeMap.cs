using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAMS.Interface;

namespace DAMS.Core.ClassFactory
{
    /// <summary> 
    /// 管理抽象类型与实体类型的字典类型 
    /// </summary> 
    public interface ITypeMap
    {
        TypeConstructor this[Type target] { get; }
    } 
}
