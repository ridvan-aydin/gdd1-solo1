using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplayScript : MonoBehaviour
{
    private int hp;
    private Text textObject;

    private void Start()
    {
        hp = 0;
        textObject = GetComponent<Text>();
        textObject.text = "HP: " + hp;
    }

    public void initLife(int life)
    {
        hp = life;
        textObject.text = "HP: " + hp;
    }

    public void reduceLife(int damage)
    {
        hp = hp - damage;
        textObject.text = "HP: " + hp;
    }
}
