using Classic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WT.UI;
using FairyGUI;

public class UIChip : WTUIPage<UI_game_chip, SelectClassicCtrl>
{
    public UIChip() : base(UIType.Normal, UIMode.DoNothing, R.UI.CLASSIC)
    { }

    internal void Init(long chipNum)
    {
        UIPage.m_n0.texture = new NTexture(GetChipNumSprite(chipNum));
    }
    private Sprite GetChipNumSprite(long chipNum)
    {
        switch (chipNum)
        {
            case 100:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP100);
            case 300:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP300);
            case 500:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP500);
            case 800:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP800);
            case 1000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP1000);
            case 1500:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP1500);
            case 2000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP2000);
            case 2500:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP2500);
            case 3000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP3000);
            case 4000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP4000);
            case 5000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP5000);
            case 6000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP6000);
            case 8000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP8000);
            case 10000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP10000);
            case 20000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP20000);
            case 30000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP30000);
            case 50000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP50000);
            case 60000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP60000);
            case 80000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP80000);
            case 100000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP100000);
            case 150000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP150000);
            case 160000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP160000);
            case 200000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP200000);
            case 250000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP250000);
            case 300000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP300000);
            case 400000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP400000);
            case 500000:
                return FileIO.LoadSprite(R.SpritePack.CHIP1_GAME_CHIP500000);
            default:
                return null;
        }
    }
}
