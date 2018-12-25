package com.unity.kotlin.presentation

import android.os.Bundle
import android.widget.Toast
import com.unity.kotlin.BuildConfig
import com.unity.kotlin.R
import com.unity.kotlin.unity.UnityPlayerActivity
import kotlinx.android.synthetic.main.activity_unity_embbed.*

class UnityEmbeddedActivity : UnityPlayerActivity() {

    override fun addUnityView() {
        setContentView(R.layout.activity_unity_embbed)
        containerUnity.addView(mUnityPlayer)
    }

    override fun getData(key: String, specification: String): String {
        return when (key) {
            "native_text" -> "Text from Native ${BuildConfig.APPLICATION_ID} ${BuildConfig.VERSION_NAME}"
            else -> ""
        }
    }

    override fun onMessage(command: String, data: String?) {
        when (command) {
            "show_toast" -> {
                Toast.makeText(this, data, Toast.LENGTH_SHORT).show()
            }
        }
    }
}
