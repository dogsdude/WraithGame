using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BaseFire : MonoBehaviour
{
    public GameObject basefirePrefab;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    //public AudioSource shoot;
    public AudioSource shot;
    public Vector3 bulletOff = new Vector3(0,0.5f,0);
    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        if (Input.GetButton("Fire1") && (cooldownTimer <= 0))
        {
            //Shoot the base shot
            //Debug.Log(("Pew!"));
            cooldownTimer = fireDelay;
            
             Instantiate(basefirePrefab, transform.position + bulletOff, transform.rotation);
             
             Debug.Log("Shoot played");
             shot.Play();

        }
        
    }
}
