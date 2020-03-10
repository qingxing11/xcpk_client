using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
  public  class ManyPepolRoomRoundDataVO
{
    [ProtoMember(1)]
    public int pos;
    [ProtoMember(2)]
    public long roundBet;
    [ProtoMember(3)]
    public List<PokerVO> list_handPoker;
    [ProtoMember(4)]
    public int pokerType;

    public ManyPepolRoomRoundDataVO() { }

}