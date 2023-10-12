using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Ändrat 12/10-2023
public class GridManager : MonoBehaviour
{
    public Cell cellPrefab;
    public Transform cameraPos;

    private float generationInterval = 0.5f;
    private int spawnPrecentage = 20;
    private int width = 53;
    private int height = 30;
    private Cell[,] grid;
    

    void Start()
    {
        GenerateGrids();
        InvokeRepeating("NextGeneration", generationInterval, generationInterval);
    }

    public void GenerateGrids()
    {
        grid = new Cell[width, height];


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                var spawnedCell = Instantiate(cellPrefab, new Vector3(x, y), Quaternion.identity);
                spawnedCell.name = $"Tile {x}, {y}";
                grid[x, y] = spawnedCell;

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
                grid[x, y].ApplyNextGenerationState();
            }
        }


        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Cell currentCell = grid[x, y];
                currentCell.SetNextGenerationState(false);

                int aliveNeighbors = CountAliveNeighbors(x, y);

                if (currentCell.IsAlive())
                {
                    if (aliveNeighbors == 2 || aliveNeighbors == 3)
                    {
                        currentCell.SetNextGenerationState(true);
                    }
                }
                else
                {
                    if (aliveNeighbors == 3)
                    {
                        currentCell.SetNextGenerationState(true);
                    }
                }
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
                    if (grid[neighborX, neighborY].IsAlive())
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
        Camera.main.orthographicSize = 15 - 7.5f;
    }

    public void ZoomOut()
    {
        Camera.main.orthographicSize = 15;
    }
}






