using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneSwitch : MonoBehaviour
{
    private GameObject map;
    private Button nextLevelButton;

    void Start() {
        map = GameObject.Find("Main Camera");
        nextLevelButton = GameObject.Find("NextLevelButton").GetComponent<Button>();
    }

    void Update() {
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "Level_1":
                if(SaveLevels.Level_1 == true) {
                    nextLevelButton.tag = "UnlockedButton";
                }
                break;
            case "Level_2":
                if(SaveLevels.Level_2 == true) {
                    nextLevelButton.tag = "UnlockedButton";
                }
                break;
            case "Level_3":
                if(SaveLevels.Level_3 == true) {
                    nextLevelButton.tag = "UnlockedButton";
                }
                break;
        }

        if(nextLevelButton.tag == "LockedButton") {
            nextLevelButton.interactable = false;
        }
        else {
            nextLevelButton.interactable = true;
        }
    }

    public void nextLevel() {           
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);         
    }

    public void backLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1); 
    }
}

