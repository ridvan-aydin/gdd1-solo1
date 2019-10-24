using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Start or quit the game
public class GameOverScript : MonoBehaviour
{
    private Button[] buttons;

    void Awake()
    {
        // Get the buttons
        buttons = GetComponentsInChildren<Button>();

        // Disable them
        HideButtons();
    }

    public void HideButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(false);
        }
    }

    public void ShowButtons()
    {
        foreach (var b in buttons)
        {
            b.gameObject.SetActive(true);
        }
    }

    public void ExitToMenu()
    {
        // Reload the level
        var persistentData = FindObjectOfType<PersistentDataScript>();
        if(persistentData != null)
        {
            Destroy(persistentData.gameObject);
        }
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        // Reload the level
        var persistentData = FindObjectOfType<PersistentDataScript>();
        if (persistentData != null)
        {
            persistentData.score = 0;
        }
        SceneManager.LoadScene("Stage1");
    }
}
