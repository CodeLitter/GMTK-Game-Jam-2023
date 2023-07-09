using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleControls : MonoBehaviour
{
   public GameObject gameObjectGroupToHide;
   public GameObject gameObjectGroupToDisplay;

   public void displayControls()
   {
      gameObjectGroupToHide.SetActive(false);
      gameObjectGroupToDisplay.SetActive(true);
   }

   public void hideControls()
   {
      gameObjectGroupToHide.SetActive(true);
      gameObjectGroupToDisplay.SetActive(false);
   }
}
