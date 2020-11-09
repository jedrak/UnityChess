using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile address, Col color)
    {
        Tile[] upleft = Board.RayCast(address, Vector2Int.up + Vector2Int.left, 8, color);
        Tile[] upright = Board.RayCast(address, Vector2Int.up + Vector2Int.right, 8, color);
        Tile[] downright = Board.RayCast(address, Vector2Int.down + Vector2Int.right, 8, color);
        Tile[] downleft = Board.RayCast(address, Vector2Int.down + Vector2Int.left, 8, color);

        Tile[] ret = new Tile[upleft.Length + upright.Length + downright.Length + downleft.Length];
        upleft.CopyTo(ret, 0);
        upright.CopyTo(ret, upleft.Length);
        downright.CopyTo(ret, upleft.Length + upright.Length);
        downleft.CopyTo(ret, upleft.Length + upright.Length + downright.Length);
        string S = "";

        foreach (Tile t in downright)
        {
            S += t.address.ToString() + " ";

        }
        //Debug.Log(S + ret.Length);

        return ret;
    }
}
