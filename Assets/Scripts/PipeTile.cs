using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeTile : MonoBehaviour
{
    public List<PipeTile> neighbours;

    public circuits.Direction currentDirection;
    public circuits.Direction[] connections;
    public circuits.TileType type;
    public bool CanRotate = true;

    private bool pipeActive;
    public bool PipeActive { 
        get { 
            return pipeActive;
        } 
        set {
            bool changed = (pipeActive != value);
            if (changed)
            {
                pipeActive = value;
                pipeRenderer.sprite = pipeActive ? typeSpriteActive : typeSprite;
            }
            else
            {
                pipeRenderer.sprite = typeSprite;
            }
        }
    }

    public Sprite typeSprite;
    public Sprite typeSpriteActive;

    public Image pipeRenderer;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        RotateToCurrentDirection();
    }

    public void Rotate()
    {
        if (type == circuits.TileType.start || type == circuits.TileType.end)
            return;

        Debug.Log("Rotate!");
        currentDirection = GetNextDirection(currentDirection);

        circuits.Direction[] directions = new circuits.Direction[connections.Length];
        int i = 0;
        foreach (circuits.Direction direction in connections)
        {
            directions[i] = GetNextDirection(direction);
            i++;
        }
        connections = directions;

    }

    private circuits.Direction GetNextDirection(circuits.Direction curDirection)
    {
        if (curDirection == circuits.Direction.up)
        {
            return circuits.Direction.right;
        }
        else if (curDirection == circuits.Direction.right)
        {
            return circuits.Direction.down;
        }
        else if (curDirection == circuits.Direction.down)
        {
            return circuits.Direction.left;
        }
        else if (curDirection == circuits.Direction.left)
        {
            return circuits.Direction.up;
        }

        return curDirection;
    }

    void RotateToCurrentDirection()
    {
        Vector3 rotation = new Vector3();
        if (currentDirection == circuits.Direction.up)
            rotation.z = 0;
        else if (currentDirection == circuits.Direction.right)
            rotation.z = 270;
        else if (currentDirection == circuits.Direction.down)
            rotation.z = 180;
        else
            rotation.z = 90;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
