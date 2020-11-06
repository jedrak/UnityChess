using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : MonoBehaviour, IPieceMovement
{
    public Tile[] CalculatePossibleMoves(Tile t, Col color)
    {
        List<Tile> ret = new List<Tile>();

        char c = t.address.Item1;
        int i = t.address.Item2;

        Tile buff = Board._instance.GetTile((char)(c + 2), i + 1);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }
        buff = Board._instance.GetTile((char)(c + 2), i - 1);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }
        buff = Board._instance.GetTile((char)(c + 1), i + 2);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }
        buff = Board._instance.GetTile((char)(c + 1), i - 2);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }
        buff = Board._instance.GetTile((char)(c - 2), i + 1);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }
        buff = Board._instance.GetTile((char)(c - 2), i - 1);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }
        buff = Board._instance.GetTile((char)(c - 1), i + 2);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }
        buff = Board._instance.GetTile((char)(c - 1), i - 2);
        if (buff != null)
        {
            if (buff.onTheBoard == null) ret.Add(buff);
            else if (buff.onTheBoard.color != color) ret.Add(buff);
        }

        return ret.ToArray();
    }
}
