using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectNode : MonoBehaviour
{
    public SpriteRenderer node;

    private Color selectedColor = Color.red;
    private Color defaultColor = Color.white;
    private Color AdjacentColor = Color.blue;
    private Color PassedColor = Color.green;

    private GameObject selectedNode;
    private GameObject map;

    void Start() {

        node = GetComponent<SpriteRenderer>();
        map = GameObject.Find("Main Camera");
    }

    void Update() {

        selectedNode = GameObject.FindGameObjectWithTag("SelectedNode");

        if(this.tag == "SelectedNode") {
            node.color = selectedColor;
        }
        else if(this.tag == "Node") {
            node.color = defaultColor;
        }
        else if(this.tag == "AdjacentNode") {
            node.color = AdjacentColor;
        }
        else if(this.tag == "PassedNode") {
            node.color = PassedColor;
        }
    }

    void OnMouseDown() {

        int PathNodeCount = map.GetComponent<PathNodes>().getPathCount();
        LineController[] allEdges = FindObjectsOfType<LineController>();

        if(this.tag == "Node" && PathNodeCount < 1) {
            
            map.GetComponent<GraphBuilder>().setAdjacent(this.gameObject);
            resetAllNodes();
            
            this.transform.gameObject.tag = "SelectedNode";

            if(selectedNode != null) 
                selectedNode.gameObject.tag = "Node";

        }
        else if(this.tag == "SelectedNode" && PathNodeCount < 1) {
            resetAllNodes();
        }
        else if(this.tag == "AdjacentNode") {

            GameObject selectedNode = GameObject.FindGameObjectWithTag("SelectedNode");

            map.GetComponent<PathNodes>().savePath(selectedNode);

            foreach(LineController edge in allEdges)
            {
                edge.GetComponent<LineController>().changeEdge(selectedNode.transform, this.transform);
            }

            selectedNode.tag = "PassedNode";
            resetAllNodes();

            this.transform.gameObject.tag = "SelectedNode";
            map.GetComponent<GraphBuilder>().setAdjacent(this.gameObject);
        }
        else if(this.tag == "PassedNode") {
            GameObject selectedNode = GameObject.FindGameObjectWithTag("SelectedNode");
            SelectNode[] allNodes = FindObjectsOfType<SelectNode>();

            bool isAdjacent = false;
            bool isAllPassed = true;
            bool isFirstElement = map.GetComponent<PathNodes>().verifyFirstElement(this.gameObject);
            
            foreach(LineController edge in allEdges)
            {
                if(selectedNode != null) {
                    if(edge.GetComponent<LineController>().verfyIsAdjacent(this.transform, selectedNode.transform))
                        isAdjacent = true;            
                }
            }

            for(int i = 0; i < allNodes.Length; i++) {

                if(allNodes[i].gameObject.tag == "Node") {
                    isAllPassed = false;
                }
            }

            if(isFirstElement == true && isAdjacent == true && isAllPassed == true) {
                
                selectedNode.tag = "PassedNode";

                foreach(LineController edge in allEdges)
                {
                    edge.GetComponent<LineController>().changeEdge(selectedNode.transform, this.transform);
                }
               
                switch (SceneManager.GetActiveScene().name)
                {
                    case "Level_1":
                        SaveLevels.Level_1 = true;
                        break;
                    case "Level_2":
                        SaveLevels.Level_2 = true;
                        break;
                    case "Level_3":
                        SaveLevels.Level_3 = true;
                        break;
                }
            }
        }
    }

    private void resetAllNodes() {

        SelectNode[] allNodes = FindObjectsOfType<SelectNode>();

        for(int i = 0; i < allNodes.Length; i++) {
            if(allNodes[i].gameObject.tag != "PassedNode")
            allNodes[i].gameObject.tag = "Node";
        }
    }

    public void resetNode() {
        this.tag = "Node";
    }
}
