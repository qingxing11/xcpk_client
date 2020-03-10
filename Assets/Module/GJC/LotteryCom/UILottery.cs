using DG.Tweening;
using FairyGUI;
using Lottery;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;
 
public class UILottery : WTUIPage<UI_LotteryCom, LotteryCtrl>
{
    public Action<int> btnZDTZ;//自动投注
    public Action<int, int> btnXZ;//下注
    public Action<string> showError;//金币不足
    public Action<int, bool> btnZDTZHideUI;//自动投注（界面隐藏）
    public Action btnHide;

    private int selectIndex=0;//投注倍数
    private int winTypeIndex=-1;//投注类型
    private int selectNumber=1;//投注数量
    private int curNum;//当前下注数
    private int curType = -1;

    private int testTime = 10;

    private List<int> wintype;

    private bool sign;//是否已经重置过
    private bool signZDTZ;//当前局是否点击(首次点击)，相对一直存在
    private bool isSignCanBuy;//是否购买

    private int buyCost = 20000;

    private long curMoney = 0;//当前总奖池

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;

    private bool firstClick=false;

   
    public UILottery() : base(UIType.Dialog, UIMode.DoNothing, R.UI.LOTTERY)
    {
    }

    public override void Awake()
    {
        signZDTZ = false;
       
        UIPage.m_btn_zdtz.onClick.Add(ZhiDongTouZhu);//自动投注

        UIPage.m_list_duigou.onClickItem.Add(OnClickItemDuigou);//倍投
        UIPage.m_list_duigou.selectedIndex = selectIndex;

        UIPage.m_list_select.itemRenderer = SelectRenderer;//赢的方式列表
        UIPage.m_list_select.numItems = 6;
        UIPage.m_list_select.onClickItem.Add(SelectOnClick);

        UIPage.m_list_record.itemRenderer = RecordItemRenderer;//中奖记录
        UIPage.m_list_record.numItems = 0;

        UIPage.m_txt_allmoney.text = "$0";
        UIPage.m_txt_title.text = "";

        UIPage.m_btn_close.onClick.Add(()=> {
            btnHide();
            //signZDTZ = false;
            //UIPage.m_btn_zdtz.selected = false;
        });

        UIPage.m_btn_no.onClick.Add(BtnNo);

        UIPage.m_btn_left.onClick.Add(OnClickLeft);
        UIPage.m_btn_right.onClick.Add(OnClickRight);

        UIPage.m_movi.visible=false;
        UIPage.m_movi.onPlayEnd.Add(MovieOver);

        UIPage.m_movi2.visible = false;
        UIPage.m_movi2.onPlayEnd.Add(MovieOver2);

        UIPage.m_movi3.visible = false;
        UIPage.m_movi3.onPlayEnd.Add(MovieOver3);

        UIPage.m_effect3.visible = false;
        UIPage.m_coinCom.visible = false;
        pos1 = UIPage.m_movi.position;
        pos2 = UIPage.m_movi2.position;
        pos3 = UIPage.m_movi3.position;

        UIPage.m_btn_zdtz.selected = false;
        UIPage.m_btn_zdtz.m_n1.visible = false;
    }

    private void MovieOver3(EventContext context)
    {
        UIPage.m_movi3.visible = false;
        UIPage.m_movi3.position = pos3;
    }

    private void MovieOver2(EventContext context)
    {
        UIPage.m_movi2.visible = false;
        UIPage.m_movi2.position = pos2;
    }

    private void MovieOver(EventContext context)
    {
        UIPage.m_movi.visible = false;
        UIPage.m_movi.position = pos1;
    }
     
    /// <summary>
    /// 烟花爆竹
    /// </summary>
    public void PlayMovi()
    {
        //Debug.Log("##########PlayMovi############");
        System.Random random = new System.Random();
        int ranNum = random.Next(0,10);
        int abs = random.Next(-1,2);

        int ranNum2 = random.Next(0, 10);
        int abs2 = random.Next(-1, 2);

        int ranNum3 = random.Next(0, 10);
        int abs3 = random.Next(-1, 2);

        int ranNum4 = random.Next(0, 10);
        int abs4 = random.Next(-1, 2);

        //Debug.Log("abs1="+ abs+ ",abs2=" + abs2+ ",abs3=" + abs3+ ",abs4=" + abs4);

        UIPage.m_movi.visible = true;
        UIPage.m_movi.position = pos1 - new Vector3(ranNum * abs, ranNum4 * abs4, 0);
        UIPage.m_movi.SetPlaySettings(0, -1, 2, 0);

        UIPage.m_movi2.visible = true;
        UIPage.m_movi2.position = pos2 - new Vector3(ranNum* abs, ranNum4* abs4, 0);
        UIPage.m_movi2.SetPlaySettings(0, -1, 2, 0);

        UIPage.m_movi3.visible = true;
        UIPage.m_movi3.position = pos3 + new Vector3(ranNum2* abs2, ranNum3* abs3, 0);
        UIPage.m_movi3.SetPlaySettings(0, -1, 2, 0);
    }
     
    private void OnClickRight(EventContext context)
    {
        UIPage.m_list_record.scrollPane.ScrollRight();
    }

    private void OnClickLeft(EventContext context)
    {
        UIPage.m_list_record.scrollPane.ScrollLeft();
    }
    /// <summary>
    /// 中奖特效
    /// </summary>
    private void WinEffect(int type)
    {
        UIPage.m_effect3.visible = true;
        switch (type)
        {
            case 0:
                //Debug.Log("播放0");
                UIPage.m_t01.Play(EffectOver);
                break;
            case 1:
                //Debug.Log("播放1");
                UIPage.m_t02.Play(EffectOver);
                break;
            case 2:
                //Debug.Log("播放2");
                UIPage.m_t03.Play(EffectOver);
                break;
            case 3:
                //Debug.Log("播放3");
                UIPage.m_t04.Play(EffectOver);
                break;
            case 4:
                //Debug.Log("播放4");
                UIPage.m_t05.Play(EffectOver);
                break;
            case 5:
                //Debug.Log("播放5");
                UIPage.m_t06.Play(EffectOver);
                break;
            default:
                EffectOver();
                break;
        }
    }

    private void EffectOver()
    {
        UIPage.m_effect3.visible = false;
    }

    private bool CanBuy()
    {
        long money = buyCost * GetNumber(selectIndex) * selectNumber;
        if (money<=CacheManager.gameData.coins)
        {
            return true;
        }
        return false;
    }

    private void BtnNo(EventContext context)
    {
        //TxtError("当前不可以下注！");
    }

    public override void Refresh()
    {
        base.Refresh();
        Debug.Log("当前下注数:"+ curNum);
        //firstClick = false;
      
        selectNumber = 1;
        RefrashSelectState();
        //UIPage.m_btn_zdtz.selected = false;
        //UIPage.m_btn_zdtz.m_n1.visible = false;

        wintype = CacheManager.wintype;
        if (wintype == null || wintype.Count == 0)
        {
            UIPage.m_list_record.numItems = 0;
        }
        else
        {
            UIPage.m_list_record.numItems = wintype.Count;
        }
        RefrashRecord();

        ZDTZNum();
    }
    private Tween tween;
    private Tween tweenJianCha;
    /// <summary>
    /// 下注时间
    /// </summary>
    /// <param name="time"></param>
    public void ShowXiaZhuTime(int time)
    {
        Debug.Log("ShowXiaZhuTime:"+time);
        StopError();//停止播放提示

        //firstClick = false;//新一局开始
        signZDTZ = false;//新一局开始

        isSignCanBuy = true;
        ResLoadIcon();
        UIPage.m_txt_title.text = "";
        //sign = false;
        winTypeIndex = -1;//投注类型
        selectNumber = 1;//投注数量
        //Debug.Log("下注时间 RefrashSelectState");
        RefrashSelectState();

        Ban(false);

        UIPage.m_list_select.SelectNone();

        if (tween != null)
        {
            tween.Kill();
        }
        UIPage.m_bg_xz.visible = true;
        UIPage.m_bg_xyj.visible = false;
        if (!signZDTZ)
        {
            //Debug.Log("111检查自动投注");
            ZhiDongTouZhu();//检查自动投注
        }
        tween =DOTween.To(()=>time-1, (value) => {

            string timeStr = MyTimeUtil.TimeToString(value);
          
          
            UIPage.m_txt_time.text = timeStr; 

        }, 0, time).SetEase(Ease.Linear).OnComplete(()=>
        {
            Debug.Log("完成...");
        });

        tweenJianCha= DOTween.To(() => time, (value) => {}, 0, time-3).OnComplete(() =>
        {
        });
       
    }

    /// <summary>
    /// 下一局时间（开奖倒计时）
    /// </summary>
    /// <param name="time"></param>
    public void ShowXiaYiJuTime(int time)
    {
        isSignCanBuy = false;

        SetOtherState();

        Ban(true);

        if (tween!=null)
        {
            tween.Kill();
        }
        UIPage.m_bg_xyj.visible = true;
        UIPage.m_bg_xz.visible = false;


        tween=DOTween.To(() => time-1, (value) => {

            string timeStr = MyTimeUtil.TimeToString(value);
 

            UIPage.m_txt_time.text = timeStr;

        }, 0, time).SetEase(Ease.Linear).OnComplete(() =>
        {
           
            XiaYiJuCom();
        });
    }

   

    private void Ban(bool ban)
    {
        UIPage.m_btn_no.visible = ban;//禁止点击
    }

   

    public void TxtError(string txt)
    {
        if (UIPage.m_t0.playing)
        {
            UIPage.m_t0.Stop();
        }
        UIPage.m_txt_error.text = txt;
        UIPage.m_t0.Play(OnPlay);
    }

    private void StopError()
    {
        if (UIPage.m_t0.playing)
        {
            UIPage.m_t0.Stop(true,true);
        }
    }

    public void OnPlay()
    {
        UIPage.m_txt_error.text = "";
    }

    /// <summary>
    /// 下一局完成
    /// </summary>
    private void XiaYiJuCom()
    {
       
    }

    //押注完成
    private void YaZhuCom()
    {
        
    }

    /// <summary>
    /// 刷新中奖记录列表
    /// </summary>
    public void RefrashRecord()
    {
        wintype = CacheManager.wintype;
        UIPage.m_list_record.numItems = wintype.Count;
        //UIPage.m_list_record.scrollPane.ScrollToView(UIPage.m_list_record.GetChildAt(0));
        if (UIPage.m_t0.playing)
        {
            UIPage.m_t0.Stop();
        }
        if (UIPage.m_t2.playing)
        {
            UIPage.m_t2.Stop();
        }
    }


    /// <summary>
    /// 抽奖记录
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    private void RecordItemRenderer(int index, GObject item)
    {
        UI_btn_record ui = (UI_btn_record)item;
        int count = wintype.Count - 1;
        ui.m_c1.selectedIndex = wintype[count - index];//中奖类型
        //ui.m_c1.selectedIndex = wintype[index];//中奖类型
    }

    private bool IsCanBugInMoneyAuto(int num)
    {
        bool can = true;
        if (CacheManager.gameData.coins < buyCost * num)
        {
            can = false;
            Debug.Log("******************金币不足**************************");
        }
        return can;
    }

    private bool IsCanBugInMoney(int num)
    {
        bool can = true;
        if (CacheManager.gameData.coins<buyCost* (num-curNum))
        {
            can = false;
            Debug.Log("******************金币不足**************************");
        }
        return can;
    }
    
    float intervalTime = 0.1f;
    Tween tweenIntervalTime;
    bool isCanOnclick=true;
    /// <summary>
    /// 选择哪个奖
    /// </summary>
    /// <param name="context"></param>
    private void SelectOnClick(EventContext context)
    {
        //if (isCanOnclick)
        //{
        //    if (tweenIntervalTime!=null)
        //    {
        //        isCanOnclick = false;
        //        tweenIntervalTime = DOTween.To(() => intervalTime, (value) => {}, 1, intervalTime).SetEase(Ease.Linear).OnComplete(() =>
        //        {
        //            isCanOnclick=true;
        //        });
        //    }
        //}
        //else
        //{
        //    return;
        //}

        //Debug.Log("触摸");
        if (!isSignCanBuy)
        {
            Debug.Log("**********************选择 isSignCanBuy****************************");
            return;
        }

        //if (UIPage.m_btn_zdtz.selected)//自动投注处理(不是10倍)
        //{
        //    UIPage.m_btn_zdtz.selected = false;//去掉自动投注
        //    UIPage.m_btn_zdtz.m_n1.visible = false;
        //}

        UI_btn_select ui = (UI_btn_select)context.data;
        int index = UIPage.m_list_select.GetChildIndex(ui);
        Debug.Log("当前选择：" + GetName(index) + index);
        if (index == winTypeIndex)//相同点击
        {
 
            //curNum += GetNumber(selectIndex) * selectNumber;
            int number = curNum + GetNumber(selectIndex) * selectNumber;
            //判断金币是否足
            bool canBuyInmoney = IsCanBugInMoney(number);
            if (!canBuyInmoney)
            {
                Debug.LogError("金币不足！");
                Debug.Log("*******************选择 1.金币不足！******************************");
                //TxtError("请充值！");
                //ui.selected = false;
                return;
            }

            if (!ui.m_num.visible)
            {
                ui.m_num.visible = true;
            }

            curNum = number;

            //ui.m_txt_number.text = curNum.ToString();
            //Debug.Log("数量："+ ui.m_txt_number.text+",curNum="+ curNum);
            SendMessage();
            return;
        }
        else if(index != winTypeIndex&&winTypeIndex == -1)//第一次点击
        {
            if (!ui.m_num.visible)
            {
                //curNum += GetNumber(selectIndex) * selectNumber;
                int number = curNum + GetNumber(selectIndex) * selectNumber;
                //判断金币是否足
                bool canBuyInmoney = IsCanBugInMoney(number);
                if (!canBuyInmoney)
                {
                    Debug.LogError("金币不足！");
                    Debug.Log("*******************选择 2.金币不足！******************************");
                    TxtError("请充值！");
                    ui.selected = false;
                    return;
                }
                ui.m_num.visible = true;
                curNum = number;
                //ui.m_txt_number.text = curNum.ToString();
                //Debug.Log("数量：" + ui.m_txt_number.text + ",curNum=" + curNum);
            }
            winTypeIndex = index;
            curType = winTypeIndex;
            for (int i = 0; i < UIPage.m_list_select.numItems; i++)
            {
                if (i!= winTypeIndex)
                {
                    UI_btn_select otherUI= (UI_btn_select) UIPage.m_list_select.GetChildAt(i);
                    otherUI.enabled = false;
                }
            }

        }
        else//不同点击
        {
        }

        //bool can = IsCanBugInMoneyAuto(curNum);
        //if (!can)
        //{
        //    //showError("您的金币不足，请充值！");
        //    Debug.Log("SelectOnClick 您的金币不足 RefrashSelectState");
        //    RefrashSelectState();
        //    return;
        //}

        SendMessage();

        SetOtherState();
    }

    private bool CanBuyInmoney(int curNum)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 设置其他未选择为灰色
    /// </summary>
    /// <param name="ui"></param>
    /// <param name="index"></param>
    /// <param name="arr"></param>
    private void SetOtherState()
    {
        GObject[] arr = UIPage.m_list_select.GetChildren();
        foreach (var item in arr)
        {
            UI_btn_select obj = (UI_btn_select)item;

            int curIndex = UIPage.m_list_select.GetChildIndex(obj);
            if (curIndex != winTypeIndex)
            {
                obj.m_button.selectedIndex = 3;
            }
        }
    }

    private void SendMessage()
    {
        if (selectIndex<0||winTypeIndex<0)
        {
            return;
        }
        int type = winTypeIndex;
        Debug.Log("对勾："+"类型="+type+"，数量="+ curNum);
        if (curNum <= 0|| type<0)
        {
            return;
        }
        btnXZ(curNum, type);
    }

    /// <summary>
    /// 重置彩票类型
    /// </summary>
    public void RefrashSelectState()
    {
 
        UIPage.m_list_select.SelectNone();
        GObject[] arr = UIPage.m_list_select.GetChildren();
 
        for (int i = 0; i < arr.Length; i++)
        {
            //Debug.Log("winTypeIndex:" + winTypeIndex);
            UI_btn_select obj = (UI_btn_select)arr[i];
            obj.m_button.selectedIndex = 0;//原始画面
            obj.enabled = true;
            if (curType == i)
            {
                obj.m_num.visible = true;
                obj.m_txt_number.text = curNum.ToString();
               
                obj.m_button.selectedIndex = 1;
            }
            else
            {
                obj.m_txt_number.text = "";
                obj.m_num.visible = false;
                if (curNum > 0)
                {
                    obj.enabled = false;
                    obj.m_button.selectedIndex = 3;
                }
            }
             
        }
 
        winTypeIndex = -1;
    }

    /// <summary>
    /// 奖列表
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    private void SelectRenderer(int index, GObject item)
    {
        UI_btn_select ui = (UI_btn_select)item;
        ui.m_c1.selectedIndex = index;
        ui.m_num.visible = false;
        StopMovie(ui);
    }

    /// <summary>
    /// 点击某个对勾
    /// </summary>
    /// <param name="context"></param>
    private void OnClickItemDuigou(EventContext context)
    {
        UI_btn_duigou ui = (UI_btn_duigou)context.data;
        int index = UIPage.m_list_duigou.GetChildIndex(ui);
        selectIndex = index;
        selectNumber = 1;//投注数量重置
        ZDTZNum();


        if (!isSignCanBuy)
        {
            return;
        }


        //if (signZDTZ)
        //{
        //    curNum += GetNumber(selectIndex);
        //    UI_btn_select select = (UI_btn_select)UIPage.m_list_select.GetChildAt(winTypeIndex);
        //    select.m_txt_number.text = curNum.ToString();
        //}
        SendMessage();
    }

    private Tween tweenAllMoney;

    /// <summary>
    /// 总奖池
    /// </summary>
    public void ShowAllMoneyNumber(long number)
    {
        if (tweenAllMoney!=null)
        {
            tweenAllMoney.Kill();
        }

        float time = 0.7f;
        //Debug.Log("curMoney:" + curMoney + "_number:" + number);
        long start = curMoney;
        long end = number;
        tweenAllMoney = DOTween.To(() => start, (value) => { UIPage.m_txt_allmoney.text = "$" + GetAllMoneyToString(value); curMoney = value; }, end, time).SetEase(Ease.Linear).OnComplete(() =>
        {
            UIPage.m_txt_allmoney.text = "$" + GetAllMoneyToString(end);
            curMoney = end;
        });
    }

    public string GetAllMoneyToString(long value)
    {
        string str = value.ToString();
        int num = str.Length/3;
        if (str.Length%3==0)
        {
            num--;
        }
        for (int i = 0; i < num; i++)
        {
            int index = str.Length-1-((i + 1) * 3 - 1 + i * 1);
            str = str.Insert(index, ",");
            //Debug.Log("插入位置：" + index + "，总奖池：" + str);
        }
        //Debug.Log("总奖池："+str);
        return str;
    }



    /// <summary>
    /// 自动投注
    /// </summary>
    /// <param name="type"></param>
    public void SetSelectBotton(int type,int num)
    {
        Debug.Log("自动投注 RefrashSelectState");
        RefrashSelectState();

        UIPage.m_list_select.selectedIndex = type;
        //UIPage.m_list_duigou.selectedIndex = 2;//10注

        int index = type;
        UI_btn_select ui =(UI_btn_select) UIPage.m_list_select.GetChildAt(index);
        winTypeIndex = index;
        curType = winTypeIndex;
        for (int i = 0; i < UIPage.m_list_select.numItems; i++)
        {
            if (i != winTypeIndex)
            {
                UI_btn_select otherUI = (UI_btn_select)UIPage.m_list_select.GetChildAt(i);
                otherUI.enabled = false;
            }
        }

        ui.m_num.visible = true;
         ui.m_txt_number.text = num.ToString();

        Debug.Log("自助投注类型："+ winTypeIndex + "，数量：" + ui.m_txt_number.text + ",curNum=" + curNum);
        winTypeIndex = index;
        //selectIndex = 2;
        curNum = num;
        SetOtherState();

        
    }

    public void SetSelect(int type,int num)
    {
        this.curType = type;
        this.curNum = num;
    }


    public void HideZDTZ()
    {
        if (UIPage!=null)
        {
            UIPage.m_btn_zdtz.selected = false;
            UIPage.m_btn_zdtz.m_n1.visible = false;
            signZDTZ = false;
        }
    }

    /// <summary>
    /// 自动投注
    /// </summary>
    /// <param name="context"></param>
    private void ZhiDongTouZhu()
    {
        if (!isSignCanBuy)
        {
            UIPage.m_btn_zdtz.selected = false;
            UIPage.m_btn_zdtz.m_n1.visible = false;
            return;
        }
        if (UIPage.m_list_select.selectedIndex>0)//本局不生效
        {
           //Debug.Log("本局不生效");
            if (UIPage.m_btn_zdtz.selected)
            {
                UIPage.m_btn_zdtz.m_n1.visible = true;
                signZDTZ = true;
            }
            else
            {
                UIPage.m_btn_zdtz.m_n1.visible = false;
            }
            return;
        }

        int num = GetNumber(UIPage.m_list_duigou.selectedIndex);
        if (num < 0)
        {
            UIPage.m_btn_zdtz.selected = false;
            UIPage.m_btn_zdtz.m_n1.visible = false;
            return;
        }
        bool can = IsCanBugInMoneyAuto(curNum);
        if (!can)
        {
            TxtError("您的金币不足，请充值！");
            signZDTZ = false;
            UIPage.m_btn_zdtz.selected = false;
            UIPage.m_btn_zdtz.m_n1.visible = false;
            return;
        }

        //if (firstClick)
        //{
        //    UIPage.m_btn_zdtz.selected = true;
        //    return;
        //}

        if (UIPage.m_btn_zdtz.selected)
        {
            //Debug.Log("自动");
            UIPage.m_btn_zdtz.m_n1.visible = true;
            signZDTZ = true;
            //firstClick = true;
            Send();
        }
        else
        {
            //firstClick = false;
            //Debug.Log("不自动");
            UIPage.m_btn_zdtz.m_n1.visible = false;
        }
    }

    private void Send()
    {
        if (!isSignCanBuy)
        {
            return;
        }

        int num = GetNumber(UIPage.m_list_duigou.selectedIndex);
        if (num<0)
        {
            return;
        }
        btnZDTZ(num);
    }

    private void BtnZDTZHideUI()
    {
        if (UIPage != null && UIPage.m_list_duigou != null)
        {
            int num = GetNumber(UIPage.m_list_duigou.selectedIndex);
            btnZDTZHideUI(num, signZDTZ);
        }
        
    }

    Tween tween2;
  

    /// <summary>
    /// 播放动画
    /// </summary>
    private void PlayMovie(UI_btn_select ui)
    {
        if (ui == null)
        {
            return;
        }
        ui.m_c2.selectedIndex = 1;
        if (!ui.m_movie.playing)
        {
            ui.m_movie.playing = true;
            //Debug.Log("播放动画");
            tween2 = DOTween.To(() => 1, (value) => {}, 0, 8).SetEase(Ease.Linear).OnComplete(()=> 
            {
                StopMovie(ui);
                //if (!signZDTZ)
                //{
                //    Debug.Log("非自动投注 RefrashSelectState");
                //    RefrashSelectState();
                //}
                //ResLoadIcon();
                //UIPage.m_txt_title.text = "";
                //sign = false;
                //winTypeIndex = -1;//投注类型
                //selectNumber = 1;//投注数量
            });
        }
    }

    /// <summary>
    /// 停止动画
    /// </summary>
    public void StopMovie(UI_btn_select ui)
    {
        if (ui==null)
        {
            return;
        }
        if (ui.m_movie.playing)
        {
            ui.m_movie.playing = false;
        }
        ui.m_c2.selectedIndex = 0;
        if (tween2!=null)
        {
            tween2.Kill();
        }
    }

    /// <summary>
    /// 彩票结果刷新
    /// </summary>
    /// <param name="type"></param>
    public void RefrashWin(int type)
    {

        //curNum = 0;
        //curType = -1;
        //sign = true;
        UIPage.m_list_select.touchable = true;//可触摸
        UIPage.m_list_duigou.touchable = true;//可触摸

        UI_btn_select ui = (UI_btn_select)UIPage.m_list_select.GetChildAt(type);
        SetOtherState();

        PlayMovie(ui);

        RefrashRecord();
        //RefrashSelectState();
         
    }

    internal void ClearPayNum()
    {
        curNum = 0;
        curType = -1;

        if (UIPage != null)
        {
            RefrashSelectState();
        }
       
    }

    public void ShowTitle(bool win,long money)
    {
        //Debug.Log("彩票结果："+ win);
        if (!win)
        {
            UIPage.m_txt_title.text = "很遗憾您没有中奖！";
        }
        else
        {
            UIPage.m_txt_title.text = "恭喜你！你已经获得"+ money + "筹码";
           
        }
    }
    /// <summary>
    /// 中奖金币
    /// </summary>
    /// <param name="type"></param>
    public void WinEffectCoin(int type)
    {
        Debug.Log("播放转圈特效");
        WinEffect(type);//播放特效
        //PlayMovi();
    }


    public void LoadIcon(PokerVO card1, PokerVO card2, PokerVO card3)
    {
        Sprite sprite1 = FileIO.LoadSprite(card1.value);
        UIPage.m_load_card1.texture = new NTexture(sprite1.texture);

        Sprite sprite2 = FileIO.LoadSprite(card2.value);
        UIPage.m_load_card2.texture = new NTexture(sprite2.texture);

        Sprite sprite3 = FileIO.LoadSprite(card3.value);
        UIPage.m_load_card3.texture = new NTexture(sprite3.texture);
    }

    public void ResLoadIcon()
    {
        UIPage.m_load_card1.texture =null;

        UIPage.m_load_card2.texture = null;

        UIPage.m_load_card3.texture = null;
    }


    public int GetNumber(int index)
    {
        switch (index)
        {
            case 0:
                return 1;
            case 1:
                return 5;
            case 2:
                return 10;
            default:
                break;
        }
        return 0;
    }


    public string GetName(int index)
    {
        switch (index)
        {
            case (int)WinType.单牌:
                return "单牌";
            case (int)WinType.对子:
                return "对子";
            case (int)WinType.豹子:
                return "豹子";
            case (int)WinType.金花:
                return "金花";
            case (int)WinType.顺子:
                return "顺子";
            case (int)WinType.顺金:
                return "顺金";
            default:
                break;
        }
        return "";
    }

 

    private object tweenCoin;
    /// <summary>
    /// 金币自下而上动效
    /// </summary>
    public void ShowPlayCoin()
    {
        UIPage.m_coinCom.visible = true;
        UIPage.m_coinCom.m_t1.Play(CoinOver);
        //Debug.Log(" 金币自下而上动效"+ UIPage.m_coinCom.visible);

        //ShowCoin(true);
        //Vector3 start = UIPage.m_effect2.position;
        //Vector3 end = start+new Vector3(0,-294,0);
        //int time = 3;
        //tweenCoin = DOTween.To(() => start, (value) => { UIPage.m_effect2.position = value; }, end, time).SetEase(Ease.Linear).OnComplete(() =>
        //{
        //    UIPage.m_effect2.visible = false;
        //    UIPage.m_effect2.position = start;
        //});
        //UIPage.m_t3.Play(()=> { ShowCoin(false);});
        //Debug.Log("UIPage.m_effect2.visible="+ UIPage.m_effect2.visible);

    }

    private void CoinOver()
    {
        //Debug.Log("CoinOver");
        UIPage.m_coinCom.visible = false;
        UIPage.m_coinCom.alpha = 1;
        //UIPage.m_coinCom.position = new Vector3(168,-401,0);
    }

    /// <summary>
    /// 自动投注数量显示
    /// </summary>
    private void ZDTZNum()
    {
        Debug.Log("自动投注数量显示:"+ GetNumber(selectIndex));
        //int num = GetNumber(selectIndex);
        UIPage.m_txt_num.text = selectIndex.ToString();

    }
 
    public void RefreshNum(int num)
    {
       
        Debug.Log("######################当前选择数量："+num+",当前下注数:"+ curNum);
        UI_btn_select ui =(UI_btn_select) UIPage.m_list_select.GetChildAt(UIPage.m_list_select.selectedIndex);
        ui.m_txt_number.text = num + "";
        curNum = num;
         
    }

   

    public override void Hide()
    {
        

        BtnZDTZHideUI();
        base.Hide();
    }
 
}

public enum WinType
{
    豹子,顺金,金花,顺子,对子,单牌
}

