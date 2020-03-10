using ProtoBuf;

/// <summary>
/// 东西南北记录
/// </summary>
[ProtoContract]
public class KillRoomLog
{
    [ProtoMember(1)]
    public bool bankerWin;
    [ProtoMember(2)]
    public bool dongWin;
    [ProtoMember(3)]
    public bool nanWin;
    [ProtoMember(4)]
    public bool xiWin;
    [ProtoMember(5)]
    public bool beiWin;

    public override string ToString()
    {
        return "KillRoomLog [bankerWin=" + bankerWin + ", dongWin=" + dongWin + ", nanWin=" + nanWin + ", xiWin="
                + xiWin + ", beiWin=" + beiWin + "]";
    }
}