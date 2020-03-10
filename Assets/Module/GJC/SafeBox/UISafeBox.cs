using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WT.UI;
using Safebox;
using FairyGUI;
using UnityEngine;

public class UISafeBox : WTUIPage<UI_SafeBoxCom, SafeBoxCtrl>
{
    private int lastComIndex;//上一个界面索引
    public Action<long> depositSafeBox;//存入银行
    public Action<long> fetchSafeBox;//取出银行
    public Action<int, long> transferSafeBox;//转账
    public Action<int> transferSureSafeBox;//转账确认

    private string nikeName;
    private long transferCoins;
    private int otherId;
    public UISafeBox() : base(UIType.Dialog, UIMode.DoNothing, R.UI.SAFEBOX)
    {

    }

    public override void Awake()
    {
        //UIPage.m_txt_input.text = "0";
        lastComIndex = 0;
        UIPage.m_btn_Close.onClick.Add(Hide);//关闭
        UIPage.m_operatingRecordCom.onClick.Add(OnClickOperatingRecordCom);//操作记录
        UIPage.m_operatingRecordCom.m_list_opera.itemRenderer = RecordItemRenderer;//操作记录列表
        UIPage.m_btn_OperatingRecord.onClick.Add(ShowRecord);//打开操作记录面板


        UIPage.m_btn_MyBox.onClick.Add(OnClickMyBox);//我的保险箱
        UIPage.m_btn_Deposit.onClick.Add(Deposit);//存入
        UIPage.m_btn_Fetch.onClick.Add(Fetch);//取出
        UIPage.m_btn_Money.onClick.Add(Transfer);//转账
        UIPage.m_btn_sureOpera.onClick.Add(TransferSure);//确认转账
        UIPage.m_sureOperaCom.m_btn_sure.onClick.Add(TransferSureSafeBox);//确认转账面板:确认按钮
        UIPage.m_sureOperaCom.m_btn_cancel.onClick.Add(TransferCancelSafeBox);//确认转账面板:取消按钮

        UIPage.m_sureOperaCom2.m_btn_sure.onClick.Add(SystemSureSafeBox);//系统消息:确认按钮
        UIPage.m_sureOperaCom2.m_btn_cancel.onClick.Add(SystemCancelSafeBox);//系统消息:取消按钮

    }

    private void ShowRecord()
    {
        if (CacheManager.sbrList==null)
        {
            UIPage.m_operatingRecordCom.m_list_opera.numItems = 0;
        }
        else
        {
            UIPage.m_operatingRecordCom.m_list_opera.numItems = CacheManager.sbrList.Count;
        }
       
    }

    public void RefreshRecord()
    {
        if (UIPage.m_c1.selectedIndex==4)
        {
            ShowRecord();
        }
    }

    private void RecordItemRenderer(int index, GObject item)
    {
        UI_OperatingCom ui=(UI_OperatingCom)item;
        int curIndex = /*CacheManager.sbrList.Count - 1-*/index;
        SafeBoxRecordVO vo = CacheManager.sbrList[curIndex];

        if (vo.otherId==CacheManager.gameData.userId)
        {
            ui.m_txt_kind.text = "转入";
            ui.m_txt_ID.text = vo.userId.ToString();//转账Id
        }
        else
        {
            ui.m_txt_ID.text = vo.otherId.ToString();//转账Id
            ui.m_txt_kind.text = vo.type == 0 ? "转账" : "";//交易类型
        }
        ui.m_txt_time.text = MyTimeUtil.TimeToString(vo.time);//交易时间
        ui.m_txt_tmoney.text =CacheManager.GetUnitNum(vo.money)+"万";//交易金额

    }

    private void SystemCancelSafeBox(EventContext context)
    {
        UIPage.m_c1.selectedIndex = 1;//返回转账面板
        //发送取消消息
    }

    private void SystemSureSafeBox(EventContext context)
    {
        transferSureSafeBox(otherId);
    }

    private void TransferCancelSafeBox(EventContext context)
    {
        UIPage.m_c1.selectedIndex = 1;//返回转账面板
        //发送取消消息

    }

    private void TransferSureSafeBox(EventContext context)
    {
        ShowSystemSureTransfer(nikeName, otherId, transferCoins);
    }

    public void ShowSystemSureTransfer(string nikeName, int userId,long transferCoins)
    {
        UIPage.m_c1.selectedIndex = 3;//系统消息确认转账

        UIPage.m_sureOperaCom2.m_txt_sureTitle.text = "转账用户：" + nikeName + "[" + userId + "]" + ",转账金额:["+ transferCoins+"], 是否确认？";

        otherId = userId;
        this.nikeName = nikeName;
    }

    public void ShowSureTransfer(string nikeName, int userId, long transferCoins)
    {
        lastComIndex = UIPage.m_c1.selectedIndex;
        UIPage.m_c1.selectedIndex = 2;//确认转账

        UIPage.m_sureOperaCom.m_txt_sureTitle.text = "转账用户：" + nikeName + "[" + userId + "]" + " 是否确认？";

        otherId = userId;
        this.nikeName = nikeName;
        this.transferCoins = transferCoins;


    }



    private void TransferSure(EventContext context)
    {
        string id = UIPage.m_txt_inpuID.text;
        string money = UIPage.m_txt_inputMoneyNum.text;
        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(money)|| (!TheStringIsOk(id))||(!TheStringIsOk(money)))
        {
            Debug.LogError("id或者金额为空");
           
            return;
        }

        int ID = int.Parse(id);
        long Money = long.Parse(money);
        if (Money >= 0)
        {
            transferSafeBox(ID, Money);
        }
    }

    public bool TheStringIsOk(string txt)
    {
        foreach (var cha in txt)
        {
            if (!(cha>='0'&&cha<='9'))
            {
                return false;
            }
        }
        return true;
    }


    private void Transfer(EventContext context)
    {
        Debug.Log("转账");
        lastComIndex = UIPage.m_c1.selectedIndex;
    }

    private void Fetch(EventContext context)
    {
        Debug.Log("取出金币");
        string txt = UIPage.m_txt_input.text;
        if (string.IsNullOrEmpty(txt) || (!TheStringIsOk(txt)))
        {
            return;
        }
        long money = long.Parse(UIPage.m_txt_input.text);
        //if (money >= 0)
        //{
        //    Debug.Log("取出金币消息" + money);
        //    fetchSafeBox(money);
        //    UIPage.m_txt_input.text = "";//清空
        //}
        Debug.Log("取出金币消息" + money);
        fetchSafeBox(money);
        UIPage.m_txt_input.text = "";//清空
    }

    private void Deposit(EventContext context)
    {
        Debug.Log("存入金币");
        string txt = UIPage.m_txt_input.text;
        if (string.IsNullOrEmpty(txt))
        {
            return;
        }
        long money = long.Parse(UIPage.m_txt_input.text);
        //if (money>=0)
        //{
        //    Debug.Log("存入金币消息"+ money);
        //    depositSafeBox(money);
        //    UIPage.m_txt_input.text = "";//清空
        //}
        Debug.Log("存入金币消息" + money);
        depositSafeBox(money);
        UIPage.m_txt_input.text = "";//清空
    }

    public override void Refresh()
    {
        base.Refresh();
        RefreshMyBox();
        if (CacheManager.gameData.vipLv<=0)
        {
            UIPage.m_txt_pre.text = "暂无转帐功能";
        }
        else
        {
            UIPage.m_txt_pre.text = "手续费" + Math.Round(CacheManager.transferAccountsPer, 2) * 100 + "%";
        }
       
    }

    public void RefreshMyBox()
    {
        if (UIPage.m_c1.selectedIndex == 0)
        {
            OnClickMyBox();
        }
    }

    private void OnClickMyBox()
    {
        lastComIndex = UIPage.m_c1.selectedIndex;
        UIPage.m_txt_boxBalance.text = CacheManager.GetBankCoin().ToString()+"万";
        UIPage.m_txt_cashBalance.text = CacheManager.GetCoin().ToString()+"万";
    }

    private void OnClickOperatingRecordCom(EventContext context)
    {
        UIPage.m_c1.selectedIndex = lastComIndex;
    }

    public void TranfeSusShow()
    {
        UIPage.m_c1.selectedIndex = 1;//转账界面；
        UIPage.m_txt_inpuID.text = "";
        UIPage.m_txt_inputMoneyNum.text = "";
    }
}
