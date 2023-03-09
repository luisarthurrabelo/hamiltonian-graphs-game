using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] public Transform node1;
    [SerializeField] public Transform node2;
    [SerializeField] private LineController line;

    private void Start() {
        
       line.SetUpLine(node1, node2);
       this.GetComponent<GraphBuilder>().buildGraph(node1, node2);
    }
}
