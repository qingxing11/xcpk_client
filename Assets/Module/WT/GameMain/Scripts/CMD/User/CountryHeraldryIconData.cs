using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ProtoContract]
public class CountryHeraldryIconData
{
    [ProtoMember(1)]
    public int bottom;// 底
    [ProtoMember(2)]
    public int up;// 图案

    public override string ToString()
    {
        return "CountryHeraldryIconData [ bottom=" + bottom + ",up" + up + "]";
    }
}

