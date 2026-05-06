using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public float timeToBreak = 2;
    private float timer = 0;
    public List<GameObject> breakablePieces;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach (var piece in breakablePieces) { 
        
            piece.SetActive(false);
        }
    }

  public void Break()
    {
        timer += Time.deltaTime;
        if (timer > timeToBreak) {
            foreach (var piece in breakablePieces)
            {
                piece.SetActive(true);
                piece.transform.parent = null;
            }

            gameObject.SetActive(false);  //This is for the Bigger Stone
        }
    }
}
