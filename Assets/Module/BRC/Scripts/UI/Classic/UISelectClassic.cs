using System;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using Classic;

public class UISelectClassic : WTUIPage<UI_SelelClassicRoom, SelectClassicCtrl>
{
    public Action<int> ActionSelectRoom;
    public UISelectClassic() : base(UIType.PopUp, UIMode.DoNothing, R.UI.CLASSIC)
    { }
    public override void Awake()
    {
        UIPage.m_btn_back.onClick.Add(()=> {
            ClickBack();
        });
        UIPage.m_btn_room1.onClick.Add(() => { SelectRoomOnClick(0); });
        UIPage.m_btn_room2.onClick.Add(() => { SelectRoomOnClick(1); });
        UIPage.m_btn_room3.onClick.Add(() => { SelectRoomOnClick(2); });
        UIPage.m_btn_room4.onClick.Add(() => { SelectRoomOnClick(3); });
    }

    private void ClickBack()
    {
        BaseCanvas.GetController<MainSceneCtrl>().CloseSelectRoom();
        base.Hide();

        ShowPage<UIMainScene>();
        BaseCanvas.GetController<MainSceneCtrl>().SendMainSceneEnterKillRoomRequest();
       
    }

    private void SelectRoomOnClick(int index)
    {
        switch (index)
        {
            case 0:
                if (CacheManager.gameData.coins > 100000)
                {
                    BaseCanvas.GetController<MessageCtrl>().Show("金币超过10万不能进入初级场");
                    return;
                }
                if (CacheManager.gameData.coins < 3000)
                {
                    BaseCanvas.GetController<MessageCtrl>().Show("金币低于30000不能进入初级场");
                    return;
                }
                break;
            case 1:
                if (CacheManager.gameData.coins > 500000)
                {
                    BaseCanvas.GetController<MessageCtrl>().Show("金币超过50万不能进入中级场");
                    return;
                }
                if (CacheManager.gameData.coins < 50000)
                {
                    BaseCanvas.GetController<MessageCtrl>().Show("金币低于5万不能进入初级场");
                    return;
                }
                break;
            case 2:
                if (CacheManager.gameData.coins > 2000000)
                {
                    BaseCanvas.GetController<MessageCtrl>().Show("金币超过200万不能进入高级场");
                    return;
                }
                if (CacheManager.gameData.coins <100000)
                {
                    BaseCanvas.GetController<MessageCtrl>().Show("金币低于10万不能进入初级场");
                    return;
                }
                break;
            case 3:
                if (CacheManager.gameData.coins < 2000000)
                {
                    BaseCanvas.GetController<MessageCtrl>().Show("金币不足，不能进入土豪场");
                    return;
                }
                break;
            default:
                break;
        }
        ActionSelectRoom?.Invoke(index);
    }


    public override void Hide()
    {
        if (UIPage != null)
            base.Hide();
    }


    public override void Refresh()
    {
        UIPage.m_text_tips.text = CacheManager.Helper_list[UnityEngine.Random.Range(0, CacheManager.Helper_list.Count)];
    }
}
