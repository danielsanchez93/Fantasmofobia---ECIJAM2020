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
        if (player.GetComponent<SimpleMovement>().playerController.movementSpeed > 2.5)
        {
            player.GetComponent<SimpleMovement>().playerController.movementSpeed -= 0.1f;
        }
        
        Debug.Log(player.GetComponent<SimpleMovement>().playerController.movementSpeed);
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
