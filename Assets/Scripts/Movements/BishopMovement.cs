using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BishopMovement : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tuple<char, int> address)
    {
        List<Tile> ret = new List<Tile>();
        //Debug.Log(("" + address.Item1 + (address.Item2 + 1)).Length);


        //TODO optimize
        for (int i = -8; i <= 8; i++)
        {
            for (int j = -8; j <= 8; j++)
            {
                Tile t = Board._instance.GetTile((char)(address.Item1 + i), (address.Item2 + j));
                if (t != null)
                {
                    if ((i == j || i == -j) && (i != 0 || j != 0)) ret.Add(t);
                }

            }
        }

        return ret.ToArray();
    }
}
