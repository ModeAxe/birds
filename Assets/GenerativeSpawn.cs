using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerativeSpawn : MonoBehaviour
{
    public GameObject bird;
    public GameObject dome;
    private List<Vector3> birds_pos = new List<Vector3>();
    void Start()
    {
        //get mesh positions
        Mesh domeMesh = dome.GetComponent<MeshFilter>().mesh;

        for (int i = 0; i < domeMesh.vertices.Length; i++)
        {
            
            birds_pos.Add(dome.transform.TransformPoint(domeMesh.vertices[i]));
        }
        //instatiate birds
        foreach (Vector3 position in birds_pos)
        {
            GameObject.Instantiate(bird, position, Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}
