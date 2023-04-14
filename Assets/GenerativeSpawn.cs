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

        Debug.Log(domeMesh.vertices.Length);

        for (int i = 0; i < 341; i++)
        {
            
            birds_pos.Add(dome.transform.TransformPoint(domeMesh.vertices[i]));
        }
        //instatiate birds
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
