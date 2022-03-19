using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Plunger : MonoBehaviour
{
    float power;
    float maxPower = 10f;
    float powerCountPerTick = 1;

    Rigidbody ballRb;
    ContactPoint contact;

    bool ballReady;

    void Update()
    {
        if(ballReady)
        {
            if(Input.GetKey(KeyCode.DownArrow))
            {
                if(power <= maxPower)
                {
                    power += powerCountPerTick * Time.deltaTime;
                }
            }

            if(Input.GetKeyUp(KeyCode.DownArrow))
            {
                if(ballRb != null)
                {
                    ballRb.AddForce(-1 * power * contact.normal,ForceMode.Impulse);
                }
            }
        }
    }

    void OnCollisionEnter(Collision col)
    {
        ballReady = true;
        power = 110f;
        contact = col.contacts[0];
        ballRb = contact.otherCollider.attachedRigidbody;
    }

    void OnCollisionExit(Collision col)
    {
        ballReady = false;
        ballRb = null;
    }
}