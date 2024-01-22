using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControl : MonoBehaviour
{
    public static UIControl Instance;

    [SerializeField]
    private TextMeshProUGUI _fruitCollected;

    [SerializeField]
    private TextMeshProUGUI _lvl;

    private GameObject _hiddenButton;

    public MeshFilter SelectedMesh;

    [SerializeField]
    private GameObject _loseScreen;

    [SerializeField]
    private GameObject _winScreen;

    void Awake()
    {
        if (Instance != null) { Destroy(this); return; }

        Instance = this;

        _winScreen.SetActive(false);
        _loseScreen.SetActive(false);
    }

    public void SetLvl(int lvl)
    {
        _lvl.text = "Lvl " + lvl;
    }


    public void RefreshFruits()
    {
        _fruitCollected.text = string.Format("{0}/{1}", FruitCollectControl.Instance.FruitCollected, FruitCollectControl.Instance.FruitReq);
    }

    public void HideButton(GameObject buttonobj)
    {
        if (_hiddenButton != null)
            _hiddenButton.SetActive(true);

        _hiddenButton = buttonobj;
        _hiddenButton.SetActive(false);
        SelectedMesh.mesh = buttonobj.transform.GetChild(0).GetComponent<MeshFilter>().mesh;
        SelectedMesh.transform.localScale = buttonobj.transform.GetChild(0).transform.localScale;

    }



    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ToReward()
    {
        SceneManager.LoadScene(2);
    }

    public void EnableLoseScreen()
    {
        _loseScreen.SetActive(true);
    }

    public void EnableWinScreen()
    {
        _winScreen.SetActive(true);
    }



    public void RequestIdSelectedChange(int id)
    {
        FruitCollectControl.Instance.ChangeSelected(id);
    }

}
