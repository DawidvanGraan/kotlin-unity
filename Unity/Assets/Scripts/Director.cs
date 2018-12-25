using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Director : MonoBehaviour
{
    public Text TextIntro;

    public InputField InputField;

    public Button Button;

    void Start()
    {
        TextIntro.text = NativeHelper.GetData("native_text");
        Button.onClick.AddListener(() =>
        {
            var text = InputField.text;
            NativePrefs.SetString("unity_text", text);

            NativeHelper.SendCommand("show_toast", "Successfully!");
        });
    }
}
