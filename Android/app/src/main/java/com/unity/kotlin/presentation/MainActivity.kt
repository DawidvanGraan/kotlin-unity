package com.unity.kotlin.presentation

import android.content.Intent
import android.support.v7.app.AppCompatActivity
import android.os.Bundle
import com.unity.kotlin.R
import com.unity.kotlin.unity.NativePrefs
import com.unity.kotlin.unity.killUnityProcessIfNeeded
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        btnStartUnity.setOnClickListener {
            startActivity(Intent(this, UnityEmbeddedActivity::class.java))
        }
    }

    override fun onResume() {
        super.onResume()

        killUnityProcessIfNeeded()

        val nativeText = NativePrefs.getString("unity_text")
        if (nativeText.isNotEmpty()) {
            tvInfo.text = nativeText
        }
    }
}
