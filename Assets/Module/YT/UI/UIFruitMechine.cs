using Main;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;
using DG.Tweening;
using FruitMachine;
using Config;
using FairyGUI;
  
public class UIFruitMechine : WTUIPage<UI_FruitsMachine, FruitMechineCtrl>
{
    private static bool isDebug = false;

    /** 下注时间 */
    public static long XiaZhu_TIME = 30 * MyTimeUtil.TIME_S;

    /** 开奖时间 */
    public static long KaiJiang_TIME = 20 * MyTimeUtil.TIME_S;

    /** 单玩家最大下注 */
    public static int BET_MAX = 20000000 * 8;

    public long startTime;

    public Action btnLottery;//彩票
    public Action btnFriend;//好友
    public Action btnChat;//聊天

    public Action enterRoom;
    public Action leaveRoom;
    public Action requestBankerList;
    public Action continueXiaZhu;
    public Action cancleContinueXiaZhu;
    public Action<int, int> fruitTypeAndValue;
    public Action ActionOnClick;

    public Action buttonMore;

    private List<Vector3> posIndex = new List<Vector3>();
    List<DataFruitMachine> dataFruitMachines = new List<DataFruitMachine>();
    private float fristTime = 0.1f;
    private float secondTime = 0.07f;
    private float slowTime = 0.2f;
    private float leiJiValue = 0.15f;
    private int index = 10;
    private int speicalStopIndex = 0;
    private int huanDongindex = 4;
    private int fruitMachineState;
    Dictionary<int, int> dic_typeAndValue = new Dictionary<int, int>();
    Dictionary<int, int> dic_LinShiXiaZhu = new Dictionary<int, int>();
    List<Vector3> list_reward = new List<Vector3>();
    List<int> list_rewardIndex = new List<int>();
    List<UIMask> list_masks = new List<UIMask>();
    List<UIMask> list_currentRewardMasks = new List<UIMask>();
    bool isSpecialRewardType = false;
    int playerWining = 0;
    int zhuangJiaWining = 0;
    private int beiValue = 1;
    List<string> list_history = new List<string>();

    internal void HideTV()
    {
        if (UIPage != null)
        {
            if (UIPage.m_scale.selectedIndex == 1)
            {
                Hide();
            }
        }
    }

    private int musicPath = -1; //音效索引
    private int showWatchOrFruit = 0;


    private int specialIndex = 0;
    private int isSpecialReward = 0;
    private int specialMoveIndex = 0;

    private int jianGeTime = 1;//特殊奖励水果爆灯间隔时间


    public Action showHorn;//喇叭
    public Action<Vector2> hornRecord;//消息记录面板
    public Action hideUI;

    public UIFruitMechine() : base(UIType.PopUp, UIMode.DoNothing, R.UI.FRUITMACHINE)
    {
    }

    public override void Hide()
    {
        //hideUI();
        base.Hide();
    }




    private void SetSpeicalIndex(int special)
    {
        speicalStopIndex = special;
    }

    /// <summary>
    /// 初始化 缓存所有的中奖位置信息
    /// </summary>
    private void InitPosIndex()
    {
        posIndex.Clear();
        for (int i = 0; i < 24; i++)
        {
            posIndex.Add(UIPage.m_fruitMachine.GetChild("btn" + (i + 1)).position);

        }
        dataFruitMachines = ConfigManager.Configs.DataFruitMachine.Values.ToList();
        UIPage.m_fruitMachine.m_mask1.visible = false;
        UIPage.m_fruitMachine.m_mask2.visible = false;
        UIPage.m_fruitMachine.m_mask3.visible = false;
        HideMaskInfo();
    }

    private void HideMaskInfo()
    {
        if (!isActive())
        {
            return;
        }
        for (int i = 0; i < 22; i++)
        {
            UIPage.m_fruitMachine.GetChild("m" + (i + 1)).visible = false;
        }
        UIPage.m_fruitMachine.m_mask1.visible = false;
        UIPage.m_fruitMachine.m_mask2.visible = false;
        UIPage.m_fruitMachine.m_mask3.visible = false;
    }
    public override void Awake()
    {
        UIPage.m_fruitMachine.m_one.onClick.Add(() =>
        {
            beiValue = 1;
            UIPage.m_fruitMachine.m_gouPos.selectedIndex = 0;
        });
        UIPage.m_fruitMachine.m_twoFive.onClick.Add(() =>
        {
            beiValue = 25;
            UIPage.m_fruitMachine.m_gouPos.selectedIndex = 1;
        });
        UIPage.m_fruitMachine.m_fiveTen.onClick.Add(() =>
        {
            beiValue = 50;
            UIPage.m_fruitMachine.m_gouPos.selectedIndex = 2;
        });
        UIPage.m_btn_friend.onClick.Add(() =>
        {
            BaseCanvas.GetController<FriendCtrl>().ShowUIFriend();
        });
        UIPage.m_btn_return.onClick.Add(() =>
        {
            ShowReturnUI();
        });
        UIPage.m_clickHide.onClick.Add(() =>
        {
            UIPage.m_closeUI.PlayReverse();
            UIPage.m_clickHide.visible = false;
        });
        UIPage.onClick.Add(() => { ActionOnClick?.Invoke(); });
        UIPage.m_btnShow.m_btn_return.onClick.Add(ReturnOnClick);
        UIPage.m_btnShow.m_btn_set.onClick.Add(() =>
        {
            BaseCanvas.GetController<SetCtrl>().ShowSetUI2();
        });


        InitPosIndex();
        #region      点击按钮下注
        UIPage.m_fruitMachine.m_btnBar.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_BAR, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.Bar) && dic_typeAndValue[EnumFruitType.Bar] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.Bar, 10, UIPage.m_fruitMachine.m_txt_downBar);
        });
        UIPage.m_fruitMachine.m_btnQiQi.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_77, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.DoubleSeven) && dic_typeAndValue[EnumFruitType.DoubleSeven] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.DoubleSeven, 10, UIPage.m_fruitMachine.m_txt_downQiQi);
        });
        UIPage.m_fruitMachine.m_btnStar.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_STAR, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.Star) && dic_typeAndValue[EnumFruitType.Star] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.Star, 10, UIPage.m_fruitMachine.m_txt_downStar);
        });
        UIPage.m_fruitMachine.m_btnXiGua.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_WMELON, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.XiGua) && dic_typeAndValue[EnumFruitType.XiGua] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.XiGua, 10, UIPage.m_fruitMachine.m_txt_downXiGua);
        });
        UIPage.m_fruitMachine.m_btnLingDang.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_BELL, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.LingDang) && dic_typeAndValue[EnumFruitType.LingDang] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.LingDang, 10, UIPage.m_fruitMachine.m_txt_downLingDang);
        });
        UIPage.m_fruitMachine.m_btnMangGuo.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_LEMON, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.MangGuo) && dic_typeAndValue[EnumFruitType.MangGuo] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.MangGuo, 10, UIPage.m_fruitMachine.m_txt_downMangGuo);
        });
        UIPage.m_fruitMachine.m_btnOrange.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_ORANGE, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.Orange) && dic_typeAndValue[EnumFruitType.Orange] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.Orange, 10, UIPage.m_fruitMachine.m_txt_downOrange);
        });
        UIPage.m_fruitMachine.m_btnApple.onClick.Add(() =>
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.PRESS_APPLE, 1, false);
            }
            if (dic_typeAndValue.ContainsKey(EnumFruitType.Apple) && dic_typeAndValue[EnumFruitType.Apple] >= 20000000)
            {
                BaseCanvas.GetController<MessageCtrl>().Show("您在当前的水果下注大于2000w  不可以下注 ！");
                return;
            }
            XiaZhuEveryBtnClick(EnumFruitType.Apple, 10, UIPage.m_fruitMachine.m_txt_downApple);
        });

        #endregion
        UIPage.m_fruitMachine.m_txt_Win.visible = false;
        UIPage.m_fruitMachine.m_history.itemRenderer = HistoryRenderer;
        UIPage.m_fruitMachine.m_btn_right.onClick.Add(() => { UIPage.m_fruitMachine.m_history.scrollPane.ScrollRight(2, false); });
        UIPage.m_fruitMachine.m_btn_left.onClick.Add(() => { UIPage.m_fruitMachine.m_history.scrollPane.ScrollLeft(2, false); });
        UIPage.m_fruitMachine.m_history.numItems = 0;
        UIPage.m_btn_shangZhuang.onClick.Add(() =>
        {
            requestBankerList();
        });

        UIPage.m_fruitMachine.m_xuYa.onClick.Add(() =>
        {
            XuYaRequest();
        });
        UIPage.m_btn_close.onClick.Add(() => {
            Hide();
            CacheManager.FruitRoomTV = 0;
            BaseCanvas.GetController<FruitMechineCtrl>().LeaveRoom();
        });
        UIPage.m_more.onClick.Add(() =>
        {
            buttonMore();

        });
        UIPage.m_btn_lottery.onClick.Add(() =>
        {
            btnLottery();
        });


        UIPage.m_lotteryNum.visible = false;//彩票界面数字显示
        UIPage.m_movie_win.visible = false;//彩票中奖闪烁

        UIPage.m_btn_horn.onClick.Add(() => showHorn());//喇叭按钮
        UIPage.m_btn_hornReocrd.onClick.Add(BtnRocrd);//消息记录面板

        UIPage.m_btn_friend.onClick.Add(() => btnFriend());
        ShowAddFriendIcon(false);//不显示红点

        UIPage.m_btn_chat.onClick.Add(() => btnChat());//聊天


        if (showWatchOrFruit == 1)
        {
            BaseCanvas.PlaySound(R.AudioClip.FRUITBGM, 1, true);
        }


    }

    public void ShowAddFriendIcon(bool show)
    {
        UIPage.m_addfriends.visible = show;
    }

    public void ReturnOnClick()
    {

        PlayerSimpleData playerBanker = BaseCanvas.GetController<FruitMechineCtrl>().GetCurrentBanker();
        if (playerBanker != null && playerBanker.userId == CacheManager.gameData.userId)
        {
            BaseCanvas.GetController<MessageCtrl>().Show("您是当前庄家，不可离开房间！！");
            return;
        }
        bool inUpList = false;
        if (BaseCanvas.GetController<FruitMechineCtrl>().players != null && BaseCanvas.GetController<FruitMechineCtrl>().players.Count > 0)
        {
            foreach (var item in BaseCanvas.GetController<FruitMechineCtrl>().players)
            {
                if (item.userId == CacheManager.gameData.userId)
                {
                    inUpList = true;
                    break;
                }
            }
        }
        if (inUpList)
        {
            BaseCanvas.GetController<MessageCtrl>().Show("您在上庄列表中，不可离开房间！！");
            return;
        }

        UIPage.m_closeUI.PlayReverse();
        GameCanvas.gameCanvas.StartCoroutine(HideUI());
        hideUI();
        GameCanvas.gameCanvas.ChangeToMain();
        CacheManager.RunRoomId = 0;
        CacheManager.KillRoomTV = 2;
    }
    public void ShowReturnUI()
    {
        if (!isActive())
        {
            return;
        }
        UIPage.m_closeUI.Play();
        UIPage.m_clickHide.visible = true;
    }

    internal void UpdateXiaZhuInfo(Dictionary<int, int> dic_currentJuSumXiaZhu)
    {
        
        if (!isActive())
        {
            return;
        }

 

        if (dic_currentJuSumXiaZhu == null || dic_currentJuSumXiaZhu.Count <= 0)
        {
            if (UIPage != null && UIPage.m_fruitMachine != null)
            {
                ClearAllXiaZhuInfo();

                //UIPage.m_fruitMachine.m_txt_apple.text = "0";
                //UIPage.m_fruitMachine.m_txt_bar.text = "0";
                //UIPage.m_fruitMachine.m_txt_qiqi.text = "0";
                //UIPage.m_fruitMachine.m_txt_lingDang.text = "0";
                //UIPage.m_fruitMachine.m_txt_mangGuo.text = "0";
                //UIPage.m_fruitMachine.m_txt_orange.text = "0";
                //UIPage.m_fruitMachine.m_txt_star.text = "0";
                //UIPage.m_fruitMachine.m_txt_xiGua.text = "0";
            }

            return;
        }
        foreach (int item in dic_currentJuSumXiaZhu.Keys)
        {
            int value = dic_currentJuSumXiaZhu[item];
            switch (item)
            {
                case EnumFruitType.Apple:
                    UIPage.m_fruitMachine.m_txt_apple.text = value / 10000 + "W";
                    break;
                case EnumFruitType.Bar:
                    UIPage.m_fruitMachine.m_txt_bar.text = value / 10000 + "W";
                    break;
                case EnumFruitType.DoubleSeven:
                    UIPage.m_fruitMachine.m_txt_qiqi.text = value / 10000 + "W";

                    break;
                case EnumFruitType.LingDang:
                    UIPage.m_fruitMachine.m_txt_lingDang.text = value / 10000 + "W";

                    break;
                case EnumFruitType.MangGuo:
                    UIPage.m_fruitMachine.m_txt_mangGuo.text = value / 10000 + "W";

                    break;
                case EnumFruitType.Orange:
                    UIPage.m_fruitMachine.m_txt_orange.text = value / 10000 + "W";

                    break;
                case EnumFruitType.Star:
                    UIPage.m_fruitMachine.m_txt_star.text = value / 10000 + "W";
                    break;
                case EnumFruitType.XiGua:
                    UIPage.m_fruitMachine.m_txt_xiGua.text = value / 10000 + "W";
                    break;
                default:
                    break;

            }
        }
        UpdatePlayerCoins();
    }

    private IEnumerator HideUI()
    {
        yield return new WaitForSeconds(0.75f);
        Hide();
        ClearUIMask();
        HelpClass._instance.StopAllCoroutines();
        BaseCanvas.PauseSound();
        BaseCanvas.GetController<MainSceneCtrl>().ShowUIMainScene();
        BaseCanvas.GetController<MainSceneCtrl>().SendMainSceneEnterKillRoomRequest();
        BaseCanvas.GetController<MoreCtrl>().Hide();
    }

    internal void SetXiaZhuInfo()
    {
        if (dic_typeAndValue == null || dic_typeAndValue.Count <= 0)
        {
            return;
        }
        int value = 0;
        foreach (var item in dic_typeAndValue)
        {
            if (CacheManager.gameData.coins >= item.Value)
            {
                CacheManager.gameData.coins -= item.Value;
                value += item.Value;
            }
            else
            {
                CacheManager.gameData.coins = 0;
                value += (int)CacheManager.gameData.coins;
                dic_typeAndValue[item.Key] = 0;
            }
        }
        Debug.Log("本次下注 续押金额为 ：" + value);
        if (!isActive())
        {
            return;
        }
        long coins = CacheManager.gameData.coins;
        if (coins > 10000)
        {
            UIPage.m_fruitMachine.m_txt_coins.text = coins / 10000 + "W";
        }
        else
        {
            UIPage.m_fruitMachine.m_txt_coins.text = coins.ToString();
        }

    }

    internal void SetOpenIsWatchOrFruit(int showWatchOrFruit)
    {
        Debug.Log("showWatchOrFruit:" + showWatchOrFruit);

        this.showWatchOrFruit = showWatchOrFruit;
        InitPosIndex();
        UIPage.m_enterOrOut.selectedIndex = showWatchOrFruit - 1;
        UIPage.m_scale.selectedIndex = showWatchOrFruit - 1;

        
        if (UIPage.m_scale.selectedIndex == 0)
        {
            WTUIPage.ShowPage<UIGlobalNotic>().SetPosition(95, 8).SetRotate(0);
        }

    }
    internal void SetPlayerInfo(PlayerSimpleData playerBanker)
    {
        if (isActive())
        {
            if (playerBanker != null)
            {


                UIPage.m_fruitMachine.m_zhuangJia.selectedIndex = 0;
                if (isDebug) Debug.Log("切换庄家信息  :" + playerBanker);

                //UIPage.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.STAR_));  //没有玩家头像 暂用星星代替
                UIPage.m_fruitMachine.m_bankerInfo.m_txt_bankerNike.text = playerBanker.nickName;
                ToolClass.GetHead(playerBanker);
                if (playerBanker.headIcon == null)
                {
                    if (playerBanker.roleId == 0)
                    {
                        UIPage.m_fruitMachine.m_bankerInfo.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
                    }
                    else
                    {
                        UIPage.m_fruitMachine.m_bankerInfo.m_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
                    }
                }
                else
                {
                    UIPage.m_fruitMachine.m_bankerInfo.m_icon.texture = new NTexture(playerBanker.headIcon.texture);
                }
                if (playerBanker.coins > 10000)
                {
                    float coins = playerBanker.coins / 10000;
                    UIPage.m_fruitMachine.m_bankerInfo.m_txt_bankerCoins.text = coins + "W";
                }
                else
                {
                    UIPage.m_fruitMachine.m_bankerInfo.m_txt_bankerCoins.text = playerBanker.coins.ToString();
                }


                Sprite vipSpriteBanker = null;
                switch (playerBanker.vipLv)
                {
                    case 1: vipSpriteBanker = FileIO.LoadSprite(R.SpritePack.VIP_VIP1); break;
                    case 2: vipSpriteBanker = FileIO.LoadSprite(R.SpritePack.VIP_VIP2); break;
                    case 3: vipSpriteBanker = FileIO.LoadSprite(R.SpritePack.VIP_VIP3); break;
                    case 4: vipSpriteBanker = FileIO.LoadSprite(R.SpritePack.VIP_VIP4); break;
                    case 5: vipSpriteBanker = FileIO.LoadSprite(R.SpritePack.VIP_VIP5); break;
                    default:
                        break;
                }
                if (vipSpriteBanker != null)
                {
                    UIPage.m_fruitMachine.m_bankerInfo.m_vip.texture = new NTexture(vipSpriteBanker);
                }
            }
            else
            {
                UIPage.m_fruitMachine.m_zhuangJia.selectedIndex = 1;

            }


           
            if (!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
            {
                Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
                UIPage.m_fruitMachine.m_load_icon.texture = new NTexture(t2d);
            }
            else if (CacheManager.gameData.roleId == 0)
            {
                UIPage.m_fruitMachine.m_load_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
            }
            else
            {
                UIPage.m_fruitMachine.m_load_icon.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
            }
            UIPage.m_fruitMachine.m_txt_nike.text = CacheManager.gameData.nickName;
            if (CacheManager.gameData.coins > 10000)
            {
                float coins = CacheManager.gameData.coins / 10000;
                UIPage.m_fruitMachine.m_txt_coins.text = coins.ToString() + "W";
            }
            else
            {
                UIPage.m_fruitMachine.m_txt_coins.text = CacheManager.gameData.coins.ToString();
            }

            Sprite vipSprite = null;
            switch (CacheManager.gameData.vipLv)
            {
                case 1: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP1); break;
                case 2: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP2); break;
                case 3: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP3); break;
                case 4: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP4); break;
                case 5: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP_VIP5); break;
                default:
                    break;
            }
            if (vipSprite != null)
            {
                UIPage.m_fruitMachine.m_vip.texture = new NTexture(vipSprite);
            }
        }
    }
    public void UpdatePlayerCoins()
    {
        if (!isActive())
        {
            return;
        }
        UIPage.m_fruitMachine.m_txt_coins.text = CacheManager.gameData.coins / 10000 + "W";
    }

    /// <summary>
    /// 点击下注  各个水果的按钮
    /// </summary>
    /// <param name="fruitType"></param>
    /// <param name="value"></param>
    /// <param name="gRich"></param>
    /// <param name="gText"></param>
    private void XiaZhuEveryBtnClick(int fruitType, int value, GTextField gText)
    {
        PlayerSimpleData playerBanker = BaseCanvas.GetController<FruitMechineCtrl>().GetCurrentBanker();

        if (playerBanker != null)
        {
            if (playerBanker.userId == CacheManager.gameData.userId)
            {
                if (isDebug) Debug.Log("您是当前房间内庄家  不可以下注 ！");
                BaseCanvas.GetController<MessageCtrl>().Show("您是当前房间内庄家  不可以下注 ！");
                return;
            }
        }
        if (GetXiaZhuValue() < BET_MAX)
        {
            bool isCoin = JudgyCoinIsEnough();
            if (!isCoin)
            {
                if (isDebug) Debug.Log("下注金币不足。。。" + value);
                BaseCanvas.GetController<MessageCtrl>().Show("您当前的金币不足  不可以下注 ！");
                return;
            }
            fruitTypeAndValue.Invoke(fruitType, EnumXiaZhuJIShu.number * beiValue);
            AddXiaZhuaValue(fruitType);
            gText.text = dic_typeAndValue[fruitType] / 10000 + "W";
            UIPage.m_fruitMachine.m_xuYa.grayed = true;
            UIPage.m_fruitMachine.m_xuYa.touchable = false;
        }
        else
        {
            BaseCanvas.GetController<MessageCtrl>().Show("您当前的押注大于16000w  不可以下注 ！");
        }
    }
    internal void setBtnUnEabled(bool isOnClick, bool isGray)
    {
        if (!isActive()) { return; }
        ResetSpecialBtnState();
        UIPage.m_fruitMachine.m_speical.selectedIndex = 0;
        UIPage.m_fruitMachine.m_btnApple.touchable = isOnClick;
        UIPage.m_fruitMachine.m_btnMangGuo.touchable = isOnClick;
        UIPage.m_fruitMachine.m_btnBar.touchable = isOnClick;
        UIPage.m_fruitMachine.m_btnQiQi.touchable = isOnClick;
        UIPage.m_fruitMachine.m_btnStar.touchable = isOnClick;
        UIPage.m_fruitMachine.m_btnXiGua.touchable = isOnClick;
        UIPage.m_fruitMachine.m_btnLingDang.touchable = isOnClick;
        UIPage.m_fruitMachine.m_btnOrange.touchable = isOnClick;

        UIPage.m_fruitMachine.m_btnApple.grayed = isGray;
        UIPage.m_fruitMachine.m_btnMangGuo.grayed = isGray;
        UIPage.m_fruitMachine.m_btnBar.grayed = isGray;
        UIPage.m_fruitMachine.m_btnQiQi.grayed = isGray;
        UIPage.m_fruitMachine.m_btnStar.grayed = isGray;
        UIPage.m_fruitMachine.m_btnXiGua.grayed = isGray;
        UIPage.m_fruitMachine.m_btnLingDang.grayed = isGray;
        UIPage.m_fruitMachine.m_btnOrange.grayed = isGray;
    }

    private void AddXiaZhuaValue(int bar)
    {
        if (dic_typeAndValue.ContainsKey(bar))
        {
            dic_typeAndValue[bar] += EnumXiaZhuJIShu.number * beiValue;
        }
        else
        {
            dic_typeAndValue.Add(bar, EnumXiaZhuJIShu.number * beiValue);
        }
        dic_LinShiXiaZhu.Clear();
        foreach (int item in dic_typeAndValue.Keys)
        {
            dic_LinShiXiaZhu.Add(item, dic_typeAndValue[item]);
        }
        Debug.Log("临时列表的元素个数:" + dic_LinShiXiaZhu.Count);
    }

    private int GetXiaZhuValue()
    {
        if (dic_typeAndValue == null || dic_typeAndValue.Count == 0)
        {
            return 0;
        }
        int value = 0;
        foreach (int item in dic_typeAndValue.Values)
        {
            value += item;
        }
        if (isDebug) Debug.Log("本场下注总值为 ：" + value);
        return value;
    }

    private bool JudgyCoinIsEnough()
    {
        long coin = CacheManager.gameData.coins;
        if (isDebug) Debug.Log("下注时判断玩家金币是否足够 玩家金币coin:" + coin);
        if (coin >= EnumXiaZhuJIShu.number * beiValue)
        {
            return true;
        }
        return false;
    }

    public override void Refresh()
    {
        int time = BaseCanvas.GetController<RoomCtrl>().GetLotteryTime();
        tween = DOTween.To(() => time - 1, (value) =>
        {

            UIPage.m_txt_lotteryTime.text = MyTimeUtil.TimeToString(value);

        }, 0, time).SetEase(Ease.Linear);
        enterRoom();
        UIPage.m_clickHide.visible = false;
    }

    private void SetRandomAndResetMove()
    {
        if (isDebug) Debug.Log("！！！！启动协程！！！！");
        HelpClass._instance.StopAllCoroutines();
        HelpClass._instance.StartCoroutine(MoveMask1());
        HelpClass._instance.StartCoroutine(MoveMask2());
        HelpClass._instance.StartCoroutine(MoveMask3());
    }


    public IEnumerator MoveMask1()
    {
        //播放跑马灯音效
        //if (showWatchOrFruit == 1)
        //{
        //    BaseCanvas.PlaySound(R.AudioClip.RUN, 1, false);
        //}

        //AudioControl.Instance.SoundPlay(R.AudioClip.RUN);
        UIPage.m_fruitMachine.m_mask1.visible = true;
        UIPage.m_fruitMachine.m_mask1.position = posIndex[0];
        if (showWatchOrFruit == 1)
        {
            BaseCanvas.PlaySound(R.AudioClip.BEGIN, 1, false);
        }
        float time = 0;
        float timefast = 0;
        for (int i = 0; i < posIndex.Count; i++)
        {
            UIPage.m_fruitMachine.m_mask1.position = posIndex[i];
            time += fristTime;
            if (time >= 1.56f)
            {
                timefast += fristTime;
                if (timefast >= 0.3f)
                {
                    timefast = 0;
                    if (showWatchOrFruit == 1)
                    {
                        BaseCanvas.PlaySound(R.AudioClip.FAST, 1, false);
                    }
                }
            }
            yield return new WaitForSeconds(fristTime);
        }
        timefast = 0;
        for (int i = 0; i < posIndex.Count; i++)
        {
            timefast += fristTime;
            if (timefast >= 0.3f)
            {
                timefast = 0;
                if (showWatchOrFruit == 1)
                {
                    BaseCanvas.PlaySound(R.AudioClip.FAST, 1, false);
                }
            }
            UIPage.m_fruitMachine.m_mask1.position = posIndex[i];
            yield return new WaitForSeconds(secondTime);
        }
        timefast = 0;
        for (int i = 0; i < index + 1; i++)
        {
            if (index > 4)
            {
                if (i < index - 4)
                {
                    timefast += fristTime;
                    if (timefast >= 0.3f)
                    {
                        timefast = 0;
                        if (showWatchOrFruit == 1)
                        {
                            BaseCanvas.PlaySound(R.AudioClip.FAST, 1, false);
                        }
                    }
                    UIPage.m_fruitMachine.m_mask1.position = posIndex[i];
                    yield return new WaitForSeconds(secondTime);
                }
                else
                {
                    if (showWatchOrFruit == 1)
                    {
                        BaseCanvas.PlaySound(R.AudioClip.END, 1, false);
                    }
                    UIPage.m_fruitMachine.m_mask1.position = posIndex[i];
                    yield return new WaitForSeconds(secondTime + leiJiValue);
                }
            }
            else
            {
                if (showWatchOrFruit == 1)
                {
                    BaseCanvas.PlaySound(R.AudioClip.END, 1, false);
                }
                UIPage.m_fruitMachine.m_mask1.position = posIndex[i];
                yield return new WaitForSeconds(secondTime + leiJiValue);
            }
        }
        if (isSpecialReward == 1)
        {
            yield return new WaitForSeconds(1);
        }
        ShowWiningResult();
        yield return new WaitForSeconds(4);
        HelpClass._instance.StopCoroutine(MoveMask1());
    }

    public IEnumerator MoveMask2()
    {
        UIPage.m_fruitMachine.m_mask2.position = posIndex[0];
        yield return new WaitForSeconds(fristTime);
        UIPage.m_fruitMachine.m_mask2.visible = true;
        for (int i = 0; i < posIndex.Count; i++)
        {
            UIPage.m_fruitMachine.m_mask2.position = posIndex[i];
            yield return new WaitForSeconds(fristTime);
        }
        for (int i = 0; i < posIndex.Count; i++)
        {
            UIPage.m_fruitMachine.m_mask2.position = posIndex[i];
            yield return new WaitForSeconds(secondTime);
        }


        int index1 = index - 1;
        if (index1 < 1)
        {
            UIPage.m_fruitMachine.m_mask2.position = posIndex[0];
            UIPage.m_fruitMachine.m_mask2.visible = false;
            HelpClass._instance.StopCoroutine(MoveMask2());
            yield return null;
        }
        for (int i = 0; i < index1 + 1; i++)
        {
            if (index1 > 4)
            {
                if (i < index1 - 4)
                {
                    UIPage.m_fruitMachine.m_mask2.position = posIndex[i];
                    yield return new WaitForSeconds(secondTime);
                }
                else
                {
                    UIPage.m_fruitMachine.m_mask2.position = posIndex[0];
                    UIPage.m_fruitMachine.m_mask2.visible = false;
                    HelpClass._instance.StopCoroutine(MoveMask2());
                    yield return null;
                }
            }
            else
            {
                UIPage.m_fruitMachine.m_mask2.position = posIndex[0];
                UIPage.m_fruitMachine.m_mask2.visible = false;
                HelpClass._instance.StopCoroutine(MoveMask2());
                yield return null;
            }
        }
    }

    public IEnumerator MoveMask3()
    {
        yield return new WaitForSeconds(fristTime * 2);
        UIPage.m_fruitMachine.m_mask3.visible = true;
        UIPage.m_fruitMachine.m_mask3.position = posIndex[0];

        for (int i = 0; i < posIndex.Count; i++)
        {
            UIPage.m_fruitMachine.m_mask3.position = posIndex[i];
            yield return new WaitForSeconds(fristTime);
        }
        for (int i = 0; i < posIndex.Count; i++)
        {
            UIPage.m_fruitMachine.m_mask3.position = posIndex[i];
            yield return new WaitForSeconds(secondTime);
        }

        int index2 = index - 2;
        if (index2 < 1)
        {
            UIPage.m_fruitMachine.m_mask3.position = posIndex[0];
            UIPage.m_fruitMachine.m_mask3.visible = false;
            HelpClass._instance.StopCoroutine(MoveMask3());
            yield return null;
        }
        for (int i = 0; i < index2 + 1; i++)
        {
            if (index2 > 4)
            {
                if (i < index2 - 4)
                {
                    UIPage.m_fruitMachine.m_mask3.position = posIndex[i];
                    yield return new WaitForSeconds(secondTime);

                }
                else
                {
                    UIPage.m_fruitMachine.m_mask3.position = posIndex[0];
                    UIPage.m_fruitMachine.m_mask3.visible = false;
                    HelpClass._instance.StopCoroutine(MoveMask3());
                    yield return null;
                }
            }
            else
            {
                UIPage.m_fruitMachine.m_mask3.position = posIndex[0];
                UIPage.m_fruitMachine.m_mask3.visible = false;
                HelpClass._instance.StopCoroutine(MoveMask3());
                yield return null;
            }
        }
    }

    private void ShowWiningResult()
    {
        if (isDebug)
        {
            Debug.Log("开奖过程  轮到爆灯！！！！");
            Debug.Log("开奖过程  轮到爆灯！！！！list_reward:" + list_reward.Count);
            Debug.Log("开奖过程  轮到爆灯！！！！list_currentRewardMasks:" + list_currentRewardMasks.Count);
        }
        Debug.Log("奖励是否是特殊奖励：" + isSpecialReward);
        GameCanvas.gameCanvas.StartCoroutine(SetPlayInfo());
        //播放爆灯音乐
        //AudioControl.Instance.SoundPlay(musicPath);
    }

    private IEnumerator SetPlayInfo()
    {
        //SetSpecicalRewardShow(specialIndex, isSpecialReward);
        if (list_reward.Count != 1)
        {
            if (specialIndex == EnumSpecialReward.OnTrain)
            {
                for (int i = 0; i < list_reward.Count; i++)
                {
                    if (showWatchOrFruit == 1)
                    {
                        BaseCanvas.PlaySound(R.AudioClip.TRAINNEXT, 1, false);
                    }
                    UIPage.m_fruitMachine.GetChild("m" + (i + 1)).visible = true;
                    UIPage.m_fruitMachine.GetChild("m" + (i + 1)).SetPosition(list_reward[i].x, list_reward[i].y, list_reward[i].z);
                    yield return new WaitForSeconds(jianGeTime);
                    if (ConfigManager.Configs.DataFruitMachine[list_rewardIndex[i]].Id == 10)
                    {
                        //音乐 替换  历史纪录替换  开奖结果替换
                        ClearUIMask();
                        UIPage.m_fruitMachine.GetChild("m1").visible = true;
                        UIPage.m_fruitMachine.GetChild("m1").SetPosition(posIndex[9].x, posIndex[9].y, posIndex[9].z);
                        break;
                    }
                }
                SetPlayerWinInfo();
            }
            else
            {

                Debug.Log("开奖的水果有：" + list_reward.Count);
                UIPage.m_fruitMachine.GetChild("m1").visible = true;
                UIPage.m_fruitMachine.GetChild("m1").SetPosition(list_reward[list_reward.Count - 1].x, list_reward[list_reward.Count - 1].y, list_reward[list_reward.Count - 1].z);
                for (int i = specialMoveIndex; i < posIndex.Count; i++)
                {
                    UIPage.m_fruitMachine.GetChild("m2").visible = true;
                    UIPage.m_fruitMachine.GetChild("m2").SetPosition(posIndex[i].x, posIndex[i].y, posIndex[i].z);
                    if (i != posIndex.Count - 1)
                    {
                        yield return new WaitForSeconds(secondTime);
                    }
                }
                UIPage.m_fruitMachine.GetChild("m2").visible = false;
                int indexCurrent = 0;
                GameCanvas.gameCanvas.StartCoroutine(SetMoveSpecial(0, indexCurrent));
            }
        }
        else
        {
            for (int i = 0; i < list_reward.Count; i++)
            {
                UIPage.m_fruitMachine.GetChild("m" + (i + 1)).visible = true;
                UIPage.m_fruitMachine.GetChild("m" + (i + 1)).SetPosition(list_reward[i].x, list_reward[i].y, list_reward[i].z);
            }
            if (showWatchOrFruit == 1)
            { BaseCanvas.PlaySound(musicPath, 1, false); }
            SetPlayerWinInfo();
        }

    }

    private void SetPlayerWinInfo()
    {

        ShowPoolValue();
        UIPage.m_fruitMachine.m_history.numItems = list_history.Count;
        PlayerSimpleData player = BaseCanvas.GetController<FruitMechineCtrl>().GetCurrentBanker();
        if (player != null && player.userId == CacheManager.gameData.userId)
        {
            if (isDebug) Debug.Log("当前玩家是庄家  战绩为 ：" + zhuangJiaWining);
            UIPage.m_fruitMachine.m_txt_coins.text = CacheManager.gameData.coins / 10000 + "W";

            if (zhuangJiaWining > 0)
            {
                UIPage.m_fruitMachine.m_txt_Win.text = "庄家金币+" + zhuangJiaWining;
            }
            else
            {
                UIPage.m_fruitMachine.m_txt_Win.text = "庄家金币" + zhuangJiaWining;
            }
            if (zhuangJiaWining > 0)
            {
                UIPage.m_fruitMachine.m_txt_Win.visible = true;
                UIPage.m_fruitMachine.m_showTips.Play();
                BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
            }
            return;
        }
        if (isDebug) Debug.Log("当前玩家是闲家  战绩为 ：" + zhuangJiaWining);
        UIPage.m_fruitMachine.m_txt_coins.text = CacheManager.gameData.coins / 10000 + "W";
        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        if (playerWining >= 0)
        {
            UIPage.m_fruitMachine.m_txt_Win.text = "金币+" + playerWining;
        }
        else
        {
            UIPage.m_fruitMachine.m_txt_Win.text = "金币" + playerWining;
        }
        UIPage.m_fruitMachine.m_txt_coins.text = CacheManager.gameData.coins / 10000 + "W";
        if (playerWining > 0)
        {
            UIPage.m_fruitMachine.m_txt_Win.visible = true;
            UIPage.m_fruitMachine.m_showTips.Play();
            BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
        }
        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        GameCanvas.gameCanvas.StopCoroutine(SetPlayInfo());
        UIPage.m_fruitMachine.m_mask1.visible = false;
    }

    private IEnumerator SetMoveSpecial(int index, int indexCurrent)
    {
        //if (showWatchOrFruit == 1 && (specialIndex == EnumSpecialReward.BigThreeYuan || specialIndex == EnumSpecialReward.SmallThreeYuan))
        //{
        BaseCanvas.PlaySound(R.AudioClip.BIGSANYUANSMALLSANYUAN, 1, false);
        //}
        for (int i = index; i < list_rewardIndex[indexCurrent]; i++)
        {
            UIPage.m_fruitMachine.GetChild("m" + (indexCurrent + 2)).visible = true;
            UIPage.m_fruitMachine.GetChild("m" + (indexCurrent + 2)).SetPosition(posIndex[i].x, posIndex[i].y, posIndex[i].z);
            yield return new WaitForSeconds(secondTime);
        }
        int lastIndex = list_rewardIndex[indexCurrent];
        indexCurrent++;
        if (indexCurrent < list_reward.Count - 1)
        {
            yield return new WaitForSeconds(1);
            GameCanvas.gameCanvas.StartCoroutine(SetMoveSpecial(lastIndex, indexCurrent));
        }
        else
        {
            SetPlayerWinInfo();
            GameCanvas.gameCanvas.StopCoroutine(SetMoveSpecial(lastIndex, indexCurrent));
        }
    }

    private IEnumerator SpecialMove()
    {
        //播放跑马灯音效
        if (showWatchOrFruit == 1)
        {
            BaseCanvas.PlaySound(R.AudioClip.BEGIN, 1, false);
        }
        for (int i = 1; i < 7; i++)
        {
            UIPage.m_fruitMachine.m_speical.selectedIndex = i;
            yield return new WaitForSeconds(secondTime);
        }
        float time = 0;
        if (showWatchOrFruit == 1)
        {
            BaseCanvas.PlaySound(R.AudioClip.FAST, 1, false);
        }
        for (int i = 1; i < 7; i++)
        {
            time += secondTime;
            if (time >= 0.3f)
            {
                time = 0;
                if (showWatchOrFruit == 1)
                {
                    BaseCanvas.PlaySound(R.AudioClip.FAST, 1, false);
                }
            }
            UIPage.m_fruitMachine.m_speical.selectedIndex = i;
            yield return new WaitForSeconds(secondTime);
        }
        for (int i = 1; i < speicalStopIndex + 1; i++)
        {
            if (showWatchOrFruit == 1)
            {
                BaseCanvas.PlaySound(R.AudioClip.END, 1, false);
            }
            UIPage.m_fruitMachine.m_speical.selectedIndex = i;
            yield return new WaitForSeconds(fristTime);
        }
        Debug.Log("特殊奖励动画索引为：" + speicalStopIndex);
        // UIPage.m_fruitMachine.m_speical.selectedIndex = 0;
        GameCanvas.gameCanvas.StopCoroutine(SpecialMove());
        //SetSpecicalRewardShow(specialIndex, isSpecialReward);
        yield return new WaitForSeconds(0.5f);
        SetRandomAndResetMove();
        if (showWatchOrFruit == 1)
        {
            if (musicPath != -1)
                BaseCanvas.PlaySound(musicPath, 1, false);
        }
    }


    public void SetStartTime(long time)
    {
        startTime = time;
        ClearUIMask();

    }

    long poolValue = 0;
    public void SetJiangPoolCoin(long jiangPool)
    {
        if (!isActive())
        {
            return;
        }
        poolValue = jiangPool;
    }

    public void ShowPoolValue()
    {
        if (!isActive())
        {
            return;
        }
        UIPage.m_fruitMachine.m_txt_userMoney.text = "0";
        //if (poolValue > 10000)
        //{
        //    UIPage.m_fruitMachine.m_txt_userMoney.text = /*"彩金：" +*/ poolValue / 10000 + "W";
        //}
        //else
        //{
        //    UIPage.m_fruitMachine.m_txt_userMoney.text =/* "彩金：" +*/ poolValue.ToString();
        //}
    }

    private void SetIndex(int index)
    {
        this.index = index;
    }


    internal void SetBankerWiningInfo(PlayerSimpleData playerBanker, int winingValue)
    {
        if (playerBanker.userId == CacheManager.gameData.userId)
        {
            if (isDebug) Debug.Log("是当前房间内玩家 结果结算为 ：" + winingValue);
            zhuangJiaWining = winingValue;
            if (isDebug) Debug.Log("当前庄家的金币为 ：" + CacheManager.gameData.coins);
            CacheManager.gameData.coins += winingValue;
            SetPlayerWinInfo();
            if (isDebug) Debug.Log("当前庄家所赢的金币为 ：" + winingValue + ",加上之后的金币为 ：" + CacheManager.gameData.coins);
        }
    }
    public void SetMachineStartScroll(int fruitType, int specialReward, int isSpecialReward, int fruitNum, int player)
    {
        if (isDebug) Debug.Log("开奖动画停止索引 index :" + index);
        if (isActive())
        {
            specialIndex = specialReward;
            this.isSpecialReward = isSpecialReward;
            //Debug.Log("奖励是否是特殊奖励：" + this.isSpecialReward);
            if (isDebug) Debug.Log(",玩家赢得:" + player);
            if (isDebug) Debug.Log("服务器发送的开奖数据 fruitType:" + fruitType + ",specialReward:" + specialReward + ",isSpecialReward:" + isSpecialReward);
            playerWining = player;
            CacheManager.gameData.coins += player;
            //清空上一局中奖的元素
            list_reward.Clear();
            list_rewardIndex.Clear();
            ClearXiaZhuInfo();
            OnClickBtnXuYa(true, false);
            ResetFruitInfo(false, true);
            List<DataFruitMachine> dataFruits = ConfigManager.Configs.DataFruitMachine.Values.ToList();
            if (isSpecialReward == 1)
            {
                isSpecialRewardType = true;
                //特殊奖励

                SetSpecialReward(fruitType, specialReward, fruitNum);
                SetIndex(specialMoveIndex - 1);
                HelpClass._instance.StartCoroutine(SpecialRewardShowing());

                BaseCanvas.PlaySound(R.AudioClip.FRUITMECHINESUPER);
            }
            else
            {
                //  isSpecialRewardType = false;
                //  int fruitId = SetRewardIndex(specialReward);
                SetIndex(fruitType - 1);
                UpdateHistory(dataFruitMachines[fruitType - 1].icon);
                SetMusicIndex(dataFruitMachines[fruitType - 1].normalReward);
                list_reward.Add(posIndex[fruitType - 1]);
                SetRandomAndResetMove();
            }
        }
    }

    private IEnumerator SpecialRewardShowing()
    {
        List<Vector3> list_show = new List<Vector3>();
        List<DataFruitMachine> dataFruits = ConfigManager.Configs.DataFruitMachine.Values.ToList();
        foreach (DataFruitMachine item in dataFruits)
        {
            if (item.nineTreasureLamp == EnumSpecialReward.TheNineTreasureLamp)
            {
                list_show.Add(posIndex[item.Id - 1]);
            }
        }
        for (int i = 0; i < list_show.Count; i++)
        {
            UIPage.m_fruitMachine.GetChild("m" + (i + 1)).visible = true;
            UIPage.m_fruitMachine.GetChild("m" + (i + 1)).SetPosition(list_show[i].x, list_show[i].y, list_show[i].z);
        }
        yield return new WaitForSeconds(4);
        for (int i = 0; i < list_show.Count; i++)
        {
            UIPage.m_fruitMachine.GetChild("m" + (i + 1)).visible = false;
        }
        GameCanvas.gameCanvas.StartCoroutine(SpecialMove());
    }

    public void OnClickBtnXuYa(bool xuya, bool cancle)
    {
        if (!isActive())
        {
            return;
        }

        PlayerSimpleData bankerPlayer = BaseCanvas.GetController<FruitMechineCtrl>().GetCurrentBanker();
        if (bankerPlayer == null)
        {
            UIPage.m_fruitMachine.m_xuYa.touchable = cancle;
            UIPage.m_fruitMachine.m_xuYa.grayed = xuya;
            return;
        }
        if (bankerPlayer != null & bankerPlayer.userId == CacheManager.gameData.userId)
        {
            UIPage.m_fruitMachine.m_xuYa.grayed = true;
            UIPage.m_fruitMachine.m_xuYa.touchable = false;
        }
        else
        {
            UIPage.m_fruitMachine.m_xuYa.touchable = cancle;
            UIPage.m_fruitMachine.m_xuYa.grayed = xuya;
        }

    }

    private void ClearXiaZhuInfo()
    {
        dic_typeAndValue.Clear();
    }

    /// <summary>
    /// 更新游戏开奖纪录  一共保留10次
    /// </summary>
    /// <param name="fruit"></param>
    private void UpdateHistory(string fruitIcon)
    {
        if (list_history == null)
        {
            list_history = new List<string>();
        }
        if (list_history.Count == 20)
        {
            list_history.Remove(list_history[list_history.Count - 1]);
        }
        if (isDebug) Debug.Log("中奖类型 图片路径 :" + fruitIcon);
        list_history.Insert(0, fruitIcon);
    }


    public void SetHistoryNum(List<string> list_history)
    {
        if (!isActive())
        {
            return;
        }
        this.list_history = list_history;
        if (list_history == null || list_history.Count <= 0)
        {
            return;
        }
        list_history.Reverse();
        UIPage.m_fruitMachine.m_history.numItems = list_history.Count;
    }

    /// <summary>
    /// 历史纪录内容显示
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    private void HistoryRenderer(int index, GObject item)
    {
        UI_history history = (UI_history)item;
        history.m_load_1.texture = new NTexture(FileIO.LoadSprite(list_history[index]).texture);
    }

    /// <summary>
    /// 开奖前清除上一局的数据
    /// </summary>
    public void ResetFruitInfo(bool isOnCLick, bool gray)
    {
        ClearUIMask();
        setBtnUnEabled(isOnCLick, gray);

        // UIPage.m_txt_time.text = "开奖中...";
    }

    private void ClearUIMask()
    {
        HideMaskInfo();
        //for (int i = 0; i < list_masks.Count; i++)
        //{
        //    list_masks[i].Hide();
        //    list_masks[i].SetPosition(0, 0, 0);
        //}
    }

    private void XuYaRequest()
    {
        if (dic_LinShiXiaZhu == null || dic_LinShiXiaZhu.Count <= 0)
        {
            Debug.Log("临时押注列表为空！！！！");
            return;
        }
        int value = 0;
        foreach (int item in dic_LinShiXiaZhu.Values)
        {
            value += item;
        }

        if (CacheManager.gameData.coins < value)
        {
            BaseCanvas.GetController<MessageCtrl>().Show("当前金币小于续押金币  不可续押 ！");
            return;
        }

        foreach (int item in dic_LinShiXiaZhu.Keys)
        {
            fruitTypeAndValue.Invoke(item, dic_LinShiXiaZhu[item]);
            dic_typeAndValue.Add(item, dic_LinShiXiaZhu[item]);
            SetXuYaInfo(item, dic_LinShiXiaZhu[item]);
        }
        UIPage.m_fruitMachine.m_xuYa.grayed = true;
        UIPage.m_fruitMachine.m_xuYa.touchable = false;
    }

    private void SetXuYaInfo(int key, int value)
    {
        switch (key)
        {
            case EnumFruitType.Apple:
                UIPage.m_fruitMachine.m_txt_downApple.text = value / 10000 + "W";
                break;
            case EnumFruitType.Bar:
                UIPage.m_fruitMachine.m_txt_downBar.text = value / 10000 + "W";
                break;
            case EnumFruitType.DoubleSeven:
                UIPage.m_fruitMachine.m_txt_downQiQi.text = value / 10000 + "W";

                break;
            case EnumFruitType.LingDang:
                UIPage.m_fruitMachine.m_txt_downLingDang.text = value / 10000 + "W";

                break;
            case EnumFruitType.MangGuo:
                UIPage.m_fruitMachine.m_txt_downMangGuo.text = value / 10000 + "W";

                break;
            case EnumFruitType.Orange:
                UIPage.m_fruitMachine.m_txt_downOrange.text = value / 10000 + "W";

                break;
            case EnumFruitType.Star:
                UIPage.m_fruitMachine.m_txt_downStar.text = value / 10000 + "W";
                break;
            case EnumFruitType.XiGua:
                UIPage.m_fruitMachine.m_txt_downXiGua.text = value / 10000 + "W";
                break;
            default:
                break;
        }
    }

    /// <summary>
    ///开奖后 清空下注框的内容
    /// </summary>
    public void ClearAllXiaZhuInfo()
    {
        ClearXiaZhuInfo();
        if (!isActive())
        {
            return;
        }

       
        OnClickBtnXuYa(false, true);

        Debug.Log("清理水果机下注。。。。");

        UIPage.m_fruitMachine.m_txt_downApple.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_apple.text = 0 + "";

        UIPage.m_fruitMachine.m_txt_downBar.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_bar.text = 0 + "";

        UIPage.m_fruitMachine.m_txt_downLingDang.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_lingDang.text = 0 + "";

        UIPage.m_fruitMachine.m_txt_downMangGuo.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_mangGuo.text = 0 + "";

        UIPage.m_fruitMachine.m_txt_downOrange.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_orange.text = 0 + "";

        UIPage.m_fruitMachine.m_txt_downQiQi.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_qiqi.text = 0 + "";

        UIPage.m_fruitMachine.m_txt_downStar.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_star.text = 0 + "";

        UIPage.m_fruitMachine.m_txt_downXiGua.text = 0 + "";
        UIPage.m_fruitMachine.m_txt_xiGua.text = 0 + "";
    }

    /// <summary>
    /// 特殊奖励的位置
    /// </summary>
    /// <param name="fruitType"></param>
    /// <param name="specialReward"></param>
    private void SetSpecialReward(int fruitType, int specialReward, int fruitNum)
    {
        if (isDebug) Debug.Log("特殊奖励类型为：fruitType:" + fruitType + ",specialReward:" + specialReward);
        List<DataFruitMachine> dataFruits = ConfigManager.Configs.DataFruitMachine.Values.ToList();
        switch (specialReward)
        {
            case EnumSpecialReward.SinglePointSmple:
            case EnumSpecialReward.SinglePointSpecial:
                // case EnumSpecialReward.SinglePointSpecial:
                foreach (DataFruitMachine item in dataFruits)
                {
                    if (item.normalReward == fruitType)
                    {
                        list_reward.Add(posIndex[item.Id - 1]);
                        if (isDebug)
                            Debug.Log("特殊奖励类型为单点：item:" + item);
                        // musicPath = item.music;
                        specialMoveIndex = item.Id;
                        list_rewardIndex.Add(item.Id);
                        break;
                    }
                }
                string pathSinglePoint = "";
                switch (fruitType)
                {
                    case EnumNormalReward.smallBar:
                        pathSinglePoint = "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_bar50";
                        musicPath = R.AudioClip.XIAOBAR;
                        break;
                    case EnumNormalReward.BigBar:
                        pathSinglePoint = "YT/FruitMachine/SpritePack/shuiguo/shuiguoji_zhongjiangjilu_bar100";
                        musicPath = R.AudioClip.BAR;
                        break;
                    default:
                        break;
                }
                // pathSinglePoint = EnumSpecialReward.GetTitle(EnumSpecialReward.SinglePointSmple);
                UpdateHistory(pathSinglePoint);
                SetSpeicalIndex(1);
                break;
            case EnumSpecialReward.OnTrain:
                foreach (DataFruitMachine item in dataFruits)
                {
                    if (item.Id == fruitType)
                    {
                        list_reward.Add(posIndex[item.Id - 1]);
                        if (isDebug)
                            Debug.Log("特殊奖励类型为开火车：item:" + item);
                        specialMoveIndex = item.Id;
                        list_rewardIndex.Add(item.Id);
                    }
                }
                if (fruitType + fruitNum > 24)
                {
                    foreach (DataFruitMachine item in dataFruits)
                    {
                        if (item.Id > fruitType && item.Id <= 24)
                        {
                            list_reward.Add(posIndex[item.Id - 1]);
                            if (isDebug)
                                Debug.Log("特殊奖励类型为开火车：item:" + item);
                            list_rewardIndex.Add(item.Id);
                        }
                    }
                    foreach (DataFruitMachine item in dataFruits)
                    {
                        if (item.Id >= 1 && item.Id <= (fruitType + fruitNum - 24))
                        {
                            list_reward.Add(posIndex[item.Id - 1]);
                            if (isDebug)
                                Debug.Log("特殊奖励类型为开火车：item:" + item);
                            list_rewardIndex.Add(item.Id);
                        }
                    }
                }
                else
                {
                    foreach (DataFruitMachine item in dataFruits)
                    {
                        if (item.Id > fruitType && item.Id <= (fruitType + fruitNum))
                        {
                            list_reward.Add(posIndex[item.Id - 1]);
                            if (isDebug)
                                Debug.Log("特殊奖励类型为开火车：item:" + item);
                            list_rewardIndex.Add(item.Id);
                        }
                    }
                }
                musicPath = R.AudioClip.S_KAIHUOCHE;
                string pathOnTrain = EnumSpecialReward.GetTitle(EnumSpecialReward.OnTrain);
                UpdateHistory(pathOnTrain);
                SetSpeicalIndex(2);
                break;
            case EnumSpecialReward.BigFourXi:
                foreach (DataFruitMachine item in dataFruits)
                {
                    if (item.bigFourXi == EnumSpecialReward.BigFourXi)
                    {
                        list_reward.Add(posIndex[item.Id - 1]);
                        if (isDebug)
                            Debug.Log("特殊奖励类型为大四喜：item:" + item);
                        specialMoveIndex = item.Id;
                        list_rewardIndex.Add(item.Id);
                    }
                }
                // musicPath = "YT/FruitMachine/AudioClip/s_xiaosixi";
                musicPath = R.AudioClip.SLOT_Z_FOUR;
                string pathBigFourXi = EnumSpecialReward.GetTitle(EnumSpecialReward.BigFourXi);
                UpdateHistory(pathBigFourXi);
                SetSpeicalIndex(3);
                break;
            case EnumSpecialReward.BigThreeYuan:
                foreach (DataFruitMachine item in dataFruits)
                {
                    if (item.bigThreeYuan == EnumSpecialReward.BigThreeYuan)
                    {
                        list_reward.Add(posIndex[item.Id - 1]);
                        if (isDebug)
                            Debug.Log("特殊奖励类型为大三元：item:" + item);
                        specialMoveIndex = item.Id;
                        list_rewardIndex.Add(item.Id);
                    }
                }
                //  musicPath = "YT/FruitMachine/AudioClip/s_dasanyuan";
                musicPath = R.AudioClip.S_DASANYUAN;
                string pathBigThreeYuan = EnumSpecialReward.GetTitle(EnumSpecialReward.BigThreeYuan);
                UpdateHistory(pathBigThreeYuan);
                SetSpeicalIndex(4);
                break;
            case EnumSpecialReward.SmallThreeYuan:
                int ran = UnityEngine.Random.Range(1, 3);
                foreach (DataFruitMachine item in dataFruits)
                {
                    if (ran == 1)
                    {
                        if (item.Id < 13)
                        {
                            if (item.smallThreeYuan == EnumSpecialReward.SmallThreeYuan)
                            {
                                list_reward.Add(posIndex[item.Id - 1]);
                                if (isDebug)
                                    Debug.Log("特殊奖励类型为小三元：item:" + item);
                                specialMoveIndex = item.Id;
                                list_rewardIndex.Add(item.Id);
                            }
                        }
                    }
                    else
                    {
                        if (item.Id >= 13)
                        {
                            if (item.smallThreeYuan == EnumSpecialReward.SmallThreeYuan)
                            {
                                list_reward.Add(posIndex[item.Id - 1]);
                                if (isDebug)
                                    Debug.Log("特殊奖励类型为小三元：item:" + item);
                                specialMoveIndex = item.Id;
                                list_rewardIndex.Add(item.Id);
                            }
                        }
                    }

                }
                //musicPath = "YT/FruitMachine/AudioClip/s_xiaosanyuan";
                musicPath = R.AudioClip.S_XIAOSANYUAN;
                string pathSmallThreeYuan = EnumSpecialReward.GetTitle(EnumSpecialReward.SmallThreeYuan);
                UpdateHistory(pathSmallThreeYuan);
                SetSpeicalIndex(5);
                break;
            case EnumSpecialReward.TheNineTreasureLamp:
                foreach (DataFruitMachine item in dataFruits)
                {
                    if (item.Id == 10)
                    {
                        list_reward.Add(posIndex[item.Id - 1]);
                        if (isDebug)
                            Debug.Log("特殊奖励类型为九宝莲灯：item:" + item);
                        specialMoveIndex = item.Id;
                        list_rewardIndex.Add(item.Id);
                    }
                }
                // musicPath = "YT/FruitMachine/AudioClip/s_nineDeng";
                musicPath = R.AudioClip.TONGPEI;
                string pathNineLight = EnumSpecialReward.GetTitle(EnumSpecialReward.TheNineTreasureLamp);
                UpdateHistory(pathNineLight);
                SetSpeicalIndex(6);
                break;
        }
    }

    private void SetMusicIndex(int fruitType)
    {
        switch (fruitType)
        {
            case EnumNormalReward.BigApple:
                musicPath = R.AudioClip.APPLE;
                break;
            case EnumNormalReward.smallApple:
                musicPath = R.AudioClip.XIAOAPPLE;
                break;
            case EnumNormalReward.smallOrange:
                musicPath = R.AudioClip.SMALLORANGE;
                break;
            case EnumNormalReward.BigOrange:
                musicPath = R.AudioClip.ORANGE;
                break;
            case EnumNormalReward.BigMangGuo:
                musicPath = R.AudioClip.NINGMENG;
                break;
            case EnumNormalReward.smallMangGuo:
                musicPath = R.AudioClip.XIAONINGMENG;
                break;
            case EnumNormalReward.smallLingDang:
                musicPath = R.AudioClip.XIAOLINGDANG;
                break;
            case EnumNormalReward.BigLingDang:
                musicPath = R.AudioClip.LINGDANG;
                break;
            case EnumNormalReward.smallSeven:
                musicPath = R.AudioClip.SMALL77;
                break;
            case EnumNormalReward.BigSeven:
                musicPath = R.AudioClip.DOUBLE77;
                break;
            case EnumNormalReward.BigXiHua:
                musicPath = R.AudioClip.XIGUA;
                break;
            case EnumNormalReward.smallXiGua:
                musicPath = R.AudioClip.SMALLXIGUA;
                break;
            case EnumNormalReward.smallStar:
                musicPath = R.AudioClip.SMALLDOUBLESTAR;
                break;
            case EnumNormalReward.BigStar:
                musicPath = R.AudioClip.DOUBLESTAR;
                break;
            case EnumNormalReward.LuckNone:
                musicPath = R.AudioClip.TONGSHA;
                break;
        }
    }


    /// <summary>
    /// 返回中奖所在索引
    /// </summary>
    /// <param name="rewardType"></param>
    /// <returns></returns>
    private int SetRewardIndex(int rewardType)
    {
        List<DataFruitMachine> dataFruits = ConfigManager.Configs.DataFruitMachine.Values.ToList();
        List<DataFruitMachine> list_fruit = new List<DataFruitMachine>();
        foreach (DataFruitMachine item in dataFruits)
        {
            if (item.normalReward == rewardType)
            {
                list_fruit.Add(item);
            }
        }
        int random = UnityEngine.Random.Range(0, list_fruit.Count);
        int fruitId = list_fruit[random].Id - 1;//配表id比缓存位置索引大1
        if (isDebug) Debug.Log("奖励随机到的位置为：" + list_fruit[random].Id);
        return fruitId;
    }
    long timeUpdate = MyTimeUtil.GetCurrTimeMM;
    public void UpdateCountDownTime()
    {
        if (isActive())
        {
            int state = BaseCanvas.GetController<FruitMechineCtrl>().GetState();
            // if (isDebug) Debug.Log("当前房间的状态为：" + state);
            if (state == 0)
            {
                //  if (isDebug) Debug.Log("！！！下注状态！！！！");
                if (MyTimeUtil.GetCurrTimeMM - startTime > XiaZhu_TIME)
                {
                    return;
                }
                int time = ((int)XiaZhu_TIME / 1000) - (int)(MyTimeUtil.GetCurrTimeMM - startTime) / 1000;
                if (time < 10)
                {
                    UIPage.m_fruitMachine.m_txt_time.text = "0" + time.ToString();
                }
                else
                {

                    UIPage.m_fruitMachine.m_txt_time.text = time.ToString();
                }
                // UIPage.m_fruitMachine.m_txt_time.textFormat.size = 32;
                //if (isDebug)
                //Debug.Log("下注时间剩余 ：" + time);
                if (time <= 5)
                {
                    if (MyTimeUtil.GetCurrTimeMM - timeUpdate >= 1000)
                    {
                        timeUpdate = MyTimeUtil.GetCurrTimeMM;
                        BaseCanvas.PlaySound(R.AudioClip.LING, 1, false);
                    }
                }
            }
            else if (state == 1)
            {
                // if (isDebug) Debug.Log("！！！开奖状态！！！！");
                if (MyTimeUtil.GetCurrTimeMM - startTime > KaiJiang_TIME)
                {
                    return;
                }
                int time = ((int)KaiJiang_TIME / 1000) - (int)(MyTimeUtil.GetCurrTimeMM - startTime) / 1000;
                if (time < 10)
                {
                    UIPage.m_fruitMachine.m_txt_time.text = "0" + time.ToString();
                }
                else
                {

                    UIPage.m_fruitMachine.m_txt_time.text = time.ToString();
                }
                //UIPage.m_fruitMachine.m_txt_time.textFormat.size = 32;
                //if (isDebug)
                //Debug.Log("开奖时间剩余 ：" + time);
            }
        }
    }

    /// <summary>
    /// 设置特殊奖励的表现
    /// </summary>
    /// <param name="specialReward"></param>
    /// <param name="isSpecialReward"></param>
    private void SetSpecicalRewardShow(int specialReward, int isSpecialReward)
    {
        if (isSpecialReward == 0)
        {
            ResetSpecialBtnState();
        }
        else
        {
            switch (specialReward)
            {
                case EnumSpecialReward.BigFourXi:
                    UIPage.m_fruitMachine.m_btn_dsx.m_c1.selectedIndex = 1;
                    UIPage.m_fruitMachine.m_btn_dsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_xsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_khc.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dd.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_jbld.m_c1.selectedIndex = 0;
                    break;
                case EnumSpecialReward.SinglePointSmple:
                case EnumSpecialReward.SinglePointSpecial:
                    //case EnumSpecialReward.SinglePointSpecial:
                    UIPage.m_fruitMachine.m_btn_dsx.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_xsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_khc.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dd.m_c1.selectedIndex = 1;
                    UIPage.m_fruitMachine.m_btn_jbld.m_c1.selectedIndex = 0;
                    break;
                case EnumSpecialReward.SmallThreeYuan:
                    UIPage.m_fruitMachine.m_btn_dsx.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_xsy.m_c1.selectedIndex = 1;
                    UIPage.m_fruitMachine.m_btn_khc.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dd.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_jbld.m_c1.selectedIndex = 0;
                    break;
                case EnumSpecialReward.TheNineTreasureLamp:
                    UIPage.m_fruitMachine.m_btn_dsx.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_xsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_khc.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dd.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_jbld.m_c1.selectedIndex = 1;
                    break;
                case EnumSpecialReward.BigThreeYuan:
                    UIPage.m_fruitMachine.m_btn_dsx.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dsy.m_c1.selectedIndex = 1;
                    UIPage.m_fruitMachine.m_btn_xsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_khc.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dd.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_jbld.m_c1.selectedIndex = 0;
                    break;
                case EnumSpecialReward.OnTrain:
                    UIPage.m_fruitMachine.m_btn_dsx.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_dsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_xsy.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_khc.m_c1.selectedIndex = 1;
                    UIPage.m_fruitMachine.m_btn_dd.m_c1.selectedIndex = 0;
                    UIPage.m_fruitMachine.m_btn_jbld.m_c1.selectedIndex = 0;
                    break;
                default:
                    break;
            }
        }
    }

    /// <summary>
    /// 重置特殊奖励的表现
    /// </summary>
    private void ResetSpecialBtnState()
    {
        UIPage.m_fruitMachine.m_btn_dsx.m_c1.selectedIndex = 0;
        UIPage.m_fruitMachine.m_btn_dsy.m_c1.selectedIndex = 0;
        UIPage.m_fruitMachine.m_btn_xsy.m_c1.selectedIndex = 0;
        UIPage.m_fruitMachine.m_btn_khc.m_c1.selectedIndex = 0;
        UIPage.m_fruitMachine.m_btn_dd.m_c1.selectedIndex = 0;
        UIPage.m_fruitMachine.m_btn_jbld.m_c1.selectedIndex = 0;
    }





    /// <summary>
    /// 打开消息记录面板
    /// </summary>
    private void BtnRocrd()
    {
        Vector2 pos = new Vector2(UIPage.m_bg_horn.x, UIPage.m_bg_horn.y) + new Vector2((UIPage.m_bg_horn.width - 383) / 2f, UIPage.m_bg_horn.height);
        hornRecord(pos);
    }

    private Tween tween;
    public void ShowLotteryTime(int time)
    {
        //Debug.LogError("Room彩票时间");
        tween = DOTween.To(() => time - 1, (value) =>
        {

            UIPage.m_txt_lotteryTime.text = MyTimeUtil.TimeToString(value);

        }, 0, time).SetEase(Ease.Linear);
    }

    public void LotteryWinPlay(bool play)
    {
        UIPage.m_movie_win.visible = play;
        if (play)
        {
            if (UIPage.m_t0.playing)
            {
                UIPage.m_t0.Stop();
            }
            UIPage.m_t0.Play();
        }
        else
        {
            if (UIPage.m_t0.playing)
            {
                UIPage.m_t0.Stop();
            }
        }
    }

    public void ShowCurBuyLotteryNum(int num)
    {
        if (num <= 0)
        {
            UIPage.m_lotteryNum.visible = false;
        }
        else
        {
            UIPage.m_txt_lotteryNum.text = num.ToString();
            UIPage.m_lotteryNum.visible = true;
        }
    }
}
