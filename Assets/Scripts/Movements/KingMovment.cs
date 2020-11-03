using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingMovment : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(System.Tuple<char, int> address)
    {
        List<Tile> ret = new List<Tile>();
        //Debug.Log(("" + address.Item1 + (address.Item2 + 1)).Length);



        for(int i = -1; i <= 1; i++)
        {
            for(int j = -1; j <= 1; j++)
            {
                Tile t = Board._instance.GetTile((char)(address.Item1 + i), (address.Item2 + j));
                if(t != null)
                {
                    if(i != 0 || j != 0) ret.Add(t);
                }
                
            }
        }

        return ret.ToArray();

    }
}
