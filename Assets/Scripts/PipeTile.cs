using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeTile : MonoBehaviour
{
    public circuits.Direction currentDirection;
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
        if (currentDirection == circuits.Direction.up)
            currentDirection = circuits.Direction.right;
        else if (currentDirection == circuits.Direction.right)
            currentDirection = circuits.Direction.down;
        else if (currentDirection == circuits.Direction.down)
            currentDirection = circuits.Direction.left;
        else
            currentDirection = circuits.Direction.up;

        //Re-check for activated pipes.


        //check for win!
        
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
