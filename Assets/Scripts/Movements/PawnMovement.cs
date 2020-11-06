using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnMovement : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile address)
    {
        Tile[] ret;
        if (address.address.Item2 != 2 && address.address.Item2 != 7)
        {
            ret = Board.RayCast(address, Vector2Int.up, 2);

        }
        else
        {
            ret = Board.RayCast(address, Vector2Int.up, 3);
        }

        return ret;
    }

}
