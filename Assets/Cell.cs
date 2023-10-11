using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Color deadColor;
    public Color aliveColor;
    public SpriteRenderer spriteRenderer;
    private bool isAliveInNextGeneration;
    private bool isAlive;

    public void Init(bool isAlive)
    {
        this.isAlive = isAlive;
    
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

        if (isAlive == true)
        {
            spriteRenderer.color = aliveColor;
        }
        else
        {
            spriteRenderer.color = deadColor;
        }
    }
}
