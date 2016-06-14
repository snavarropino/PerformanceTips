using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CloningBenchMark.Cloners
{
    public class SerializationCloner: BaseCloner
    {
        public SerializationCloner():base()
        {
            Trace.TraceInformation("SerializationCloner()");
        }

        public override T Clone<T>(T source)
        {
            StartTime();

            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", "source");
            }

            // Don't serialize a null object, simply return the default for that object
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }

            IFormatter formatter = new BinaryFormatter();
            
            using (Stream stream = new MemoryStream())
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);

                var result= (T)formatter.Deserialize(stream);
                TraceTime();
                return result;
            }
        }        
    }
}
