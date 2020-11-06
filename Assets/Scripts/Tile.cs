using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Tuple<char, int> address;
    public bool Taken = false;
    [SerializeField] public GameObject _dot { get; private set; }
    private void Start()
    {
        _dot = GetComponentsInChildren<Transform>()[1].gameObject;
        _dot.SetActive(false);
    }
}
