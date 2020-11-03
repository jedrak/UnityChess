﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private Board _board;
    private Tile _currentTile;
    public string StartingTile = "a1";
    private bool _pickedUp = false;
    private IPieceMovement _movement;

    private void Start()
    {
        _board = Board._instance;
        // _startingTile = Board._instance.GetTiles()[0];
        //Debug.Log(StartingTile);
        //Debug.Log(Board._instance.GetTile(StartingTile));
        _currentTile = Board._instance.GetTile(StartingTile);
        transform.position = _currentTile.transform.position;
        _movement = GetComponent<IPieceMovement>();

    }


    private void OnMouseDown()
    {
        _pickedUp = true;
        foreach(Tile t in _movement.CalculatePossibleMoves(_currentTile.address))
        {
            t._dot.SetActive(true);
        }
    }

    private void OnMouseDrag()
    {


        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseUp()
    {
        _pickedUp = false;
        float distance = .5f;
        foreach(Tile t in _movement.CalculatePossibleMoves(_currentTile.address))
        {
            if (Vector3.Distance(transform.position, t.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, t.transform.position);
                _currentTile = t;
            }
            t._dot.SetActive(false);
        }
        //Debug.Log(_currentTile.address);
    }

    private void Update()
    {
        if (!_pickedUp && _currentTile != null) transform.position = _currentTile.transform.position;
    }
}
