using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private int extinctionYear;
    private string birdName;
    void Start()
    {
        
    }
    void Update()
    {
        if (GenerativeSpawn.YEAR == extinctionYear)
        {
            //gameObject.GetComponent<AudioSource>().PlayOneShot();
            Destroy(gameObject);
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
}
