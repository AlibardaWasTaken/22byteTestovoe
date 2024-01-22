using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInitiator : MonoBehaviour
{
    public static LevelInitiator Instance;

    public Level[] Levels;

    private int _sceneloading;
    void Awake()
    {
        if (Instance != null) { Destroy(this); return; }

        Instance = this;

        DontDestroyOnLoad(this.gameObject);

    }

    public void LoadLevel(int num)
    {
        _sceneloading = num;
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        LevelControl.Instance.Init(Levels[_sceneloading].Lvltime, Levels[_sceneloading].FruitReq, _sceneloading + 1, Levels[_sceneloading].Prefabs);
    }
}

[Serializable]
public class Level
{
    public float Lvltime;
    public int FruitReq;
    public GameObject[] Prefabs;
    //public int[] UsedIds;
}
