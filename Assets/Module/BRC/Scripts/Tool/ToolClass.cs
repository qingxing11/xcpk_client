using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 包小威工具类
/// </summary>
public static class ToolClass
{
    /// <summary>
    /// 把long转化成亿万结尾
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static string LongConverStr(long num)
    {
        bool numLess = false;
        if (num < 0)
        {
            num = -num;
            numLess = true;
        }
        string str = "";
        if (num > 100000000)
        {
            long num3 = num / 100000000;
            long num4 = (num - num3 * 100000000) / 10000000;
            if (num4 == 0)
                str = num3 + "亿";
            else
                str = num3 + "." + num4 + "亿";

        }
        else if (num > 10000)
        {
            long num3 = num / 10000;
            long num4 = (num - num3 * 10000) / 1000;

            if (num4 == 0)
                str = num3 + "万";
            else
                str = num3 + "." + num4 + "万";
        }
        else
        {
            str = num.ToString();
        }
        if (numLess)
        {
            str = "-" + str;
        }
        return str;
    }
    
    public static string LongConverStr2(long num)
    {
        bool numLess = false;
        if (num < 0)
        {
            num = -num;
            numLess = true;
        }
        string str = "";
        if (num >= 100000000)
        {
            str = (num / 100000000f).ToString("0.00") + "亿";
        }
        else if (num >= 10000)
        {
            str = (num / 10000f).ToString("0.00") + "万";
        }
        else
        {
            str= num.ToString();
        }
        if (numLess)
        {
            str = "-" + str;
        }
        return str;
    }

    /// <summary>
    /// 等级转换成段位
    /// </summary>
    /// <param name="level"></param>
    /// <returns></returns>
    public static string Grading(int level)
    {
        int i = (level - 1) / 5 + 1;
        return ConfigManager.Configs.DataGrading[i].Grad;
    }

    /// <summary>
    /// 绝对坐标转相对坐标（经典场）
    /// </summary>
    public static int AbsToRel(int pos)
    {
        return (pos - CacheManager.selfPos + 5) % 5;
    }

    /// <summary>
    /// 相对坐标转绝对坐标（经典场）
    /// </summary>
    public static int RelToAbs(int pos)
    {
        return (pos + CacheManager.selfPos) % 5;
    }

    /// <summary>
    /// 万人场绝对位置转换成相对位置
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    public static int AbsToRelThous(int pos)
    {
        return (pos - CacheManager.selfPosThous + 5) % 5;
    }

    /// <summary>
    /// 相对坐标转绝对坐标（经典场）
    /// </summary>
    public static int RelToAbsThous(int pos)
    {
        return (pos + CacheManager.selfPosThous) % 5;
    }

    private static int[] Coins0 = new int[] { 1000, 800, 500, 300, 100 };
    private static int[] Coins1 = new int[] {5000,4000,2500,1500,500 };
    private static int[] Coins2 = new int[] {10000,8000,5000,3000,1000 };
    private static int[] Coins3 = new int[] { 250000,150000,100000,80000,30000,20000};
    /// <summary>
    ///  经典初级场把不规则的金币转换成规则的金币
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static List<int> CoinCconversion0(long num)
    {
        int[] Coins = new int[5];
        switch (CacheManager.classicType)
        {
            case 0:
                Coins = Coins0;
                break;
            case 1:
                Coins = Coins1;
                break;
            case 2:
                Coins = Coins2;
                break;
            case 3:
                Coins = Coins3;
                break;
            default:
                break;
        }
       
        List<int> nums = new List<int>();
        for (int i = 0; i < Coins.Length; i++)
        {
            if (num >= Coins[i])
            {
                nums.Add(Coins[i]);
                num -= Coins[i];
                i--;
            }
        }

        return nums;
    }


    private static int[] CoinsManyPeople = new int[] { 250000, 200000, 150000, 100000, 80000, 50000 };
    /// <summary>
    /// 万人场把不规则的金币转换成规则的金币
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static List<int> CoinCconversionManyPeople(long num)
    {
        List<int> nums = new List<int>();
        for (int i = 0; i < CoinsManyPeople.Length; i++)
        {
            if (num >= CoinsManyPeople[i])
            {
                nums.Add(CoinsManyPeople[i]);
                num -= CoinsManyPeople[i];
                i--;
            }
        }

        return nums;
    }

    public static string GuaGuale(long num)
    {
        string str = null;
        if (num < 1000)
            return num.ToString();
        else if (num >= 1000 && num < 10000)
        {
            string str1 = (num / 1000).ToString();
            string str2 = (num % 1000).ToString();
            while (str2.Length < 3)
            {
                str2 = "0" + str2;
            }
            return str1 + "," + str2;
        }
        else if (num >= 10000 && num < 100000000)
        {
            string str1 = (num / 10000).ToString();
            string str2 = (num % 10000).ToString();
            while (str2.Length < 2)
            {
                str2 = str2 + "0";
            }
            return str1 + "." + str2 + "万";
        }
        else
        {
            string str1 = (num / 100000000).ToString();
            string str2 = (num % 100000000).ToString();
            while (str2.Length < 2)
            {
                str2 = str2 + "0";
            }
            return str1 + "." + str2 + "亿";
        }
    }

    public static void GetHead(PlayerSimpleData playerSimpleData)
    {
        if (!string.IsNullOrEmpty(playerSimpleData.headIconUrl))
        {
           
            Texture2D texture2D = CacheManager.GetHeadIcon(playerSimpleData.headIconUrl);
            playerSimpleData.headIcon = Sprite.Create(texture2D, new Rect(0, 0, texture2D.width, texture2D.height), Vector2.zero);
        }
        else
        {
            if (playerSimpleData.roleId == 0)
            {
                playerSimpleData.headIcon = FileIO.LoadSprite(R.SpritePack.HEAD_MAN);
            }
            else
            {
                playerSimpleData.headIcon = FileIO.LoadSprite(R.SpritePack.HEAD_WOMAN);
            }
        }
    }

    public static void SetVipTexture(GLoader gLoader,int vipLv)
    {
        Sprite vipSprite = null;
        switch (vipLv)
        {
            case 1: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP2_VIP1); break;
            case 2: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP2_VIP2); break;
            case 3: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP2_VIP3); break;
            case 4: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP2_VIP4); break;
            case 5: vipSprite = FileIO.LoadSprite(R.SpritePack.VIP2_VIP5); break;
            default:
                break;
        }
        if (vipSprite != null)
            gLoader.texture = new NTexture(vipSprite);
        else
            gLoader.texture = null;

    }

    /// <summary>
    /// 设置排行榜图标
    /// </summary>
    /// <param name="player"></param>
    public static void SetRankSprite(PlayerSimpleData player)
    {
       
        player.sprites.Clear();
        List<RankVO> PayRank = CacheManager.PayRank;
        List<RankVO> CoinsRank = CacheManager.CoinsRank;
        List<RankVO> BigWinRank = CacheManager.BigWinRank;
        for (int i = 0; i < 3; i++)
        {
 
            if (PayRank.Count > i && PayRank[i] != null && player.userId == PayRank[i].userId)
            {
                if (i == 0)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_RMB1));
                if (i == 1)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_RMB2));
                if (i == 2)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_RMB3));
            }
            if (CoinsRank.Count > i && CoinsRank[i] != null && player.userId == CoinsRank[i].userId)
            {
                if (i == 0)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_MONEY1));
                if (i == 1)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_MONEY2));
                if (i == 2)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_MONEY3));
            }
            if (BigWinRank.Count > i && BigWinRank[i] != null && player.userId == BigWinRank[i].userId)
            {
                if (i == 0)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_WIN1));
                if (i == 1)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_WIN2));
                if (i == 2)
                    player.sprites.Add(FileIO.LoadSprite(R.SpritePack.RANKING_WIN3));
            }
        }
    }
}