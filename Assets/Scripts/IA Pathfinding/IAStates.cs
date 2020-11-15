using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IAStates : AIPath
{
    
    Rigidbody2D rb;
    AIDestinationSetter destinationSetter;
    Transform player;

    bool destinationReached;

    //Idle es caminar por ahí, no estar quieto
    [System.Serializable]
    public enum IAStatus { Idle, Chasing, Investigating}
    public IAStatus state = new IAStatus();


    // Start is called before the first frame update
    new void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        destinationSetter = GetComponent<AIDestinationSetter>();
    }

    public override void OnTargetReached()
    {
        if (!destinationReached)
        {
            destinationReached = true;
        }
        else
        {
            //acción deseada
            //timer
            StartCoroutine(Cooldown(2));
        }
    }

    public void GoToEmergency(Transform place)
    {
        state = IAStatus.Investigating;
        destinationSetter.target = place;
    }

    public void ChasePJ()
    {
        state = IAStatus.Chasing;
        destinationSetter.target = player;
    }
   
    IEnumerator Cooldown(int secs)
    {
        yield return new WaitForSeconds(secs);
    }

    //private void FixedUpdate()
    //{
    //    if (path == null) return;

    //    if(currentWaypoint >= path.vectorPath.Count)
    //    {
    //        reachedEndOfPath = true;
    //        return;
    //    }
    //    else
    //    {
    //        reachedEndOfPath = false;
    //    }

    //    float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

    //    if (distance < nextWaypointDistance)
    //    {
    //        currentWaypoint++;
    //    }
    //}

}
