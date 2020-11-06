using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueensMovement : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile address)
    {

        //should problably use rock and bisho movement to calculate this
        Tile[] up = Board.RayCast(address, Vector2Int.up, 8);
        Tile[] down = Board.RayCast(address, Vector2Int.down, 8);
        Tile[] left = Board.RayCast(address, Vector2Int.left, 8);
        Tile[] right = Board.RayCast(address, Vector2Int.right, 8);

        Tile[] upleft = Board.RayCast(address, Vector2Int.up + Vector2Int.left, 8);
        Tile[] upright = Board.RayCast(address, Vector2Int.up + Vector2Int.right, 8);
        Tile[] downright = Board.RayCast(address, Vector2Int.down + Vector2Int.right, 8);
        Tile[] downleft = Board.RayCast(address, Vector2Int.down + Vector2Int.left, 8);

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
