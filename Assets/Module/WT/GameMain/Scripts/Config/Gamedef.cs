using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[Serializable]
public class GameDef
{

	public List<PayItemInfoDef.BeanDef> arrayList_payOrder = new List<PayItemInfoDef.BeanDef>();
    public List<Itemdef> arrayList_itemDef = new List<Itemdef>();
    public List<GoodsDef> arrayList_goodsDef = new List<GoodsDef>();

    /** 房卡消耗 */
    public int game_round0_cost;
    public int game_round1_cost;
    public int game_round2_cost;

    /** 游戏房间最大玩家数 */
    public int game_maxplayer = 4;

    /** 每次思考时间,单位毫秒 */
    public int gamerThinkTime;

    /** 发牌后客户端处理发牌动画的时间,单位毫秒 */
    public int fapaiTime;

    /** 聊天表情CD时间 */
    public int chatCD;

    public int game_calc_time;
}