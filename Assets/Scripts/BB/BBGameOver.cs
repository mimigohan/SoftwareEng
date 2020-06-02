using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBGameOver : MonoBehaviour
{
    public void Reset(bool menu)
    {
        FindObjectOfType<GameState>().ResetGame(menu);
    }
}
