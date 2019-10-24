using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentDataScript : MonoBehaviour
{
    public int spaceship;
    public uint score;

    void Start()
    {
        score = 0;
        DontDestroyOnLoad(gameObject);
    }
}
