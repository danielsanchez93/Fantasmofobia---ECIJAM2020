using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    //public Rigidbody2D rb;
    public PlayerController playerController;
    public bool crucifijoEnRango = false;
    //public float speed = 5;
    public bool detectedBysensor = false;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        /*float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        if (!isFrezee)
        {
            movement = new Vector2(horizontal, vertical);
            rb.velocity = movement * Time.deltaTime;
        }*/
           
        if (!crucifijoEnRango && playerController.movementSpeed <= 5)
        {
            playerController.movementSpeed += 0.1f;
        }
    }

    public void Freeze()
    {
        StartCoroutine(FreezeCharacter());
    }

    IEnumerator FreezeCharacter() 
    {
        playerController.isFreeze = true;
        playerController.rigidBody.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        playerController.isFreeze = false;
    }
    


}
