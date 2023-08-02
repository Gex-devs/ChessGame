using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Highlight()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void RemoveHighlight()
    {
        GetComponent<Renderer>().material.color = new Color(255,255,255,98);
    }
}
