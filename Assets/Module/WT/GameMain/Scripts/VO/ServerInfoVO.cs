using System;
using ProtoBuf;

[ProtoContract]
public class ServerInfoVO
{
    [ProtoMember(1)]
    public string host;

    [ProtoMember(2)]
    public int port;

    [ProtoMember(3)]
    public string name;
 
    public ServerInfoVO()
	{
		
	}

    public override string ToString()
    {
        return "ServerInfoVO [host=" + host + ", port=" + port + ", name=" + name + "]";
    }
}
