using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Title screen script
public class MenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("selectPlayer");
    }

    public void PlayerRocket()
    {
        GameObject.FindObjectOfType<PersistentDataScript>().spaceship = 1;
        SceneManager.LoadScene("stage1");
    }

    public void PlayerUfo()
    {
        GameObject.FindObjectOfType<PersistentDataScript>().spaceship = 2;
        SceneManager.LoadScene("stage1");
    }
}