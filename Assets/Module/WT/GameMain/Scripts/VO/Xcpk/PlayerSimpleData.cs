using UnityEngine;
using ProtoBuf;
using System.Collections.Generic;

[ProtoContract]
public class PlayerSimpleData
{
    /// <summary>
    /// Ψһid
    /// </summary>
    [ProtoMember(1)]
    public int userId;
    /// <summary>
    /// �ǳ�
    /// </summary>
    [ProtoMember(2)]
    public string nickName;
    /// <summary>
    /// ͷ��
    /// </summary>
    [ProtoMember(3)]
    public string headIconUrl;
    /// <summary>
    /// ���
    /// </summary>
    [ProtoMember(4)]
    public long coins;
    /// <summary>
    /// ���䳡λ��
    /// </summary>
    [ProtoMember(5)]
    public int classicGamepos;
    /// <summary>
    /// ���˳�λ��
    /// </summary>
    [ProtoMember(6)]
    public int manyGamepos;
    /// <summary>
    /// ˮ����λ��
    /// </summary>
    [ProtoMember(7)]
    public int fruitGamepos;
    /// <summary>
    /// ͨɱ��λ��
    /// </summary>
    [ProtoMember(8)]
    public int killRoomPos;
    /// <summary>
    /// �Ա�
    /// </summary>
    [ProtoMember(9)]
    public int roleId;
    /// <summary>
    /// vip�ȼ�
    /// </summary>
    [ProtoMember(10)]
    public int vipLv;
    /// <summary>
    /// ��ҵȼ�
    /// </summary>
    [ProtoMember(11)]
    public int lv;
    /// <summary>
    /// שʯ
    /// </summary>
    [ProtoMember(12)]
    public int crystals; //��ʯ
    /// <summary>
    /// ǩ��
    /// </summary>
    [ProtoMember(13)]
    public string sign;
    /// <summary>
    /// ʤ��
    /// </summary>
    [ProtoMember(14)]
    public int victoryNum;

    /// <summary>
    /// ����
    /// </summary>
    [ProtoMember(15)]
    public int failureNum;

    /**
    *�ٵ�ǰ��Ϸ�е���ע��(�����Ϸ����ע��)
    */
    [ProtoMember(16)]
    public long betNum;

    /**�Ƿ���*/
    [ProtoMember(17)]
    public bool isCheckPoker;

    /**0,����   1:��ͨ()  2:ʧ�� 3:�ȴ���ʼ*/
    [ProtoMember(18)]
    public int gameState;

    //[ProtoMember(16)]
    //public byte[] headImgIcon;

    /// <summary>
    /// ��Ҫ��ʾ��icon
    /// </summary>
    public List<Sprite> sprites = new List<Sprite>();

    /// <summary>
    /// 
    /// </summary>
    public Sprite headIcon;

    public override string ToString()
    {
        return "PlayerSimpleData [userId=" + userId + ", nickName=" + nickName + ", coins=" + coins + ", classicGamepos=" + classicGamepos + ", manyGamepos=" + manyGamepos + ", fruitGamepos=" + fruitGamepos + ",killRoomPos:"+ killRoomPos+"]";
    }
}