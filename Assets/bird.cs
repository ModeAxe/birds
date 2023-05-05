using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject deathChimePlayer;

    private int extinctionYear = 2030;
    private string birdName;
    void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //gameObject.GetComponent<AudioSource>().Stop();
            //AudioClip deathChime = sceneManager.GetComponent<AudioServer>().GetDeathChime();
            //gameObject.GetComponent<AudioSource>().PlayOneShot(deathChime);
        }
        if (GenerativeSpawn.YEAR >= extinctionYear)
        {
            gameObject.GetComponent<AudioSource>().Stop();
            GameObject.Instantiate(deathChimePlayer, transform.position, Quaternion.identity);
            Debug.Log("Death");
            KillBird(0.5f);
        }
    }

    public void SetExtinctionDate(int year)
    {
        extinctionYear = year;
    }

    public void SetName(string name)
    {
        birdName = name;
    }

    public void SetAudio(AudioClip clip)
    {
        gameObject.GetComponent<AudioSource>().clip = clip;
        gameObject.GetComponent<AudioSource>().Play();
    }

    IEnumerator KillBird(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
