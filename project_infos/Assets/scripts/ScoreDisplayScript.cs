using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayScript : MonoBehaviour
{
    private int score;
    private Text textObject;

    private void Start()
    {
        score = 0;
        textObject = GetComponent<Text>();
        textObject.text = "Score: " + score;
    }

    public void addScore(int points)
    {
        score = score + points;
        textObject.text = "Score: " + score;
    }
}
