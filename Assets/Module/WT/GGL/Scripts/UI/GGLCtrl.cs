using System;
using UnityEngine;
 
using WT.UI;

public class GGLCtrl : BaseController,IHandlerReceive
{
    private UIggl uiggl;
    private UIGGLGame uigglgame;
    private UIBuyMenu uIBuyMenu;

    private UIHornRecord uiHornRecord;//消息记录面板

    private int mGameIndex;

    public void ShowTxtTitle(string info)
    {
        HornInfoVO vo = new HornInfoVO();
        vo.info = info;
        vo.nikeName = "系统";
        if (uiggl.isActive())
        {
            CacheManager.AddHorn(vo);

            uiggl.NoticPlay(vo);
        }
        RefreshHornRecordList();
    }

    public void RefreshHornRecordList()
    {
        if (uiHornRecord.isActive())
        {
            uiHornRecord.RefreshList();
        }
    }

    public int GameIndex
    {
        get
        {
            return mGameIndex;
        }
    }

    public override void InitAction()
    {
        uiggl = GetUIPage<UIggl>();
        uiggl.actionClickGame = ClickGGLGame;

        uigglgame = GetUIPage<UIGGLGame>();
        uigglgame.showBugMenu = ShowBuyMenu;
        uigglgame.action_reward = RequestReward;

        uIBuyMenu = GetUIPage<UIBuyMenu>();
        uIBuyMenu.ziDingYiBuy = ZiDingYiBuy;


        
        //AddEvent();
    }
     
    private void RequestReward()
    {
        SendMessage(new GglRewardRequest());
    }

   

    private void OnTouchDragEnd()
    {
        Debug.Log("OnTouchDragEnd:");
    }

    private void OnTouchDrag(int arg1, Vector2 arg2)
    {
        Debug.Log("OnTouchBegin:" + arg2);
    }

    private void OnTouchBegin(int arg1, Vector2 arg2)
    {
        Debug.Log("OnTouchBegin:" + arg2);
    }

    private void OnTouchEnd(int arg1, Vector2 arg2)
    {
        Debug.Log("OnTouchBegin:" + arg2);
    }

    private void ShowBuyMenu(int type, int index)
    {
        if (type==2)
        {
            SendBuyOnceRequest(index);
        }
        else
        {
            uIBuyMenu = ShowUI<UIBuyMenu>();
            uIBuyMenu.SetInfo(type, index);
            
        }
    }


    private void SendBuyOnceRequest(int index)
    {
        GglBuyOnceRequest request = new GglBuyOnceRequest();
        request.level = index;
        SendMessage(request);
    }
    private void ZiDingYiBuy(int zhangValue, int costCoin,int type)
    {
        if (CacheManager.gameData.coins >= costCoin)
        {
            GglCustomizeBuyRequest request = new GglCustomizeBuyRequest
            {
                level = type,
                num = zhangValue,
            };
            SendMessage(request);
        }
       
    }

    private void ClickGGLGame(int gameIndex)
    {
        this.mGameIndex = gameIndex;
        uiggl.Hide();
        uigglgame = ShowUI<UIGGLGame>();
        uigglgame.SetGameIndex(gameIndex);
      
    }

    public void ShowGGL()
    {
        uiggl = ShowUI<UIggl>();

        
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.GGL_单次购买:
                    SetOnceBuyResult(response.data);
                    break;

                case MsgType.GGL_兑奖:
                    ReceiveReward(response.data);
                    break;

                case MsgType.GGL_自定义购买:
                    ReceiveCustomizeBuy(response.data);
                    break;

                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveCustomizeBuy(byte[] data)
    {
        GglCustomizeBuyRespone response = MySerializerUtil.DeSerializerFromProtobufNet<GglCustomizeBuyRespone>(data);
        switch (response.code)      
        {
            case GglCustomizeBuyRespone.SUCCESS:
                CacheManager.gameData.coins -= response.costMoney;
                int gift = 0;
                foreach (var item in response.list_money)
                {
                    gift += item;
                }

                CacheManager.gameData.coins += gift;
                uIBuyMenu.ShowCustomizeBuy(response.list_money, gift);
               
                uigglgame.RefreshTextGold();
                uiggl.RefreshTextGold();
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                if (gift == 0)
                {
                    uigglgame.ShowReward0();
                }
                break;

            default:
                Debug.Log("自定义购买错误");
                break;
 
        }
    }

    private void ReceiveReward(byte[] data)
    {
        GglRewardRespone reqponse = MySerializerUtil.DeSerializerFromProtobufNet<GglRewardRespone>(data);
        ShowReward(reqponse.money);
    }

    private void ShowReward(int money)
    {
        CacheManager.gameData.coins += money;

        uigglgame.ChangeToGame();
        uigglgame.RefreshTextGold();
        uiggl.RefreshTextGold();

        GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        if (money > 0)
        {
            Debug.Log("获得奖励：" + money);

            GetController<LotteryCtrl>().ShowUiGglWin(money);
            EventCenter.Broadcast<int>(EventDefine.CoinsChange, money);
        }
        else
        {
            uigglgame.ShowReward0();
            Debug.Log("谢谢惠顾");
        }
    }
  
    private void SetOnceBuyResult(byte[] data)
    {
        GglBuyOnceRespone respone = MySerializerUtil.DeSerializerFromProtobufNet<GglBuyOnceRespone>(data);
        switch (respone.code)
        {
            case GglBuyOnceRespone.SUCCESS:
                CacheManager.gameData.coins -= respone.costMoney;
                //CacheManager.gameData.coins += respone.money;//此时不增加金币
                EventCenter.Broadcast<int>(EventDefine.CoinsChange, respone.money);
                uigglgame.SetQiInfo(respone.list_luckyChess,respone.list_myChess,respone.money);
                uigglgame.RefreshTextGold();
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                break;
            case GglBuyOnceRespone.ERROR_金币不足:
                break;
            default:
                break;
        }
    }
}