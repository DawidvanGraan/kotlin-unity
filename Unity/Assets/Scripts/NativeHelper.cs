using UnityEngine;
#if UNITY_IOS
using System.Runtime.InteropServices;
using System;
#endif

public class NativeHelper
{
    private static AndroidJavaObject GetAndroidJavaObject()
    {
        AndroidJavaObject jo = new AndroidJavaObject("com.unity.kotlin.unity.NativeHelper");
        return jo;
    }

    public static void SendCommand(string command, string data = "")
    {
        try
        {
            Debug.Log("Send command: " + command + " data: " + data);
#if UNITY_ANDROID
            SendCommandAndroid(command, data);
#endif
#if UNITY_IOS
            sendCommandIos(command, data);
#endif
        }
        catch (System.Exception exception)
        {
            Debug.Log(exception.Message);
        }
    }

    private static void SendCommandAndroid(string command, string data)
    {
        AndroidJavaObject jo = GetAndroidJavaObject();
        jo.CallStatic("sendCommand", command, data);
    }

#if UNITY_IOS
    [DllImport("__Internal")] private static extern void sendCommandIos(string command, string data);
#endif

    public static string GetData(string key, string specification = "")
    {
        try
        {
#if UNITY_ANDROID
            return GetDataAndroid(key, specification);
#endif
#if UNITY_IOS
            return getDataIos(key, specification);
#endif
        }
        catch (System.Exception exception)
        {
            Debug.Log(exception.Message);
            return "";
        }
    }

    private static string GetDataAndroid(string key, string specification)
    {
        AndroidJavaObject jo = GetAndroidJavaObject();
        return jo.CallStatic<string>("getData", key, specification);
    }

#if UNITY_IOS
    [DllImport("__Internal")] private static extern string getDataIos(string key, string specification);
#endif
}