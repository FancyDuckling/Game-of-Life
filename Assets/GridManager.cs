using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GridManager : MonoBehaviour
{
    public Cell cellPrefab;
    public Transform cameraPos;

    private float generationInterval = 0.5f;
    private int spawnPrecentage = 15;
    private int width = 53;
    private int height = 30;
    private Cell[,] currentGrid;
    private Cell[,] nextGrid;

    void Start()
    {
        GenerateGrids();
        InvokeRepeating("NextGeneration", generationInterval, generationInterval);
    }

    public void GenerateGrids()
    {
        currentGrid = new Cell[width, height];
        nextGrid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedCell = Instantiate(cellPrefab, new Vector3(x, y), Quaternion.identity);
                spawnedCell.name = $"Tile {x}, {y}";
                currentGrid[x, y] = spawnedCell;
  
                float randomValue = Random.Range(0f, 100f);

                bool isAlive = randomValue < spawnPrecentage; 

                spawnedCell.Init(isAlive);
            }
        }

        cameraPos.transform.position = new Vector3((float)width / 2 - 0.5f, (float)height / 2 - 0.5f, -10f);
    }

    void NextGeneration()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell cell = currentGrid[x, y];
                Cell currentCell = cell;
                int aliveNeighbors = CountAliveNeighbors(x, y);

                bool isAliveInNextGeneration = false;

                if (currentCell.IsAlive())
                {
                    if (aliveNeighbors == 2 || aliveNeighbors == 3)
                    {
                        isAliveInNextGeneration = true;
                    }
                }
                else
                {
                    if (aliveNeighbors == 3)
                    {
                        isAliveInNextGeneration = true;
                    }
                }

                nextGrid[x, y] = currentCell;
                nextGrid[x, y].SetNextGenerationState(isAliveInNextGeneration);
            }
        }

        //next generation
        Cell[,] tempGrid = currentGrid;
        currentGrid = nextGrid;
        nextGrid = tempGrid;

        //new generation's state
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                currentGrid[x, y].ApplyNextGenerationState();
            }
        }
    }

    int CountAliveNeighbors(int x, int y)
    {
        int count = 0;

        for (int deltaX = -1; deltaX <= 1; deltaX++)
        {
            for (int deltaY = -1; deltaY <= 1; deltaY++)
            {
                if (deltaX == 0 && deltaY == 0)
                {
                    continue; 
                }

                int neighborX = x + deltaX;
                int neighborY = y + deltaY;

                if (neighborX >= 0 && neighborX < width && neighborY >= 0 && neighborY < height)
                {
                    if (currentGrid[neighborX, neighborY].IsAlive())
                    {
                        count++;
                    }
                }
            }
        }

        return count;
    }

    public void PauseGame()
    {
        Time.timeScale = 0; 
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
    }

    public void FasterGame()
    {
       Time.timeScale = 1 * 2;
    }

    public void ZoomIn()
    {
        Camera.main.orthographicSize = 15-7.5f;
    }

    public void ZoomOut()
    {
        Camera.main.orthographicSize = 15;
    }
}






