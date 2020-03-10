using ProtoBuf;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using System;
/*
* 自动生成代码，请勿编辑
* WangTuo 	2018/4/24
*/
[ProtoContract]
public class TVDef{
	private static TVDef instance;

	[ProtoMember(1)]
	public BeanDef[] defs;

	
	//功能代码块
	public static BeanDef[] Defs
    {
        get
        {
            if (instance == null)
            {
                throw new Exception("未初始化");
            }
            return instance.defs;
        }
    }

	public static BeanDef[] GetDefs(int index)
    {
       if (instance == null)
       {
           InitData(index);
       }
       return instance.defs;
    }

	public static void InitData(int index)
    {
       if (instance == null)
       {
           byte[] data = FileIO.LoadBytes(index);
           data = DecompressGZip(data);
           instance = DeSerial<TVDef>(data);
       }
    }

	private static T DeSerial<T>(byte[] msg)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(msg, 0, msg.Length);
            ms.Position = 0;
            T obj = Serializer.Deserialize<T>(ms);
            return obj;
        }
    }

	private static byte[] DecompressGZip(byte[] data)
    {
        MemoryStream ms = new MemoryStream(data);
        int bufferSize = 8192;
        int bytesRead = 0;
        byte[] buffer = new byte[bufferSize];
        GZipInputStream decompressionStream = new GZipInputStream(ms);
        ms = new MemoryStream();
        while ((bytesRead = decompressionStream.Read(buffer, 0, bufferSize)) > 0)
        {
            ms.Write(buffer, 0, bytesRead);
        }
        byte[] deData = ms.ToArray();
        ms.Close();
        decompressionStream.Close();
        return deData;
    }



	public const int TYPE_江苏电视台 = 0;
	public const int TYPE_徐州电视台 = 1;
	public const int TYPE_泰州电视台 = 2;

	[ProtoContract]
	public class BeanDef{
		[ProtoMember(1)]
		public int tv_id;
		[ProtoMember(2)]
		public string tv_name;
	}
}