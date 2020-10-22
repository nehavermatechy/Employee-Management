using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EmployeeManagement.Repositories.Extensions
{
    public static class ExtensionHelper
    {
        public static T Cast<T>(this Object myobj)
        {
            Type objectType = myobj.GetType();
            Type target = typeof(T);
            var taretInstance = Activator.CreateInstance(target, false);
            var sourceInstance = from source in target.GetMembers().ToList()
                    where source.MemberType == MemberTypes.Property
                    select source;
            List<MemberInfo> members = sourceInstance.Where(memberInfo => sourceInstance.Select(c => c.Name)
               .ToList().Contains(memberInfo.Name)).ToList();
            PropertyInfo propertyInfo;
            object value;
            foreach (var memberInfo in members)
            {
                propertyInfo = typeof(T).GetProperty(memberInfo.Name);
                value = myobj.GetType().GetProperty(memberInfo.Name)?.GetValue(myobj, null);

                propertyInfo.SetValue(taretInstance, value, null);
            }
            return (T)taretInstance;
        }
    }
}
