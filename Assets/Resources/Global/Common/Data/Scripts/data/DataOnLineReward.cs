using System;
namespace Config{
    [Serializable]
    public class DataOnLineReward
    {
    
/**
* 在线奖励id
*/
public int Id;

/**
* 名字
*/
public string name;

/**
* 在线时间段前半段
*/
public string before;

/**
* 在线时间段后半段
*/
public string after;

/**
* 在线奖励值
*/
public int onLineRewardValue;

    }
}
