using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FruitMachineVO
{
    private int fruitType;
    private int fruitRewardType;
    private bool isSpecialReward;

    public FruitMachineVO()
    {

    }

    public FruitMachineVO(int fruitType, int fruitRewardType, bool isSepcial)
    {
        this.fruitType = fruitType;
        this.fruitRewardType = fruitRewardType;
        this.isSpecialReward = isSepcial;
    }

    public override string ToString()
    {
        return "FruitMachineVO ="+ ",fruitType :" + fruitType + ",fruitRewardType:" + fruitRewardType+ ",isSpecialReward:" + isSpecialReward;
    }
}