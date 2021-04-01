using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnReagent : MonoBehaviour
{
    public GameObject reagentPrefab;
    // Start is called before the first frame update
    

    GameObject reagent;
    void Start()
    {
        CreateReagent();

    }

    void CreateReagent()
    {
        if(reagent == null)
        {
            reagent = Instantiate(reagentPrefab, this.transform.position, Quaternion.identity);
            reagent.name = reagentPrefab.name;
            reagent.GetComponent<Reagent>().potionColor = new Color(RandomColor(), RandomColor(), RandomColor());
            
            
        }
        
    }

    


    // Update is called once per frame
    void Update()
    {
        CreateReagent();
    }

    private void FixedUpdate()
    {
        
    }

    private float RandomColor()
    {
        return Random.Range(0f, 1f);
    }
    
}
