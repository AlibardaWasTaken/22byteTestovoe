using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelControl : MonoBehaviour
{
    public static LevelControl Instance;
    private float _timeRemaining = 300f;

    private bool _inited;

    private bool _winLocked = false;
    void Awake()
    {
        if (Instance != null) { Destroy(this); return; }

        Instance = this;

        
    }


    public void Init(float time, int FruitReq, int level, GameObject[] Prefabs)
    {
        _timeRemaining = time;
        FruitCollectControl.Instance.FruitReq = FruitReq;
        _inited = true;

        UIControl.Instance.SetLvl(level);
        UIControl.Instance.RefreshFruits();

        foreach (var item in Prefabs)
        {
            GameObject.Instantiate(item);
        }



        //В случае если делаем рандомную раскидку фруктов
        //for (int i = 0; i < FruitReq; i++)
        //{
        //    var RandomNum = Random.Range(0, Prefabs.Length);
        //    var randomColumn = Random.Range((-GridGroundResizer.Instance.Colums + 1) / 2, (GridGroundResizer.Instance.Colums - 1) / 2);
        //    var randomRow = Random.Range((-GridGroundResizer.Instance.Rows + 1) / 2, (GridGroundResizer.Instance.Rows - 1)/2);

        //    GameObject.Instantiate(Prefabs[RandomNum], new Vector3(randomRow, Prefabs[RandomNum].transform.localPosition.y, randomColumn), Quaternion.identity);
        //}

    }


    void Update()
    {
        if (_inited == false) return;

        if (_timeRemaining > 0)
        {
            _timeRemaining -= Time.deltaTime;
            return;
        }
        EndGame();
    }


    public float GetTime()
    {
        return _timeRemaining;
    }

   public void EndGame()
    {
        if (_winLocked == true) return;
        Debug.Log("EG");
        UIControl.Instance.EnableLoseScreen();
        _winLocked = true;

    }

    public void WinGame()
    {
        if (_winLocked == true) return;

        UIControl.Instance.EnableWinScreen();
        _winLocked = true;

    }
}
