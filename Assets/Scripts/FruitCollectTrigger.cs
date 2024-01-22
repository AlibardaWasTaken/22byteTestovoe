using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollectTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent<Fruit>(out var fruitcomp);
        if (fruitcomp != null)
        {
           FruitCollectControl.Instance.CollectFruit(fruitcomp.Id);
           Destroy(fruitcomp.gameObject);
        }
    }

}
