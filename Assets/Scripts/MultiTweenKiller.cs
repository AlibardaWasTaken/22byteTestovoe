using DG.Tweening;
using UnityEngine;

public class MultiTweenKiller : MonoBehaviour
{

    void OnDestroy()
    {
        DOTween.KillAll(complete: false, idsOrTargetsToExclude: "FadeOverlayTween");
    }


}