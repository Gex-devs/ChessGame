using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chess;
using Assets;

public class ChessManager : MonoBehaviour
{
    private bool isTileSelected = false;
    private string TheMove;
    private playerEnum CurrentPlayer = playerEnum.White;
    private ChessBoard chess;

    public ChessTile firstSelectedTile { get; private set; }
    public ChessTile SecondSelectedTile { get; private set; }

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

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Collider2D thesomething = hit.collider;
                
                
                Debug.Log(thesomething.gameObject.name);
                // Check if a chessboard tile is clicked
                ChessTile clickedTile = hit.collider.GetComponent<ChessTile>();


                if (clickedTile != null)
                {
                    if (!CheckIfCanSelectTile(clickedTile))
                    {
                        return;
                    }

                    if (!isTileSelected)
                    {
                        Debug.Log("first tile selected");

                        // First tile is selected
                        firstSelectedTile = clickedTile;
                        isTileSelected = true;
                        clickedTile.Highlight(); // Visual feedback
                        string pos = clickedTile.gameObject.name;
                        TheMove += pos;
                        // Store the selected tile's position or handle move logic directly here
                    }
                    else
                    {
                        // Second tile is selected
                        isTileSelected = false;
                        SecondSelectedTile = clickedTile;
                        string pos = clickedTile.gameObject.name;
                        TheMove += pos;
                        CurrentPlayer = (CurrentPlayer == playerEnum.White) ? playerEnum.Black : playerEnum.White;
                        // Check if the move is valid and perform the move logic here
                        bool isValidMove = chess.IsValidMove(TheMove);

                        if (isValidMove)
                        {
                            Debug.Log("Move is valid");
                            // Perform the move logic
                            MovePiece(TheMove);
                            
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
    private bool CheckIfCanSelectTile(ChessTile tile)
    {

        Collider2D Piece = isPieceOverlapping(tile);

        if (Piece != null)
        {
            return true;

        }

        if (isTileSelected)
        {
            return true;
        }


        return false;
    }
    private Collider2D isPieceOverlapping(ChessTile tile)
    {
        Collider2D[] overlappedColliders = Physics2D.OverlapCircleAll(tile.transform.position, 1f);

        // Loop through the colliders and check if they have any of the specified tags
        foreach (Collider2D collider in overlappedColliders)
        {
            Debug.Log(collider.gameObject.name);
            // Check if the collider's game object has any of the specified tags
            if (collider.gameObject.tag == "pieces")
            {
                // Do something with the overlapped object (e.g., access its properties or call methods)
                Debug.Log("Overlapped object with tag: " + collider.gameObject.tag);

                return collider;

            }
        }

        return null;
    }
    private void MovePiece(string move)
    {
        chess.Move(move);



        Collider2D Piece = isPieceOverlapping(firstSelectedTile);

        Collider2D SecondPiece = isPieceOverlapping(SecondSelectedTile);

        if (Piece != null)
        {
            Piece.gameObject.transform.position = SecondSelectedTile.transform.position;


            if (SecondPiece != null)
            {
                Destroy(SecondPiece.gameObject);
            }
        }

        ClearAllForNextMove();
    }

    private void ClearAllForNextMove()
    {
        TheMove = string.Empty;
        isTileSelected = false;
        ClearHighlights();
        firstSelectedTile = null;
        SecondSelectedTile = null;
    }

    private void ClearHighlights()
    {
        firstSelectedTile.RemoveHighlight();
        SecondSelectedTile.RemoveHighlight();
    }

  
}
