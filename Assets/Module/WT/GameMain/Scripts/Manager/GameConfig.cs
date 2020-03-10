using System;
using UnityEngine;

[Serializable]
public class GameConfig : MonoBehaviour
{
    [Tooltip("是否开启日志")]
    public bool isDebug;

    [Tooltip("写消息闲置多少时间后主动发送心跳")]
    public int heartIdelTime;
    
    private static GameConfig gameConfig;
    public static GameConfig Config
    {
        get {
            return gameConfig;
        }
    }

    public void Awake()
    {
        gameConfig = this;
    }
}