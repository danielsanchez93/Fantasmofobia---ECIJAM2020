using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource source;
    public AudioClip playSound;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene()
    {
        source.clip = playSound;
        source.Play();
        StartCoroutine(scene());
    }

    IEnumerator scene() 
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene("Main");
    }

    IEnumerator quit()
    {
        yield return new WaitForSeconds(0.1f);
        Application.Quit();
    }

    public void ExitGame() 
    {
        source.clip = playSound;
        source.Play();
        StartCoroutine(quit());
    }
}
