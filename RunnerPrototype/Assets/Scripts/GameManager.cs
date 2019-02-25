using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject boulder;
    public GameObject endUI;
    public GameObject player;
    public GameObject startUI;
    private static GameManager instance;

    public static GameManager Instance()
    {
        return instance;
    }

    public void EndGame()
    {
        Time.timeScale = 0;
        endUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        boulder.SetActive(true);
        player.SetActive(true);
        startUI.SetActive(false);
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        boulder.SetActive(false);
        player.SetActive(false);
    }
}