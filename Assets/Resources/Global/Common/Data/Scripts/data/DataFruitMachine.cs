using System;
namespace Config{
    [Serializable]
    public class DataFruitMachine
    {
    
/**
* 水果机id
*/
public int Id;

/**
* 对应奖励名字
*/
public string Name;

/**
* 普通奖励类型
*/
public int normalReward;

/**
* 奖品种类（对应FruitType）
*/
public int fruitType;

/**
* 大四喜
*/
public int bigFourXi;

/**
* 大三元
*/
public int bigThreeYuan;

/**
* 小三元
*/
public int smallThreeYuan;

/**
* 开火车
*/
public int onTrain;

/**
* 单点
*/
public int siglePoint;

/**
* 九连宝灯
*/
public int nineTreasureLamp;

/**
* 音效
*/
public string music;

/**
* 奖励图片
*/
public string icon;

/**
* 奖励倍数
*/
public int rewardMultiple;

    }
}
