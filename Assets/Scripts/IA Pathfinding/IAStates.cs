using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class IAStates : AIPath
{
    
    Rigidbody2D rb;
    AIDestinationSetter destinationSetter;
    SitesManager sitesM;
    Transform player;

    bool destinationReached;

    //Idle es caminar por ahí, no estar quieto
    public enum IAStatus { Idle, Chasing, Investigating}
    [Space]
    [Header("States")]
    [UnityEngine.Serialization.FormerlySerializedAs("speed")]
    public IAStatus state = new IAStatus();


    // Start is called before the first frame update
    new void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        destinationSetter = GetComponent<AIDestinationSetter>();
        sitesM = FindObjectOfType<SitesManager>();
        GoToWalk();
    }

    public override void OnTargetReached()
    {
        if (!destinationReached)
        {
            destinationReached = true;
        }
        else
        {
            StartCoroutine(Cooldown(4));
        }
    }

    public void GoToEmergency(Transform place)
    {
        state = IAStatus.Investigating;
        destinationSetter.target = place;
    }

    /// <summary>
    /// Si se pierde la referencia mientras se están en Chase, se debería volver a GoToWalk
    /// </summary>
    public void ChasePJ()
    {
        state = IAStatus.Chasing;
        destinationSetter.target = player;
    }

    public void GoToWalk()
    {
        state = IAStatus.Idle;
        destinationSetter.target = sitesM.GetRandomTransformPlace();
    }
   
    IEnumerator Cooldown(int secs)
    {
        yield return new WaitForSeconds(secs);
        switch (state)
        {
            case IAStatus.Chasing:
                //llamar a los demás
                break;
            case IAStatus.Idle:
                GoToWalk();
                break;
            case IAStatus.Investigating:
                //arreglar la luz
                GoToWalk();
                break;
        }
    }

    

}
