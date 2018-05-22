using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IService<T> where T : class
    {
        ICollection<T> Get(string controllerName, string actionName);
        T Get(string controllerName, string actionName, int id);
        T Get(string controllerName, string actionName, Dictionary<string,string> parameters);
    }
}
