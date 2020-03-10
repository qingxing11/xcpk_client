using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MyTimeUtil
{
    /// <summary>
    /// 秒
    /// </summary>
    public const long TIME_S = 1000L;

    /// <summary>
    /// 分
    /// </summary>
    public const long TIME_M = TIME_S * 60L;

    /// <summary>
    ///  小时
    /// </summary>
    public const long TIME_H = TIME_M * 60L;

    /// <summary>
    /// 天
    /// </summary>
    public const long TIME_DAY = TIME_H * 24L;

    public static long GetCurrTimeMM
    {
        get {
           
            return (DateTime.Now.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }
    }

    public static DateTime TimeStampToDateTime(long timestamp)
    {
        System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);

       
        return dateTime.AddSeconds(timestamp);
      
    }

    public static string TimeToString(long mm)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
        DateTime dt = startTime.AddMilliseconds(mm);
        return dt.ToString("yyyy/MM/dd HH:mm:ss");
    }

    public static string TimeToStringS(long mm)
    {
        DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)); // 当地时区
        DateTime dt = startTime.AddMilliseconds(mm);
        return dt.ToString("yyyy/MM/dd HH:mm:ss");
    }

    /// <summary>
    /// 指定时间秒转换成00:00格式，暂未处理9分钟以上时间
    /// </summary>
    /// <param name="time"></param>
    /// <returns></returns>
    public static string TimeToString(int time)
    {
        int m = time / 60;
        int s = time % 60;
        string timeS = s < 10 ? ("0" + s) : (s.ToString());
        string timeStr = "0" + m + ":" + timeS;
        return timeStr;
    }

    public static string GetCurrentYear()
    {
        string[] str = DateTime.Now.ToString("yyyy/MM/d").Split('/');
        return str[0]+"年"+str[1]+"月";
    }
}