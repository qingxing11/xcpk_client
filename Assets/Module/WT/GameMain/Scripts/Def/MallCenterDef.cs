using ProtoBuf;
using System.IO;
using System.IO.Compression;
using System;
using ICSharpCode.SharpZipLib.GZip;
/*
* 自动生成代码，请勿编辑
* WangTuo 	2018/5/21
*/
[ProtoContract]
public class MallCenterDef{
	private static MallCenterDef instance;

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
           instance = DeSerial<MallCenterDef>(data);
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



	public const int TYPE_1 = 0;
	public const int TYPE_2 = 1;
	public const int TYPE_3 = 2;
	public const int TYPE_4 = 3;
	public const int TYPE_5 = 4;
	public const int TYPE_6 = 5;
	public const int TYPE_7 = 6;
	public const int TYPE_8 = 7;
	public const int TYPE_9 = 8;
	public const int TYPE_10 = 9;
	public const int TYPE_11 = 10;
	public const int TYPE_12 = 11;
	public const int TYPE_13 = 12;
	public const int TYPE_14 = 13;

	[ProtoContract][Serializable]
	public class BeanDef{
		[ProtoMember(1)]
		public int goodsDefld;
		[ProtoMember(2)]
		public int mallPage;
		[ProtoMember(3)]
		public string goodsName;
		[ProtoMember(4)]
		public int goodsNum;
		[ProtoMember(5)]
		public int goodsId;
		[ProtoMember(6)]
		public string costName;
		[ProtoMember(7)]
		public int costNum;
		[ProtoMember(8)]
		public int costId;
	}
}