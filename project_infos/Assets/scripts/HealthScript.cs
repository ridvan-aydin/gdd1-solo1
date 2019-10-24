using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//handle hitpoints and damage
public class HealthScript : MonoBehaviour
{
    //total hitpoints
    public int hp = 1;

    //enemy or player
    public bool isEnemy = true;

    //for score
    private ScoreScript scoreScript;
    private LifeDisplayScript lifeDisplayScript;

    private void Awake()
    {
        scoreScript= GetComponent<ScoreScript>();
        lifeDisplayScript = FindObjectOfType<LifeDisplayScript>();
        
        if(isEnemy == false && lifeDisplayScript != null)
        {
            lifeDisplayScript.initLife(hp);
        }
    }

    //inflicts damage and check if the object should be destroyed
    public void Damage(int damageCount)
    {
        hp = hp - damageCount;

        //update hp dislay
        if (isEnemy == false)
        {
            lifeDisplayScript.reduceLife(damageCount);
        }

        if (hp <= 0)
        {
            //get points
            if(isEnemy && scoreScript != null)
            {
                 scoreScript.addPoints();
            }
            //dead
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //is this a shot?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();

        if(shot != null)
        {
            //avoid friendly fire
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);

                if(shot.isExplosiveShot)
                {
                    //explosion effect
                    SpecialEffectsHelper.Instance.Explosion(transform.position);
                }

                //destroy the shot
                //remember to always target the game object, otherwise you will just remove the script
                Destroy(shot.gameObject);
            }
        }

        //is this an area effect?
        AreaEffectScript effect = otherCollider.gameObject.GetComponent<AreaEffectScript>();

        if(effect != null)
        {
            if(isEnemy)
            {
                if (effect.isExplosiveEffect)
                {
                    Damage(effect.damage);
                }
            }
        }
    }
}
