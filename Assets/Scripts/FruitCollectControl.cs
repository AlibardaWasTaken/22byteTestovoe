using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollectControl : MonoBehaviour
{
    public static FruitCollectControl Instance;

    private int _fruitCollected = 0;
    public int FruitReq = 11;

    public int SelectedBucketId;

    public int FruitCollected { get => _fruitCollected; }
    public int SelectedId { get => _selectedId; }

    private int _selectedId = -1;

    void Awake()
    {
        if (Instance != null) Destroy(this);

        Instance = this;

    }


    public void ChangeSelected(int id)
    {
        _selectedId = id;
    }

    public void CollectFruit(int id)
    {
        if(_selectedId != id) { LevelControl.Instance.EndGame(); return; }

        _fruitCollected++;
        UIControl.Instance.RefreshFruits();
        if (_fruitCollected >= FruitReq) LevelControl.Instance.WinGame();
    }
}
