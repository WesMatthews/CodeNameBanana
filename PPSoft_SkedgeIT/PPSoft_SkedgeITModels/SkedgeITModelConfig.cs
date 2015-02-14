using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Diagnostics;
using System.Data;
using System.Runtime.Serialization;

namespace PPSoft_SkedgeITModels
{
    public class SkedgeITModelConfig
    {
        public static void ErrorRoutine(Exception e, string obj, string method)
        {
            //debug to console to get around privilege issues with writing to log file
            //during development

            if(e.InnerException != null)
            {
                Debug.WriteLine("Error in eStoreModels, object=" + obj +
                    ", method=" + method +
                    ", inner exception message=" +
                    e.InnerException.Message, EventLogEntryType.Error);
                throw e.InnerException;
            }
            else
            {
                Debug.WriteLine("Error in eStoreModels, object=" + obj +
                    ", method=" + method + ", message=" +
                    e.Message, EventLogEntryType.Error);
                throw e;
            }
        }

        public static byte[] Serializer(Object inObject)
        {
            BinaryFormatter frm = new BinaryFormatter();
            MemoryStream strm = new MemoryStream();
            frm.Serialize(strm, inObject);
            byte[] ByteArrayObject = strm.ToArray();
            return ByteArrayObject;
        }

        public static Object Deserializer(byte[] ByteArrayIn)
        {
            BinaryFormatter frm = new BinaryFormatter();
            MemoryStream strm = new MemoryStream(ByteArrayIn);
            Object returnObject = frm.Deserialize(strm);
            return returnObject;
        }
    }
}
