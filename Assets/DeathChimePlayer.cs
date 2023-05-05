using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathChimePlayer : MonoBehaviour
{
    public GameObject sceneManager;
    public bool sound = false;
    private AudioSource audioSource;

    void Start()
    {
        if (sound)
        {
            sceneManager = GameObject.Find("SceneManager");
            var clip = sceneManager.GetComponent<AudioServer>().GetDeathChime();
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = clip;
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator KillBird(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
