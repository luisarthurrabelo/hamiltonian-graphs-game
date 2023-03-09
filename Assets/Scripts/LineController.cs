using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer lr;
    private List<Transform> nodes = new List<Transform>();

    public Color passColor;
    public Color defaultColor;

    private void Awake() {

        lr = GetComponent<LineRenderer>();

        passColor = Color.yellow;
        defaultColor = Color.white;
    }

    public void SetUpLine(Transform node1, Transform node2) {

        lr.positionCount = 2;

        nodes.Add(node1);
        nodes.Add(node2);   
    }

    private void Update() {

        for(int i = 0; i < nodes.Count; i++) {
            lr.SetPosition(i, nodes[i].position);
        }
    }

    public void changeEdge(Transform node1, Transform node2) {

        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(passColor, 0.0f), new GradientColorKey(passColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
        );

        if(verfyIsAdjacent(node1, node2))
            lr.colorGradient = gradient;
    }

    public bool verfyIsAdjacent(Transform node1, Transform node2) {

        if(nodes[0] == node1 && nodes[1] == node2)
            return true;

        else if(nodes[0] == node2 && nodes[1] == node1)
            return true;
        else 
            return false;
        
    }

    public void resetEdge() {
        Gradient gradient = new Gradient();

        gradient.SetKeys(
            new GradientColorKey[] { new GradientColorKey(defaultColor, 0.0f), new GradientColorKey(defaultColor, 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(1.0f, 0.0f), new GradientAlphaKey(1.0f, 1.0f) }
        );
        
        lr.colorGradient = gradient;
    }
}
