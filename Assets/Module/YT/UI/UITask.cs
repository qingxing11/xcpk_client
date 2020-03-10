using Config;
using FairyGUI;
using GameTask;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using WT.UI;

public class UITask : WTUIPage<UI_GameTask, SendRedEnvelopeCtrl>
{

    private List<TaskDetailedInfo> list_dayTask = new List<TaskDetailedInfo>();
    private List<TaskDetailedInfo> list_personSelfTask = new List<TaskDetailedInfo>();
    private List<TaskDetailedInfo> list_systemTask = new List<TaskDetailedInfo>();
    public Action<int> taskReceiveAction;
    public Action<int> chouJiangAction;
    public Action<int> onLineRewardLingQu;
    public List<Vector3> list_pos = new List<Vector3>();
    private List<int> list_onLineReward = new List<int>();
    private float fristTime = 0.08f;
    private float secondTime = 0.08f;
    private float slowTime = 0.3f;
    private float leiJiValue = 0.15f;
    private int index = 10;
    private int huanDongindex = 4;
    public UITask() : base(UIType.PopUp, UIMode.DoNothing, R.UI.GAMETASK)
    {

    }


    public override void Awake()
    {
        UIPage.m_compGameTask.m_task.selectedIndex = 0;
        UIPage.m_compGameTask.m_taskList.numItems = list_dayTask.Count;
        UIPage.m_btn_close.onClick.Add(Hide);
        UIPage.m_compGameTask.m_btn_dayTask.onClick.Add(() =>
        {
            UIPage.m_compGameTask.m_task.selectedIndex = 0;
            UIPage.m_compGameTask.m_taskList.numItems = list_dayTask.Count;
            StopChouJiangShow();
        });
        UIPage.m_compGameTask.m_btn_geRenTask.onClick.Add(() =>
        {
            UIPage.m_compGameTask.m_task.selectedIndex = 1;
            UIPage.m_compGameTask.m_taskList.numItems = list_personSelfTask.Count;
        });
        UIPage.m_compGameTask.m_btn_system.onClick.Add(() =>
        {
            UIPage.m_compGameTask.m_task.selectedIndex = 2;
            UIPage.m_compGameTask.m_taskList.numItems = list_systemTask.Count;
        });
        UIPage.m_btn_onLineReward.onClick.Add(() =>
        {
            StopChouJiangShow();
            // UIPage.m_btnClick.selectedIndex = 0;
        });
        UIPage.m_btn_chouJiang.onClick.Add(() =>
        {
            //int freeChouJiangValue = BaseCanvas.GetController<TaskCtrl>().freeChouJiang;
            //if (freeChouJiangValue == 1)
            //{
            //    UIPage.m_freeChouJiang.m_btn.selectedIndex = 0;
            //}
            //else {
            //    UIPage.m_freeChouJiang.m_btn.selectedIndex =1;
            //}
            //UIPage.m_btnClick.selectedIndex = 1;
        });
        UIPage.m_btn_gameTask.onClick.Add(() =>
        {
            StopChouJiangShow();
            //UIPage.m_btnClick.selectedIndex = 2;
        });
        UIPage.m_freeChouJiang.m_btn_free.onClick.Add(() =>
        {
            chouJiangAction.Invoke(1);
        });
        UIPage.m_freeChouJiang.m_btn_cost.onClick.Add(() =>
        {
            chouJiangAction.Invoke(2);
        });
        UIPage.m_compGameTask.m_taskList.itemRenderer = SetTaskInfoRenderer;
        UIPage.m_onLineReward.m_n33.itemRenderer = SetOnLineRewardRenderer;
        InitPos();
        UIPage.m_txt_pop.visible = false;
    }

    internal void UpdateOnLineRewardInfo(int timeId)
    {
        list_onLineReward[timeId - 1] = 3;
        if (!isActive())
        {
            return;
        }
        DataOnLineReward dataOnLine = ConfigManager.Configs.DataOnLineReward[timeId];
        CacheManager.gameData.coins += dataOnLine.onLineRewardValue;
        //BaseCanvas.GetController<FruitMechineCtrl>().ShowTips("金币+" + dataOnLine.onLineRewardValue);
        SetShowCoins(dataOnLine.onLineRewardValue);
        BaseCanvas.GetController<MainSceneCtrl>().RefCoinsAndMasonry();
        UIPage.m_onLineReward.m_n33.numItems = list_onLineReward.Count;
    }

    /// <summary>
    /// 在线奖励列表赋值
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    private void SetOnLineRewardRenderer(int index, GObject item)
    {
        UI_OnLineRewardItem onLineRewardItem = (UI_OnLineRewardItem)item;
        onLineRewardItem.m_timeDuan.text = ConfigManager.Configs.DataOnLineReward.Values.ToList()[index].name;
        int isLingQu = list_onLineReward[index];
        if (isLingQu == 1)
        {
            onLineRewardItem.m_btn_lingQu.selectedIndex = 1;
        }
        else if (isLingQu == 2)
        {
            onLineRewardItem.m_btn_lingQu.selectedIndex = 0;
            onLineRewardItem.m_btn_canLingQu.onClick.Add(() =>
            {
                Debug.Log("请求领取奖励的时间段为 ：" + ConfigManager.Configs.DataOnLineReward.Values.ToList()[index].Id);
                onLineRewardLingQu.Invoke(ConfigManager.Configs.DataOnLineReward.Values.ToList()[index].Id);
            });
        }
        else
        {
            onLineRewardItem.m_btn_lingQu.selectedIndex = 2;
        }
        onLineRewardItem.m_reward.text = "奖励" + ConfigManager.Configs.DataOnLineReward.Values.ToList()[index].onLineRewardValue + "金币";
    }

    /// <summary>
    /// 给在线奖励任务赋值
    /// </summary>
    /// <param name="list_onLineRewardInfo"></param>
    internal void SetOnLineRewardInfo(List<int> list_onLineRewardInfo)
    {
        this.list_onLineReward = list_onLineRewardInfo;
        if (!isActive())
        {
            return;
        }
        UIPage.m_onLineReward.m_n33.numItems = list_onLineReward.Count;
    }

    /// <summary>
    /// 定时判断 是否可以领奖励
    /// </summary>
    /// <param name="timeId"></param>
    internal void SetLineRewardCanLingQu(int timeId)
    {
        //Debug.Log("[===在线任务===]：" + list_onLineReward.Count);
        if (list_onLineReward == null || list_onLineReward.Count <= 0)
        {
            return;
        }
        list_onLineReward[timeId - 1] = 2;
        if (!isActive())
        {
            return;
        }
        UIPage.m_onLineReward.m_n33.numItems = list_onLineReward.Count;
    }



    private void InitPos()
    {
        UIPage.m_freeChouJiang.m_move.visible = false;
        UIPage.m_freeChouJiang.m_movePlay.visible = false;
        for (int i = 0; i < 16; i++)
        {
            list_pos.Add(UIPage.m_freeChouJiang.GetChild("ka" + (i + 1)).position);
            //Debug.Log("初始化位置信息:" + list_pos[i]);
        }
    }

    public IEnumerator MoveMask()
    {
        UIPage.m_freeChouJiang.m_move.visible = true;
        UIPage.m_freeChouJiang.m_move.position = list_pos[0];
        for (int i = 0; i < list_pos.Count; i++)
        {
            UIPage.m_freeChouJiang.m_move.position = list_pos[i];
            yield return new WaitForSeconds(fristTime);
        }
        for (int i = 0; i < list_pos.Count; i++)
        {
            UIPage.m_freeChouJiang.m_move.position = list_pos[i];
            yield return new WaitForSeconds(secondTime);
        }
        for (int i = 0; i < index + 1; i++)
        {
            if (index > 4)
            {
                if (i < index - 4)
                {
                    UIPage.m_freeChouJiang.m_move.position = list_pos[i];
                    yield return new WaitForSeconds(secondTime);
                }
                else
                {
                    UIPage.m_freeChouJiang.m_move.position = list_pos[i];
                    yield return new WaitForSeconds(secondTime + leiJiValue);
                }
            }
            else
            {
                UIPage.m_freeChouJiang.m_move.position = list_pos[i];
                yield return new WaitForSeconds(secondTime + leiJiValue);
            }
        }
        //ShowWiningResult();
        UIPage.m_freeChouJiang.m_movePlay.position = UIPage.m_freeChouJiang.m_move.position;
        UIPage.m_freeChouJiang.m_move.visible = false;
        UIPage.m_freeChouJiang.m_movePlay.visible = true;
        UIPage.m_freeChouJiang.m_play.Play();
        yield return new WaitForSeconds(4);
        UIPage.m_freeChouJiang.m_movePlay.visible = false;
        HelpClass._instance.StopCoroutine(MoveMask());
        int freeChouJiang = BaseCanvas.GetController<TaskCtrl>().freeChouJiang;
        SetFreeChouJiang(freeChouJiang);
        UIPage.m_freeChouJiang.m_btn_free.touchable = true;
        UIPage.m_freeChouJiang.m_btn_cost.touchable = true;
        UIPage.m_freeChouJiang.m_btn_free.grayed = false;
        UIPage.m_freeChouJiang.m_btn_cost.grayed = false;

    }

    public override void Refresh()
    {
        UIPage.m_compGameTask.m_task.selectedIndex = 0;
        if (list_onLineReward == null || list_onLineReward.Count <= 0)
        {
            return;
        }
        int freeChouJiang = BaseCanvas.GetController<TaskCtrl>().freeChouJiang;
        if (freeChouJiang == 1)
        {
            UIPage.m_freeChouJiang.m_btn.selectedIndex = 0;
        }
        else
        {
            UIPage.m_freeChouJiang.m_btn.selectedIndex = 1;
        }
        UIPage.m_onLineReward.m_n33.numItems = list_onLineReward.Count;
        UpdateTaskInfoList();
    }

    internal void SetFreeChouJiang(int freeChouJiang)
    {
        if (!isActive())
        {
            return;
        }
        if (freeChouJiang == 1)
        {
            UIPage.m_freeChouJiang.m_btn.selectedIndex = 0;
        }
        else
        {
            UIPage.m_freeChouJiang.m_btn.selectedIndex = 1;
        }
    }

    internal void SetShowCoins(int taskRewardValue)
    {
        if (!isActive())
        {
            return;
        }
        BaseCanvas.GetController<LotteryCtrl>().ShowUiLotteryWinSigleCoin(taskRewardValue);
        //UIPage.m_txt_pop.visible = true;
        //UIPage.m_txt_pop.text = "金币+" + taskRewardValue;
        //UIPage.m_showTips.Play();
        BaseCanvas.PlaySound(R.AudioClip.SOUND_SOUND_HUODEJINBI,1,false);
    }

    /// <summary>
    /// 列表内容设置
    /// </summary>
    /// <param name="index"></param>
    /// <param name="item"></param>
    private void SetTaskInfoRenderer(int index, GObject item)
    {
        UI_GameTaskItem uI_GameTaskItem = (UI_GameTaskItem)item;
        TaskDetailedInfo taskDetailedInfo = null;
        if (UIPage.m_compGameTask.m_task.selectedIndex == 0)
        {
            taskDetailedInfo = list_dayTask[index];
        }
        else if (UIPage.m_compGameTask.m_task.selectedIndex == 1)
        {
            taskDetailedInfo = list_personSelfTask[index];
        }
        else
        {
            taskDetailedInfo = list_systemTask[index];
        }
        //taskDetailedInfo = list_show[index];
        DataTask dataTask = ConfigManager.Configs.DataTask[taskDetailedInfo.taskId];
        uI_GameTaskItem.m_taskName.text = dataTask.Name;
        uI_GameTaskItem.m_taskDec.text = dataTask.Desc;
        uI_GameTaskItem.m_taskReward.text = "奖励：" + dataTask.taskRewardValue + "金币";
        uI_GameTaskItem.m_taskLimit.text = taskDetailedInfo.currentValue + "/" + taskDetailedInfo.completeValue;

        if (taskDetailedInfo.isLingQu)
        {
            uI_GameTaskItem.m_btn_lingQu.selectedIndex = 2;
            ///uI_GameTaskItem.m_btn_lingQu.selectedIndex = 1;
        }
        else
        {
            if (taskDetailedInfo.isGetReward)
            {
                uI_GameTaskItem.m_btn_lingQu.selectedIndex = 0;
            }
            else
            {
                uI_GameTaskItem.m_btn_lingQu.selectedIndex = 1;
            }
        }
        uI_GameTaskItem.m_btn_canLingQu.onClick.Add(() =>
        {
            if (taskDetailedInfo.isLingQu)
            {
                return;
            }
            taskDetailedInfo.isLingQu = true;
            Debug.Log("请求领取奖励的任务 ：" + taskDetailedInfo);
            taskReceiveAction.Invoke(taskDetailedInfo.taskId);
        });

    }

    internal int GetLineReward(int timeId)
    {
        if (list_onLineReward == null || list_onLineReward.Count <= 0)
        {
            return 0;
        }
        return list_onLineReward[timeId - 1];
    }


    List<TaskDetailedInfo> list_show = new List<TaskDetailedInfo>();
    /// <summary>
    /// 更新任务列表内容
    /// </summary>
    public void UpdateTaskInfoList()
    {
        if (!isActive())
        {
            return;
        }
        if (UIPage.m_compGameTask.m_task.selectedIndex == 0)
        {
            UIPage.m_compGameTask.m_taskList.numItems = list_dayTask.Count;
            list_show = list_dayTask;
        }
        else if (UIPage.m_compGameTask.m_task.selectedIndex == 1)
        {
            UIPage.m_compGameTask.m_taskList.numItems = list_personSelfTask.Count;
            list_show = list_personSelfTask;
        }
        else
        {
            UIPage.m_compGameTask.m_taskList.numItems = list_systemTask.Count;
            list_show = list_systemTask;
        }
        Debug.Log("list_show.count" + list_show.Count);
        // UIPage.m_compGameTask.m_taskList.numItems = list_show.Count;
    }

    internal void SetLineRewardNotCanLingQu(int timeId)
    {
        //Debug.Log("[===在线任务===]：" + list_onLineReward.Count);
        if (list_onLineReward == null || list_onLineReward.Count <= 0)
        {
            return;
        }
        list_onLineReward[timeId - 1] = 1;
        if (!isActive())
        {
            return;
        }
        UIPage.m_onLineReward.m_n33.numItems = list_onLineReward.Count;
    }


    /// <summary>
    /// 设置任务信息
    /// </summary>
    /// <param name="list_dayTask"></param>
    /// <param name="list_personSelfTask"></param>
    /// <param name="list_systemTask"></param>
    public void SetTaskInfo(List<TaskDetailedInfo> list_dayTask, List<TaskDetailedInfo> list_personSelfTask, List<TaskDetailedInfo> list_systemTask)
    {
        this.list_dayTask = list_dayTask;
        //foreach (var item in list_dayTask)
        //{
        //    Debug.Log("list_dayTask :"+item.ToString());
        //}
        this.list_personSelfTask = list_personSelfTask;
        //foreach (var item in list_personSelfTask)
        //{
        //    Debug.Log("list_personSelfTask :" + item.ToString());
        //}
        this.list_systemTask = list_systemTask;
        //foreach (var item in list_systemTask)
        //{
        //    Debug.Log("list_systemTask :" + item.ToString());
        //}
        UpdateTaskInfoList();
    }





    private void StopChouJiangShow()
    {
        UIPage.m_freeChouJiang.m_move.visible = false;
        UIPage.m_freeChouJiang.m_movePlay.visible = false;
        HelpClass._instance.StopCoroutine(MoveMask());
    }

    public void SetChouJiangShowInfo(int pathId)
    {
        if (!isActive())
        {
            return;
        }
        if (UIPage.m_btnClick.selectedIndex != 1)
        {
            return;
        }
        index = pathId - 1;
        UIPage.m_freeChouJiang.m_btn_free.touchable = false;
        UIPage.m_freeChouJiang.m_btn_cost.touchable = false;
        UIPage.m_freeChouJiang.m_btn_free.grayed = true;
        UIPage.m_freeChouJiang.m_btn_cost.grayed = true;
        HelpClass._instance.StartCoroutine(MoveMask());

    }

    public void ShowTiShi(string name)
    {
        UITaskTiShi uITaskTiShi = ShowPage<UITaskTiShi>("name");
        uITaskTiShi.Play(name);
    }
}