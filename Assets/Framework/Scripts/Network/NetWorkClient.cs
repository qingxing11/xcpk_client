
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using WT.UI;

/// <summary>
/// 功能示例：
/// 
/// </summary>
public class NetWorkClient
{
    private static int idleNum;
    private static List<IHandlerGlobal> list_handlerReceive_lost = new List<IHandlerGlobal>();

    private static bool isWrite;
    private static bool isRead;
    private static long startIdleTime_write;
    private static long startIdleTime_read;

    public static IEnumerator RunIdleHeartCoroutine()
    {
        while (true)
        {
            yield return null;
            RunIdleHeart_write();
            RunIdleHeart_read();
        }
    }

    public static void RunIdleHeart()
    {
        RunIdleHeart_write();
        RunIdleHeart_read();
    }

    /// <summary>
    /// 读取到数据包后开始计时，长时间没有数据写出时发送心跳
    /// </summary>
    public static void StartWrite()
    {
        if (!isWrite)
        {
            startIdleTime_write = MyTimeUtil.GetCurrTimeMM;
            isWrite = true;
        }
    }

    /// <summary>
    /// 发出数据包后开始计时读数据,超过指定时间后超时,发送一次心跳
    /// </summary>
    public static void StartRead()
    {
        if (!isRead)
        {
            startIdleTime_read = MyTimeUtil.GetCurrTimeMM;
            isRead = true;
        }
    }

    internal static void ClearReceiveHandler()
    {
        list_handlerReceive_lost.Clear();
    }

    private static void RunIdleHeart_read()
    {
        if (isRead)
        {
            long now = MyTimeUtil.GetCurrTimeMM;
            if (now - startIdleTime_read >= 3000)
            {
                Debug.LogWarning("读超时, 长时间没有收到消息，发送心跳");
                BaseCanvas.GetController<LoadingCtrl>().ShowLoading();
            }


            if (now - startIdleTime_read > GameConfig.Config.heartIdelTime * 1000)
            {
                Debug.Log("AddIdelNum.....");
                isRead = false;
                AddIdelNum();
                SendHeartbeat();
                if (GameConfig.Config.isDebug)
                {
                    Debug.LogWarning("读超时,长时间没有收到消息，发送心跳");
                }
            }
        }
    }

    private static void SendHeartbeat()
    {
        Request request = new Request
        {
            msgType = MsgType.HEARTBEAT,
        };
        sendRequest(request);
    }

    private static void RunIdleHeart_write()
    {
        if (isWrite)
        {
            long now = MyTimeUtil.GetCurrTimeMM;
            if (now - startIdleTime_write > GameConfig.Config.heartIdelTime * 1000)
            {
                isWrite = false;
                SendHeartbeat();
                if (GameConfig.Config.isDebug)
                {
                    Debug.LogWarning("写超时，长时间没有写出消息,发送心跳");
                }
            }
        }
    }

    private static void AddIdelNum()
    {
        idleNum++;
       
        if (idleNum >= 1)
        {
            foreach (var item in list_handlerReceive_lost)
            {
                item.LostConnect();
            }

            ClearIdleNum();
        }
    }

    private static void ClearReadIdle()
    {
        isRead = false;
    }

    private static void ClearWriteIdle()
    {
        isWrite = false;
    }

    /// <summary>
    /// 收到消息或者新建连接，初始化心跳
    /// </summary>
    public static void ClearIdleNum()
    {
        idleNum = 0;
        ClearReadIdle();
        ClearWriteIdle();
    }

    private static Queue<Response> queue_receiveMission = new Queue<Response>();

    /// <summary>
    /// 初始化连接
    /// </summary>
    /// <param name="ip"></param>
    /// <param name="port"></param>
    public static void InitConnect(string ip, int port,int serializerUtil)
    {
        //list_handlerReceive.Clear();
        queue_receiveMission.Clear();
       

        Debug.Log("链接到====>" + ip + ":" + port+ ",serializerUtil:"+ serializerUtil);
        ClientHelper.InitConnect(ip, port, serializerUtil,AddReceiveMission);

        ClearIdleNum();

    }

    /// <summary>
    /// 连接丢失
    /// </summary>
    /// <param name="lostConnect"></param>
    public static void AddReceiveHandler(IHandlerGlobal handlerReceive)
    {
        list_handlerReceive_lost.Add(handlerReceive);
    }

    /// <summary>
    /// 如服务器有返回数据，取出服务器返回数据的第一个
    /// </summary>
    /// <returns></returns>
    public static Response NextMission()
    {
        if (queue_receiveMission != null && queue_receiveMission.Count > 0)
        {
            ClearIdleNum();
            StartWrite();
            return queue_receiveMission.Dequeue();
        }
        return null;
    }
     
    /// <summary>
    /// 获取服务器回调数据
    /// </summary>
    /// <param name="data"></param>
    /// <param name="msgType"></param>
    private static void AddReceiveMission(byte[] data, int msgType)
    {
        Response response = new Response(msgType, data);
        queue_receiveMission.Enqueue(response);
    }
     
    /// <summary>
    /// 向服务器发送一个request
    /// </summary>
    /// <param name="request"></param>
    public static bool sendRequest(Request request)
    {
         
        if (GameConfig.Config != null && GameConfig.Config.isDebug)
        {
            //if (request.msgType != -999 || request.msgType != -998)
            Debug.LogWarning("发送消息 : " + request);
        }
        bool isSend = ClientHelper.addRequest(request);
        if (isSend)
        {
            StartRead();
        }
        
        return isSend;
    }

    /// <summary>
    /// 当app退出时必须关闭链接
    /// </summary>
    public static void Disconnect()
    {
        ClientHelper.Disconnect();
    }
}
