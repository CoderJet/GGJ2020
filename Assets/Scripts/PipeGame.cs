﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeGame : MonoBehaviour
{
    public PipeTile pipeTile;
    public int rowTilesCount = 5;
    public int columnTilesCount = 5;

    private GridLayoutGroup group;
    public Sprite startSprite, endSprite, straightSprite, cornerSprite;
    public Sprite startSpriteActive, endSpriteActive, straightSpriteActive, cornerSpriteActive;

    // Start is called before the first frame update
    void Start()
    {
        group = GetComponent<GridLayoutGroup>();
        group.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        group.constraintCount = columnTilesCount;

        for (int x = 0; x < columnTilesCount; x++)
        {
            for (int y = 0; y < rowTilesCount; y++)
            {
                if (x == 0 && y == 0)
                {
                    PipeTile go = Instantiate(pipeTile, this.transform);
                    go.currentDirection = circuits.Direction.right;
                    go.PipeActive = true;
                    go.type = circuits.TileType.start;
                }
                else if (x == columnTilesCount - 1 && y == rowTilesCount - 1)
                {
                    PipeTile go = Instantiate(pipeTile, this.transform);
                    go.currentDirection = circuits.Direction.right;
                    go.PipeActive = false;
                    go.type = circuits.TileType.end;
                }
                else
                {
                    PipeTile go = Instantiate(pipeTile, this.transform);
                    go.type = ((circuits.TileType)Random.Range(2, 4));
                    go.currentDirection = circuits.Direction.up;
                    int direction = Random.Range(0, 4);

                    switch (go.type)
                    {
                        case circuits.TileType.start:
                            //go.typ
                            go.connections = new circuits.Direction[]
                            {
                                circuits.Direction.right
                            };
                            break;
                        case circuits.TileType.corner:
                            go.typeSprite = cornerSprite;
                            go.typeSpriteActive = cornerSpriteActive;
                            go.PipeActive = false;
                            go.connections = new circuits.Direction[]
                            {
                                circuits.Direction.up,
                                circuits.Direction.right
                            };
                            for (int i = 0; i < direction; i++)
                            {
                                go.Rotate();
                            }
                            break;
                        case circuits.TileType.straight:
                            go.typeSprite = straightSprite;
                            go.typeSpriteActive = straightSpriteActive;
                            go.PipeActive = false;
                            go.connections = new circuits.Direction[]
                            {
                                circuits.Direction.up,
                                circuits.Direction.down
                            };
                            if (direction % 2 == 1)
                                go.Rotate();
                            break;
                        case circuits.TileType.end:
                            go.typeSprite = endSprite;
                            go.typeSpriteActive = endSpriteActive;
                            go.PipeActive = false;
                            go.connections = new circuits.Direction[]
                            {
                                circuits.Direction.left
                            };
                            break;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
