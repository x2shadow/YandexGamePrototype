using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;

[System.Serializable]
public class PlayerInfo
{
    public int coins;
    public int width;
    public int height;
    public int level;
}

public class Progress : MonoBehaviour
{
    public PlayerInfo playerInfo;

    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    [SerializeField]
    TextMeshProUGUI playerInfoText;

    public static Progress Instance;

    void Awake()
    {
        if(Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        #if !UNITY_EDITOR
            LoadExtern();
        #endif
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(playerInfo);
        SaveExtern(jsonString);
    }

    public void SetPlayerInfo(string value)
    {
        playerInfo = JsonUtility.FromJson<PlayerInfo>(value);
        playerInfoText.text = playerInfo.coins + "\n" + playerInfo.width + "\n" + playerInfo.height + "\n" + playerInfo.level;
    }
}
