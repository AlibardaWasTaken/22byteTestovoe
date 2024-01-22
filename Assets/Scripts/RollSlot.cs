using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollSlot : MonoBehaviour
{
    private int _id;

    private bool _hidden = false;

    [SerializeField]
    private GameObject _revealObj;

    [SerializeField]
    private MeshFilter _meshRenderer;


    public void SetID(int id)
    {
        _id = id;
        _meshRenderer.mesh = RollController.Instance.MeshDictionary[_id];
    }


    public void Reveal()
    {
        if (RollController.Instance.IsLocked == true || _hidden == true) return;

        _hidden = true;

        RollController.Instance.CheckReveal(_id);
        _revealObj.SetActive(true);
        
    }
}
