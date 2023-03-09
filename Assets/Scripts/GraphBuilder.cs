using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphBuilder : MonoBehaviour
{
    private List<GameObject[]> graph = new List<GameObject[]>();
    private List<GameObject> adjacentNodes = new List<GameObject>();

    public void buildGraph(Transform node1, Transform node2) {

        graph.Add(new GameObject[2]{ node1.gameObject, node2.gameObject});
    } 

    public void setAdjacent(GameObject obj) {
        
        foreach(GameObject[] edge in graph)
        {
            if(obj == edge[0]) {
                adjacentNodes.Add(edge[1]);
            }
            if(obj == edge[1]) {
                adjacentNodes.Add(edge[0]);
            }
        }
    }

    void Update() {

        if(adjacentNodes.Count > 0) {
        
            for(int i = 0; i < adjacentNodes.Count; i++) {
                if(adjacentNodes[i].tag != "PassedNode")
                    adjacentNodes[i].tag = "AdjacentNode";
            }

            adjacentNodes.Clear();
        }
    }
}
