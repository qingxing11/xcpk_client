using ProtoBuf;

[ProtoContract]
public class Push_LevelUP : Response
{
    /**
	 * 升级后剩余经验值
	 */
    [ProtoMember(5)]
    public int exp;

    /**
	 * 升级到等级
	 */
    [ProtoMember(6)]
    public int level;
    public Push_LevelUP()
    {
        msgType = PUSHUSER_等级变化;
    }
}