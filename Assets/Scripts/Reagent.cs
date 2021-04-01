using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;





public class Reagent : MonoBehaviour
{
    public string effectName;
    public float effectValue;
    public float effectDuration;
    public Color potionColor;

    public enum effectType { attribute, skill, statusEffect };
    public effectType thisEffectType;

    //default constructor;
    

    // Start is called before the first frame update
    void Start()
    {
        
        
        //set the color of the material;
        SetColor(potionColor);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public Reagent()
    {
        thisEffectType = effectType.attribute;
        effectName = "null";
        effectValue = 0f;
        effectDuration = 0f;
        potionColor = Color.white;
    }

    public Reagent(effectType _thisEffectType, string _effectName, float _effectValue, float _effectDuration, Color _potionColor)
    {
        thisEffectType = _thisEffectType;
        effectName = _effectName;
        effectValue = _effectValue;
        effectDuration = _effectDuration;
        potionColor = _potionColor;
    }

    private void SetColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;

    }
}

