using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class AddFriendAgreeRequest:Request
{
    [ProtoMember(3)]
    public int id;//请求添加好友方

    [ProtoMember(4)]
    public bool result;//结果

    public AddFriendAgreeRequest()
    {
        this.msgType = MsgType.Agree_同意添加好友;
    }

    public AddFriendAgreeRequest(int id, bool result)
    {
        this.msgType = MsgType.Agree_同意添加好友;
        this.id = id;
        this.result = result;
    }
    public override string ToString()
    {
        return "AddFriendAgreeRequest  添加好友同意请求[好友id=" + id + "]";
    }
}
