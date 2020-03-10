
using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class HotfixUpdateFileVO
{

    /**
	 * 所有文件
	 */
    [ProtoMember(1)]
    public List<string> list_fileUrl = new List<string>();

    /**
	 * 下载路径，公共部分
	 */
    [ProtoMember(2)]
    public string url_path;

    /**
	 * 总字节数
	 */
    [ProtoMember(3)]
    public int allSize;

    /**
	 * 对应的版本号
	 */
    [ProtoMember(4)]
    public int version;

    [ProtoMember(5)]
    public string gateway_host;

    [ProtoMember(6)]
    public int gateway_port;

   
    public override string ToString()
    {
        return "HotfixUpdateFileVO [list_fileUrl=" + list_fileUrl + ", url_path=" + url_path + ", allSize=" + allSize + ", version=" + version + "]";
    }



}
