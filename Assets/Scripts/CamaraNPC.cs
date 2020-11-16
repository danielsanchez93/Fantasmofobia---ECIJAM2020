using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraNPC : MonoBehaviour
{
    public GameObject player;
    public float visionRadius;
    public float timeToShoot = 0;

    private void Update()
    {
        timeToShoot += Time.deltaTime;
        if (timeToShoot >=4)
        {
            timeToShoot = 0;
        }

       // Debug.DrawLine(transform.position, player.transform.position, Color.green);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log("InRangeCamera");
        Debug.Log(collision.tag);
        if (timeToShoot >=3)
        {
            //GetComponent<PolygonCollider2D>().enabled = false;
            RaycastHit2D hit = Physics2D.Raycast(
                transform.position, 
                player.transform.position - transform.position, 
                visionRadius,
                1 << LayerMask.NameToLayer("Default"));

            Vector3 forward = transform.TransformDirection(player.transform.position - transform.position);
            Debug.DrawRay(transform.position, forward, Color.red);

            Debug.Log(hit.collider.tag);
            if (hit.collider != null)
            {
                Debug.Log("is not null");
                Debug.Log(hit.collider.tag);
                if (hit.collider.tag == "Player")
                {
                    Debug.Log("got the player");
                    player.GetComponent<SimpleMovement>().Freeze();
                    //GetComponent<PolygonCollider2D>().enabled = true;
                } 
            }
        }
    }


}
