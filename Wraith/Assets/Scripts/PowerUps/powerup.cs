using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class powerup : MonoBehaviour
{
   public AudioSource powerMe;
   public AudioClip gotcha;
   public GameObject speed;
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         Debug.Log("PICKED UP!");
         PickUp();
      }
   }

   void PickUp()
   {
      powerMe.clip = gotcha;
      powerMe.Play();
      
      
      //Instantiate()
      Debug.Log("PowerUp!");
      PlayShipMove.maxAccel = 15f;
      StartCoroutine(waitTilDeath());
   }

   IEnumerator waitTilDeath()
   {
      
      speed.GetComponent<PolygonCollider2D>().enabled = false;
      speed.GetComponent<SpriteRenderer>().enabled = false;
  
      yield return new WaitForSeconds(10f);
      PlayShipMove.maxAccel = 9f;
      Destroy(gameObject);
    
   }
}
