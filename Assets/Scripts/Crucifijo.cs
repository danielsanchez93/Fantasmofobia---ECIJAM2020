using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crucifijo : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("In range");
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        player.GetComponent<SimpleMovement>().crucifijoEnRango = true;
        if (player.GetComponent<SimpleMovement>().speed > 50)
        {
            player.GetComponent<SimpleMovement>().speed -= 5;
        }
        
        Debug.Log(player.GetComponent<SimpleMovement>().speed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Out of range");
            player.GetComponent<SimpleMovement>().crucifijoEnRango = false;

        }
        
    }



}
