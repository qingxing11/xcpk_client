using WT.UI;
using System;
using Main;
using UnityEngine;
using Room;
using FairyGUI;
using System.Collections.Generic;

public class UIMainScene : WTUIPage<UI_MainScene, MainSceneCtrl>
{
    public Action ActionTask;
    public Action safebox;
    public Action ActionMore;
    public Action ActionRank;
    public Action fruitMachine;
    public Action tenThousand;
    public Action ActionTree;
    public Action ActionMail;
    public Action<int> ActionShop;
    public Action ActionHead;
    public Action ActionAllKill;
    public Action ActionFriend;
    public Action freeMoney;
    public Action ActionSelect;
    public Action ActionClassic;//经典场
    public Action showHorn;//喇叭
    public Action<Vector2> hornRecord;//消息记录面板
    public Action ActionLow;   //低保
    public UIMainScene() : base(UIType.Normal, UIMode.DoNothing, R.UI.MAIN)
    {
        
    }

    public override void Awake()
    {
        //UIPage.m_text_nickname.text = CacheManager.gameData.nickName;

        UIPage.m_btn_task.onClick.Add(() => { ActionTask?.Invoke(); });//任务
        UIPage.m_btn_safebox.onClick.Add(() => safebox());
        UIPage.m_btn_rank.onClick.Add(() => { ActionRank?.Invoke(); });//排行榜
        UIPage.m_btn_more.onClick.Add(() => ActionMore());
        UIPage.m_btn_fruit.onClick.Add(() => { fruitMachine(); });      //水果机

        UIPage.m_btn_tree.onClick.Add(() => { ActionTree?.Invoke(); });
        UIPage.m_btn_mail.onClick.Add(() => { ActionMail?.Invoke(); });
        UIPage.m_btn_shop.onClick.Add(() => { ActionShop?.Invoke(0); });
        UIPage.m_btn_allkill.onClick.Add(() => { ActionAllKill?.Invoke(); });  //通杀局
        UIPage.m_btn_classic.onClick.Add(() => { ActionClassic?.Invoke(); });  //经典场
        UIPage.m_btn_tenThousand.onClick.Add(() => { tenThousand(); }); //万人场
        UIPage.m_btn_friend.onClick.Add(() => { ActionFriend?.Invoke(); });
        UIPage.m_btn_freeMoney.onClick.Add(() => { freeMoney(); });//免费金币
        UIPage.m_btn_select.onClick.Add(OnSelectClick);

        UIPage.m_btn_addgold.onClick.Add(() => { ActionShop?.Invoke(0); });
        UIPage.m_btn_addmasonry.onClick.Add(() => { ActionShop?.Invoke(1); });

        UIPage.m_head.onClick.Add(() => { ActionHead?.Invoke(); });

        UIPage.m_addfriends.visible = false;

        UIPage.m_btn_horn.onClick.Add(() => showHorn());//喇叭按钮
        UIPage.m_btn_hornReocrd.onClick.Add(BtnRocrd);//消息记录面板

        Init();
        ShowAddFriendIcon(false);//不显示红点

        
        
       
    }
 

    /// <summary>
    /// 小红点
    /// </summary>
    /// <param name="show"></param>
    public void ShowAddFriendIcon(bool show)
    {
        UIPage.m_addfriends.visible = show;
    }
    public void Init()
    {
 
        UIPage.m_text_nickname.text = CacheManager.gameData.nickName;
        RefCoinsAndMasonry();
        SetLevel();

 
        if(!string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        //if (CacheManager.headImgIcon != null)
        {
            Texture2D t2d = CacheManager.GetHeadIcon(CacheManager.gameData.headIconUrl);
 
            UIPage.m_head.texture = new NTexture(t2d);  //设置头像
        }
        else
        {

            Sprite sprite = null;
            if (CacheManager.gameData.roleId == 0)
            {
                sprite = FileIO.LoadSprite(R.SpritePack.HEAD_MAN);
            }
            else
            {
                sprite = FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN);
            }

            UIPage.m_head.texture = new NTexture(sprite);
        }
        SetVip();
    }

    public void ShowIcon(bool show)
    {
        UIPage.m_addfriends.visible = show;
    }

    public void SetNickname()
    {
        UIPage.m_text_nickname.text = CacheManager.gameData.nickName;
    }
    public void SetHead()
    {
        if(string.IsNullOrEmpty(CacheManager.gameData.headIconUrl))
        //if (CacheManager.headImgIcon == null)
        {
            if (CacheManager.gameData.roleId == 0)     //男生
            {
                UIPage.m_head.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_MAN));
            }
            else        //女
            {
                UIPage.m_head.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN));
            }
        }
    }
    public void SetHead(Texture2D t2d)
    {
        UIPage.m_head.texture = new NTexture(t2d);
    }
    public void SetLevel()
    {
        UIPage.m_text_level.text = ToolClass.Grading(CacheManager.gameData.playerLevel);
    }
    /// <summary>
    /// 刷新金币和砖石
    /// </summary>
    public void RefCoinsAndMasonry()
    {
        UIPage.m_text_coins.text = ToolClass.LongConverStr2(CacheManager.gameData.coins);
        UIPage.m_text_masonry.text = ToolClass.LongConverStr(CacheManager.gameData.crystals);
    }


    public override void Refresh()
    {
        WTUIPage.ShowPage<UIGlobalNotic>().SetPosition(263, 45).SetRotate(0);

        UIPage.m_text_nickname.text = CacheManager.gameData.nickName;
        SetTaskInfoTiShi();
        SetSelectC1(0);
        RefCoinsAndMasonry();
        if ((CacheManager.gameData.coins + CacheManager.gameData.bankCoins) < 3000)
        {
            ActionLow?.Invoke();
        }
        BaseCanvas. PlayBGM(R.AudioClip.GAME_BGM);
        BaseCanvas.GetController<ShopBoxCtrl>().Hide();
    }
    public void SetTaskInfoTiShi()
    {
        if (!isActive())
        {
            return;
        }
        int value = BaseCanvas.GetController<TaskCtrl>().UpdateCanLingQuTask();
        //Debug.Log("当前可领取的任务数为：" + value);
        if (value == 0)
        {
            UIPage.m_taskCtrl.selectedIndex = 0;
            return;
        }
        UIPage.m_taskCtrl.selectedIndex = 1;
        Debug.Log("任务红点控制索引为：" + UIPage.m_taskCtrl.selectedIndex);
        UIPage.m_taskNum.text = value.ToString();
    }
    public void OnSelectClick()
    {
        ActionSelect?.Invoke();
        SetSelectC1(1);
    }
    public void SetSelectC1(int index)
    {
        UIPage.m_c1.SetSelectedIndex(index);
    }
    public void SetVip()
    {
        switch (CacheManager.gameData.vipLv)
        {
            case 0: UIPage.m_vip_load.texture = null; break;
            case 1: UIPage.m_vip_load.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP1));break;
            case 2: UIPage.m_vip_load.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP2)); break;
            case 3: UIPage.m_vip_load.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP3)); break;
            case 4: UIPage.m_vip_load.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP4)); break;
            case 5: UIPage.m_vip_load.texture = new NTexture(FileIO.LoadSprite(R.SpritePack.VIP_VIP5)); break;
            default:
                UIPage.m_vip_load.texture = null;
                break;
        }
    }


    //private List<HornInfoVO> infoList = new List<HornInfoVO>();

    //public void NoticPlay(HornInfoVO vo)
    //{
    //    infoList.Add(vo);
    //    PlayAll();
    //}

    //private void PlayAll()
    //{
    //    if (UIPage.m_notice.m_t1.playing)
    //    {
    //        PlayAllSecond();//再来消息
    //        return;
    //    }
    //    if (UIPage.m_notice.m_t2.playing)
    //    {
    //        PlayAllOne();//再来消息
    //        return;
    //    }

    //    if (infoList == null || infoList.Count == 0)
    //    {
    //        ResetNotie();
    //        return;
    //    }
    //    Movie();
    //}

    /// <summary>
    ///重置小广播面板
    /// </summary>
    //private void ResetNotie()
    //{
    //    UIPage.m_notice.visible = false;
    //    UIPage.m_notice.m_n2.text = "";
    //    UIPage.m_notice.m_n4.texture = null;
    //    UIPage.m_notice.m_n6.text = "";
    //    UIPage.m_notice.m_n7.texture = null;
    //} 

    //private void PlayAllSecond()
    //{
    //    CancelMovie1();
    //    Movie2();
    //}

    /// <summary>
    /// 处理动效1
    /// </summary>
    //private void CancelMovie1()
    //{
    //    if (UIPage.m_notice.m_t1.playing)
    //    {
    //        UIPage.m_notice.m_n5.visible = false;
    //        UIPage.m_notice.m_n2.text = "";
    //        UIPage.m_notice.m_n4.texture = null;
    //        UIPage.m_notice.m_t1.Stop();
    //    }
    //}

    /// <summary>
    /// 动效2
    /// </summary>
    //private void Movie2()
    //{
    //    UIPage.m_notice.visible = true;
    //    UIPage.m_notice.m_n8.visible = true;
    //    UIPage.m_notice.m_n5.visible = false;

    //    HornInfoVO vo = infoList[0];
    //    if (vo.vipLv != 0)
    //    {
    //        string vipName = "GJC/Player/SpritePack/VIP2/vip" + vo.vipLv;
    //        Sprite sp = FileIO.LoadSprite(vipName);
    //        if (sp != null)
    //        {
    //            UIPage.m_notice.m_n7.texture = new NTexture(sp.texture);
    //        }
    //    }
      
    //    string info = "";
    //    if (vo.nikeName == "系统")
    //    {
    //        info = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]" + vo.info;
    //    }
    //    else if (vo.role == 0)
    //    {
    //        info = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]" + vo.info;
    //    }
    //    else
    //    {
    //        info = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]" + vo.info;
    //    }
    //    Debug.LogError("滚动条收到消息：" + info + ",等级：" + vo.vipLv);

    //    UIPage.m_notice.m_n6.text = info;
    //    infoList.RemoveAt(0);

    //    UIPage.m_notice.m_t2.Play(() => { UIPage.m_notice.visible = false; UIPage.m_notice.m_n8.visible = false; PlayAll(); });
    //}

    /// <summary>
    /// 播放动效1
    /// </summary>
    //private void PlayAllOne()
    //{
    //    CancelMovieTwo();
    //    Movie();
    //}
    /// <summary>
    /// 处理动效2
    /// </summary>
    //private void CancelMovieTwo()
    //{
    //    if (UIPage.m_notice.m_t2.playing)
    //    {
    //        UIPage.m_notice.m_n8.visible = false;
    //        UIPage.m_notice.m_n6.text = "";
    //        UIPage.m_notice.m_n7.texture = null;
    //        UIPage.m_notice.m_t2.Stop();
    //    }
    //}

    /// <summary>
    /// 动效1
    /// </summary>
    //private void Movie()
    //{
    //    UIPage.m_notice.visible = true;
    //    UIPage.m_notice.m_n5.visible = true;
    //    UIPage.m_notice.m_n8.visible = false;

    //    HornInfoVO vo = infoList[0];
    //    Sprite sp = null;
    //    if (vo.vipLv > 0)
    //    {
    //        string vipName = "GJC/Player/SpritePack/VIP2/vip" + vo.vipLv;
    //        sp = FileIO.LoadSprite(vipName);
    //    }
    //    if (sp != null)
    //    {
    //        UIPage.m_notice.m_n4.texture = new NTexture(sp.texture);
    //    }

    //    string info;
    //    if (vo.nikeName == "系统")
    //    {
    //        info = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]" + vo.info;
    //    }
    //    else if (vo.role == 0)
    //    {
    //        info = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]" + vo.info;
    //    }
    //    else
    //    {
    //        info = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]" + vo.info;
    //    }

    //    UIPage.m_notice.m_n2.text = info;
    //    infoList.RemoveAt(0);

    //    float speed = (UIPage.m_notice.width + 387) / 16F;
    //    float add = 0;
    //    //动效播放的速度将会是原来的一半。
    //    if (sp != null)
    //    {
    //        add = UIPage.m_notice.m_n4.width;
    //    }
    //    float time = (UIPage.m_notice.m_n2.textWidth + add + UIPage.m_notice.width) / speed;
    //    //Debug.Log("真实时间："+ time+ ",UIPage.m_room.m_notice.width="+ UIPage.m_room.m_notice.width);
    //    if (vo.nikeName == "系统")
    //    {
    //        UIPage.m_notice.m_t1.timeScale = 8f / time * 2;
    //    }
    //    else
    //    {
    //        UIPage.m_notice.m_t1.timeScale = 8f / time;
    //    }
        
    //    //Debug.Log("acale:"+(6f / time));
    //    UIPage.m_notice.m_t1.Play(() => { UIPage.m_notice.visible = false; UIPage.m_notice.m_n5.visible = false; PlayAll(); });
    //}


    /// <summary>
    /// 打开消息记录面板
    /// </summary>
    private void BtnRocrd()
    {
        Vector2 pos = new Vector2(UIPage.m_bg_horn.x, UIPage.m_bg_horn.y) + new Vector2((UIPage.m_bg_horn.width - 383) / 2, UIPage.m_bg_horn.height);
        hornRecord(pos);
    }
}
