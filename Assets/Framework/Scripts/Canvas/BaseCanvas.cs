using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;

/// <summary>
/// canvas基类
/// WangTuo
/// </summary>
public abstract partial class BaseCanvas : MonoBehaviour
{
    public Action<Response> hotfix_receive;

    protected int state;

    /// <summary>
    /// 声音组件
    /// </summary>
    private static GameObject audioObject;
    /// <summary>
    /// 特效组件
    /// </summary>
    private static GameObject effectObject;
	/// <summary>
	/// 苹果支付组件
	/// </summary>
	private static GameObject appPayObject;

    private static List<IHandlerReceive> handlerReceive = new List<IHandlerReceive>();

    private static Dictionary<Type, BaseController> map_controller = new Dictionary<Type, BaseController>();

    /// <summary>
    /// 激活控制器，
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static void ActivationConntroller<C>() where C: BaseController, new()
    {
        BaseController ctrl = map_controller.GetValue(typeof(C));
        if (ctrl == null)
        {
            ctrl = new C();
            map_controller.Add(typeof(C), ctrl);
            ctrl.InitAction();
            if (typeof(IHandlerReceive).IsAssignableFrom(typeof(C)))
            {
                handlerReceive.Add((IHandlerReceive)ctrl);
            }
        }
    }

    /// <summary>
    /// 获取控制器，如果空则创建并激活
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T GetController<T>() where T : BaseController, new()
    {
        BaseController ctrl = map_controller.GetValue(typeof(T));
       
        if (ctrl == null)
        {
            ActivationConntroller<T>();
            ctrl = map_controller.GetValue(typeof(T));
            return (T)ctrl;
        }
        return (T)ctrl;
    }
  
    //private Dictionary<Type,Base>

    /// <summary>
    /// 注册回调事件
    /// </summary>
    /// <param name="canvas"></param>
    protected void AddHandlerReceiveEvent(IHandlerReceive canvas)
    {
        handlerReceive.Add(canvas);
        //NetWorkClient.AddReceiveHandler(canvas);
    }

    protected void AddHandlerGlobalReceiveEvent<T>() where T : IHandlerGlobal, new()
    {
        T t = new T();
        handlerReceive.Add((IHandlerReceive)t);

       
        NetWorkClient.AddReceiveHandler(t);
    }
  
    /// <summary>
    /// 为canvas添加声音控制
    /// </summary>
    protected void AddAudioControl()
    {
        if (audioObject == null)
        {
            audioObject = new GameObject("[AudioClip]");
            audioObject.transform.parent = this.transform.parent;
            audioObject.AddComponent<AudioControl>();
        }
    }
	protected void AddAppPayControl()
	{
		#if UNITY_IOS
		if (appPayObject == null)
		{
			appPayObject = new GameObject("AppPay");
			appPayObject.transform.parent = this.transform.parent;
			appPayObject.AddComponent<AppPayManager>();
		}
		#endif
	}
    /// <summary>
    /// 为canvas添加特效控制
    /// </summary>
    protected void AddEffectControl()
    {
        if (effectObject == null)
        {
            effectObject = new GameObject("[SpecialEffect]");
            effectObject.transform.parent = this.transform.parent;
            effectObject.AddComponent<EffectControl>();
        }
    }

    /// <summary>
    /// 设置状态
    /// </summary>
    /// <param name="state"></param>
    protected void SetState(int state)
    {
        this.state = state;
    }

    /// <summary>
    /// 发送数据给服务器
    /// </summary>
    /// <param name="request"></param>
    protected void SendMessage(Request request)
    {
        NetWorkClient.sendRequest(request);
         
        //Debug.Log("发送消息后开始计时等待回应");
        
    }

 

    /// <summary>
    /// 如不为空,获得并移除最后的网络事件
    /// </summary>
    /// <returns></returns>
    protected static Response Response
    {
        get
        {
            return NetWorkClient.NextMission();
        }
    }

    private void RunServerReceive(Response response)
    {
        if (handlerReceive.Count > 0 && response != null)
        {
            //foreach (var item in handlerReceive)
            //{
            //    Debug.Log("item:" + item.GetType().Name);
            //}

            int index = 0;
            do
            {
                int msgType = response.msgType;
                response = handlerReceive[index].RunServerReceive(response);

                if (GameConfig.Config.isDebug)
                {
                    if (response == null)
                    {
                        Debug.LogWarning(handlerReceive[index].GetType().Name + "处理了消息,msgType:"+ msgType);
                    }
                    else
                    {
                        Debug.LogWarning(handlerReceive[index].GetType().Name + "未能处理消息:"+ msgType);
                    }
                }

                index++;
            } while (response != null && index < handlerReceive.Count);

            if (GameConfig.Config.isDebug)
            {
                if (response != null)
                {
                    Debug.LogWarning("接收消息 ： " + response.ToString());
                }
            }

            if (response != null)
            {
                if (hotfix_receive != null)
                {
                    hotfix_receive(response);
                }

                if (GameConfig.Config.isDebug)
                    Debug.LogWarning("未处理的消息："+response.ToString());
            }
        }
    }

    protected virtual void Update()
    {
        RunServerReceive(Response);
        NetWorkClient.RunIdleHeart();
    }

    protected virtual void OnApplicationQuit()
    {
        NetWorkClient.Disconnect();
    }

    protected virtual void OnDisable()
    {
        WTUIPage.CloseAll();
        NetWorkClient.ClearReceiveHandler();

        map_controller.Clear();
        handlerReceive.Clear();
        //
    }

    protected virtual void OnApplicationPause()
    {

    }

    protected virtual void OnApplicationFocus()
    {
            

    }
}

