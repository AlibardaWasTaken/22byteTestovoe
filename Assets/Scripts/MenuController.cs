using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private int _money;
    [SerializeField]
    private TextMeshProUGUI _moneyText;
    public int Money { get => _money; }

    public static MenuController Instance;

    [SerializeField]
    private LevelHolder[] _holders;

    [SerializeField]
    private int _amountUnlocked;

    public void Awake()
    {
        if (Instance != null) Destroy(this);

        Instance = this;

        _money = PlayerPrefs.GetInt("Money") + 999;
        _moneyText.text = _money.ToString() + "$";

        _amountUnlocked = PlayerPrefs.GetInt("LvlUnlocked");

        for (int i = 0; i < _amountUnlocked+1; i++)
        {
            _holders[i].Unlock();
        }
    }

    public bool CanSpendMoney(int amount)
    {
        if (_money >= amount) return true;

        return false;
    }


    public void SpendMoney(int amount)
    {
        _money -= amount;
        _moneyText.text = _money.ToString() + "$";
        PlayerPrefs.SetInt("Money", _money);
    }

    public void AddUnlockedLvl()
    {
        _amountUnlocked++;
        PlayerPrefs.SetInt("LvlUnlocked", _amountUnlocked);
    }

    public bool IsPrevUnlocked(int lvl)
    {
        if (_holders[lvl - 1] != null)
        {
            if (_holders[lvl - 1].IsUnlocked == true) return true;

            return false;
        }
        return true;

    }

}
