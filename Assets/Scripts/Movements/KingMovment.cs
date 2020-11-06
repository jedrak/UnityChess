﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovment : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile address, Col color)
    {
        Tile[] up = Board.RayCast(address, Vector2Int.up, 2, color);
        Tile[] down = Board.RayCast(address, Vector2Int.down, 2, color);
        Tile[] left = Board.RayCast(address, Vector2Int.left, 2, color);
        Tile[] right = Board.RayCast(address, Vector2Int.right, 2, color);

        Tile[] upleft = Board.RayCast(address, Vector2Int.up + Vector2Int.left, 2, color);
        Tile[] upright = Board.RayCast(address, Vector2Int.up + Vector2Int.right, 2, color);
        Tile[] downright = Board.RayCast(address, Vector2Int.down + Vector2Int.right, 2, color);
        Tile[] downleft = Board.RayCast(address, Vector2Int.down + Vector2Int.left, 2, color);

        Tile[] ret = new Tile[up.Length + down.Length + left.Length + right.Length + upleft.Length + upright.Length + downright.Length + downleft.Length];


        up.CopyTo(ret, 0);
        down.CopyTo(ret, up.Length);
        left.CopyTo(ret, up.Length + down.Length);
        right.CopyTo(ret, up.Length + down.Length + left.Length);
        upleft.CopyTo(ret, up.Length + down.Length + left.Length + right.Length);
        upright.CopyTo(ret, up.Length + down.Length + left.Length + right.Length + upleft.Length);
        downright.CopyTo(ret, up.Length + down.Length + left.Length + right.Length + upleft.Length + upright.Length);
        downleft.CopyTo(ret, up.Length + down.Length + left.Length + right.Length + upleft.Length + upright.Length + downright.Length);

        return ret;

    }
}
