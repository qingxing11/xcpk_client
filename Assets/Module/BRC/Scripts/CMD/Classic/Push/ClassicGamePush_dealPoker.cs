using ProtoBuf;
/**
* 开始发牌，播放发牌动画，客户端扣底注
*/
[ProtoContract]
public class ClassicGamePush_dealPoker : Response
{
    /**
	 * 庄家位置
	 */
    [ProtoMember(5)]
    public int bankerPos;

    /**
     * 扣底注数
     */
    [ProtoMember(6)]
    public int betNum;

    [ProtoMember(7)]
    public int playPos;
    public ClassicGamePush_dealPoker()
    {
        msgType = classic_开始发牌;
    }
}