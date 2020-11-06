using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Col
{
    Black,
    White
}

public class Piece : MonoBehaviour
{
    private Board _board;
    private Tile _currentTile;
    public string StartingTile = "a1";
    
    private bool _pickedUp = false;
    private IPieceMovement _movement;
    public Col color;

    private void Start()
    {
        _board = Board._instance;
        _currentTile = Board._instance.GetTile(StartingTile);
        
        _currentTile.onTheBoard = this;
        transform.position = _currentTile.transform.position;
        _movement = GetComponent<IPieceMovement>();


    }


    private void OnMouseDown()
    {
        if(color == Board._instance.Turn)
        {
            _pickedUp = true;
            _currentTile.onTheBoard = null;

            foreach (Tile t in _movement.CalculatePossibleMoves(_currentTile, color))
            {
                if(t != null)
                {
                    t._dot.SetActive(true);
                }
                    
            }
        }


    }

    private void OnMouseDrag()
    {
        if(_pickedUp) transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
    }

    private void OnMouseUp()
    {
        if (color == Board._instance.Turn)
        {
            _pickedUp = false;
            Tile before = _currentTile;
            float distance = .5f;
            foreach(Tile t in _movement.CalculatePossibleMoves(_currentTile, color))
            {
                if(t != null)
                {
                    if (Vector3.Distance(transform.position, t.transform.position) < distance)
                    {
                        distance = Vector3.Distance(transform.position, t.transform.position);
                        _currentTile = t;
                        
                    }
                    t._dot.SetActive(false);
                
                }

            }
            
            if(_currentTile.onTheBoard != null) Destroy(_currentTile.onTheBoard.gameObject);
            _currentTile.onTheBoard = this;
            if (before != _currentTile)
            {
                switch (Board._instance.Turn)
                {
                    case Col.White:
                        Board._instance.Turn = Col.Black;
                        break;
                    case Col.Black:
                        Board._instance.Turn = Col.White;
                        break;
                }
            }


            
        }
       
    }

    private void Update()
    {
        if (!_pickedUp && _currentTile != null) transform.position = _currentTile.transform.position;
    }
}
