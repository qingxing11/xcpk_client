using System;
using UnityEngine;

[Serializable]
public class ClientConfig
{
    public string ip;
    public int port;

    public string gameIp;
    public int gamePort;

    /// <summary>
    /// 0:protobuf,1:protobuf_net项目,2:阿里的fastjosn
    /// </summary>
    [Tooltip("0:protobuf,1:protobuf_net项目,2:阿里的fastjosn")]
    public int serializerUtil = 0;

    /// <summary>
    /// 当前内部版本号，热更新用
    /// </summary>
    [Tooltip("当前内部版本号，热更新用")]
    public int versionCode = 0;

    /// <summary>
    /// 当前大版本号，大版本更新用
    /// </summary>
    [Tooltip("当前大版本号，大版本更新用")]
    public int bigVersion = 0;

    [Tooltip("是否开启新游客账号")]
    public bool isNewGuest;
     
}