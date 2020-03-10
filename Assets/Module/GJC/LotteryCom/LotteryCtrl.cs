using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class LotteryCtrl : BaseController,IHandlerReceive
{
    private UILottery uiLottery;
    private UILotteryWin uiLotteryWin;
    private UILotteryLose uiLotteryLose;

    //private UIGglwin uiGglWin; 
    private int buyCost = 20000;
    private int defaultNum = 10;
    public override void InitAction()
    {
        uiLottery=GetUIPage<UILottery>();
        uiLottery.btnXZ = SendXiaZhu;
        uiLottery.btnZDTZ = SendZiDongTouZhu;
        uiLottery.showError = ShowError;
        uiLottery.btnZDTZHideUI = HideUIZDXZ;
        uiLottery.btnHide = Hide;

        uiLotteryWin = GetUIPage<UILotteryWin>();
        uiLotteryLose = GetUIPage<UILotteryLose>();
        //uiGglWin = GetUIPage<UIGglwin>();
    }

    private void Hide()
    {
        uiLottery.Hide();
        ShowUIOrHideUI(false);
    }

    /// <summary>
    /// 自动投注
    /// </summary>
    /// <param name="number"></param>
    private void SendZiDongTouZhu(int num)
    {
        //Debug.Log("自动投注,投注数量："+num);
        AskAutoLotteryRequest request = new AskAutoLotteryRequest(CacheManager.gameData.userId,num);
        SendMessage(request);
    }

    /// <summary>
    /// 下注
    /// </summary>
    /// <param name="number"></param>
    /// <param name="type"></param>
    private void SendXiaZhu(int number, int type)
    {
        AskLotteryRequest request = new AskLotteryRequest(CacheManager.gameData.userId,number,type);
        SendMessage(request);
        Debug.Log("下注数量："+number+"， 下注类型："+uiLottery.GetName(type));
    }

    public void ShowUILottery()
    {
        ShowUIOrHideUI(true);
        ShowUI<UILottery>();
        SendAskTime();
        //uiLottery.ShowPlayCoin();
    }

    public void Update()
    {
        for (int i = list_particleEffect.Count - 1; i >= 0; i--)
        {
            var item = list_particleEffect[i];
            ParticleSystem particleSystem = item.GetComponent<ParticleSystem>();
            if (particleSystem != null && particleSystem.isStopped)
            {
                GameObject.Destroy(item);
                list_particleEffect.RemoveAt(i);
            }
        }
    }

    public void SendAskTime()
    {
        AskLotteryTimeRequest request = new AskLotteryTimeRequest();
        SendMessage(request);
    }


    public Response RunServerReceive(Response response)
    {
        if (response!=null)
        {
            switch (response.msgType)
            {
                case MsgType.Lottery_彩票结果:
                    PushLotteryResultMessage(response.data);
                    break;
                case MsgType.Lottery_同步时间:
 
                    AskLotteryTimeMessage(response.data);
                    break;
                case MsgType.Lottery_下注时间:
                    PushBottomPourTimeMessage(response.data);
                    break;
                case MsgType.Lottery_开奖时间:
                    PushRunALotteryTimeMessage(response.data);
                    break;
                case MsgType.Lottery_下注:
                    AskLotteryMessage(response.data);
                    break;
                case MsgType.Lottery_自动下注:
                    AskAutoLotteryMessage(response.data);
                    break;
                case MsgType.Lottery_金钱改变:
                    PushTitleMoneyMessage(response.data);
                    break;
                case MsgType.Lottery_中奖提示:
                    PushWinMoneyTxtMessage(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private bool show=false;
    private bool zdtz = false;
    private int num = 0;

    /// <summary>
    /// 关闭UI或者打开UI
    /// </summary>
    /// <param name="show"></param>
    private void ShowUIOrHideUI(bool show)
    {
        this.show = show;
    }

    /// <summary>
    /// 下注时间
    /// </summary>
    /// <param name="time"></param>
    public void HideUIZDXZ(int num,bool zdtz)
    {
        this.zdtz = zdtz;
        this.num = num;
        Debug.Log("当前投注数量："+ num);
    }

    /// <summary>
    /// 下注时间
    /// </summary>
    /// <param name="time"></param>
    public void ZDXZ()
    {
        if (!show)
        {
            if (zdtz)
            {
                if (num > 0)
                {
                    SendZiDongTouZhu(num);
                }
            }
        }
    }
    /// <summary>
    /// 中奖提示
    /// </summary>
    /// <param name="data"></param>
    private void PushWinMoneyTxtMessage(byte[] data)
    {
        PushWinMoneyTxtResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushWinMoneyTxtResponse>(data);
        switch (response.code)
        {
            case PushWinMoneyTxtResponse.SUCCESS:
                List<TxtVO> list = response.vo; 
                Debug.Log("中奖提示:"+ response);
                if (list!=null)
                {
                    string info = "恭喜玩家：";
                    foreach (var item in list)
                    {
                        info += "\""+item.nikeName + "\"  " + ToolClass.LongConverStr(item.money) + "  ";
                    }
                    info += "，在高频彩中爆发！";

                    Debug.Log("中奖提示=" + info);
                    GetController<RoomCtrl>().ShowTxtTitle(info);
                    GetController<ClassicRoomCtrl>().ShowTxtTitle(info);
                    GetController<TenThousandRoomCtrl>().ShowTxtTitle(info);
                }
                break;
            default:
                //Debug.Log("PushWinMoneyTxtResponse 出错" + response.code);
                break;
        }
    }

    /// <summary>
    /// 总金钱改变
    /// </summary>
    /// <param name="data"></param>
    private void PushTitleMoneyMessage(byte[] data)
    {
        PushTitleMoneyResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushTitleMoneyResponse>(data);
        //Debug.Log("response" + response);
        switch (response.code)
        {
            case PushTitleMoneyResponse.SUCCESS:
                FefrashTitle(response.titleMoney);
                break;
            default:
                //Debug.Log("PushTitleMoneyMessage 出错" + response.code);
                break;
        }
    }

    /// <summary>
    /// 彩票结果
    /// </summary>
    /// <param name="data"></param>
    private void PushLotteryResultMessage(byte[] data)
    {
        PushLotteryResultResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushLotteryResultResponse>(data);
        switch (response.code)
        {
            case PushLotteryResultResponse.SUCCESS:
                //Debug.LogError("彩票结果："+ response);
                CacheManager.AddWinRecord(response.type);
                FefrashResult(response.type, response.card1, response.card2, response.card3,response.win,response.winnerMoney);

                if (response.win)//其他界面
                {
                    CacheManager.gameData.coins +=Math.Abs(response.winnerMoney);
                    PlayAudioClip();
                    ShowRoomLotteryWin(true);
                    ShowuiLotteryWin(response.winnerMoney);
                    PlayLotteryWinEffect();
                    GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                    GetController<RoomCtrl>().RefreshCoin();
                    GetController<ClassicRoomCtrl>().RefreshCoin();
                    GetController<TenThousandRoomCtrl>().RefreshCoin();
                    GetController<FruitMechineCtrl>().RefreshCoin();
                }else
                {
                    //ShowError("悲剧了，未押中高频彩~");
                    ShowuiLotteryLose();
                    //GetController<MessageCtrl>().Show("悲剧了，未押中高频彩~");
                }
                break;
            case PushLotteryResultResponse.Error_没有下注:
                //Debug.LogError("彩票结果：" + response);
                CacheManager.AddWinRecord(response.type);
                FefrashResult(response.type, response.card1, response.card2, response.card3);
                break;
            default:
                //Debug.Log("PushLotteryResultResponse 出错" + response.code);
                break;
        }
    }

    private void FefrashResult(int type, PokerVO card1, PokerVO card2, PokerVO card3)
    {
        if (uiLottery.isActive())
        {
            //加载牌型
            uiLottery.LoadIcon(card1, card2, card3);
            uiLottery.RefrashWin(type);
        }
        else if(uiLottery != null)
        {
            uiLottery.ClearPayNum();
        }
    }

    private GameObject gameObject;
    private List<GameObject> list_particleEffect = new List<GameObject>();
    public void FefrashResult(int type,PokerVO card1,PokerVO card2, PokerVO card3, bool win, long money)
    {
 
        if (uiLottery.isActive())
        {
            //加载牌型
            uiLottery.OnPlay();//清空错误显示

            uiLottery.LoadIcon(card1, card2, card3);
           
            uiLottery.ShowTitle(win,money);
            uiLottery.RefrashWin(type);
            if (win)
            {
                uiLottery.WinEffectCoin(type);
            }
        }
        else if (uiLottery != null)
        {
            uiLottery.ClearPayNum();
        }
    }


    /// <summary>
    /// 播放音效
    /// </summary>
    public void PlayAudioClip()
    {
        //Debug.Log("播放彩票音效");
        BaseCanvas.PlaySound(R.AudioClip.LOTTERYCLIP, 15, false);
    }

    private void PlayLotteryWinEffect()
    {
        gameObject = FileIO.LoadPrefab(R.Prefab.LOTTERYEFFECT);
        gameObject = GameObject.Instantiate(gameObject);

        gameObject.transform.position += new Vector3(MyUtil.GetRandom(-4, 4), MyUtil.GetRandom(-3, 3), 0);
        ParticleSystem particleSystem = gameObject.GetComponent<ParticleSystem>();
        particleSystem.Play();
        list_particleEffect.Add(gameObject);
    }

    private void FefrashTitle(long money)
    {

        if (uiLottery.isActive())
        {
            uiLottery.ShowAllMoneyNumber(money);
        }
    }


    /// <summary>
    /// 自动下注
    /// </summary>
    /// <param name="data"></param>
    private void AskAutoLotteryMessage(byte[] data)
    {
        AskAutoLotteryResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskAutoLotteryResponse>(data);
        Debug.Log("response" + response);
        switch (response.code)
        {
            case AskAutoLotteryResponse.SUCCESS:
                SetButton(response.type,response.num);
                FefrashTitle(response.titleMoney);
                CacheManager.gameData.coins -=Math.Abs(response.costMoney);
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                ShowRoomLotteryNum(response.num);
                GetController<RoomCtrl>().RefreshCoin();
                GetController<ClassicRoomCtrl>().RefreshCoin();
                GetController<TenThousandRoomCtrl>().RefreshCoin();
                break;
            case AskAutoLotteryResponse.Error_钱不够:
                //ShowError("您的金币不足，请充值！");
                break;
            case AskAutoLotteryResponse.Error_不能押注:
                //ShowError("当前不能押注");
                break;
            default:
                Debug.Log("AskLotteryResponse 出错" + response.code);
                break;
        }
    }
    public void SetButton(int type,int num)
    {
        if (uiLottery != null)
        {
            uiLottery.SetSelectBotton(type,num);
        }
       
    }
     
    /// <summary>
    /// 下注
    /// </summary>
    /// <param name="data"></param>
    private void AskLotteryMessage(byte[] data)
    {
        AskLotteryResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskLotteryResponse>(data);
        Debug.Log("AskLotteryMessage,num:" + response.num);

        switch (response.code)
        {
            case AskLotteryResponse.SUCCESS:
               
                FefrashTitle(response.titleMoney);
                CacheManager.gameData.coins -=Math.Abs(response.costMoney);
                if (uiLottery.isActive())
                {
                    uiLottery.RefreshNum(response.num);
                }
                ShowRoomLotteryNum(response.num);
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                GetController<RoomCtrl>().RefreshCoin();
                GetController<ClassicRoomCtrl>().RefreshCoin();
                GetController<TenThousandRoomCtrl>().RefreshCoin();
                break;
           case AskLotteryResponse.Error_不能押注:
                //Debug.LogError("AskLotteryResponse.Error_不能押注" + response.code);
                //ShowError("当前不能押注");//todo 有问题待测试
                ShowRoomLotteryNum(0);
                break;
            case AskLotteryResponse.Error_钱不够:
                //Debug.LogError("AskLotteryResponse.Error_钱不够" + response.code);
                //ShowError("您的金币不足，请充值！");
                int type = response.type;
                int num = response.num;
                ShowRoomLotteryNum(0);
                break;
            default:
                ShowRoomLotteryNum(0);
                //Debug.Log("AskLotteryResponse 出错" + response.code);
                break;
        }
    }

    private void ShowError(string txt)
    {
        if (uiLottery.isActive())
        {
            uiLottery.TxtError(txt);
        }
    }


    /// <summary>
    /// 开奖时间
    /// </summary>
    /// <param name="data"></param>
    private void PushRunALotteryTimeMessage(byte[] data)
    {
        PushRunALotteryTimeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushRunALotteryTimeResponse>(data);
        switch (response.code)
        {
            case PushRunALotteryTimeResponse.SUCCESS:
                RefrashWinTime(response.time / 1000);
                //Debug.LogError("彩票 界面开奖时间");
                ShowTime(response.time / 1000);
                ShowRoomLotteryNum(0);
                break;
            default:
                //Debug.Log("PushRunALotteryTimeResponse 出错" + response.code);
                break;
        }
    }

    /// <summary>
    /// 下注时间
    /// </summary>
    /// <param name="data"></param>
    private void PushBottomPourTimeMessage(byte[] data)
    {
        PushBottomPourTimeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushBottomPourTimeResponse>(data);
        switch (response.code)
        {
            case PushBottomPourTimeResponse.SUCCESS:
                RefrashBuyTime(response.time/1000);
                if (uiLottery != null)
                {
                    uiLottery.ClearPayNum();
                }
                ShowTime(response.time / 1000);
                ShowRoomLotteryWin(false);//关闭中奖效果
                ZDXZ();
                break;
            default:
                //Debug.Log("PushBottomPourTimeMessage 出错" + response.code);
                break;
        }
    }

    private void AskLotteryTimeMessage(byte[] data)
    {
        AskLotteryTimeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<AskLotteryTimeResponse>(data);
 
        switch (response.code)
        {
            case AskLotteryTimeResponse.SUCCESS:
                if (response.residueBuyTime>0)
                {
                    RefrashBuyTime(response.residueBuyTime/1000);
                }
                if (response.residueWinTime > 0)
                {
                    RefrashWinTime(response.residueWinTime / 1000);
                }
                if (response.recordWinType != null)
                {
                    foreach (int type in response.recordWinType)
                    {
                        CacheManager.AddWinRecord(type);
                    }
                }
                if (uiLottery.isActive())
                {
                    uiLottery.OnPlay();//清空错误显示
                    uiLottery.RefrashRecord();
                }

                if (uiLottery != null)
                {
                    uiLottery.SetSelect(response.curType, response.curNum);
                }
                ShowRoomLotteryNum(response.curNum);

                //Debug.LogError("彩票 界面同步时间");
                ShowTime(response.residueBuyTime / 1000);
                break;
            default:
                //Debug.Log("AskLotteryTimeResponse 出错"+ response.code);
                break;
        }
    }
  
    public void ShowTime(int time)
    {
        GetController<RoomCtrl>().ShowLotteryTime(time);
        GetController<ClassicRoomCtrl>().ShowLotteryTime(time);
        GetController<TenThousandRoomCtrl>().ShowLotteryTime(time);
        GetController<FruitMechineCtrl>().ShowLotteryTime(time);
       
    }


    private void RefrashBuyTime(int time)
    {
        if (uiLottery.isActive())
        {
            uiLottery.OnPlay();//清空错误显示
            uiLottery.ShowXiaZhuTime(time);
        }
    }
    private void RefrashWinTime(int time)
    {
        if (uiLottery.isActive())
        {
            uiLottery.OnPlay();//清空错误显示
            uiLottery.ShowXiaYiJuTime(time);
        }
    }

    private void ShowRoomLotteryNum(int num)
    {
        GetController<RoomCtrl>().ShowLotteryNum(num);
        GetController<ClassicRoomCtrl>().ShowLotteryNum(num);
        GetController<TenThousandRoomCtrl>().ShowLotteryNum(num);
        GetController<FruitMechineCtrl>().ShowLotteryNum(num);
    }

    private void ShowRoomLotteryWin(bool win)
    {
        GetController<RoomCtrl>().ShowLotteryWin(win);
        GetController<ClassicRoomCtrl>().ShowLotteryWin(win);
        GetController<TenThousandRoomCtrl>().ShowLotteryWin(win);
        GetController<FruitMechineCtrl>().ShowLotteryWin(win);
    }

    public void ShowuiLotteryWin(long addCoin)
    {
        ShowUI<UILotteryWin>();
        uiLotteryWin.ShowCoin(addCoin);
    }

    public void ShowuiLotteryLose()
    {
        ShowUI<UILotteryLose>();
        uiLotteryLose.ShowCoin();
    }

    public void ShowUiLotteryWinSigleCoin(long addCoin)
    {
        ShowUI<UILotteryWin>();
        uiLotteryWin.ShowSigleCoin(addCoin);
    }

    public void ShowUiGglWin(long addCoin)
    {
        UIGglwin gglWin = ShowUI<UIGglwin>(addCoin+MyUtil.GetRandom(100000) + MyUtil.GetRandom(100000) + "");
        gglWin.ShowSigleCoin(addCoin);
    }

    internal void HideLottery()
    {
        if (uiLottery != null && uiLottery.isActive())
        {
            uiLottery.Hide();
        }
    }
}
