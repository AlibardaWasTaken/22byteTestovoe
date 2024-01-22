using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRotate : MonoBehaviour
{
    Tween _tween;
    void Start()
    {
        _tween = this.transform.DOLocalRotate(new Vector3(transform.rotation.x, 360f, transform.rotation.z), 10f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).SetId(1);
    }
    private void OnDestroy()
    {
        _tween.Kill();
    }
}
