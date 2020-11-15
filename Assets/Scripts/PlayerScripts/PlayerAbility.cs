using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbility : MonoBehaviour
{
    // This is the class for the players ability.
    // the player will be able to phase through walls 
    //after the use of the ability there will be a cooldown 

    GameObject[] walls;
    public int CooldownTimer;
    private void Awake()
    {
        walls = GameObject.FindGameObjectsWithTag("WallInterior");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("WallInterior"))
        {
            foreach(GameObject wall in walls)
            {
                wall.GetComponent<BoxCollider2D>().isTrigger = false;
            }
            GameObject.FindGameObjectsWithTag("WallInterior")[0].GetComponent<BoxCollider2D>().isTrigger = false;
            StartCoroutine("timer");
        }
    }

    IEnumerator timer()
    {
        yield return new WaitForSeconds(CooldownTimer);
        foreach (GameObject wall in walls)
        {
            wall.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
