using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RanchController : MonoBehaviour
{
    [OnValueChanged("InitDataPet")]
    public DataPet prefab;

    [ReadOnly, Expandable]
    public DataPet currentPet;

    [Button()]
    public void InitDataPet()
    {
        currentPet = prefab.Replicate();
        currentWeek.AssignWeek(currentPet);
    }

    public class GameCalander
    {
        public enum Season
        {
            Spring,
            Summer,
            Fall,
            Winter
        }
    }

    [System.Serializable]
    public class GameWeek
    {
        public DataPet Owner;
        //7 activities for the week
        public ActivityBase[] activities; 

        public void InitWeek()
        {
            activities = new ActivityBase[]
            {
                new RestActivity(),
                new WorkActivity(),
                new WorkActivity(),
                new RestActivity(),
                new WorkActivity(),
                new WorkActivity(),
                new RestActivity()
            };
        }
        
        public void DoWeek()
        {
            for (int i = 0; i < activities.Length; i++)
            {
                activities[i].DoActivity();
            }
        }

        public void AssignWeek(DataPet pet)
        {
            Owner = pet;
            InitWeek(); 
            for (int i = 0; i < activities.Length; i++)
            {
                activities[i].doer = Owner;
            }
     
        }
    }



    //Activities

    public class RestActivity : ActivityBase
    {
        public float restValue = 0.5f;

        public override void DoActivity()
        {
            doer.rest += restValue;
            print("REST");
            base.DoActivity();
        }


    }

    public class WorkActivity : ActivityBase
    {
        public float ethicValue = 0.05f;

        public float restCost = 0.20f;
        public override void DoActivity()
        {
            print("WORK");
            doer.ethic += ethicValue;
            doer.rest -= restCost;
            base.DoActivity();
        }
    }



    [System.Serializable]
    public class ActivityBase //the base class for all activity funcutionality
    {
        public DataPet doer;
        public virtual void DoActivity()
        {
            print("ActivityBase: Activity Complete");
        }
    }

public GameWeek currentWeek;


[Button()]
public void RunWeek()
{
    currentWeek.DoWeek();
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
