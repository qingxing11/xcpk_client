using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ProtoContract]

public class FriendsDataVO
{
    [ProtoMember(1)]
    public FriendsData friendsData;

    [ProtoMember(2)]
    public bool stateOnLine;

    public override string ToString()
    {
        return "FriendsDataVO [FriendsData=" + friendsData + ",stateOnLine" + stateOnLine + "]";
    }
}
