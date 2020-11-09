using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KingMovment : MonoBehaviour, IPieceMovement
{
    private bool isChecking = false;
    public bool isChceked(Tile address, Col color)
    {
        //Debug.Log(Board._instance.GetComponentsInChildren<Piece>().Length);
        foreach(Piece p in Board._instance.GetComponentsInChildren<Piece>().Where((p) => p != GetComponent<Piece>()))
        {
            Tile[] possibleMoves;
            if (p._movement is KingMovment)
            {
                possibleMoves = ((KingMovment) p._movement).CalculatePossibleMovesWithChecks(p._currentTile, p.color);
            }
            else if(p._movement is PawnMovement)
            {
                possibleMoves = ((PawnMovement)p._movement).CalculatePossibleAttacks(p._currentTile, p.color);
                //Debug.Log(possibleMoves[0] + " " + possibleMoves[1]);
            }
            else
            {
                possibleMoves = p._movement.CalculatePossibleMoves(p._currentTile, p.color);
            }
            foreach (Tile t in possibleMoves)
            {

                //Debug.Log(t.address+" "+ address.address + " "+(address.address.Item1 == t.address.Item1) + (address.address.Item2 == t.address.Item2) + (p.color != color));
                if(address.address.Item1 == t.address.Item1 && address.address.Item2 == t.address.Item2 && p.color != color)
                {
                    //Debug.Log(p._movement.ToString() + " " + p._currentTile.address);
                    return true;
                }
            }            

        }
        return false;
    }

    public Tile[] CalculatePossibleMoves(Tile address, Col color)
    {


        Tile[] ret = CalculatePossibleMovesWithChecks(address, color);


        //delete tiles which are checked from array
        ret = ret.Where((tile) => isChceked(tile, color) != true).ToArray();

        //Debug.Log(S + ret.Length);
        return ret;

    }


    private Tile[] CalculatePossibleMovesWithChecks(Tile address, Col color)
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


        //Debug.Log(S + ret.Length);
        return ret;
    }


    private void Update()
    {
        //Piece p = GetComponent<Piece>();
        //Debug.Log(p.color + " " + isChceked(p._currentTile, p.color) + " " + p._currentTile.address);
    }
}
