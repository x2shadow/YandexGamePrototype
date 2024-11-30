using System.Collections;
using System.Collections.Generic;
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

    }
}
