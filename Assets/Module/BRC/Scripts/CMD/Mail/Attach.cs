using ProtoBuf;

[ProtoContract]
public class Attach
{
    [ProtoMember(1)]
    public int id;      //物品id item表中的id
    [ProtoMember(2)]
    public int num;  //物品的数量

    public Attach()
    {

    }
    public Attach(int id, int num)
    {
        this.id = id;
        this.num = num;
    }
    public override string ToString()
    {
        return "id:"+id+"   num:"+num;
    }
}