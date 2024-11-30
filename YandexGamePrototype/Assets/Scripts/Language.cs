using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

public class Language : MonoBehaviour
{
    [DllImport("__Internal")]
    static extern string GetLanguage();

    [SerializeField]
    TextMeshProUGUI langText;

    public string currentLanguage;  // ru en

    public static Language Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    void Start()
    {
        #if !UNITY_EDITOR
            currentLanguage = GetLanguage();
        #endif
        
        langText.text = currentLanguage;
    }
}
