using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WCGameOver : MonoBehaviour
{
public void Reset(bool menu)
    {
        FindObjectOfType<GameStateWC>().ResetGame(menu);

    }
}
