using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class h1_tile : MonoBehaviour 
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
        // Add your logic to highlight the tile here
        // For example, change the color or add some visual effect
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
