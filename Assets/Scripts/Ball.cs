using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }
    
    private void OnCollisionExit(Collision other)
    {
        var velocity = m_Rigidbody.velocity;
        
        //after a collision we accelerate a bit
        velocity += velocity.normalized * Main.s.accelerationFactor;
        
        //check if we are not going totally vertically as this would lead to being stuck, we add a little vertical force
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            velocity += velocity.y > 0 ? Vector3.up * (1/Main.s.startImpulse) : Vector3.down * (1 / Main.s.startImpulse);
        }

        //max velocity
        if (velocity.magnitude > Main.s.maxVelocity )
        {
            velocity = velocity.normalized * Main.s.maxVelocity;
        }

        m_Rigidbody.velocity = velocity;
    }
}
