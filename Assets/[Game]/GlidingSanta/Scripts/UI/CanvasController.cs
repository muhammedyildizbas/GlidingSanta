using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public GameObject inGamePanel;
    public GameObject gameOverPanel;
    public void LoadScene(int sceneid)
    {
        SceneManager.LoadScene(sceneid);
    }

    public void GameOverPanel()
    {
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }

}
