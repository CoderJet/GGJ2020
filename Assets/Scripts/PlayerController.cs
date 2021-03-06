﻿using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    new Rigidbody2D rigidbody2D;

    public float movementSpeed = 1000.0f;
    public float[] verticalLayerAffects;
    public SpriteRenderer sprite;

    private float prevX = 0;

    public bool isHoldingPart = false;
    public GameObject currentHeldObject;
    [SerializeField] AssetList al;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        rigidbody2D.isKinematic = false;
        rigidbody2D.angularDrag = 0.0f;
        rigidbody2D.gravityScale = 0.0f;
    }

    void Update()
    {
        Vector2 targetVelocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Move(targetVelocity);
        SetSortingOrder();

        if(Input.GetKeyDown(KeyCode.M))
        {
            if (!al.gameObject.activeSelf)
            {
                al.Menu();
                al.InTrigger(true);
                al.gameObject.SetActive(true);
            }
            else
            {
                al.InTrigger(false);
                al.gameObject.SetActive(false);
            }
        }
    }

    void Move(Vector2 targetVelocity)
    {
        rigidbody2D.velocity = (targetVelocity * movementSpeed) * Time.deltaTime;
        if (targetVelocity.x != 0)
        {
            sprite.flipX = targetVelocity.x < 0;
        }
    }

    void SetSortingOrder()
    {
        // Change the layer when we go above/below certain thresholds.
        int sortingOrder = 0;
        foreach (float layer in verticalLayerAffects)
        {
            if (transform.position.y < layer)
                sortingOrder++;
        }
        sprite.sortingOrder = sortingOrder;
    }

    public void TakePart(GameObject partGO)
    {
        isHoldingPart = true;
        currentHeldObject = null;
        partGO.transform.SetParent(this.transform);
        partGO.transform.localPosition = Vector3.zero;
        //if (partGO.GetComponent<Animator>())
        //    partGO.GetComponent<Animator>().runtimeAnimatorController = null;
        Destroy(partGO.GetComponent<Animator>());
        partGO.GetComponent<SpriteRenderer>().sortingOrder = 10;
        if (partGO.GetComponentsInChildren<SpriteRenderer>().Length > 0)
        {
            foreach (SpriteRenderer rend in partGO.GetComponentsInChildren<SpriteRenderer>())
            {
                if (rend.transform == partGO.transform)
                    continue;

                var col = rend.color;
                col.a = 0;
                rend.color = col;
            }
        }
        currentHeldObject = partGO;
    }

    public GameObject GivePart()
    {
        GameObject ret = currentHeldObject;
        isHoldingPart = false;
        currentHeldObject.transform.SetParent(null);
        currentHeldObject = null;
        return ret;
    }
}