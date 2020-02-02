using UnityEngine;

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
        currentHeldObject = partGO;
    }

    public void GivePart()
    {
        isHoldingPart = false;
        currentHeldObject.transform.SetParent(null);
        Destroy(currentHeldObject);
    }
}