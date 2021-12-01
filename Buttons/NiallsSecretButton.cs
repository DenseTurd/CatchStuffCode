using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NiallsSecretButton : MonoBehaviour
{
   public void BidyActivate()
   {
        AudioManager.instance.Play("blip", Random.Range(0.7f, 1.4f));
       
            ScoreControl.bidy = true;   
   }
}
