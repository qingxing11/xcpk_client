using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCtrl : BaseController,IHandlerReceive
{
    private UIShop uiShop;
    public override void InitAction()
    {
        uiShop = GetUIPage<UIShop>();
        uiShop.ActionShop = ActionShopClick;
    }

    public void ActionShopClick(int shopType, int payIndex)
    {
        Debug.Log(shopType + "   " + ",payIndex:"+ payIndex);

        if (shopType == 0)
        {
            ShopBuyGold(payIndex);
            return;
        }
        else if (shopType == 2)
        {
            ShopBuyItem(payIndex);
            return;
        }
         
        int cost = 0;
        int gift = 0;

        switch (payIndex)
        {
            case 0:
                cost = 5;
                gift = 5;
                break;

            case 1:
                cost = 10;
                gift = 11;
                break;

            case 2:
                cost = 30;
                gift = 35;
                break;

            case 3:
                cost = 50;
                gift = 60;
                break;

            case 4:
                cost = 100;
                gift = 130;
                break;

            case 5:
                cost = 500;
                gift = 750;
                break;

            default:
                break;
        }


#if UNITY_STANDALONE || UNITY_EDITOR//unity编辑器模式
        PayTestPayRequest request = new PayTestPayRequest
        {
            payNum = gift,
        };
        SendMessage(request);

        return;
         
#endif

        GetController<PayCtrl>().ShowUI(gift,cost,payIndex);
    }

    private void ShopBuyItem(int payIndex)
    {
        int crystals = CacheManager.gameData.crystals;
        int cost = 0;
        switch (payIndex)
        {
            case 0:
                cost = 5;
                break;

            case 1:
                cost = 5;
                break;

            case 2:
                cost = 5;
                break;

            case 3:
                cost = 50;
                break;

            case 4:
                cost = 50;
                break;

            case 5:
                cost = 50;
                break;

            default:
                break;
        }
        if (crystals >= cost)
        {
            CacheManager.gameData.crystals -= cost;
            SendMessage(new BuyItemRequest(payIndex));
        }
    }

    private void ShopBuyGold(int payIndex)
    {
        int crystals = CacheManager.gameData.crystals;
        int cost = 0;
        switch (payIndex)
        {
            case 0:
                cost = 5;
                break;

            case 1:
                cost = 10;
                break;

            case 2:
                cost = 30;
                break;

            case 3:
                cost = 50;
                break;

            case 4:
                cost = 100;
                break;

            case 5:
                cost = 500;
                break;

            default:
                break;
        }

        if (crystals >= cost)
        {
            CacheManager.gameData.crystals -= cost;
            SendMessage(new BuyGoldRequest(payIndex));
        }
    }

    public void Show(int index)
    {
        ShowUI<UIShop>();
        uiShop.SetIndex(index);
    }

    public void RefreshGoldAndCry()
    {
        if(uiShop != null && uiShop.isActive())
            uiShop.RefreshGoldAndCry();
    }

    public void Hide()
    {
        uiShop.Hide();
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.PAY_TestPay:
                    PayTestPayRespone payResponse = MySerializerUtil.DeSerializerFromProtobufNet<PayTestPayRespone>(response.data);
                    CacheManager.gameData.crystals += payResponse.reward;

                    GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                    uiShop.RefreshGoldAndCry();

                    Debug.Log("钻石增加:"+ payResponse.reward);
                    break;

                case MsgType.PAY_BUYGOLD:
                    ReceiveBuyGold(response.data);
                    break;

                case MsgType.PAY_BUYITEM:
                    ReceiveBuyItem(response.data);
                    break;

                default:
                    return response;
            }
        }
        return null;

    }

    private void ReceiveBuyItem(byte[] data)
    {
        BuyItemRespone response = MySerializerUtil.DeSerializerFromProtobufNet<BuyItemRespone>(data);
        switch (response.code)
        {
            case 1000:
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                AddItem(response.payIndex);
                break;

            default:
                break;
        }

    }

    private void AddItem(int payIndex)
    {
        switch (payIndex)
        {
            case 0:
                CacheManager.gameData.robPos += 6;
                break;

            case 1:
                CacheManager.gameData.addTime += 6;
                break;

            case 2:
                CacheManager.gameData.modifyNickName += 6;
                break;

            case 3:
                CacheManager.gameData.robPos += 70;
                break;

            case 4:
                CacheManager.gameData.addTime += 70;
                break;

            case 5:
                CacheManager.gameData.modifyNickName += 70;
                break;

            default:
                break;
        }
    }

    private void ReceiveBuyGold(byte[] data)
    {
        BuyGoldRespone response = MySerializerUtil.DeSerializerFromProtobufNet<BuyGoldRespone>(data);
        switch (response.code)
        {
            case 1000:
                CacheManager.gameData.coins += response.reward;
                GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                uiShop.RefreshGoldAndCry();
                break;

            default:
                break;
        }
    }
}
