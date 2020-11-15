﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public bool crucifijoEnRango = false;
    public float speed = 5;
    bool isFrezee = false;
    public bool detectedBysensor = false;
    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        if (!isFrezee)
        {
            movement = new Vector2(horizontal, vertical);
            rb.velocity = movement * Time.deltaTime;
        }
           
        if (!crucifijoEnRango && speed <= 300)
        {
            speed += 15;
        }
    }

    public void Freeze()
    {
        StartCoroutine(FreezeCharacter());
    }

    IEnumerator FreezeCharacter() 
    {
        isFrezee = true;
        rb.velocity = Vector2.zero;
        yield return new WaitForSeconds(1f);
        isFrezee = false;
    }
    


}
