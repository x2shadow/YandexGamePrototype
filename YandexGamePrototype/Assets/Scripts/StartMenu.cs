using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void buttonStart()
    {
        SceneManager.LoadScene(Progress.Instance.playerInfo.level + 1);
    }
}
