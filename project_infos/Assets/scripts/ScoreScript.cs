using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    public int points = 10;

    private ScoreDisplayScript scoreDisplayScript;

    private void Start()
    {
        scoreDisplayScript = FindObjectOfType<ScoreDisplayScript>();
    }

    public void addPoints()
    {
        scoreDisplayScript.addScore(points);
    }
}
