using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//projectile behaviour
public class ShotScript : MonoBehaviour
{
    //damage inflicted
    public int damage = 1;

    //projectile damage player or enemies?
    public bool isEnemyShot = false;

    //projectile affinities
    public bool isExplosiveShot = false;

    private void Start()
    {
        //limited time to live to avoid any leak
        Destroy(gameObject, 20); //20sec
    }
}
