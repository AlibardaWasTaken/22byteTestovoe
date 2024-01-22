using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField]
    private int _id;

    public int Id { get => _id; }

    private void Start()
    {
        float x = Mathf.Round(transform.position.x);
        float y = Mathf.Round(transform.position.y);
        float z = Mathf.Round(transform.position.z);

        transform.position = new Vector3(x, y, z);
    }
}
