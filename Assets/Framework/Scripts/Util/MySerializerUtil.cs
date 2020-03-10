﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class MySerializerUtil
{
    /// <summary>
    /// 序列化
    /// </summary>
    /// <returns></returns>
    public static byte[] SerializerToProtobufNet(object obj)//将object转化成字节数组
    {
        using (MemoryStream ms = new MemoryStream())
        {
            Serializer.Serialize<object>(ms, obj);
            byte[] data = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(data, 0, data.Length);
            return data;
        }
    }

    /// <summary>
    /// 反序列化
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static T DeSerializerFromProtobufNet<T>(byte[] msg) where T : Response
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(msg, 0, msg.Length);
            ms.Position = 0;
            T obj = Serializer.Deserialize<T>(ms);
            return obj;
        }
    }

    public static T DeSerializerFromProtobufNet<T>(T t, byte[] msg) where T : Response
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(msg, 0, msg.Length);
            ms.Position = 0;
            T obj = Serializer.Deserialize<T>(ms);
            return obj;
        }
    }

    public static T DeSerial_Generic<T>(byte[] msg)
    {
        using (MemoryStream ms = new MemoryStream())
        {
            ms.Write(msg, 0, msg.Length);
            ms.Position = 0;
            T obj = Serializer.Deserialize<T>(ms);
            return obj;
        }
    }

    public static T DeSerialFromJson<T>(byte[] data)
    {
        return DeSerialFromJson<T>(data.EncodingToString());
    }

    public static T DeSerialFromJson<T>(string json)
    {
        return JsonUtility.FromJson<T>(json);
    }

    public static string SerializerToJson(object obj)
    {
        return JsonUtility.ToJson(obj);
    }
}