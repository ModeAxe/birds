using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeSpawn : MonoBehaviour
{
    public GameObject bird;
    public GameObject dome;
    private List<Vector3> birds_pos = new List<Vector3>();
    private List<GameObject> birds = new List<GameObject>();
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
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(birds.Count);
            for (int i = 0; i < 50; i++)
            {
                Destroy(birds[i]);
                Debug.Log("Gone");
            }

        }  
    }
}
