using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CloningBenchMark.Cloners
{

    public class ReflectionCloner : BaseCloner
    {

        public ReflectionCloner()
            : base()
        {
            Trace.TraceInformation("ReflectionCloner()");
        }

        public override T Clone<T>(T source)
        {
            StartTime();

            var res= CloneRec(source);

            TraceTime();

            return res;
        }

        protected T CloneRec<T>(T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            var destination = Activator.CreateInstance(source.GetType());
            var props = destination.GetType().GetProperties();
            int propIndex = 0;

            foreach (var propInfo in props)
            {
                if (propInfo.GetValue(source,null) != null)
                {

                    if (ImplementsInterface(propInfo.PropertyType, "IList"))
                    {
                        var enumerable = (IEnumerable)propInfo.GetValue(source,null);
                        //int i = 0;
                        IList list = (IList)propInfo.GetValue(destination,null);
                        foreach (var item in enumerable)
                            list.Add(CloneRec(item));
                    }
                    else if (ImplementsInterface(propInfo.PropertyType, "ICloneable"))
                    {
                        props[propIndex].SetValue(destination, ((ICloneable)propInfo.GetValue(source, null)).Clone(), null);
                    }
                    else if(propInfo.PropertyType.IsValueType)
                    {
                        props[propIndex].SetValue(destination, propInfo.GetValue(source, null), null);
                    }
                    else
                    {
                        props[propIndex].SetValue(destination, CloneRec(propInfo.GetValue(source, null)),null);
                    }
                }
                propIndex++;
            }            
            return (T)destination;
        }     
        
        public static bool ImplementsInterface(Type type, string interfaceName) 
        { 
            return type.GetInterface(interfaceName, true) != null; 
        }
    }
}
