using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess;
public class ChessManager : MonoBehaviour
{
    private bool isTileSelected = false;
    private Vector3 selectedTilePosition;
    private string TheMove;

    private ChessBoard chess;
    // Start is called before the first frame update
    void Start()
    {
        chess = new ChessBoard();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {

                Collider thesomething = hit.collider;
                Debug.Log(thesomething.gameObject.name);
                // Check if a chessboard tile is clicked
                ChessTile clickedTile = hit.collider.GetComponent<ChessTile>();

                if (clickedTile != null)
                {
                    Debug.Log("Hit a tile");
                    if (!isTileSelected)
                    {
                        // First tile is selected
                        isTileSelected = true;
                        selectedTilePosition = clickedTile.transform.position;
                        clickedTile.Highlight(); // Visual feedback
                        string pos = clickedTile.gameObject.name;
                        TheMove += pos;
                        // Store the selected tile's position or handle move logic directly here
                    }
                    else
                    {
                        // Second tile is selected
                        isTileSelected = false;
                        clickedTile.Highlight(); // Visual feedback
                        string pos = clickedTile.gameObject.name;
                        TheMove += pos;
                        
                        // Check if the move is valid and perform the move logic here
                        bool isValidMove = chess.IsValidMove(TheMove);
                        chess.Move(TheMove);
                        Debug.Log(chess.ToAscii());

                        if (isValidMove)
                        {
                            Debug.Log("Move is valid");
                            // Perform the move logic
                            chess.Move(TheMove);
                            Debug.Log(chess.ToAscii());
                        }
                        else
                        {
                            Debug.Log("Move invalid");
                            Debug.Log("The Move: " + TheMove);
                            // Invalid move, handle accordingly (e.g., show an error message)
                        }
                    }
                }
            }
        }
    }


    private void OnAnimatorMove()
    {
        if (isTileSelected)
        {

        }
    }
}
