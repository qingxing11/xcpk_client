using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifCtrl : BaseController, IHandlerReceive
{
    private UIGif uiGif;

    public override void InitAction()
    {
        uiGif = GetUIPage<UIGif>();
    }

    public void Show()
    {
        ShowUI<UIGif>();
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.CHAT_收费表情:
                    ReciveChargesEmoji(response.data);
                    break;
                case MsgType.PUSH_收费表情:
                    ReciveSendMsg_ChargesEmoji(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }



    //自己发送收费表情
    private void ReciveChargesEmoji(byte[] data)
    {
        Debug.Log("自己发送收费表情");
        ChargesEmojiResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ChargesEmojiResponse>(data);
        switch (response.code)
        {
            case Response.SUCCESS:
                OnChargesEmoji(response.emojiId,response.toUserId,response.roomId);
                break;
            case ChargesEmojiResponse.ERROR_不在游戏中:
                Debug.LogError("不在游戏中");
                break;
            case ChargesEmojiResponse.ERROR_金币不足:
                Debug.LogError("金币不足");
                break;
            default:
                Debug.LogError("收费表情发生未知错误，错误代码：" + response.code);
                break;
        }
    }

    private void OnChargesEmoji(int emojiId,int toUserId,int roomId)
    {
        Show();
        int coins = GetEmojiCost(emojiId);

        int startPos = 9;
        int endPos = -1;

        long mineCoins = CacheManager.gameData.coins;
        CacheManager.gameData.coins -= coins;
        Debug.Log("自己发送收费表情,发送前金币:"+ mineCoins + ",扣除金币:" + coins+ ",自己金币剩余:"+ CacheManager.gameData.coins+ ",CacheManager.KillRoomTV:"+ CacheManager.KillRoomTV+ ",roomId:"+ roomId);
        switch (CacheManager.RunRoomId)
        {
            case 0: //通杀场
                if (toUserId == CacheManager.banker.userId)     //发送给庄家
                {
                    CacheManager.banker.coins += (long)(0.8f * coins);
                    endPos = 8;
                }
                else
                {
                    if (CacheManager.TablePlayers != null)
                    {
                        for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
                        {
                            PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[i];
                            if (playerSimpleData != null && playerSimpleData.userId == toUserId)
                            {
                                playerSimpleData.coins += (long)(0.8f * coins);
                                endPos = i;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
                {
                    PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[i];
                    if (playerSimpleData != null && playerSimpleData.userId == CacheManager.gameData.userId)
                    {
                        Debug.Log("收费表情扣除金币 ：" + coins);
                        startPos = i;
                        playerSimpleData.coins -= coins;
                        break;
                    }
                }
                if (roomId == 0)
                {
                    uiGif.PlayGifAnim(startPos, endPos, emojiId);
                }
           
                GetController<RoomCtrl>().RefreshCoin();
                GetController<RoomCtrl>().RefPosCoinse(endPos);
                break;

            case 1:  //经典场

                startPos = 0;
                //刷新金币
                GetController<ClassicRoomCtrl>().RefPosCoin(0);

                for (int i = 0; i < 5; i++)
                {
                    PlayerSimpleData playerSimpleData = CacheManager.ClassRoomPlayers[i];
                    if (playerSimpleData != null && playerSimpleData.userId == toUserId)
                    {
                        playerSimpleData.coins += (int)(0.8f * coins);
                        GetController<ClassicRoomCtrl>().RefPosCoin(i);
                        endPos = i;
                        break;
                    }
                }

                uiGif.PlayGifAnimClassic(startPos, endPos, emojiId);
                break;

            case 5://万人场
                startPos = 0;
                for (int i = 0; i < 5; i++)
                {
                    PlayerSimpleData playerSimpleData = CacheManager.ManyPeopleRoomPlayers[i];
                    if (playerSimpleData != null && playerSimpleData.userId == toUserId)
                    {
                        playerSimpleData.coins += (int)(0.8f * coins);

                        endPos = i;
                        break;
                    }
                }
                if (CacheManager.ManyPeopleRoomPlayers[0] != null && CacheManager.ManyPeopleRoomPlayers[0].userId == CacheManager.gameData.userId)
                {
                    CacheManager.ManyPeopleRoomPlayers[0].coins -= coins;
                    GetController<TenThousandRoomCtrl>().RefreshPosCoin(0);
                }
                //刷新自己金币
                GetController<TenThousandRoomCtrl>().RefreshCoin();
                GetController<TenThousandRoomCtrl>().RefreshPosCoin(endPos);
                uiGif.PlayGifAnimClassic(startPos, endPos, emojiId);
                break;

            default:
                break;
        }
        PlayGifAudio(CacheManager.gameData.roleId, emojiId);
    }

    private static int GetEmojiCost(int emojiId)
    {
        int coins = 0;
        if (emojiId == 0 || emojiId == 1)
            coins = 50000;
        else if (emojiId == 2 || emojiId == 3)
            coins = 100000;
        else if (emojiId == 4 || emojiId == 5)
            coins = 200000;
        return coins;
    }

    //其他玩家发送收费表情
    private void ReciveSendMsg_ChargesEmoji(byte[] data)
    {
        SendMsg_ChargesEmoji response = MySerializerUtil.DeSerializerFromProtobufNet<SendMsg_ChargesEmoji>(data);
        Debug.Log("ReciveSendMsg_ChargesEmoji,CacheManager.RunRoomId:" + CacheManager.RunRoomId+ ",roomId:" + response.roomId+ ",toUserId:" + response.toUserId+ ",KillRoomTV="+ CacheManager.KillRoomTV);

        if (CacheManager.KillRoomTV == 1 || CacheManager.KillRoomTV == 2)
            return;

        Show();

        int startPos = -1;
        int endPos = -1;

        int coins = 0;
        if (response.emojiId == 0 || response.emojiId == 1)
            coins = 50000;
        else if (response.emojiId == 2 || response.emojiId == 3)
            coins = 100000;
        else if (response.emojiId == 4 || response.emojiId == 5)
            coins = 200000;

        int roleId = 0;

        if (CacheManager.RunRoomId == 0 && response.roomId == CacheManager.RunRoomId)  //通杀场
        {
            if (response.toUserId == CacheManager.banker.userId)     //发送给庄家
            {
                CacheManager.banker.coins += (long)(0.8f * coins);
                endPos = 8;
            }
            else
            {
                if (CacheManager.TablePlayers != null)
                {
                    for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
                    {
                        PlayerSimpleData playerSimple = CacheManager.TablePlayers[i];
                        if (playerSimple != null && playerSimple.userId == response.toUserId)
                        {
                            endPos = i;
                            playerSimple.coins += (long)(0.8f * coins);
                        }
                    }
                }
            }
            if (response.toUserId == CacheManager.gameData.userId)
            {
                CacheManager.gameData.coins += (long)(0.8f * coins);
                GetController<RoomCtrl>().RefreshCoin();
            }

            if (response.userId == CacheManager.banker.userId)
            {
                CacheManager.banker.coins -= coins;
                startPos = 8;
                roleId = CacheManager.banker.roleId;
            }
            else
            {
                if (CacheManager.TablePlayers != null)
                {
                    for (int i = 0; i < CacheManager.TablePlayers.Length; i++)
                    {
                        PlayerSimpleData playerSimpleData = CacheManager.TablePlayers[i];
                        if (playerSimpleData != null && playerSimpleData.userId == response.userId)
                        {
                            playerSimpleData.coins -= coins;
                            startPos = i;
                            roleId = playerSimpleData.roleId;
                        }
                    }
                }
            }
            GetController<RoomCtrl>().RefPosCoinse(startPos);
            GetController<RoomCtrl>().RefPosCoinse(endPos);

            uiGif.PlayGifAnim(startPos, endPos, response.emojiId);
        }
         
        else if (CacheManager.RunRoomId == 1 && response.roomId == CacheManager.RunRoomId)//经典场
        {
            for (int i = 0; i < CacheManager.ClassRoomPlayers.Length; i++)
            {
                PlayerSimpleData playerSimple = CacheManager.ClassRoomPlayers[i];
                if (playerSimple != null && playerSimple.userId == response.toUserId)
                {
                    endPos = i;
                    playerSimple.coins += (long)(0.8f * coins);
                }
                if (playerSimple != null && playerSimple.userId == response.userId)
                {
                    startPos = i;
                    playerSimple.coins -= coins;
                    roleId = playerSimple.roleId;
                }
            }
            if (response.toUserId == CacheManager.gameData.userId)
            {
                CacheManager.gameData.coins += (long)(0.8f * coins);
            }
            uiGif.PlayGifAnimClassic(startPos, endPos, response.emojiId);
            GetController<ClassicRoomCtrl>().RefPosCoin(startPos);
            GetController<ClassicRoomCtrl>().RefPosCoin(endPos);
        }
        else if (CacheManager.RunRoomId == 5 && response.roomId == CacheManager.RunRoomId)//万人场
        {
            startPos = endPos = 0;
            for (int i = 0; i < CacheManager.ManyPeopleRoomPlayers.Length; i++)
            {
                PlayerSimpleData playerSimple = CacheManager.ManyPeopleRoomPlayers[i];
                if(playerSimple!=null&&playerSimple.userId==response.toUserId)
                {
                    playerSimple.coins += (long)(0.8f * coins);
                    endPos = i;
                }
                if (playerSimple != null && playerSimple.userId == response.userId)
                {
                    playerSimple.coins -=  coins;
                    startPos = i;
                }
            }
            if(response.toUserId == CacheManager.gameData.userId)
            {
                CacheManager.gameData.coins += (long)(0.8f * coins);
                GetController<TenThousandRoomCtrl>().RefreshCoin();
            }
            uiGif.PlayGifAnimClassic(startPos, endPos, response.emojiId);
            GetController<TenThousandRoomCtrl>().RefreshPosCoin(startPos);
            GetController<TenThousandRoomCtrl>().RefreshPosCoin(endPos);
        }

        if(response.roomId == CacheManager.RunRoomId)
            PlayGifAudio(roleId, response.emojiId);
    }

    private void PlayGifAudio(int roleId,int emojiId)
    {
        int soundId = -1;
        int emojiSound = -1;
        switch (emojiId)
        {
            case 0:
                if (roleId == 0)
                    soundId = R.AudioClip.GIF_FLOWER0;
                else
                    soundId = R.AudioClip.GIF_FLOWER1;
                    emojiSound = R.AudioClip.GIF_GIFFLOWER;
                break;
            case 1:
                if (roleId == 0)
                    soundId = R.AudioClip.GIF_GANBEI0;
                else
                    soundId = R.AudioClip.GIF_GANBEI1;
                emojiSound = R.AudioClip.GIF_GIFGANBEI;
                break;
            case 2:
                if (roleId == 0)
                    soundId = R.AudioClip.GIF_KISS0;
                else
                    soundId = R.AudioClip.GIF_KISS1;
               
                break;
            case 3:
                if (roleId == 0)
                    soundId = R.AudioClip.GIF_EGG0;
                else
                    soundId = R.AudioClip.GIF_EGG1;
                break;
            case 4:
                if (roleId == 0)
                    soundId = R.AudioClip.GIF_SHOSE0;
                else
                    soundId = R.AudioClip.GIF_SHOSE1;
                emojiSound = R.AudioClip.GIF_GIFSHOSE;
                break;
            case 5:
                if (roleId == 0)
                    soundId = R.AudioClip.GIF_BOOM0;
                else
                    soundId = R.AudioClip.GIF_BOOM1;
                emojiSound = R.AudioClip.GIF_GIFBOOM;
                break;
            default:
                break;
        }
        if (soundId != -1)
        {
            BaseCanvas.PlaySound(soundId);
        }
        if (emojiSound != -1)
        {
            BaseCanvas.PlaySound(emojiSound);
        }
    }
}