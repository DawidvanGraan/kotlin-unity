package com.unity.kotlin.unity

import com.unity.kotlin.App
import com.unity.kotlin.presentation.MultiProcessPreferences

object NativePrefs {
    @JvmStatic
    fun getString(key: String, defaultValue: String? = ""): String {
        val pref = MultiProcessPreferences(App.INSTANCE)
        return pref.getString(key, defaultValue) ?: ""
    }

    @JvmStatic
    fun setString(key: String, value: String) {
        val pref = MultiProcessPreferences(App.INSTANCE)
        pref.put(key, value)
    }
}