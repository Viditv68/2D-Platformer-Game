﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class LevelLoader : MonoBehaviour
{
    private Button button;
    public string levelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(LoadLevel);
    }


    private void Start()
    {
        if(LevelManager.Instance.GetLevelStatus(levelName) == LevelStatus.Locked)
        {
            button.GetComponentInChildren<Text>().text = "Unlocked";
        }

        else if(LevelManager.Instance.GetLevelStatus(levelName) == LevelStatus.Unlocked)
        {
            button.GetComponentInChildren<Text>().text = levelName;
        }    
    }

    private void LoadLevel()
    {
        LevelStatus levelStatus = LevelManager.Instance.GetLevelStatus(levelName);
        switch (levelStatus)
        {
            case LevelStatus.Locked:
                Debug.Log("Level is locked");
                break;

            case LevelStatus.Unlocked:
                SceneManager.LoadScene(levelName);
                break;

            case LevelStatus.Completed:
                SceneManager.LoadScene(levelName);
                break;

        }

        
    }
}