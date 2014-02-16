using ITMCServiceCenter.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITMCServiceCenter.Web.DLL
{
    public interface IManager<T>
    {
         List<T> GetList(byte typeMasterId, int typeId);
         bool Save(List<T> members, byte typeMasterId, int typeId);
    }
}
