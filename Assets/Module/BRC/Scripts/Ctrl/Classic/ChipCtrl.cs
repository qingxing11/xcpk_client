using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipCtrl : BaseController
{
    private  UIChip uiChip;
    public override void InitAction()
    {
        
    }
    public UIChip Show(long chipNum)
    {
        string chipName = "chip" + CacheManager.coinsIndex++;
        uiChip = ShowUI<UIChip>(chipName);
        uiChip.Init(chipNum);
        return uiChip;
    }
}
