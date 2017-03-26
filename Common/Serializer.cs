using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common
{
  public class Serializer
  {
    public static byte[] Serialize(object objectToSerialize)
    {
      IFormatter formatter = new BinaryFormatter();
      MemoryStream memStream = new MemoryStream();

      formatter.Serialize(memStream, objectToSerialize);

      return memStream.GetBuffer();
    }

    public static object Deserialize(byte[] streamToDeserialize)
    {
      IFormatter formatter = new BinaryFormatter();
      MemoryStream memStream = new MemoryStream(streamToDeserialize);

      return formatter.Deserialize(memStream);
    }
  }
}
