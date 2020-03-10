using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class TaskCtrl : BaseController, IHandlerReceive
{
    private List<TaskDetailedInfo> list_dayTask = new List<TaskDetailedInfo>();
    private List<TaskDetailedInfo> list_personSelfTask = new List<TaskDetailedInfo>();
    private List<TaskDetailedInfo> list_systemTask = new List<TaskDetailedInfo>();
    //  private List<bool> list_onLineReward = new List<bool>();
    private UITask uITask;
    private UIWinShow uIWinShow;
    public int freeChouJiang;
    private bool isLingQuIng = false;
    public override void InitAction()
    {
        uITask = GetUIPage<UITask>();
        uITask.taskReceiveAction = TaskRequestReceiveReqward;
        uITask.chouJiangAction = ChouJiangActon;
        uITask.onLineRewardLingQu = LingQuOnLineReward;


        uIWinShow = GetUIPage<UIWinShow>();
    }

    private void LingQuOnLineReward(int timeId)
    {
        Debug.Log("发送请求领取在线奖励消息：" + timeId);
        OnLineRewardRequest request = new OnLineRewardRequest(timeId);
        isLingQuIng = true;
        SendMessage(request);
    }

    private void ChouJiangActon(int isFreeChouJiang)
    {
        if (isFreeChouJiang == 1)
        {
            ChouJiangRequest request = new ChouJiangRequest(isFreeChouJiang);
            SendMessage(request);
        }
        else
        {
            if (CacheManager.gameData.crystals >= 10)
            {
                ChouJiangRequest request = new ChouJiangRequest(isFreeChouJiang);
                SendMessage(request);
            }
            else
            {
                GetController<MessageCtrl>().Show("您的钻石不足");
            }
        }

    }

    private void TaskRequestReceiveReqward(int taskId)
    {
        ReceiveRewardRequest request = new ReceiveRewardRequest(taskId);
        SendMessage(request);
    }

    public Response RunServerReceive(Response response)
    {
        if (response != null)
        {
            switch (response.msgType)
            {
                case MsgType.Push_TaskEveryTimeComplete:
                    UpdateTaskInfo(response.data);
                    break;
                case MsgType.Push_TaskInfo:
                    SetTaskInfo(response.data);
                    break;
                case MsgType.ReceiveReward:
                    ReceiveTaskResponse(response.data);
                    break;
                case MsgType.Push_FreeChouJiang:
                    ReceiveChouJiangInfo(response.data);
                    break;
                case MsgType.ChouJiangResult:
                    ReceiveChouJiangResult(response.data);
                    break;
                case MsgType.Push_onLineRewardInfo:
                    SetOnLineRewardInfo(response.data);
                    break;
                case MsgType.RequestLingQuOnLineReward:
                    UpdateOnLIneRewardInfo(response.data);
                    break;
                default:
                    return response;
            }
        }
        return null;
    }

    private void UpdateOnLIneRewardInfo(byte[] data)
    {
        OnLineRewardResponse response = MySerializerUtil.DeSerializerFromProtobufNet<OnLineRewardResponse>(data);
        switch (response.code)
        {
            case OnLineRewardResponse.SUCCESS:
                uITask.UpdateOnLineRewardInfo(response.timeId);
                isLingQuIng = false;
                break;
            case OnLineRewardResponse.该时间段的奖励已领取:
               // GetController<FruitMechineCtrl>().ShowTips("该时间段的奖励已领取");
                break;
            case OnLineRewardResponse.没有找到该时间段的奖励:
               // GetController<FruitMechineCtrl>().ShowTips("没有找到该时间段的奖励");
                break;
            case OnLineRewardResponse.未到领取该时间段的时间:
               // GetController<FruitMechineCtrl>().ShowTips("未到领取该时间段的时间");
                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 设置在线奖励信息
    /// </summary>
    /// <param name="data"></param>
    private void SetOnLineRewardInfo(byte[] data)
    {
        Push_OnLineRewardInfo response = MySerializerUtil.DeSerializerFromProtobufNet<Push_OnLineRewardInfo>(data);
        uITask.SetOnLineRewardInfo(response.list_onLineRewardInfo);
    }

    private void ReceiveChouJiangResult(byte[] data)
    {
        ChouJiangResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ChouJiangResponse>(data);
        switch (response.code)
        {
            case ChouJiangResponse.SUCCESS:
                if (freeChouJiang == 1)
                {
                    freeChouJiang = 2;
                }
                else
                {
                    if (CacheManager.gameData.crystals >= 10)
                    {
                        CacheManager.gameData.crystals -= 10;
                    }
                    GetController<MainSceneCtrl>().RefCoinsAndMasonry();
                }
                uITask.SetChouJiangShowInfo(response.pathId);
                break;
            case ChouJiangResponse.您今天已经免费抽过奖了:
               // GetController<FruitMechineCtrl>().ShowTips("您今天已经免费抽过奖了");
                break;
            case ChouJiangResponse.没找到该奖项:
               // GetController<FruitMechineCtrl>().ShowTips("没找到该奖项");
                break;
            case ChouJiangResponse.您当前可以免费抽奖一次:
                freeChouJiang = 1;
                uITask.SetFreeChouJiang(freeChouJiang);
                break;
            case ChouJiangResponse.您的钻石不足了:
             //   GetController<FruitMechineCtrl>().ShowTips("您的钻石不足了");
                break;
            default:
                break;
        }
    }

    private void ReceiveChouJiangInfo(byte[] data)
    {
        PushTodayIsFreeChouJiangResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushTodayIsFreeChouJiangResponse>(data);
        freeChouJiang = response.freeChouJiang;
        uITask.SetFreeChouJiang(response.freeChouJiang);
    }


    /// <summary>
    /// 接收服务器发送的领取奖励的消息
    /// </summary>
    /// <param name="data"></param>
    private void ReceiveTaskResponse(byte[] data)
    {
        ReceiveRewardResponse response = MySerializerUtil.DeSerializerFromProtobufNet<ReceiveRewardResponse>(data);
        switch (response.code)
        {
            case ReceiveRewardResponse.SUCCESS:
                UpdataTaskDetailInfo(response.taskDetailedInfo);
                break;
            case ReceiveRewardResponse.当前任务不存在:
               // GetController<FruitMechineCtrl>().ShowTips("当前任务不存在");
                break;
            case ReceiveRewardResponse.当前任务已领取奖励:
                //GetController<FruitMechineCtrl>().ShowTips("当前任务已领取奖励");
                break;
            case ReceiveRewardResponse.当前任务未到领取条件:
               // UpdataTaskDetailInfo(response.taskDetailedInfo);
                break;
            default:
                break;
        }
    }

    private void SetTaskInfo(byte[] data)
    {
        PushPlayerTaskInfoResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushPlayerTaskInfoResponse>(data);
        list_dayTask = response.taskInfo.list_dayTaskInfo;
        list_personSelfTask = response.taskInfo.list_personSelfTaskInfo;
        list_systemTask = response.taskInfo.list_systemTaskInfo;
        uITask.SetTaskInfo(list_dayTask, list_personSelfTask, list_systemTask);
        GetController<MainSceneCtrl>().RefreshRedPoint();
    }



    private void UpdateTaskInfo(byte[] data)
    {
        PushPlayerTaskEveryTimeCompleteResponse response = MySerializerUtil.DeSerializerFromProtobufNet<PushPlayerTaskEveryTimeCompleteResponse>(data);
        UpdataTaskDetailInfo(response.taskDetailInfo);
    }


    /// <summary>
    /// 设置并更新 任务信息
    /// </summary>
    /// <param name="taskDetailedInfo"></param>
    public void UpdataTaskDetailInfo(TaskDetailedInfo taskDetailedInfo)
    {
        TaskDetailedInfo selfTaskDetailedInfo = null;
        if (taskDetailedInfo.taskBigType == 1)
        {
            foreach (TaskDetailedInfo item in list_dayTask)
            {
                if (item.taskId == taskDetailedInfo.taskId)
                {
                    selfTaskDetailedInfo = item;
                    break;
                }
            }
        }
        else if (taskDetailedInfo.taskBigType == 2)
        {
            foreach (TaskDetailedInfo item in list_personSelfTask)
            {
                if (item.taskId == taskDetailedInfo.taskId)
                {
                    selfTaskDetailedInfo = item;
                    break;
                }
            }
        }
        else
        {
            foreach (TaskDetailedInfo item in list_systemTask)
            {
                if (item.taskId == taskDetailedInfo.taskId)
                {
                    selfTaskDetailedInfo = item;
                    break;
                }
            }
        }
        if (selfTaskDetailedInfo == null)
        {
            return;
        }
        selfTaskDetailedInfo.currentValue = taskDetailedInfo.currentValue;
        selfTaskDetailedInfo.isGetReward = taskDetailedInfo.isGetReward;
        selfTaskDetailedInfo.isLingQu = taskDetailedInfo.isLingQu;
        DataTask dataTask = ConfigManager.Configs.DataTask[taskDetailedInfo.taskId];
        //CacheManager.gameData.coins += dataTask.taskRewardValue;
        // GetController<FruitMechineCtrl>().ShowTips("金币+"+dataTask.taskRewardValue);
        uITask.SetShowCoins(dataTask.taskRewardValue);
        GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        uITask.UpdateTaskInfoList();


        //判断任务是否完成 弹出提示文字
        if (selfTaskDetailedInfo.isGetReward&& !selfTaskDetailedInfo.isLingQu)
        {
            //TODO 弹出文字
            uITask.ShowTiShi(dataTask.Name);
            BaseCanvas.PlaySound(R.AudioClip.SOUND_MISSIONCOMPLETE);
        }

        //刷新红点数
        GetController<MainSceneCtrl>().RefreshRedPoint();
    }

    public int UpdateCanLingQuTask()
    {
        int canLingQuValue = 0;
        if (list_dayTask.Count<=0||list_personSelfTask.Count <= 0 || list_systemTask.Count <= 0)
        {
            return canLingQuValue;
        }
        foreach (var item in list_dayTask)
        {
            if (item.isGetReward&&!item.isLingQu)
            {
                canLingQuValue += 1;
            }
        }
        foreach (var item in list_personSelfTask)
        {
            if (item.isGetReward && !item.isLingQu)
            {
                canLingQuValue += 1;
            }
        }
        foreach (var item in list_systemTask)
        {
            if (item.isGetReward && !item.isLingQu)
            {
                canLingQuValue += 1;
            }
        }
        //TODO  设置主界面的任务提示红点数字
        return canLingQuValue;
    }

    public void ShowTask()
    {
        uITask = ShowUI<UITask>();
        if (GameObject.Find("Main Camera").GetComponent<HelpClass>() == null)
        {
            GameObject.Find("Main Camera").AddComponent<HelpClass>();
        }
    }
    int frameIndex = 0;
    public void RunTime()
    {
        if (isLingQuIng)
        {
            return;
        }
        if (++frameIndex % 600 == 0)
        {
            int hour = DateTime.Now.Hour;
            if (hour >= 8 && hour < 9)
            {
                if (uITask.GetLineReward(1) == 3)
                {
                    return;
                }
                uITask.SetLineRewardCanLingQu(1);
            }
            else if (hour >=12 && hour <13)
            {
                if (uITask.GetLineReward(2) == 3)
                {
                    return;
                }
                uITask.SetLineRewardCanLingQu(2);

            }
            else if (hour >= 20 && hour < 21)
            {
                if (uITask.GetLineReward(3) == 3)
                {
                    return;
                }
                uITask.SetLineRewardCanLingQu(3);
            }
            else
            {
                if (uITask.GetLineReward(1) != 3)
                {
                    uITask.SetLineRewardNotCanLingQu(1);
                }
                if (uITask.GetLineReward(2) != 3)
                {
                    uITask.SetLineRewardNotCanLingQu(2);
                }
                if (uITask.GetLineReward(3) != 3)
                {
                    uITask.SetLineRewardNotCanLingQu(3);
                }
            }
        }
    }

    /// <summary>
    /// 中奖效果播放
    /// </summary>
    /// <param name="winCoins"></param>
    public void ShowUIWinShow(long winCoins)
    {
        uIWinShow = ShowUI<UIWinShow>();
        uIWinShow.setWinTextContent(winCoins);
    }
}