using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile address)
    {
        Tile[] upleft = Board.RayCast(address, Vector2Int.up + Vector2Int.left, 8);
        Tile[] upright = Board.RayCast(address, Vector2Int.up + Vector2Int.right, 8);
        Tile[] downright = Board.RayCast(address, Vector2Int.down + Vector2Int.right, 8);
        Tile[] downleft = Board.RayCast(address, Vector2Int.down + Vector2Int.left, 8);

        Tile[] ret = new Tile[upleft.Length + upright.Length + downright.Length + downleft.Length];
        upleft.CopyTo(ret, 0);
        upright.CopyTo(ret, upleft.Length);
        downright.CopyTo(ret, upleft.Length + upright.Length);
        downleft.CopyTo(ret, upleft.Length + upright.Length + downright.Length);


        return ret;
    }
}
