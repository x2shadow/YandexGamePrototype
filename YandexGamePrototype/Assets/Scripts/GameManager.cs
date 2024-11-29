using System.Collections;
using System.Collections.Generic;
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

    void Start()
    {
        levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        startMenu.SetActive(false);
        yandexDebugMenu.SetActive(false);
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void NextLevel()
    {
        coinManager.SaveToProgress();
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if(next < SceneManager.sceneCountInBuildSettings) SceneManager.LoadScene(next);
    }

    public void ShowFinishWindow()
    {
        finishWindow.SetActive(true);
    }
}
