using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokers
{
    public static int[] PokerFace;

    public static Sprite GetPokerFace(int index)
    {

        if (PokerFace == null || PokerFace.Length <= 0)
        {
            PokerFace = new int[]
            {
                R.SpritePack.CARDS_CARD01,
                R.SpritePack.CARDS_CARD02,
                R.SpritePack.CARDS_CARD03,
                R.SpritePack.CARDS_CARD04,
                R.SpritePack.CARDS_CARD05,
                R.SpritePack.CARDS_CARD06,
                R.SpritePack.CARDS_CARD07,
                R.SpritePack.CARDS_CARD08,
                R.SpritePack.CARDS_CARD09,
                R.SpritePack.CARDS_CARD10,
                R.SpritePack.CARDS_CARD11,
                R.SpritePack.CARDS_CARD12,
                R.SpritePack.CARDS_CARD13,
                R.SpritePack.CARDS_CARD14,
                R.SpritePack.CARDS_CARD15,
                R.SpritePack.CARDS_CARD16,
                R.SpritePack.CARDS_CARD17,
                R.SpritePack.CARDS_CARD18,
                R.SpritePack.CARDS_CARD19,
                R.SpritePack.CARDS_CARD20,
                R.SpritePack.CARDS_CARD21,
                R.SpritePack.CARDS_CARD22,
                R.SpritePack.CARDS_CARD23,
                R.SpritePack.CARDS_CARD24,
                R.SpritePack.CARDS_CARD25,
                R.SpritePack.CARDS_CARD26,
                R.SpritePack.CARDS_CARD27,
                R.SpritePack.CARDS_CARD28,
                R.SpritePack.CARDS_CARD29,
                R.SpritePack.CARDS_CARD30,
                R.SpritePack.CARDS_CARD31,
                R.SpritePack.CARDS_CARD32,
                R.SpritePack.CARDS_CARD33,
                R.SpritePack.CARDS_CARD34,
                R.SpritePack.CARDS_CARD35,
                R.SpritePack.CARDS_CARD36,
                R.SpritePack.CARDS_CARD37,
                R.SpritePack.CARDS_CARD38,
                R.SpritePack.CARDS_CARD39,
                R.SpritePack.CARDS_CARD40,
                R.SpritePack.CARDS_CARD41,
                R.SpritePack.CARDS_CARD42,
                R.SpritePack.CARDS_CARD43,
                R.SpritePack.CARDS_CARD44,
                R.SpritePack.CARDS_CARD45,
                R.SpritePack.CARDS_CARD46,
                R.SpritePack.CARDS_CARD47,
                R.SpritePack.CARDS_CARD48,
                R.SpritePack.CARDS_CARD49,
                R.SpritePack.CARDS_CARD50,
                R.SpritePack.CARDS_CARD51,
                R.SpritePack.CARDS_CARD52,
            };
        }
        if (index < 1 || index > PokerFace.Length)
            return FileIO.LoadSprite(R.SpritePack.CARDS_CARD00);
        return FileIO.LoadSprite(PokerFace[index - 1]);
    }

    public static int[] PokerTypeIndex;

    public static Sprite GetPokerType(int index)
    {
        if (PokerTypeIndex == null || PokerTypeIndex.Length <= 0)
        {
            PokerTypeIndex = new int[]
            {
                R.SpritePack.CARDTYPE2_CARDTYPE1,
                R.SpritePack.CARDTYPE2_CARDTYPE2,
                R.SpritePack.CARDTYPE2_CARDTYPE3,
                R.SpritePack.CARDTYPE2_CARDTYPE4,
                R.SpritePack.CARDTYPE2_CARDTYPE5,
                R.SpritePack.CARDTYPE2_CARDTYPE6,
            };
        }
        if (index < 0 || index >= PokerTypeIndex.Length)
            return FileIO.LoadSprite( PokerTypeIndex[PokerTypeIndex.Length-1]);
        return FileIO.LoadSprite (PokerTypeIndex[index]);
    }
}