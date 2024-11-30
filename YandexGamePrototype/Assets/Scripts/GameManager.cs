using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject yandexDebugMenu;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] GameObject finishWindow;
    [SerializeField] CoinManager coinManager;

    [DllImport("__Internal")] private static extern void SetToLeaderboard(int value);

    void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        #if !UNITY_EDITOR
            Progress.Instance.Save();
        #endif
        startMenu.SetActive(false);
        yandexDebugMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next == 3) next = 1;
        if(next < SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(next);
    }

    public void ShowFinishWindow()
    {
        coinManager.SaveToProgress();
        
        #if !UNITY_EDITOR
            Progress.Instance.playerInfo.level = SceneManager.GetActiveScene().buildIndex;
            if(Progress.Instance.playerInfo.level == 2) Progress.Instance.playerInfo.level = 0;
            Progress.Instance.Save();
            SetToLeaderboard(Progress.Instance.playerInfo.height);
        #endif
        finishWindow.SetActive(true);
    }
}
