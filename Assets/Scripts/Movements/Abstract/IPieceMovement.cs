using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IPieceMovement
{
    Tile[] CalculatePossibleMoves(Tile address, Col color);

    

}
