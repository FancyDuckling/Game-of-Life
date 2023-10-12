using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ändrat 12/10-2023
public class Cell : MonoBehaviour
{
    public Color deadColor;
    public Color aliveColor;
    public SpriteRenderer spriteRenderer;
    public bool isAliveInNextGeneration;
    public bool isAlive;

    public void Init(bool isAlive)
    {
        this.isAlive = isAlive;
        this.isAliveInNextGeneration = isAlive;

        if (isAlive == true)
        {
            spriteRenderer.color = aliveColor;
        }
        else
        {
            spriteRenderer.color = deadColor;
        }
    }

    public bool IsAlive()
    {
        return isAlive;
    }

    public void SetNextGenerationState(bool isAlive)
    {
        isAliveInNextGeneration = isAlive;
    }

    public void ApplyNextGenerationState()
    {
        isAlive = isAliveInNextGeneration;

        if (isAlive)
        {
            spriteRenderer.color = aliveColor;
        }
        else
        {
            spriteRenderer.color = deadColor;
        }
    }
}
