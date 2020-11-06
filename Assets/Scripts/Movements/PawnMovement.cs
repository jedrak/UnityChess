using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile address)
    {

        Tile[] up;
        if (address.address.Item2 != 2 && address.address.Item2 != 7)
        {
            up = Board.RayCast(address, Vector2Int.up, 2);

        }
        else
        {
            up = Board.RayCast(address, Vector2Int.up, 3);
        }
        Tile[] upleft;// Board.RayCast(address, Vector2Int.up + Vector2Int.left, 2);
        Tile [] upright; //Board.RayCast(address, Vector2Int.up + Vector2Int.right, 2);
        Tile [] buff = Board.RayCast(address, Vector2Int.up + Vector2Int.left, 2);
        if (buff[0].Taken)
        {
            upleft = new Tile[1];
            buff.CopyTo(upleft, 0);
        }
        else
        {
            upleft = new Tile[0];
        }

        buff = Board.RayCast(address, Vector2Int.up + Vector2Int.right, 2);
        if (buff[0].Taken)
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
