using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailCtrl : BaseController, IHandlerReceive
{
    private UIMail uiMail;
    public override void InitAction()
    {
        uiMail = GetUIPage<UIMail>();
        uiMail.ActionReadMail = SendReadMailRequest;
        uiMail.ActionGetAttach = SendGetAttachRequest;
        uiMail.ActionDelete = SendDeleteMailRequest;
    }

    public void Show(List<MailDataPO> userMailDataPOS)
    {
        ShowUI<UIMail>();
        uiMail.Init(userMailDataPOS);
    }
    private void SendReadMailRequest(int mailId)
    {
        ReadMailRequest request = new ReadMailRequest
        {
            mailId = mailId
        };
        SendMessage(request);
    }
    private void SendGetAttachRequest(int mailId)
    {
        GetAttachRequest request = new GetAttachRequest
        {
            mailId = mailId,
        };
        SendMessage(request);
    }
    private void SendDeleteMailRequest(int mailId)
    {
        DeleteMailRequest request = new DeleteMailRequest
        {
            mailId = mailId,
        };
        SendMessage(request);
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.MAIL_READ:
                    ReceiveReadMail(response.data);
                    break;
                case MsgType.MAIL_GETATTACH:
                    ReceiveGetAttach(response.data);
                    break;
                case MsgType.MAIL_DELETE:
                    ReceiveDeleteMail(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveReadMail(byte[] data)
    {
        ReadMailResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ReadMailResponse>(data);
        switch (response.code)
        {
            case Response.SUCCESS:
                uiMail.ReadAMail(response.mailId);
                break;
            case ReadMailResponse.ERROR_已阅读:
                Debug.LogError("邮件已经阅读过了");
                break;
            case ReadMailResponse.ERROR_邮件不存在:
                Debug.LogError("要阅读的邮件不存在");
                break;
            default:
                break;
        }
    }
    /// <summary>
    /// 领取附件
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveGetAttach(byte[] data)
    {
        GetAttachResponse response = MySerializerUtil.DeSerializerFromProtobufNet<GetAttachResponse>(data);
        switch (response.code)
        {
            case GetAttachResponse.SUCCESS:
                
                Attach attach = JsonUtility.FromJson<Attach>(response.attachString);

                int oldVip = CacheManager.gameData.vipLv;

                switch (attach.id)
                {
                    case (int)LuckyType.VIP1:GetController<MessageCtrl>().Show("领取VIP成功"); 
                        if (CacheManager.gameData.vipLv > 1)
                            break;
                        else
                        {
                            CacheManager.gameData.vipLv = 1;
                           
                            break;
                        }
                    case (int)LuckyType.VIP2:
                        GetController<MessageCtrl>().Show("领取VIP成功");
                        if (CacheManager.gameData.vipLv > 2)
                            break;
                        else
                        {
                            CacheManager.gameData.vipLv = 2;
                          
                            break;
                        }
                    case (int)LuckyType.VIP3:
                        GetController<MessageCtrl>().Show("领取VIP成功");
                        if (CacheManager.gameData.vipLv > 3)
                            break;
                        else
                        {
                            CacheManager.gameData.vipLv = 3;
                          
                            break;
                        }
                    case (int)LuckyType.VIP4:
                        GetController<MessageCtrl>().Show("领取VIP成功");
                        if (CacheManager.gameData.vipLv > 4)
                            break;
                        else
                        {
                            CacheManager.gameData.vipLv = 4;
                           
                            break;
                        }
                    case (int)LuckyType.VIP5:
                        GetController<MessageCtrl>().Show("领取VIP成功");
                        if (CacheManager.gameData.vipLv > 5)
                            break;
                        else
                        {
                            CacheManager.gameData.vipLv = 5;
                          
                            break;
                        }
                    case (int)LuckyType.增时卡:
                        GetController<MessageCtrl>().Show("领取增时卡"+ attach.num +"张");
                        CacheManager.gameData.addTime += attach.num;
                        break;
                    case (int)LuckyType.抢座卡:
                        GetController<MessageCtrl>().Show("领取抢座卡" + attach.num + "张");
                        CacheManager.gameData.robPos += attach.num;
                        break;
                    case (int)LuckyType.改名卡:
                        GetController<MessageCtrl>().Show("领取改名卡" + attach.num + "张");
                        CacheManager.gameData.modifyNickName += attach.num;
                        break;
                    case (int)LuckyType.金币:
                        GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin( attach.num );
                        CacheManager.gameData.coins += attach.num;
                        GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                         BaseCanvas. PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI);
                        break;
                    case (int)LuckyType.钻石:
                        GetController<MessageCtrl>().Show("领取钻石" + attach.num);
                        CacheManager.gameData.crystals += attach.num;
                        GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                        BaseCanvas.PlaySound(R.AudioClip.SOUND_JINBI);
                        break;
                    default:
                        break;
                }
                //如果vip等级变化 刷新
                if (oldVip < CacheManager.gameData.vipLv)
                {
                    //主界面vip变换
                    GetController<MainSceneCtrl>().SetVip();
                    //通杀场下边vip
                    GetController<RoomCtrl>().SetInfoVip();
                }
                uiMail.GetAttach(response.mailId);
                break;
            case GetAttachResponse.ERROR_邮件不存在:
                Debug.LogError("邮件不存在");
                break;
            case GetAttachResponse.ERROR_附件不存在:
                Debug.LogError("附件不存在");
                break;
            default:
                break;
        }
    }
    private void ReceiveDeleteMail(byte[] data)
    {
        DeleteMailResponse response = MySerializerUtil.DeSerializerFromProtobufNet<DeleteMailResponse>(data);
        switch (response.code)
        {
            case DeleteMailResponse.SUCCESS:
                uiMail.RemoveMail(response.mailId);
                uiMail.Refresh();
                Debug.LogError("删除成功");
                break;
            case DeleteMailResponse.ERROR_邮件不存在:
                Debug.LogError("邮件不存在");
                break;
            case DeleteMailResponse.ERROR_附件未领取:
                Debug.LogError("附件未领取");
                GetController<MessageCtrl>().Show("该邮件有附件未领取，不能删除");
                break;
            default:
                break;
        }
    }
}