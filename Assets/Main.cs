using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess;

public class Main : MonoBehaviour
{
    private ChessBoard chess;
    // Start is called before the first frame update
    void Start()
    {
        chess = new ChessBoard();
        //s
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void MovePiece(string moveCmd) { 
    
        chess.Move(moveCmd);
    }
}
