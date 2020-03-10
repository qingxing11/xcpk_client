using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoginCtrl : BaseController,IHandlerReceive
{
    private bool isDebug = true;

    public UILogin uiLogin;
    public UIRegist uiRegist;
    public override void InitAction()
    {
        //Show();

        RequestGuestLogin();
    }

    private void RequestGuestLogin()
    {
        int isSupplementary = PlayerPrefs.GetInt(LocalArchiveManager.IS_SupplementaryAccount);
        if (isDebug)
        {
            Debug.Log("是否已注册账号 ：" + isSupplementary);
        }
 
        if (isSupplementary == 0 || InitGameCanvas.ClientConfig.isNewGuest)
        {
            GuestLogin();
        }
        else
        {//已完善账号
            string account = PlayerPrefs.GetString(LocalArchiveManager.ACCOUNT);
            string password = PlayerPrefs.GetString(LocalArchiveManager.PASSWORD);

            if (isDebug)
            {
                Debug.Log("已注册账号,account:" + account+"="+ string.IsNullOrEmpty(account) + ",password:"+ password+"="+ string.IsNullOrEmpty(password));
            }
            if (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))
            {
                GuestLogin();
               
            }
            else
            {
                if (isDebug)
                {
                    Debug.Log("账号登陆过，走登陆通道");
                }
                LoginRequest request = new LoginRequest()
                {
                    account = account,
                    password = password,
                };
                SendMessage(request);
            }
          
        }
    }

    private void GuestLogin()
    {
        string guestAccount = PlayerPrefs.GetString(LocalArchiveManager.GUEST_ACCOUNT);
        if (string.IsNullOrEmpty(guestAccount))
        {
            guestAccount = SystemInfo.deviceUniqueIdentifier;

            //guestAccount = MyUtil.GetRandom(100000000) + (MyTimeUtil.GetCurrTimeMM % 1000000) + "";
        }

        if (InitGameCanvas.ClientConfig.isNewGuest)
        {
            guestAccount = MyUtil.GetRandom(100000000) + (MyTimeUtil.GetCurrTimeMM % 1000000) + "";
        }

        GuestLoginAuthRequest request = new GuestLoginAuthRequest
        {
            device_code = guestAccount,
        };
        Debug.Log("device_code:" + request.device_code);
        SendMessage(request);
    }

    public void Show()
    {
        uiLogin = ShowUI<UILogin>();
        uiLogin.ActionLogin = LoginOnClick;
        uiLogin.ActionRegist = ShowRegistUI;
    }

    private void ShowRegistUI()
    {
        uiRegist = ShowUI<UIRegist>();
        uiRegist.ActionRegist = RegistOnClick;
    }

    private void RegistOnClick(string account, string nickname, string pwd)
    {
        RegisterRequest request = new RegisterRequest
        {
            account = account,
            password = pwd,
            nickName=nickname,
        };
        SendMessage(request);
    }

    private void LoginOnClick(string account, string pwd)
    {
        LoginRequest request = new LoginRequest
        {
            account = account,
            password = pwd,
        };
        SendMessage(request);
    }

    public Response RunServerReceive(Response response)
    {
 
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.USER_GUESTLOGIN:
                    ReceiveGuestLogin(response.data);
                    break;

                case MsgType.USER_LOGIN:
                    ReceiveLogin(response.data);
                    break;
              
                case MsgType.USER_VALIDATION_TOKEN:
                    ReceiveValidation(response.data);
                    break;
                case MsgType.USER_REGISTER:
                    ReceiveRegister(response.data);
                    break;

                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveGuestLogin(byte[] data)
    {
         GuestLoginAuthResponse response = MySerializerUtil.DeSerializerFromProtobufNet<GuestLoginAuthResponse>(data);

        switch (response.code)
        {
            case GuestLoginAuthResponse.SUCCESS:
                 
                CacheManager.tokenVO = response.tokenVO;

                NetWorkClient.InitConnect(InitGameCanvas.mClientConfig.gameIp, InitGameCanvas.mClientConfig.gamePort, InitGameCanvas.mClientConfig.serializerUtil);
                ValidationLogin();

                //if (string.IsNullOrEmpty(PlayerPrefs.GetString(LocalArchiveManager.GUEST_ACCOUNT)))
                //{
                    
                //}
                PlayerPrefs.SetString(LocalArchiveManager.GUEST_ACCOUNT, response.device_code);
                break;

            default:
                Debug.LogError("注册失败");
                ShowUI<UIRegist>();
                break;
        }
    }

    private void ReceiveRegister(byte[] data)
    {
        RegisterResponse response = MySerializerUtil.DeSerializerFromProtobufNet<RegisterResponse>(data);

        switch (response.code)
        {
            case RegisterResponse.SUCCESS:
                

                CacheManager.tokenVO = response.tokenVO;
                NetWorkClient.InitConnect(InitGameCanvas.mClientConfig.gameIp, InitGameCanvas.mClientConfig.gamePort, InitGameCanvas.mClientConfig.serializerUtil);
                ValidationLogin();

                break;

            default:
                Debug.LogError("注册失败");
                ShowUI<UIRegist>();
                break;
        }
    }

    private void ReceiveValidation(byte[] data)
    {
        UserValidationLoginResponse response = MySerializerUtil.DeSerializerFromProtobufNet<UserValidationLoginResponse>(data);
        switch (response.code)
        {
            case UserValidationLoginResponse.SUCCESS:
                CacheManager.gameData = response.gameData;
                CacheManager.Init();
                SceneManager.LoadScene("GameScene");

               
                break;

            case UserValidationLoginResponse.ERROR_已被封号:
                ShowUI<UIBanned>().SetUserId(CacheManager.tokenVO.uid.ToString());
                break;

            default:
                Debug.LogError("向游戏服验证时错误");
                break;
        }
    }

    private void ReceiveLogin(byte[] data)
    {
        LoginResponse response = MySerializerUtil.DeSerializerFromProtobufNet<LoginResponse>(data);
        switch (response.code)
        {
            case LoginResponse.SUCCESS:
                CacheManager.tokenVO = response.tokenVO;
                NetWorkClient.InitConnect(InitGameCanvas.mClientConfig.gameIp, InitGameCanvas.mClientConfig.gamePort, InitGameCanvas.mClientConfig.serializerUtil);
                ValidationLogin();
               
                break;

            default:
                GuestLogin();
                break;
        }
    }


   
    private void ValidationLogin()
    {
        UserValidationLoginRequest request = new UserValidationLoginRequest
        {
            tokenVO = CacheManager.tokenVO,
        };
        SendMessage(request);
    }
}