using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    // This is the class for the players ability.
    // the player will be able to phase through walls 
    //after the use of the ability there will be a cooldown 
    #region declarations

    private GameObject[] walls;
    public int cooldownTimer;
    public bool IsInCooldown;
    //public bool IsNearMark;
    //private float startTime = 0f;
    //private float Timer = 0f;
    //public float holdTime = 3f;
    //private bool held = false;

    #endregion

    private void Awake()
    {
        walls = GameObject.FindGameObjectsWithTag("WallInterior");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WallInterior"))
        {
            foreach (GameObject wall in walls)
            {
                wall.GetComponent<BoxCollider2D>().isTrigger = false;
                wall.GetComponent<SpriteRenderer>().color = new Color32(120,120,120,120);
            }
            //GameObject.FindGameObjectsWithTag("WallInterior")[0].GetComponent<BoxCollider2D>().isTrigger = false;
            print("Istrigger = false");
            StartCoroutine("timer");
        }
    }

    public void LightCooldown()
    {
        StartCoroutine("Cooldown");
    }


    IEnumerator timer()
    {
        yield return new WaitForSeconds(cooldownTimer);
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<BoxCollider2D>().isTrigger = true;
            print("Istrigger = true");
            wall.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }

    IEnumerator Cooldown()
    {
        IsInCooldown = true;
        yield return new WaitForSeconds(cooldownTimer);
        IsInCooldown = false;
    }
}


