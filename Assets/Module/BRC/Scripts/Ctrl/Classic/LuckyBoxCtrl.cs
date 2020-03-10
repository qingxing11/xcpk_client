using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
/// <summary>
/// 宝箱
/// </summary>
public class LuckyBoxCtrl : BaseController, IHandlerReceive
{
    private UILuckyBox uiLuckyBox;
    private UIGifLuckyBox uiGifLuckyBox;

    public int index = 0;

    bool canTrue = true;
    public override void InitAction()
    {
        uiLuckyBox = GetUIPage<UILuckyBox>();
        uiLuckyBox.ActionLuckyBox = SendLuckyBoxRequest;

        uiGifLuckyBox = GetUIPage<UIGifLuckyBox>();
    }

    public void Show()
    {
        ShowUI<UILuckyBox>();
        canTrue = true;
        uiLuckyBox.Init();
        GameCanvas.gameCanvas.StartCoroutine(HideUILuckyBox());
    }

    public IEnumerator HideUILuckyBox()
    {
        yield return new WaitForSeconds(3f);
        if (uiLuckyBox != null && uiLuckyBox.isActive())
        {
            uiLuckyBox.Hide();
        }
        yield return null;
    }

    public void ShowLuckyGifBox(Attach attach, int pos)
    {
        Debug.Log("ShowLuckyGifBox,pos:"+pos);
        //ShowUI<UIGifLuckyBox>();
        //uiGifLuckyBox.Init(index);
        //GameCanvas.gameCanvas.StartCoroutine(HideGifBox());

        WTUIPage.ShowPage<UINewLuckBox>(new object[] { attach, pos });
    }
    private void SendLuckyBoxRequest(int index)
    {
        if (canTrue)
        {
            this.index = index;
            LuckyBoxRequest request = new LuckyBoxRequest { index = index, };
            SendMessage(request);
        }
    }

    public void Hide()
    {
        if (uiLuckyBox != null && uiLuckyBox.isActive())
            uiLuckyBox.Hide();
        GetController<ClassicRoomCtrl>().CloseBtnLucky();
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.LUCKY_BOX:
                    ReceiveLuckyBox(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveLuckyBox(byte[] data)
    {
        LuckyBoxResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LuckyBoxResponse>(data);
        Debug.Log("ReceiveLuckyBox:" + response);
        switch (response.code)
        {
            case Response.SUCCESS:
                GetUIPage<UIClassicRoom>().StopButtonAmi();
                canTrue = false;
                if (response.attachs != null && response.attachs.Count > 0)
                {
                    for (int i = 0; i < response.attachs.Count; i++)
                    {
                        Attach attach = response.attachs[i];
                        ShowLuckyGifBox(attach, GetPos(response.userId));

                    }
                }
                break;
            default:
                break;
        }
    }

    private int GetPos(int userId)
    {
        if (CacheManager.ClassRoomPlayers != null)
        {
            for (int i = 0; i < CacheManager.ClassRoomPlayers.Length; i++)
            {
                PlayerSimpleData item = CacheManager.ClassRoomPlayers[i];
                if (item != null && item.userId == userId)
                {
                    return i;
                }
            }
        }
        return 0;
    }

    IEnumerator HideGifBox()
    {
        yield return new WaitForSeconds(2f);
        if (uiGifLuckyBox != null && uiGifLuckyBox.isActive())
            uiGifLuckyBox.Hide();
        yield return null;
    }
    private void PlayAnim(int num)
    {
        uiLuckyBox.PlayAnima(this.index, num);
    }
}