using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject tag;
    [SerializeField] BoxType boxType;
    [SerializeField] LayerMask playerMask;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tag.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tag.SetActive(false);
    }

    void Interact()
    {
        BoxCollider2D boxCollider2D = GetComponent<BoxCollider2D>();

        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.layerMask = playerMask;

        Collider2D[] colliders = new Collider2D[1];

        int collisionCount = boxCollider2D.OverlapCollider(contactFilter2D, colliders);

        if(collisionCount > 0)
        {
            // TODO
            // colliders[0].gameObject;
        }
    }
}

enum BoxType
{
    head,
    body,
    arms,
    legs
}