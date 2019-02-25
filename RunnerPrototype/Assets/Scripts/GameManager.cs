using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject boulder;
    public GameObject player;
    public GameObject UI;

    public void StartGame()
    {
        boulder.SetActive(true);
        player.SetActive(true);
        UI.SetActive(false);
    }

    private void Awake()
    {
        boulder.SetActive(false);
        player.SetActive(false);
    }
}