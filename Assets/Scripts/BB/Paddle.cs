using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Paddle : MonoBehaviour
{

    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float minY = 1f;
    [SerializeField] float maxY = 17f;
    [SerializeField] float screenWidthInUnits = 16f;
 
    
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        if(tag == "Horizontal")
        {
            paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
            transform.position = paddlePos;
        }

        else if(tag == "Vertical")
        {
            paddlePos.y = Mathf.Clamp(GetYPos(), minY, maxY);
            transform.position = paddlePos;
        }
        
    }

    private float GetXPos()
    {
        if(FindObjectOfType<GameState>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.x;
        }
        else{
            return Input.mousePosition.x / (Screen.width) * screenWidthInUnits;
        }
    }

    private float GetYPos()
    {
        if(FindObjectOfType<GameState>().IsAutoPlayEnabled())
        {
            return FindObjectOfType<Ball>().transform.position.y;
        }
        else{
            return Input.mousePosition.y / (Screen.height) * screenWidthInUnits;
        }
    }
}
