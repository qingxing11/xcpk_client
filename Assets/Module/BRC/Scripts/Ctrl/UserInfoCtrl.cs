using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfoCtrl : BaseController, IHandlerReceive
{

    private const bool IsDebug = false;
    private UISelfInfo uiSelfInfo;
    private UIOtherInfo uiOtherInfo;
    public override void InitAction()
    {
        uiSelfInfo = GetUIPage<UISelfInfo>();
        uiSelfInfo.ActionUpdateNickName = SendUpdateNickNameRequest;
        uiSelfInfo.ActionEditorSign = SendUpdateSignRequest;
        uiSelfInfo.ActionUpdateGender = SendUpdateGarderRequest;
        uiSelfInfo.ActionError = ShowErrorUI;
        uiSelfInfo.ActionEditorHead = EditHeadImg;


        uiOtherInfo = GetUIPage<UIOtherInfo>();
        uiOtherInfo.ActionGif = SendChargesEmojiRequest;

        AndroidAndiOS.inst.takePhotoSuccess = SetHeadImg;
    }

    public void SetHeadImg(Texture2D t2d)
    {
        uiSelfInfo.SetHead(t2d);
        GetController<MainSceneCtrl>().SetHeadImg(t2d);

        UpdateHeadIconRequest request = new UpdateHeadIconRequest
        {
            headIcon = t2d.EncodeToJPG(),
        };

        Debug.Log("上传自定义头像，长度:"+ request.headIcon.Length);


#if UNITY_IPHONE
         SendMessage(request);
        return;
#endif

        GameCanvas.gameCanvas.AddReuqestMission(request);

    }

    private void EditHeadImg()
    {
        AndroidAndiOS.inst.TakePhoto();
    }

    /// <summary>
    /// 打开玩家信息简介面板
    /// </summary>
    /// <param name="userId"></param>
    public void PlayInfo(int userId)
    {
        GetSimpleRequest request = new GetSimpleRequest()
        {
            userId = userId,
        };
        SendMessage(request);
    }

#region Request
    private void SendChargesEmojiRequest(int emojiId, int toUserId,int roomId)
    {
        
        ChargesEmojiRequest request = new ChargesEmojiRequest
        {
            emojiId = emojiId,
            toUserId = toUserId,
            roomId = roomId,
        };
        SendMessage(request);
    }
    private void SendUpdateNickNameRequest(string nickName)
    {
        UpdateNickNameRequest request = new UpdateNickNameRequest
        {
            nickName = nickName,
        };
        SendMessage(request);
    }
    private void SendUpdateGarderRequest(int gender)
    {
        UpdateGarderRequest request = new UpdateGarderRequest
        {
            gender = gender,
        };
        SendMessage(request);
    }
    private void SendUpdateSignRequest(string sign)
    {
        UpdateSignRequest request = new UpdateSignRequest
        {
            sign = sign,
        };
        SendMessage(request);
    }
#endregion

    private void ShowErrorUI(string str)
    {
        GetController<MessageCtrl>().Show(str);
    }

    public void ShowSelfInfoUI(bool isCanUpdape = false)
    {
        ShowUI<UISelfInfo>();
        uiSelfInfo.Init(isCanUpdape);
    }

    /// <summary>
    /// 显示其他玩家信息
    /// </summary>
    /// <param name="pos"></param>
    public void ShowOtherInfoUI(PlayerSimpleData playerSimpleData)
    {
        ShowUI<UIOtherInfo>();
        uiOtherInfo.Init(playerSimpleData);
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.USER_上传自定义头像:
                    ReceiveHeadIcon(response.data);
                    break;
                case MsgType.UPDATENICKNAME:
                    ReceiveUpdateInfoResponse(response.data);
                    break;
                case MsgType.UPDATESIGN:
                    ReceiveUpdateSign(response.data);
                    break;
                case MsgType.UPDATEGENDER:
                    ReceiveUpdateGarder(response.data);
                    break;
                case MsgType.GET_SIMPLEDATA:
                    ReceiveGetSimple(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveHeadIcon(byte[] data)
    {
        UpdateHeadIconResponse response = MySerializerUtil.DeSerializerFromProtobufNet<UpdateHeadIconResponse>(data);
        switch (response.code)
        {
            case UpdateHeadIconResponse.SUCCESS:
                Debug.Log("上传头像成功");

                CacheManager.gameData.headIconUrl = response.headIconUrl;
                CacheManager.Init();

                uiSelfInfo.SetHead();
                CacheManager.Init();
                GetController<RoomCtrl>().RefHead();
                break;

            default:
                Debug.Log("上传头像失败");
                break;
        }
    }

    private void ReceiveUpdateInfoResponse(byte[] data)
    {
        UpdateNickNameResponse response = MySerializerUtil.DeSerializerFromProtobufNet<UpdateNickNameResponse>(data);
        switch (response.code)
        {
            case UpdateNickNameResponse.SUCCESS:
                if (IsDebug)
                    Debug.LogError("修改昵称成功");
                CacheManager.gameData.modifyNickName--;
                CacheManager.gameData.nickName = response.nickName;
                uiSelfInfo.SetNickNameAndGender();

                GetController<UserInfoCtrl>().SetCards();
                GetController<MainSceneCtrl>().SetNickname();
                GetController<RoomCtrl>().SetNickname();
                break;
            case UpdateNickNameResponse.ERROR_昵称重复:
                GetController<MessageCtrl>().Show("昵称重复，请重新输入");
                break;
            case UpdateNickNameResponse.ERROR_改名卡不足:
                GetController<MessageCtrl>().Show("改名卡不足");
                break;
            case UpdateNickNameResponse.FAILED:
                Debug.LogError("修改昵称失败");
                break;
        }
    }
    private void ReceiveUpdateSign(byte[] data)
    {
        UpdateSignResponse response = MySerializerUtil.DeSerializerFromProtobufNet<UpdateSignResponse>(data);
        switch (response.code)
        {
            case UpdateSignResponse.SUCCESS:
                if (IsDebug)
                    Debug.LogError("修改签名成功:" + response.sign);
                CacheManager.gameData.sign = response.sign;
                uiSelfInfo.SetSign();
                break;
            case UpdateSignResponse.FAILED:
                Debug.LogError("修改签名失败");
                break;

            default:
                break;
        }
    }
    private void ReceiveUpdateGarder(byte[] data)
    {
        UpdateGarderResponse response = MySerializerUtil.DeSerializerFromProtobufNet<UpdateGarderResponse>(data);
        switch (response.code)
        {
            case UpdateGarderResponse.SUCCESS:
                CacheManager.gameData.roleId = response.garder;
                GetController<MainSceneCtrl>().SetHead();
                uiSelfInfo.SetHead();
                break;
            default:
                break;
        }
    }
    private void ReceiveGetSimple(byte[] data)
    {
        GetSimpleResponse response = MySerializerUtil.DeSerializerFromProtobufNet<GetSimpleResponse>(data);
        switch (response.code)
        {
            case GetSimpleResponse.SUCCESS:
                ShowUI<UIOtherInfo>();
                uiOtherInfo.Init(response.simpleData);
                break;
            default:
                break;
        }
    }
    public void SetCards()
    {
        uiSelfInfo.SetCards();
    }
    /// <summary>
    /// 刷新头像
    /// </summary>
    public void UpdateHead()
    {
        uiSelfInfo.UpdateHead();
        //刷新主面板的头像
        GetController<MainSceneCtrl>().SetHead();
    }

}