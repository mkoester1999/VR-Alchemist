using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal;
using UnityEngine;


public class PotionBase : MonoBehaviour
{

    private List<Reagent> reagents = new List<Reagent>();
    private Vector3 totalColor = new Vector3(0,0,0);
    private Color basePotionColor;
    public Dictionary<string, Reagent> potionEffects = new Dictionary<string, Reagent>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        
    }


    //when an object collides with this, if it contains the Reagent component, it will call AddReagent
    private void OnTriggerExit(Collider collision)
    {


        if (collision != null  && collision.TryGetComponent(out Reagent addedReagent))
        {
            
            //Debug.Log(addedReagent.effectName);
            AddReagent(addedReagent);
            //Destroy(collision.collider.gameObject);
            Destroy(addedReagent.gameObject);

            

        }



    }

    //AddReagent
    //Adds an Reagent called reagent to the reagents list
    //returns void
    //Parameters: Reagent

    void AddReagent(Reagent reagent)
    {
        
        reagents.Add(reagent);

        totalColor.x += reagent.potionColor.r;
        totalColor.y += reagent.potionColor.g;
        totalColor.z += reagent.potionColor.b;

        /*basePotionColor.r += reagent.potionColor.r;
        basePotionColor.b += reagent.potionColor.b;
        basePotionColor.g += reagent.potionColor.g;*/

        SetColor(ref basePotionColor);

        ConvertEffects(reagent);
        
    }

    //SetColor
    //Sets the color of the material
    //returns void
    //Parameters: Color
    void SetColor(ref Color color)
    {
        //gets the mean color and clamps it within the bounds of color (0-255)
        basePotionColor.r = Mathf.Clamp(totalColor.x / reagents.Count, 0, 255);
        basePotionColor.g = Mathf.Clamp(totalColor.y / reagents.Count, 0, 255);
        basePotionColor.b = Mathf.Clamp(totalColor.z / reagents.Count, 0, 255);


        GetComponent<Renderer>().material.color = color;

    }


    //ConvertEffects method
    //Combines potion effects in potionBase and adds them to Dictionary potionEffects.
    //Returns void
    //parameters: none
    private void ConvertEffects(Reagent effect)
    {
        //potionEffects key is effect name + effect thisEffectType
        if (effect.name != null)
        {
            if (potionEffects.ContainsKey(effect.effectName + effect.thisEffectType))
            {
                //if key exists, get value from the key and then add effect's effectValue to dictEffect's effectValue
                potionEffects.TryGetValue((effect.effectName + effect.thisEffectType), out Reagent dictEffect);

                dictEffect.effectValue += effect.effectValue;

                //if effect.effectDuration is smaller, set dictEffect.effectDuration to effect.effectDuration,
                if (effect.effectDuration < dictEffect.effectDuration)
                    dictEffect.effectDuration = effect.effectDuration;

            }
            else
            {
                //else add the effect to the dictionary with the key effect.name + effect.thisEffectType
                potionEffects.Add((effect.effectName + effect.thisEffectType), effect);
            }
        }
    }

    public Color GetPotionColor()
    {
        return basePotionColor;
    }

}
