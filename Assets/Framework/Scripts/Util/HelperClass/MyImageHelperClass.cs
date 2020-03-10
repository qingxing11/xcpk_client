using UnityEngine;

public static class MyImageHelperClass
{
    /// <summary>
    /// 叠加纹理，但是不提交到GPU(不支持半透明)
    /// </summary>
    /// <param name="t2d"></param>
    /// <param name="sx"></param>
    /// <param name="sy"></param>
    /// <param name="src"></param>
    public static void DrawImageNotApply(this Texture2D t2d, int sx, int sy, Texture2D src)
    {
        for (int y = 0; y < src.height; y++)
        {
            for (int x = 0; x < src.width; x++)
            {
                var uC = src.GetPixel(x, y);
                bool isNull = false;
                if (uC.a <= 0 || x > src.width || y > src.height)
                {
                    isNull = true;
                }
                if (!isNull)
                    t2d.SetPixel(sx + x, sy + y, uC);
            }
        }
    }

    /// <summary>
    /// 叠加纹理，并且提交到GPU(不支持半透明)
    /// </summary>
    /// <param name="t2d"></param>
    /// <param name="sx"></param>
    /// <param name="sy"></param>
    /// <param name="src"></param>
    public static void DrawImageAndApply(this Texture2D t2d,int sx,int sy,Texture2D src)
    {
        DrawImageNotApply(t2d,sx,sy,src);
        t2d.Apply();
    }
}