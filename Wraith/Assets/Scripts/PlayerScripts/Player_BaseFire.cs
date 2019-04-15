using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BaseFire : MonoBehaviour
{
    public float fireDelay = 0.25f;
    private float cooldownTimer = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && (cooldownTimer <= 0.0f))
        {
            //Shoot the base shot
            cooldownTimer = fireDelay;

        }
        
    }
}
