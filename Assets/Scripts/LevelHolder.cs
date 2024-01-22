using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelHolder : MonoBehaviour
{

    [SerializeField]
    private int _cost;
    [SerializeField]
    private int _level;
    [SerializeField]
    private bool _isUnlocked = false;


    [SerializeField]
    private TextMeshProUGUI _priceText;

    [SerializeField]
    private TextMeshProUGUI _leveltext;

    [SerializeField]
    private GameObject _lockObject;

    public bool IsUnlocked { get => _isUnlocked; }

    public void Start()
    {
        _lockObject.SetActive(!_isUnlocked);

        _priceText.text = _cost.ToString() +"$";
        _leveltext.text = "Level "+ (_level + 1).ToString();
    }


    public void Buy()
    {
        if (this._isUnlocked == true) return;
        if(MenuController.Instance.CanSpendMoney(_cost) && MenuController.Instance.IsPrevUnlocked(_level))
        {
            MenuController.Instance.SpendMoney(_cost);
            this.Unlock();
            MenuController.Instance.AddUnlockedLvl();
        }
    }


    public void InitLvl()
    {
        if (this._isUnlocked == false) return;

        LevelInitiator.Instance.LoadLevel(_level);

    } 


    public void Unlock()
    {
        Debug.Log("Unlocked");
        _isUnlocked = true;
        _lockObject.SetActive(false);
    }
}
