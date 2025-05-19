using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableRank : MonoBehaviour
{

    public int rankLevel = 1;                   
    public float dragSpeed = 10f;               
    public float snapBackSpeed = 20f;           

    public bool isDragging = false;             
    public Vector3 originalPosition;            
    public GridCell currentCell;                

    public Camera mainCamera;                   
    public Vector3 dragOffset;                  
    public SpriteRenderer spriteRenderer;       
    public GameManager gamemanager;

    private void Awake()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();
        gamemanager = GetComponent<GameManager>();
    }


    void Start()
    {
        originalPosition = transform.position;
    }

    
    void Update()
    {

    }

    void StartDragging()
    {
        isDragging = true;
        dragOffset = transform.position-GetMouseWorldPosition();
        spriteRenderer.sortingOrder = 10;
    }

    void StopDragging()
    {
        isDragging = false;
        spriteRenderer.sortingOrder = 0;
    }


    public void MoveToCell(GridCell targetCell)     
    {
        if (currentCell != null)
        {
            currentCell.currentRank = null; 
        }

        currentCell = targetCell;           
        targetCell.currentRank = this;

        originalPosition = new Vector3(targetCell.transform.position.x, targetCell.transform.position.y, 0f);
        transform.position = originalPosition;
    }

    public void ReturnToOriginalPosition()
    {
        transform.position = originalPosition;
    }

    public void MergeWithCell(GridCell targetCell)
    {
        if (targetCell.currentRank == null || targetCell.currentRank.rankLevel != rankLevel) 
        {
            ReturnToOriginalPosition(); 
            return;
        }

        if (currentCell != null)
        {
            currentCell.currentRank = null; 
        }

    }

    public Vector3 GetMouseWorldPosition()                  
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z;
        return mainCamera.ScreenToWorldPoint(mousePos);
    }

    public void SetRankLevel(int level)
    {
        rankLevel = level;

        if (gamemanager != null && gamemanager.rankSprites.Length > level - 1)
        {
            spriteRenderer.sprite = gamemanager.rankSprites[level - 1];    
        }
    }


}