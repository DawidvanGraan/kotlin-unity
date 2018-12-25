using UnityEngine;
#if UNITY_IOS
using System.Runtime.InteropServices;
using System;
#endif

public class NativePrefs
{
    private static AndroidJavaObject GetAndroidJavaObject()
    {
        AndroidJavaObject jo = new AndroidJavaObject("com.unity.kotlin.unity.NativePrefs");
        return jo;
    }

    public static string GetString(string key, string defaultValue = "")
    {
#if UNITY_ANDROID
        return getStringAndroid(key, defaultValue);
#endif
#if UNITY_IOS
        return getStringIos(key, defaultValue);
#endif
    }

    private static string getStringAndroid(string key, string defaultValue)
    {
        AndroidJavaObject jo = GetAndroidJavaObject();
        return jo.CallStatic<string>("getString", key, defaultValue);
    }

#if UNITY_IOS
    [DllImport("__Internal")] private static extern string getStringIos(string key, string defaultValue);
#endif

    public static void SetString(string key, string value)
    {
#if UNITY_ANDROID
        setStringAndroid(key, value);
#endif
#if UNITY_IOS
        setStringIos(key, value);
#endif
    }

    private static void setStringAndroid(string key, string value)
    {
        AndroidJavaObject jo = GetAndroidJavaObject();
        jo.CallStatic("setString", key, value);
    }

#if UNITY_IOS
    [DllImport("__Internal")] private static extern void setStringIos(string key, string value);
#endif
}