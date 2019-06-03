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
    public bool canFire = true;
    public int counter = 0;
    public Vector3 bulletOff = new Vector3(0,0.5f,0);
    // Update is called once per frame

    public void Start()
    {
        counter = 0;
    }
    private void Update()
    {
//        cooldownTimer -= Time.deltaTime;
//        if (Input.GetButton("Fire1") && (cooldownTimer <= 0))
//        {
//            //Shoot the base shot
//            //Debug.Log(("Pew!"));
//             cooldownTimer = fireDelay;
//            
//             Instantiate(basefirePrefab, transform.position + bulletOff, transform.rotation);
//             
//             Debug.Log("Shoot played");
//             shot.Play();
//
//        }

        if (canFire)
        {
            StartCoroutine(fire());
        }
    }

    IEnumerator fire()
    {
       
            //cooldownTimer -= Time.deltaTime;
            cooldownTimer -= Time.deltaTime;
                if (Input.GetButton("Fire1") && (cooldownTimer <= 0) && (counter < 4) )
                {

                    cooldownTimer = fireDelay;
                    Instantiate(basefirePrefab, transform.position + bulletOff, transform.rotation);

                    Debug.Log("Shoot played");
                    shot.Play();
                    counter++;

                }

                if (counter == 3)
                {
                    canFire = false;

                    Debug.Log("Loop broken");

                    yield return new WaitForSeconds(1f);

                    canFire = true;
                    counter = 0;
                }
    }
}
