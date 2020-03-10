using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCtrl : BaseController, IHandlerReceive
{
    bool isDebug = true;

    private UISet uiSet;//设置
    private UISet2 uiSet2;//
    private UIModifyPwd uiModifyPwd;//修改密码
    private UIFindPwd uiFindPwd;    //找回密码
    private UIBindPhone uiBindPhone;//绑定手机
    private UIChangeAcc uiChangeAcc;//切换账号
    private UIPerfectAcc uiPerfectAcc;//完善账号
    public override void InitAction()
    {
        uiSet = GetUIPage<UISet>();
        uiSet.ActionMusic = MusicOnClick;
        uiSet.ActionBullet = BulletOnClick;

        uiSet.ActionSoundValue = ActionSoundValueOnClick;
        uiSet.ActionMusicValue = ActionMusicValueOnClick;

        uiSet.ActionUpdatePwd = ShowModifyPwdUI;  //修改密码
        uiSet.ActionFindPwd = ShowFindPwdUI;      //找回密码
        uiSet.ActionBindPhone = ShowBindPhoneUI;  //绑定手机
        uiSet.ActionChangeAcc = ShowChangeAccUI;  //切换账号
        uiSet.ActionPerfectAcc = ShowPerfectAccUI;//完善账号

        uiSet2 = GetUIPage<UISet2>();
        uiSet2.ActionSoundValue = ActionSoundValueOnClick;
        uiSet2.ActionMusicValue = ActionMusicValueOnClick;
        uiSet2.ActionMusic = MusicOnClick;

        uiModifyPwd = GetUIPage<UIModifyPwd>();
        uiModifyPwd.ActionModifyPwd = SendModifyPwdRequest;
        uiModifyPwd.ActionShowErrorLog = ShowErrorTips;

        uiFindPwd = GetUIPage<UIFindPwd>();
        uiFindPwd.GetCode = FindPasswordGetCode;
        uiFindPwd.FindPassword = FindPassword;

        uiBindPhone = GetUIPage<UIBindPhone>();
        uiBindPhone.ActionGetCode = SendGetCodeRequest;
        uiBindPhone.ActionBind = SendBindPhoneRequest;

        uiPerfectAcc = GetUIPage<UIPerfectAcc>();
        uiPerfectAcc.ActionCreate = SupplementaryAccount;              //完善账号
        uiPerfectAcc.ActionErrorCode = ShowErrorTips;

        uiChangeAcc = GetUIPage<UIChangeAcc>();
        uiChangeAcc.btn_ok = RequestChangeAcc;
    }

    private void BulletOnClick(bool obj)
    {
        if (obj)
            PlayerPrefs.SetInt("bullte", 0);
        else
            PlayerPrefs.SetInt("bullte", 1);
        CacheManager.Bullte = obj;
        //GetController<ChatCtrl>().PopUp(obj);
    }

    private void FindPassword(string password1, string password2, string code)
    {
        string pattern = @"^[a-zA-Z][a-zA-Z0-9]*$"; //匹配字符是以字母开头的字母数字组合

        if (string.IsNullOrEmpty(password1) || string.IsNullOrEmpty(password2))
        {
            GetController<MessageCtrl>().Show("必须输入新密码");
            Debug.Log("必须输入新密码");
            return;
        }

        if (!System.Text.RegularExpressions.Regex.IsMatch(password1, pattern))
        {
            GetController<MessageCtrl>().Show("密码必须是以字母开头的字母或者数字组合");
            Debug.LogError("密码必须是以字母开头的字母或者数字组合");
            return;
        }

        if (string.IsNullOrEmpty(code))
        {
            GetController<MessageCtrl>().Show("验证码不能为空");
            Debug.Log("必须输入验证码");
            return;
        }

        if (!password1.Equals(password2))
        {
            GetController<MessageCtrl>().Show("2次密码输入不一样");
            Debug.Log("2次密码输入不一样");
            return;
        }

        int codeInt = int.Parse(code);
        FindPasswordRequest request = new FindPasswordRequest()
        {
            password = password1,
            code = codeInt,
        };
        SendMessage(request);
    }

    private void FindPasswordGetCode()
    {
        FindPasswordGetCodeRequest request = new FindPasswordGetCodeRequest()
        {

        };
        SendMessage(request);
    }

    private void RequestChangeAcc(string account, string password)
    { 
        CacheManager.gameData.headIconUrl = null;
        //CacheManager.headImgIcon = null;

        ChangeAccountRequest request = new ChangeAccountRequest
        {
            account = account,
            password = password,
        };
        SendMessage(request);
    }

    private void SupplementaryAccount(string account, string nickName, string password)
    {
        SupplementaryAccountRequest request = new SupplementaryAccountRequest
        {
            account = account,
            nickName = nickName,
            password = password,
        };
        SendMessage(request);
    }

    /// <summary>
    /// 音效大小
    /// </summary>
    /// <param name="value"></param>
    private void ActionSoundValueOnClick(int value)
    {
        CacheManager.soundValue = (float)value / 100;
    }
    private void ActionMusicValueOnClick(int value)
    {
        CacheManager.musicValue = (float)value / 100;
        BaseCanvas.BGMSetVolume(CacheManager.musicValue);
    }

    /// <summary>
    /// 音乐开关
    /// </summary>
    /// <param name="arg1"></param>
    /// <param name="arg2"></param>
    private void MusicOnClick(bool arg1, int value)
    {
        if (arg1)
        {
            AudioControl.Instance.BGMPlay(R.AudioClip.LOB_BG);
            AudioControl.Instance.BGMSetVolume((float)value / 100);
        }
        else
        {
            AudioControl.Instance.BGMPause();
        }
    }
    #region ShowUI
    public void ShowSetUI2()
    {
        ShowUI<UISet2>();
    }
    public void ShowSetUI(int index)
    {
        ShowUI<UISet>();
        uiSet.Init(index);
    }
    public void ShowModifyPwdUI()
    {
        ShowUI<UIModifyPwd>();
    }
    public void ShowFindPwdUI()
    {
        ShowUI<UIFindPwd>();
    }
    public void ShowBindPhoneUI()
    {
        if (CacheManager.gameData.accountSupplementary)
        {
            ShowUI<UIBindPhone>();
        }
        else
        {
            GetController<MessageCtrl>().Show("请先完善账号！");
        }
    }
    public void ShowChangeAccUI()
    {
        ShowUI<UIChangeAcc>();
    }
    public void ShowPerfectAccUI()
    {
        ShowUI<UIPerfectAcc>();
    }

    public void ShowErrorTips(string code)
    {
        GetController<MessageCtrl>().Show(code);
    }

    #endregion

    #region SendRequest
    private void SendGetCodeRequest(string phoneNumber)
    {
        BindPhoneGetCodeRequest request = new BindPhoneGetCodeRequest
        {
            phoneNumber = phoneNumber,
        };

        SendMessage(request);
    }
    private void SendBindPhoneRequest(int codeNum)
    {
        BindPhoneRequest request = new BindPhoneRequest
        {
            codeNum = codeNum,
        };
        SendMessage(request);
    }

    public void SendModifyPwdRequest(string oldPwd, string newPwd)
    {
        ModifyPwdRequest request = new ModifyPwdRequest
        {
            oldPwd = oldPwd,
            newPwd = newPwd,
        };
        SendMessage(request);
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.BINDPHONE:
                    ReceiveBindPhone(response.data);
                    break;

                case MsgType.SET_找回密码:
                    FindPassword(response.data);
                    break;

                case MsgType.SET_找回密码获取验证码:
                    FindPasswordGetCode(response.data);
                    break;

                case MsgType.SET_完善账号:
                    SupplementaryAccount(response.data);
                    break;

                case MsgType.SET_切换账号:
                    ReceiveChangeAccout(response.data);
                    break;

                case MsgType.MODIFYPWD:
                    ChangePassword(response.data);
                    break;
                case MsgType.BINDPHONE_GETCODE:
                    ReceiveGetCode(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void ReceiveBindPhone(byte[] data)
    {
        BindPhoneResponse response = MySerializerUtil.DeSerializerFromProtobufNet<BindPhoneResponse>(data);
        switch (response.code)
        {
            case BindPhoneResponse.SUCCESS:
                Debug.Log("绑定成功");
                GetController<MessageCtrl>().Show("绑定成功");
                uiBindPhone.Hide();
                break;

            default:
                Debug.Log("绑定失败");
                break;
        }
    }

    private void FindPassword(byte[] data)
    {
        FindPasswordResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FindPasswordResponse>(data);
        Debug.Log("FindPasswordResponse:" + response);
        switch (response.code)
        {
            case FindPasswordResponse.SUCCESS:
                PlayerPrefs.SetString(LocalArchiveManager.PASSWORD, response.password);
                Debug.Log("修改密码成功");
                GetController<MessageCtrl>().Show("找回密码成功");
                uiFindPwd.Hide();
                break;
            case FindPasswordResponse.ERROR_验证码错误:
                GetController<MessageCtrl>().Show("验证码错误");
                break;
            default:
                GetController<MessageCtrl>().Show("找回密码失败");
                break;
        }
    }

    private void FindPasswordGetCode(byte[] data)
    {
        FindPasswordGetCodeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<FindPasswordGetCodeResponse>(data);
        switch (response.code)
        {
            case FindPasswordGetCodeResponse.SUCCESS:

                GetController<MessageCtrl>().Show("获取验证码成功，请等待");
                break;

            default:
                GetController<MessageCtrl>().Show("获取验证码失败，请重新获取");
                break;
        }
    }

    private void ChangePassword(byte[] data)
    {
        ModifyPwdResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ModifyPwdResponse>(data);
        if (isDebug) Debug.Log("response:" + response);
        switch (response.code)
        {
            case ModifyPwdResponse.SUCCESS:
                PlayerPrefs.SetString(LocalArchiveManager.PASSWORD, response.password);
                Debug.Log("修改密码成功");
                GetController<MessageCtrl>().Show("修改密码成功");
                uiModifyPwd.Hide();
                break;

            case ModifyPwdResponse.ERROR_账号不存在:
                Debug.Log("ERROR_账号不存在");
                GetController<MessageCtrl>().Show("账号不存在");
                break;

            case ModifyPwdResponse.ERROR_原始密码错误:
                Debug.Log("ERROR_原始密码错误");
                GetController<MessageCtrl>().Show("原始密码错误");
                break;

            default:
                Debug.Log("未知错误");
                break;
        }
    }

    private void ReceiveGetCode(byte[] data)
    {
        BindPhoneGetCodeResponse response = MySerializerUtil.DeSerializerFromProtobufNet<BindPhoneGetCodeResponse>(data);
        switch (response.code)
        {
            case Response.SUCCESS:
                GameCanvas.gameCanvas.StartCoroutine(uiBindPhone.GetCode(60));
                break;
            case BindPhoneGetCodeResponse.ERROR_已绑定手机号:
                Debug.LogError("该账号已经绑定了手机号");
                GetController<MessageCtrl>().Show("该账号已经绑定了手机号");
                break;
            case BindPhoneGetCodeResponse.ERROR_获取验证码失败:
                Debug.LogError("获取验证码失败");
                GetController<MessageCtrl>().Show("获取验证码失败");
                break;
            case BindPhoneGetCodeResponse.ERROR_未完善账号:
                Debug.LogError("未完善账号");
                GetController<MessageCtrl>().Show("未完善账号,请先完善账号");
                break;
            default:
                break;
        }
    }

    private void ReceiveChangeAccout(byte[] data)
    {
        Debug.Log("ReceiveChangeAccout.........");
        ChangeAccountResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ChangeAccountResponse>(data);
        switch (response.code)
        {
            case ChangeAccountResponse.SUCCESS:
                GetController<RoomCtrl>().HideOn();
                if (isDebug) Debug.Log("ReceiveChangeAccout:" + response);
                PlayerPrefs.SetInt(LocalArchiveManager.IS_SupplementaryAccount, 1);
                PlayerPrefs.SetString(LocalArchiveManager.ACCOUNT, response.account);
                PlayerPrefs.SetString(LocalArchiveManager.PASSWORD, response.password);
                NetWorkClient.Disconnect();

                SceneManager.LoadScene("InitScene");
                break;
 

            default:
                if (isDebug) Debug.Log("账号或者密码错误，请重新输入..");
                GetController<MessageCtrl>().Show("账号或者密码错误，请重新输入");
                break;
        }
    }

    private void SupplementaryAccount(byte[] data)
    {
        SupplementaryAccountResponse response = MySerializerUtil.DeSerializerFromProtobufNet<SupplementaryAccountResponse>(data);
        Debug.Log("response:" + response);

        switch (response.code)
        {
            case SupplementaryAccountResponse.SUCCESS:
                Debug.Log("完善账号成功");
                //存储账号密码，下次登陆时用账号密码登陆
                if (uiSet != null && uiSet.isActive())
                {
                    uiSet.Hide();
                }
                PlayerPrefs.SetInt(LocalArchiveManager.IS_SupplementaryAccount, 1);
                PlayerPrefs.SetString(LocalArchiveManager.ACCOUNT, response.account);
                PlayerPrefs.SetString(LocalArchiveManager.PASSWORD, response.password);
                uiPerfectAcc.Hide();
                NetWorkClient.Disconnect();

                SceneManager.LoadScene("InitScene");
                break;

            case SupplementaryAccountResponse.ERROR_账号重复:
                GetController<MessageCtrl>().Show("账号重复，请重新输入");
                Debug.Log("ERROR_账号重复");
                break;

            case SupplementaryAccountResponse.ERROR_昵称重复:
                GetController<MessageCtrl>().Show("昵称重复，请重新输入");
                Debug.Log("ERROR_昵称重复");
                break;

            case SupplementaryAccountResponse.ERROR_已经是完善账号:
                Debug.Log("ERROR_已经是完善账号");
                break;

            default:
                Debug.Log("ERROR_其他错误");
                break;
        }
    }
    #endregion
}