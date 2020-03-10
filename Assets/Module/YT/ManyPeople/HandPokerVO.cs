using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

[ProtoContract]
public class HandPokerVO
{
    public int pos;
    public List<PokerVO> list_handPoker;

    public HandPokerVO() { }


}