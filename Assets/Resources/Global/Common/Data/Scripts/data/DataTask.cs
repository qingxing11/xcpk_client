using System;
namespace Config{
    [Serializable]
    public class DataTask
    {
    
/**
* 任务id
*/
public int Id;

/**
* 对应任务名字
*/
public string Name;

/**
* 任务描述
*/
public string Desc;

/**
* 任务达到值
*/
public int taskLimit;

/**
* 任务奖励
*/
public int taskRewardValue;

/**
* 任务大类型（日常/终极）
*/
public int taskType;

/**
* 任务小类型
*/
public int taskSmallType;

    }
}
