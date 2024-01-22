using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RollController : MonoBehaviour
{

    public Dictionary<int, Mesh> MeshDictionary = new Dictionary<int, Mesh>();

    [SerializeField]
    private int _money;
    [SerializeField]
    private TextMeshProUGUI _moneyText;
    public int Money { get => _money; }
    public bool IsLocked { get => isLocked; }

    public static RollController Instance;

    [SerializeField]
    private RollSlot[] Rollbuttons;

    [SerializeField]
    private Mesh _firstMesh;

    [SerializeField]
    private Mesh _secMesh;


    [SerializeField]
    private Mesh _thirdMesh;

    [SerializeField]
    private bool isLocked = false;

    [SerializeField]
    private GameObject continueButton;

    private int _numPicked;
    private int _firstPicked = -1;

    public void Awake()
    {
        if (Instance != null) { Destroy(this); return; }
        Instance = this;

        _money = Random.Range(5, 8);
        _moneyText.text = string.Format("+{0}$", _money);

        

        MeshDictionary.Add(0, _firstMesh);
        MeshDictionary.Add(1, _secMesh);
        MeshDictionary.Add(2, _thirdMesh);

        ShuffleArray();

        
        for (int i = 0; i < 3; i++)
        {
            Rollbuttons[i].SetID(0);
        }
        for (int i = 3; i < 6; i++)
        {
            Rollbuttons[i].SetID(1);
        }
        for (int i = 6; i < 9; i++)
        {
            Rollbuttons[i].SetID(2);
        }

    }


    internal void CheckReveal(int id)
    {
        if (_firstPicked == -1) { _firstPicked = id; _numPicked++; return; }

        if (_firstPicked != id) { Lose(); return; };

        _numPicked++;

        if (_numPicked >= 3)
            Win();

    }

    private void Lose()
    {
        isLocked = true;
        continueButton.SetActive(true);
    }

    private void Win()
    {
        isLocked = true;
        _money += Random.Range(5, 11);
        _moneyText.text = string.Format("+{0}$", _money);
        continueButton.SetActive(true);

    }

    public void Process()
    {
        PlayerPrefs.SetInt("Money", _money);
        SceneManager.LoadScene(0);
    }

    private void ShuffleArray()
    {
        int n = Rollbuttons.Length;
        System.Random rng = new System.Random();

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            var temp = Rollbuttons[k];
            Rollbuttons[k] = Rollbuttons[n];
            Rollbuttons[n] = temp;
        }
    }






}
