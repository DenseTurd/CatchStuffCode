using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAPButtonScript : MonoBehaviour
{
   public void PayToLose()
    {
        IAPManagement.instance.BuyNonConsumable();
    }
}
