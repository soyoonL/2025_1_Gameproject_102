﻿using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int gridWidth = 7;
    public int gridHeight = 7;
    public float cellSize = 1.4f;
    public GameObject cellPrefabs;
    public Transform gridContainer;
    public GameObject rankPrefabs;
    public Sprite[] rankSprites;
    public int maxRankLevel = 7;
    public GridCell[,] grid;
    void InitializeGrid()
    {
        grid = new GridCell[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector3 position = new Vector3(
                    x * cellSize - (gridWidth * cellSize / 2) + cellSize / 2,
                    y * cellSize - (gridHeight * cellSize / 2) + cellSize / 2,
                    1f
                );

                GameObject cellObj = Instantiate(cellPrefabs, position, Quaternion.identity, gridContainer);
                GridCell cell = cellObj.AddComponent<GridCell>();
                cell.Initialize(x, y);

                grid[x, y] = cell;
            }
        }
    }


    void Start()
    {
        InitializeGrid();

        for (int i = 0; i < 4; i++)
        {
            SpawnNewRank();
        }
    }


    void Update()
    {

    }

    public DraggableRank CreateRankInCell(GridCell cell, int level)
    {

        if (cell == null || !cell.IsEmpty()) return null;

        level = Mathf.Clamp(level, 1, maxRankLevel);

        Vector3 rankPosition = new Vector3(cell.transform.position.x, cell.transform.position.y, 0f);

        GameObject rankObj = Instantiate(rankPrefabs, rankPosition, Quaternion.identity, gridContainer);
        rankObj.name = "Rank_Lvel" + level;

        DraggableRank rank = rankObj.AddComponent<DraggableRank>();
        rank.SetRankLevel(level);

        return rank;

    }

    private GridCell FindEmptyCell()
    {
        List<GridCell> emptyCells = new List<GridCell>();

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (grid[x, y].IsEmpty())
                {
                    emptyCells.Add(grid[x, y]);
                }
            }
        }

        if (emptyCells.Count == 0)
        {
            return null;
        }

        return emptyCells[Random.Range(0, emptyCells.Count)];

    }

    public bool SpawnNewRank()
    {
        GridCell emptyCell = FindEmptyCell();
        if (emptyCell == null) return false;

        int rankLevel = Random.Range(0, 100) < 80 ? 1 : 2;
        CreateRankInCell(emptyCell, rankLevel);

        return true;
    }

    public GridCell FindClosestCell(Vector3 position)
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                if (grid[x, y].ContainsPosition(position))
                {
                    return grid[x, y];
                }
            }
        }
        GridCell closestCell = null;
        float closestDistance = float.MaxValue;

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0;y < gridHeight; y++)
            {
                float distance = Vector3.Distance(position, grid[x, y], transform.position);
                if (distance < closestDistance)
                {
                    
                }
            }
        }
    }
}