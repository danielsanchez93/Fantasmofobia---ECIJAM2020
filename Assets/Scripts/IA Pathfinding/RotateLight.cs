using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLight : MonoBehaviour
{
    Rigidbody2D rb;
    IAStates iaStates;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponentInParent<Rigidbody2D>();
        iaStates = GetComponentInParent<IAStates>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iaStates.velocity.magnitude > 0)
        {
            float angle = Mathf.Atan2(iaStates.velocity.y, iaStates.velocity.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
