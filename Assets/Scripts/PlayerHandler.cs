using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHandler : MonoBehaviour
{
    public int maxPlayerHealth;
    public int maxPlayerStamina;

    public List<PotionEffectsHandler> activeEffects;

    //attributes
    public int playerMind;
    public int playerBody;
    public int playerSoul;


    //skills
    public int playerHunting; //body
    public int playerCombat; //body
    public int playerAlchemy; //mind
    public int playerSpeech; //mind
    public int playerGardening; //soul
    public int playerFishing; //soul


    private int playerHealth;
    private int playerStamina;


    
    public int PlayerHealth
    {
        get => playerHealth;
        set => playerHealth = value;
    }

    public int PlayerStamina
    {
        get => playerStamina;
        set => playerStamina = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = maxPlayerHealth;
        playerStamina = maxPlayerStamina;
    }



    // Update is called once per frame
    void Update()
    {
        foreach (PotionEffectsHandler item in activeEffects)
        {
            item.UpdateTimer();
            
        }
    }

    public void DrinkPotion(Dictionary<string, Reagent> potion)
    {
        foreach (KeyValuePair<string, Reagent> item in potion)
        {
            activeEffects.Add(new PotionEffectsHandler(item.Value, this.gameObject)); 
            
        }
    }

}
