using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 扩展类:
/// 王拓
/// </summary>
public static class HelperClass
{
    public static Texture2D DecodeTexture2d(this byte[] data,int w,int h)
    {
        Texture2D t2d = new Texture2D(w, h);
        t2d.LoadImage(data);
        return t2d;
    }

    internal static string MapGetString<T>(this Dictionary<int, T> map)
    {
        if (map == null)
        {
            return null;
        }
        List<string> list = new List<string>(map.Select(keyValuePair => "[" + keyValuePair.Key + ":" + keyValuePair.Value + "]"));
        var toString = string.Join(", ", list.ToArray());
        return toString;
    }

    internal static Tvalue GetValue<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key)
    {
        Tvalue value;
        dict.TryGetValue(key, out value);
        return value;
    }

    public static string ExtendStr(this StringBuilder sb,string sym)
    {
        string temp = sb.ToString();
        int length = temp.Length;
        if (length > 0)
        {
            temp = temp.Remove(length - 1, 1) + sym;
            return temp;
        }
        return null;
    }
    public static bool AddValue<Tkey, Tvalue>(this Dictionary<Tkey, Tvalue> dict, Tkey key, Tvalue value)
    {
        if (dict.ContainsKey(key))
        {
            return false;
        }
        dict.Add(key, value);
        return true;
    }
    public static void SetTransforms(this GameObject go,Transform parent)
    {
        go.transform.SetParent(parent);
        go.transform.localScale = Vector3.one;
        go.transform.localPosition = Vector3.zero;
    }
    public static T LoadObjectByAb<T>(this AssetBundle ab, string abName) where T : UnityEngine.Object
    {
        return ab.LoadAsset<T>(abName);
    }
    
    /// <summary>
    /// 将byte数组解析为string ，使用utf-8编码格式
    /// </summary>
    /// <param name="self"></param>
    /// <returns></returns>
    internal static string EncodingToString(this byte[] self)
    {
        return System.Text.Encoding.UTF8.GetString(self);
    }

    internal static string SerializerToJson(this object self)
    {
        return MySerializerUtil.SerializerToJson(self);
    }

    internal static T DeSerialFromJson<T>(this string self)
    {
        return MySerializerUtil.DeSerialFromJson<T>(self);
    }

    internal static T DeSerialFromJson<T>(this byte[] self)
    {
        return MySerializerUtil.DeSerialFromJson<T>(self);
    }

    internal static byte[] GetBytes(this string self)
    {
        return GetSBytesForEncoding_byte(System.Text.Encoding.UTF8, self);
    }

    private static byte[] GetSBytesForEncoding_byte(System.Text.Encoding encoding, string s)
    {
        byte[] sbytes = new byte[encoding.GetByteCount(s)];
        encoding.GetBytes(s, 0, s.Length, (byte[])(object)sbytes, 0);
        return sbytes;
    }


}
 
internal static class ListHelperClass
{
    internal static  string GetString<T>(this List<T> list)
    {
        if (list == null)
        {
            return null;
        }
        StringBuilder sb = new StringBuilder();
        foreach (var item in list)
        {
            sb.Append(item);
            sb.Append(",");
        }

        return sb.ToString();
    }
}
