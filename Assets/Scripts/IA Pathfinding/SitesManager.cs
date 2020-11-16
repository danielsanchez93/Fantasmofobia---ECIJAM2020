using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitesManager : MonoBehaviour
{
    [SerializeField]
    public List<Transform> sites = new List<Transform>();

    public int radio=15;

    Collider2D[] cols;
    public void LaunchEmergency(Transform place)
    {
        Physics2D.OverlapCircleNonAlloc(place.position,radio,cols);
        foreach (Collider2D col in cols)
        {
            if (col.CompareTag("Enemy"))
            {
                col.GetComponent<IAStates>().GoToEmergency(place);
            }
        }
    }

    public Transform GetRandomTransformPlace()
    {
        int a = Random.Range(0,sites.Count-1);
        return sites[a];
    }
    
}
