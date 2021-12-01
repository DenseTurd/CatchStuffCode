using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBurstControl : MonoBehaviour
{
    public GameObject burstShieldUp;
    public GameObject burstShieldLeft;
    public GameObject burstShieldRight;
    public List<GameObject> shields = new List<GameObject>();
    List<GameObject> XShields = new List<GameObject>();
    public List<GameObject> springyShields = new List<GameObject>();
    public List<GameObject> springyShieldShieldsL = new List<GameObject>();
    public List<GameObject> springyShieldShieldsR = new List<GameObject>();
    public bool springyL;
    public bool springyR;
   
    public static ShieldBurstControl instance { get; set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;
    }
    public void AddShield(GameObject shield)
    {
        shields.Add(shield);
    }

    public void AddXShield(GameObject XShield)
    {
        XShields.Add(XShield);
    }

    public void AddSpringyShield(GameObject springyShield)
    {
        springyShields.Add(springyShield);
    }

    public void AddSpringyShieldShieldL(GameObject springyShieldShield)
    {
        springyShieldShieldsL.Add(springyShieldShield);
    }
    public void AddSpringyShieldShieldR(GameObject springyShieldShield)
    {
        springyShieldShieldsR.Add(springyShieldShield);
    }

    public void Burst()
    {
        StartCoroutine(BurstCoRoutine());
    }

    public IEnumerator BurstCoRoutine()
    {
        foreach (GameObject shield in shields)
        {
            Instantiate(burstShieldUp, shield.transform.position, shield.transform.rotation);
            Instantiate(burstShieldLeft, shield.transform.position, shield.transform.rotation);
            Instantiate(burstShieldRight, shield.transform.position, shield.transform.rotation);
            yield return null;
        }
        foreach (GameObject XShield in XShields)
        {
            Instantiate(burstShieldUp, XShield.transform.position, XShield.transform.rotation);
            Instantiate(burstShieldLeft, XShield.transform.position, XShield.transform.rotation);
            Instantiate(burstShieldRight, XShield.transform.position, XShield.transform.rotation);
            yield return null;
        }
        foreach (GameObject springyShield in springyShields)
        {
            Instantiate(burstShieldUp, springyShield.transform.position, springyShield.transform.rotation);
            Instantiate(burstShieldLeft, springyShield.transform.position, springyShield.transform.rotation);
            Instantiate(burstShieldRight, springyShield.transform.position, springyShield.transform.rotation);
            yield return null;
        }
        foreach (GameObject springyShieldShieldL in springyShieldShieldsL)
        {
            Instantiate(burstShieldUp, springyShieldShieldL.transform.position, springyShieldShieldL.transform.rotation);
            Instantiate(burstShieldLeft, springyShieldShieldL.transform.position, springyShieldShieldL.transform.rotation);
            Instantiate(burstShieldRight, springyShieldShieldL.transform.position, springyShieldShieldL.transform.rotation);
            yield return null;
        }
        foreach (GameObject springyShieldShieldR in springyShieldShieldsR)
        {
            Instantiate(burstShieldUp, springyShieldShieldR.transform.position, springyShieldShieldR.transform.rotation);
            Instantiate(burstShieldLeft, springyShieldShieldR.transform.position, springyShieldShieldR.transform.rotation);
            Instantiate(burstShieldRight, springyShieldShieldR.transform.position, springyShieldShieldR.transform.rotation);
            yield return null;
        }

        if (PlayerControllerBlochFall.Instance != null)
        {
            Instantiate(burstShieldUp, PlayerControllerBlochFall.Instance.transform.position, transform.rotation);
            Instantiate(burstShieldLeft, PlayerControllerBlochFall.Instance.transform.position, transform.rotation);
            Instantiate(burstShieldRight, PlayerControllerBlochFall.Instance.transform.position, transform.rotation);
            yield return null;
        }
    }
    
    public void RemoveShield(GameObject shield)
    {
        shields.Remove(shield);
    }

    public void RemoveXShield(GameObject XShield)
    {
        XShields.Remove(XShield);
    }

    public void RemoveSpringyShield(GameObject springyShield)
    {
        springyShields.Remove(springyShield);
    }

    public void RemoveSpringyShieldShieldL(GameObject springyShieldShield)
    {
        springyShieldShieldsL.Remove(springyShieldShield);
    }

    public void RemoveSpringyShieldShieldR(GameObject springyShieldShield)
    {
        springyShieldShieldsR.Remove(springyShieldShield);
    }

    public int ListLenght()
    {
        return shields.Count;
    }

    public int SpringyListLenght()
    {
        return springyShieldShieldsL.Count;
    }

    public int ListIndex(GameObject Shield)
    {
        return shields.IndexOf(Shield);
    }

    public int SpringyListIndex(GameObject Shield)
    {
        return springyShieldShieldsL.IndexOf(Shield);
    }

    public int SpringyRListIndex(GameObject Shield)
    {
        return springyShieldShieldsR.IndexOf(Shield);
    }
}
