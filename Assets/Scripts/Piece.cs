using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private Board _board;
    private Tile _currentTile;
    private Tile _startingTile;
    private bool _pickedUp = false;

    private void Start()
    {
        _board = Board._instance;
        //_startingTile = Board._instance.GetTiles()[0];
        _currentTile = _startingTile;
    }

    private void OnMouseDrag()
    {
        _pickedUp = true;
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseUp()
    {
        _pickedUp = false;
        float distance = 1.0f;
        foreach(Tile t in Board._instance.GetTiles())
        {
            if (Vector3.Distance(transform.position, t.transform.position) < distance)
            {
                distance = Vector3.Distance(transform.position, t.transform.position);
                _currentTile = t;
            }
        }

    }

    private void Update()
    {
        if (!_pickedUp && _currentTile != null) transform.position = _currentTile.transform.position;
    }
}
