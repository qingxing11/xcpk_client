using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AskFriendsResponse:Response
{
    public const int ERROR_NUll = 0; //没有好友

    [ProtoMember(4)]
    public int code;

    [ProtoMember(5)]
    public List<FriendsDataVO> friends_list;

    public AskFriendsResponse()
    {
        this.msgType = MsgType.ASKFRIENDS;
    }
    public AskFriendsResponse(int code)
    {
        this.msgType = MsgType.ASKFRIENDS;
        this.code = code;
    }
    public override string ToString()
    {
        return "AskFriendsResponse [friends_list=" + friends_list + "]";
    }
}
