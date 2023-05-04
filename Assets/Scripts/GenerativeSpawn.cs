using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GenerativeSpawn : MonoBehaviour
{
    public float timeScale = 20f;

    public GameObject bird;
    public GameObject dome;

    public TextAsset DATA;

    private List<Vector3> birds_pos = new List<Vector3>();
    private List<GameObject> birds = new List<GameObject>();

    public static int YEAR = 1470;
    private float time;

    void Start()
    {
        //get mesh positions
        Mesh domeMesh = dome.GetComponent<MeshFilter>().mesh;
        HashSet<Vector3> unique_birds_pos = new HashSet<Vector3>();

        for (int i = 0; i < domeMesh.vertices.Length; i++)
        {
            if (!unique_birds_pos.Contains(domeMesh.vertices[i]))
            {
                unique_birds_pos.Add(dome.transform.TransformPoint(domeMesh.vertices[i]));
            }

        }
        //instatiate birds
        birds_pos = new List<Vector3>(unique_birds_pos);
        foreach (Vector3 position in birds_pos)
        {
            birds.Add(GameObject.Instantiate(bird, position, Quaternion.identity));
        }

        AssignBirdData();
    }

    void Update()
    {
        if (time > timeScale)
        {
            time = 0;
            YEAR++;
            Debug.Log(YEAR);
        }
        time += Time.deltaTime;
    }

    private void AssignBirdData()
    {
        //Open CSV
        string[] lines_array = DATA.text.Split(new string[] { "\n" }, StringSplitOptions.None);
        List<string> lines = lines_array.ToList();
        lines.RemoveAt(0);
        //for each line assign data
        int index = 0;
        int domeBirdCount = birds.Count;
        foreach (string line in lines)
        {
            string[] lineData = line.Split(new string[] { "," }, StringSplitOptions.None);
            if (lineData[0] == "")
            {
                continue;
            }

            string name = lineData[2];
            string species = lineData[1];
            List<float> rates = new List<float>();
            int extinctionDate = int.Parse(lineData[4]);
            int audioIndex = int.Parse(lineData[6]);

            AudioClip clip;
            if (audioIndex == 999)
            {
                clip = gameObject.GetComponent<AudioServer>().GetBirdSound();
            }
            else
            {
                clip = gameObject.GetComponent<AudioServer>().GetBirdSound(audioIndex);
            }

            birds[index].GetComponent<bird>().SetName(name);
            birds[index].GetComponent<bird>().SetExtinctionDate(extinctionDate);
            birds[index].GetComponent<bird>().SetAudio(clip);

            var twin_index = domeBirdCount - index - 1;
            birds[twin_index].GetComponent<bird>().SetName(name);
            birds[twin_index].GetComponent<bird>().SetExtinctionDate(extinctionDate);
            birds[twin_index].GetComponent<bird>().SetAudio(clip);

            index++;
        }

    }
}