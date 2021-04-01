using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class PotionEffectsHandler : MonoBehaviour
{
    public Action<GameObject, float, bool> EffectMethod { get; set; }

    private bool active;
    private float timer;

    private GameObject target;
    private Reagent potion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTimer()
    {
        if (active && Time.unscaledTime >= timer)
        {
            active = false;
            EffectMethod(target, potion.effectValue, active);
            target.GetComponent<PlayerHandler>().activeEffects.Remove(this);
            Destroy(this);
        }
    }
    //Parameterized constructor that creates the potion effect
    //returns void
    //parameters: Reagent
    public PotionEffectsHandler(Reagent _potion, GameObject _target)
    {
        target = _target;
        potion = _potion;
        //case switch for each effect type. Each type will have a method that handles the creation of the potion from there.
        switch(potion.thisEffectType)
        {
            //put each effect type here. (so far attribute, skill, status effect)
            case Reagent.effectType.attribute:
                EffectMethod = AttributeHandler(potion);
                break;
            case Reagent.effectType.skill:
                EffectMethod = SkillHandler(potion);
                break;

        }
        if(EffectMethod != null)
        {
            active = true;
            EffectMethod(target, potion.effectValue, active);
            timer = Time.unscaledTime + potion.effectDuration;
        }
    }

    private Action<GameObject, float, bool> AttributeHandler(Reagent potion)
    {
        switch(potion.effectName)
        {
            case "body":
                return Effects.effectBody;
            case "mind":
                return Effects.effectMind;
            case "soul":
                return Effects.effectSoul;          
            default:
                return null;
        }
        

    }

    private Action<GameObject, float, bool> SkillHandler(Reagent potion)
    {
        switch (potion.effectName)
        {
            case "combat":
                return Effects.effectCombat;
            case "hunting":
                return Effects.effectHunting;
            case "speech":
                return Effects.effectSpeech;
            case "alchemy":
                return Effects.effectAlchemy;
            case "gardening":
                return Effects.effectGardening;
            case "fishing":
                return Effects.effectFishing;
            default:
                return null;
        }


    }


}

static class Effects
{
    
    //maybe add another argument for what attribute/skill to use so that I don't have so many methods doing virtually the same thing
    public static void effectBody(GameObject target, float value, bool active)
    {
        //int sign = GetActive(active); //simplify. This can just be here v
        target.GetComponent<PlayerHandler>().playerBody += GetActive(active) * (int)value;
        
    }
    public static void effectMind(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerMind += GetActive(active) * (int)value;
    }
    public static void effectSoul(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerSoul += GetActive(active) * (int)value;
    }

    public static void effectCombat(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerCombat += GetActive(active) * (int)value;
    }

    public static void effectHunting(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerHunting += GetActive(active) * (int)value;
    }

    public static void effectSpeech(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerSpeech += GetActive(active) * (int)value;
    }

    public static void effectAlchemy(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerAlchemy += GetActive(active) * (int)value;
    }

    public static void effectGardening(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerGardening += GetActive(active) * (int)value;
    }

    public static void effectFishing(GameObject target, float value, bool active)
    {
        target.GetComponent<PlayerHandler>().playerFishing += GetActive(active) * (int)value;
    }
    private static int GetActive(bool active)
    {
        if (active)
            return 1;
        else return -1;
    }

    //list all effects here
}
