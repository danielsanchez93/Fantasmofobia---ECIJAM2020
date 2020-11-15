using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    // using a float on movement speed allows us to fine tune the speed better than an Integer would
    public float movementSpeed;
    private Vector2 moveDirection;
    
    private void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }
    
    #region Custom Methods
    private void ProcessInputs()
    {
        //using get axis raw allows us to include controller support if need be
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");
        //We normalize moveDirection to avoid making diagonal movement faster 
        moveDirection = new Vector2(movementX, movementY).normalized;
    }

    public void Move()
    {
        rigidBody.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
    #endregion
}
