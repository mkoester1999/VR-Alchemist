using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class BottleContents : MonoBehaviour
{
    public GameObject bottleLiquid;

    public GameObject bottleContents;
    public GameObject player;

    private Dictionary<string, Reagent> bottleEffects = new Dictionary<string, Reagent>();
    private Color potionContentsColor;

    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    public Dictionary<string, Reagent> BottleEffects
    {
        get => bottleEffects;
        set => bottleEffects = value;
    }

    public void SetContents(ref PotionBase potionBase)
    {
        bottleEffects = potionBase.potionEffects;

        bottleContents = Instantiate(bottleLiquid, this.transform.position, this.transform.rotation);
        bottleContents.transform.SetParent(this.transform);
        potionContentsColor = potionBase.GetPotionColor();

        bottleContents.GetComponent<Renderer>().material.color = potionContentsColor;

    }

    public void PotionDrink()
    {
        player.GetComponent<PlayerHandler>().DrinkPotion(bottleEffects);
        Destroy(bottleContents);
       
    }

    

}
