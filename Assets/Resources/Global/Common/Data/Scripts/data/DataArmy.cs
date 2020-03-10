using System;
namespace Config{
    [Serializable]
    public class DataArmy
    {
    
/**
* 军队id
*/
public int Id;

/**
* 军队名字
*/
public string Name;

/**
* 军队简介
*/
public string Introduce;

/**
* 军事面板大众脸
*/
public string ArmyJSIcon;

/**
* 建造面板大众脸
*/
public string ArmyJZBigIcon;

/**
* 军队面板大众脸（出征大）
*/
public string ArmyBSIcon;

/**
* 出征大众脸（小）
*/
public string ArmyCZIcon;

/**
* 部队出击预定界面缩略图
*/
public string ArmySmallIcon;

/**
* 军队图片
*/
public string Icon;

/**
* 模型
*/
public string Model;

/**
* 单位动画控制器加载路径
*/
public string animPath;

/**
* 陆地单位进入海里时，单位模型变成商船，商船控制器加载路径
*/
public string shipAnimPath;

/**
* 容量
*/
public int Capacity;

/**
* 等级
*/
public int Level;

/**
* 攻击
*/
public int Atk;

/**
* 射程
*/
public int Range;

/**
* 血量
*/
public int Hp;

/**
* 防御
*/
public int Def;

/**
* 移动速度
*/
public int Speed;

/**
* 攻击速度
*/
public float Aspd;

/**
* 暴击率
*/
public float Crit;

/**
* 攻城值
*/
public int AttackCity;

/**
* 军队对应的技能id_1
*/
public int Skill1;

/**
* 军队对应的技能id_2
*/
public int Skill2;

/**
* 军队类型
*/
public int ArmyType;

/**
* 军队大类型
*/
public int ArmyBigType;

/**
* 种族
*/
public int RaceType;

/**
* 人口消耗
*/
public int labour;

/**
* 对应士兵长
*/
public int SailorID;

/**
* hp对应的BuffDebuf的id
*/
public int HpBuffDebuff_Id;

/**
* atk对应的BuffDebuf的id
*/
public int AtkBuffDebuff_Id;

/**
* morale对应的BuffDebuf的id
*/
public int MoraleBuffDebuff_Id;

    }
}
