using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "DataPet", menuName = "DataPet/Pet Data", order = 1)]
public class DataPet : ScriptableObject
{

    
    //Stats For Combat
    
    //Stats for CurrentStatus
    public float rest = 1;
    public float ethic = 0;


    public DataPet Replicate()
    {
        //return ScriptableObject.CreateInstance<DataPet>(this);
        return ScriptableObject.Instantiate(this); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
