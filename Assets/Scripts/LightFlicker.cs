using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightFlicker : MonoBehaviour
{
    public Light2D light; 
    public GameObject player;
    public float MinLight;
    public float MaxLight;
    public float lightWaitTime;
    public float LightCooldown;
    private bool InRoom = false;
    public bool IsRepaired = true;

    [Space]
    public Transform emergencypos;

    SitesManager sitesManager;
    private void Start()
    {
        sitesManager = FindObjectOfType<SitesManager>();
    }

    // Start is called before the first frame update
    private void Update()
    {
        //print(InRoom);
        if(InRoom)
        if (Input.GetKeyDown(KeyCode.E) && player.GetComponent<PlayerAbility>().IsInCooldown == false)
        {
            lightFlicker();
            player.GetComponent<PlayerAbility>().LightCooldown();
                //Genera una alerta que los enemigos más cercanos irán a revisar
                sitesManager.LaunchEmergency(emergencypos);
        }   
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            InRoom = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            InRoom = false;
    }

    private void lightFlicker()
    {
        StartCoroutine("LightTimer");
    }

    IEnumerator LightTimer()
    {
        if (!IsRepaired)
        {
            light.enabled = !light.enabled;
            yield return new WaitForSeconds(LightCooldown);
            StartCoroutine("LightTimer");
        }
        else
        {
            StopCoroutine("LightTimer");
        }
    }
}


