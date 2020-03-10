using ProtoBuf;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using System;
/*
* 自动生成代码，请勿编辑
* WangTuo 	2018/4/24
*/
[ProtoContract]
public class ChatMessageTxt{
	private static ChatMessageTxt instance;

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
           instance = DeSerial<ChatMessageTxt>(data);
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



	public const int TYPE_txt1 = 0;
	public const int TYPE_txt2 = 1;
	public const int TYPE_txt3 = 2;
	public const int TYPE_txt4 = 3;
	public const int TYPE_txt5 = 4;
	public const int TYPE_txt6 = 5;
	public const int TYPE_txt7 = 6;

	[ProtoContract]
	public class BeanDef{
		[ProtoMember(1)]
		public string text;
	}
}