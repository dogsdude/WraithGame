using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class powerup : MonoBehaviour
{
   public AudioSource powerMe;
   public AudioClip gotcha;
   
   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         PickUp();

      }
   }

   void PickUp()
   {
      powerMe.clip = gotcha;
      powerMe.Play();
      //Instantiate()
      Debug.Log("PowerUp!");
      
      StartCoroutine(waitTilDeath());
   }

   IEnumerator waitTilDeath()
   {
      yield return new WaitForSeconds(0.64f);
      Destroy(gameObject);
   }
}
