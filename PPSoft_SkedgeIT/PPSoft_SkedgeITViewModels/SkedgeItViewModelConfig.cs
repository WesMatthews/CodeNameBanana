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

namespace PPSoft_SkedgeITViewModels
{
    public class SkedgeITViewModelConfig
    {
        public static void ErrorRoutine(Exception e, string obj, string method)
        {
            //debug to console to get around privilege issues with writing
            //during development
            if (e.InnerException != null)
            {
                Debug.WriteLine("Error in eStoreModels, object=" + obj +
                    ", method=" + method +
                    " , inner exception message=" +
                    e.InnerException.Message, EventLogEntryType.Error);
                throw e.InnerException;
            }
            else
            {
                Debug.WriteLine("Error in eStoreModels, object=" + obj +
                    ", method=" + method + " , message=" +
                    e.Message, EventLogEntryType.Error);
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
        ///<summary>
        ///Deserializer
        ///</summary>
        ///<param name="ByteArrayIn"> serialized Object
        ///<returns> Reconstructed Object</returns>
        public static Object Deserializer(byte[] ByteArrayIn)
        {
            BinaryFormatter frm = new BinaryFormatter();
            MemoryStream strm = new MemoryStream(ByteArrayIn);
            Object returnObject = frm.Deserialize(strm);
            return returnObject;
        }
    }
}
