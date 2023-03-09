using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNodes : MonoBehaviour
{
    private List<GameObject> nodePath = new List<GameObject>();

    public void savePath(GameObject node) {
        nodePath.Add(node);
    }

    public int getPathCount() {
        return nodePath.Count;
    }

    public bool verifyFirstElement(GameObject node) {
        
        if(node == nodePath[0]) {
            return true;
        }
        else {
            return false;
        }
    }

    public void resetPath() {

        nodePath.Clear();
        SelectNode[] allNodes = FindObjectsOfType<SelectNode>();
        LineController[] allEdges = FindObjectsOfType<LineController>();

        for(int i = 0; i < allNodes.Length; i++) {
            allNodes[i].GetComponent<SelectNode>().resetNode();
        }

        foreach(LineController edge in allEdges) {
            edge.GetComponent<LineController>().resetEdge();
        }
    }
}
