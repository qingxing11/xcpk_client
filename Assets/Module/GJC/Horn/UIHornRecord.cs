using FairyGUI;
using Horn;
using Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public class UIHornRecord : WTUIPage<UI_HornRecord, RoomCtrl>
{
    public UIHornRecord() : base(UIType.PopUp, UIMode.DoNothing, R.UI.ROOM)
    {

    }

    public override void Awake()
    {
        UIPage.m_list.itemRenderer = ItemRenderer;
        UIPage.m_list.autoResizeItem = true;
        UIPage.m_btn_close.onClick.Add(Hide);
    }

    private void ItemRenderer(int index, GObject item)
    {
        UI_recordCom ui = (UI_recordCom)item;
        HornInfoVO vo = CacheManager.list_hornVO[CacheManager.list_hornVO.Count - 1 - index];
        if (vo == null)
        {
            Debug.LogError("没有HornInfoVO数据！");
            return;
        }
        if (vo.vipLv > 0)
        {
            string vipName = "GJC/Player/SpritePack/VIP2/vip" + vo.vipLv;
            Sprite sp = FileIO.LoadSprite(vipName);
            if (sp != null)
            {
                ui.m_icon.texture = new NTexture(sp.texture);
            }
        }

        if (vo.vipLv > 0)
        {
            ui.m_c1.selectedIndex = 1;
           
            if (vo.nikeName == "系统")
            {
                ui.m_txt_nikeName.text = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]";
            }
            else if(vo.role == 0)
            {
                ui.m_txt_nikeName.text = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]";
            }
            else
            {
                ui.m_txt_nikeName.text = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]";
            }

            ui.m_txtInfo.text = vo.info;
            ui.m_txtInfo.x = ui.m_txt_nikeName.x + ui.m_txt_nikeName.textWidth;
            ui.height = ui.m_txtInfo.textHeight + 5;
        }
        else
        {
            if (vo.nikeName == "系统")
            {
                ui.m_txt_title.text = "[color=#FF0000]" + vo.nikeName + ":" + "[/color]";
            }
            else if (vo.role == 0)
            {
                ui.m_txt_title.text = "[color=##5888B0]" + vo.nikeName + ":" + "[/color]";
            }
            else
            {
                ui.m_txt_title.text = "[color=#BB7493]" + vo.nikeName + ":" + "[/color]";
            }

            ui.m_c1.selectedIndex = 0;
            ui.m_txtInfo0.text = vo.info;
            ui.m_txtInfo0.x = ui.m_txt_title.x + ui.m_txt_title.textWidth;
            ui.height = ui.m_txtInfo0.textHeight + 5;
        }

    }

    public override void Refresh()
    {
        RefreshList();
    }

    public void RefreshList()
    {
        UIPage.m_list.numItems = CacheManager.list_hornVO.Count;
        UIPage.m_list.autoResizeItem = true;
    }

    public void SetHornPosition(Vector2 pos)
    {
        UIPage.m_recordCom.position = pos;
    }

}
