using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour, IPieceMovement
{
    public int dir = 1;
    private Piece piece;

    public Tile[] CalculatePossibleAttacks(Tile address, Col color)
    {
        Tile[] upleft = Board.RayCast(address, dir * (Vector2Int.up + Vector2Int.left), 2, color);
        Tile[] upright = Board.RayCast(address, dir * (Vector2Int.up + Vector2Int.right), 2, color);
        Tile[] ret = new Tile[upleft.Length + upright.Length];
        upleft.CopyTo(ret, 0);upright.CopyTo(ret, upleft.Length);
        return ret;
    }

    public Tile[] CalculatePossibleMoves(Tile address, Col color)
    {
        Tile[] buff;
        Tile[] up;
        if (address.address.Item2 != 2 && address.address.Item2 != 7)
        {
            buff = Board.RayCast(address, dir * Vector2Int.up, 2, color);
            if (buff.Length != 0 && buff[0].onTheBoard == null) up = buff;
            else up = new Tile[0];

        }
        else
        {
            buff = Board.RayCast(address, dir * Vector2Int.up, 3, color);
            if (buff.Length != 0 && buff[0].onTheBoard == null) up = buff;
            else up = new Tile[0];
        }
        Tile[] upleft;
        Tile [] upright;
        buff = Board.RayCast(address, dir*(Vector2Int.up + Vector2Int.left), 2, color);
        if (buff.Length != 0 && buff[0].onTheBoard != null)
        {
            upleft = new Tile[1];
            buff.CopyTo(upleft, 0);
        }
        else
        {
            upleft = new Tile[0];
        }

        buff = Board.RayCast(address, dir * (Vector2Int.up + Vector2Int.right), 2, color);
        if (buff.Length != 0 && buff[0].onTheBoard != null)
        {
            upright = new Tile[1];
            buff.CopyTo(upright, 0);
        }
        else
        {
            upright = new Tile[0];
        }

        Tile[] ret = new Tile[up.Length + upleft.Length + upright.Length];
        up.CopyTo(ret, 0);
        upleft.CopyTo(ret, up.Length);
        upright.CopyTo(ret, up.Length + upleft.Length);

        return ret;
    }

}
