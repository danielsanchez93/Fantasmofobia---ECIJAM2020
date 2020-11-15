using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionSensor : MonoBehaviour
{
    public GameObject player;
    public float visionRadius = 2.5f;
    private void Update()
    {
        if (player.GetComponent<SimpleMovement>().detectedBysensor)
        {
            GetComponent<PolygonCollider2D>().enabled = false;
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position,
                player.transform.position - transform.position,
                visionRadius,
                1 << LayerMask.NameToLayer("Default"));

            Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
            Debug.DrawRay(transform.position, forward, Color.red);


            if (hit.collider != null)
            {
                Debug.Log("is not null");
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Player")
                {
                    Debug.Log("got the player");
                    GetComponent<PolygonCollider2D>().enabled = true;
                    player.GetComponent<SimpleMovement>().detectedBysensor = false;
                }
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.GetComponent<SimpleMovement>().detectedBysensor = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        //player.GetComponent<SimpleMovement>().detectedBysensor = false;
        Debug.Log(player.GetComponent<SimpleMovement>().detectedBysensor);
    }
}
