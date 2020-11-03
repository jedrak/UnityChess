using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPieceMovement
{
    Tile[] CalculatePossibleMoves(System.Tuple<char, int> address);

}
