using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class LookFriendsResponse:Response
{
    public const int ERROR_查无此人 = 0;

    [ProtoMember(4)]
    public int code;
    [ProtoMember(5)]
    public FriendsDataVO vo;

    public LookFriendsResponse()
    {
    }
    public override string ToString()
    {
        return "LookFriendsResponse [vo=" + vo + "]";
    }
}
