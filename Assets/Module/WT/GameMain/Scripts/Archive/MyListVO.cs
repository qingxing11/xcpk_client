using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ProtoContract]
public class MyListVO
{
    [ProtoMember(1)]
    public List<int> list;
}

