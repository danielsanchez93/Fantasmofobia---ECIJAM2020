using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitesManager : MonoBehaviour
{
    [SerializeField]
    public List<Transform> sites = new List<Transform>();

    public int radio=15;

    GameObject[] cols;
    public void LaunchEmergency(Transform place,LightFlicker roomToRepair)
    {
        cols = GameObject.FindGameObjectsWithTag("Enemy"); /*Physics2D.OverlapCircleAll(place.position,radio);*/
        if(cols!=null)foreach (GameObject col in cols)
        {
            if (Vector2.Distance(transform.position,col.transform.position)<=30)
            {
                col.GetComponent<IAStates>().GoToEmergency(place,roomToRepair);
            }
        }
    }

    public Transform GetRandomTransformPlace()
    {
        int a = Random.Range(0,sites.Count-1);
        return sites[a];
    }
    
}
