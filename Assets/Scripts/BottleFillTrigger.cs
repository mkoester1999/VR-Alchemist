using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BottleFillTrigger : MonoBehaviour
{
    public GameObject bottle;
    public GameObject head;


    
    private void OnTriggerExit(Collider other)
    {

        if (other.TryGetComponent(out PotionBase potionBase) && bottle.GetComponent<BottleContents>().bottleContents == null)
        {
            bottle.GetComponent<BottleContents>().SetContents(ref potionBase);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == head.tag && bottle.GetComponent<BottleContents>().bottleContents != null)
        {
            bottle.GetComponent<BottleContents>().PotionDrink();
        }
    }


}
