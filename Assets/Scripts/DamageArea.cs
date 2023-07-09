using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
   public int damageDealt;
   public bool teleportOnHit;

   public Transform teleportDestination;

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.CompareTag("Player"))
      {
         var health = other.GetComponent<Health>();
         if (health != null)
         {
            health.TakeDamage(damageDealt);
            if (teleportOnHit)
            {
               health.gameObject.transform.position = teleportDestination.position;
            }
         }
      }
   }
}
