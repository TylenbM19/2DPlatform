using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawning : MonoBehaviour
{
    [SerializeField] private Transform[] _point;
    [SerializeField] private GameObject _object;

    private void Awake ()
    {
        CreateObject();
    }

    private void CreateObject()
    {
        for(int i = 0; i < _point.Length; i++)
        {
            Instantiate(_object, _point[i].position, _point[i].rotation);
        }
    }
}
