using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using PlayShipMove;
public class speedUp : MonoBehaviour
{   public AudioSource powerMe;
    public AudioClip gotcha;
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PickUp();
        }
    }

    IEnumerator PickUp()
    {
        powerMe.clip = gotcha;
        powerMe.Play();

        PlayShipMove.maxAccel = 16f;
        //Instantiate()
        Debug.Log("PowerUp!");
      
        StartCoroutine(waitTilDeath());
        yield return new WaitForSeconds(3f);
        PlayShipMove.maxAccel = 9f;
    }

    IEnumerator waitTilDeath()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }
}
