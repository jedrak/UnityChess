using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour,  IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile address)
    {
        Tile[] up = Board.RayCast(address, Vector2Int.up, 8);
        Tile[] down = Board.RayCast(address, Vector2Int.down, 8);
        Tile[] left = Board.RayCast(address, Vector2Int.left, 8);
        Tile[] right = Board.RayCast(address, Vector2Int.right, 8);
        Tile[] ret = new Tile[up.Length + down.Length + left.Length + right.Length];
        up.CopyTo(ret, 0);
        down.CopyTo(ret, up.Length);
        left.CopyTo(ret, up.Length + down.Length);
        right.CopyTo(ret, up.Length + down.Length + left.Length);

        return ret;
    }

}
