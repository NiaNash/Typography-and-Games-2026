using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTicket : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;

    private bool isInDropZone = false;
    private Sprite newSprite;

    private SpriteRenderer sr;

    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }

    void OnMouseUp()
    {
        // ✅ ONLY change when released inside zone
        if (isInDropZone && newSprite != null)
        {
            sr.sprite = newSprite;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        return mousePos;
    }

    // 👇 Detect entering zone
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropZone"))
        {
            isInDropZone = true;

            // get sprite from zone
            TicketDropZone zone = other.GetComponent<TicketDropZone>();
            if (zone != null)
            {
                newSprite = zone.newTicketSprite;
            }
        }
    }

    // 👇 Detect leaving zone
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropZone"))
        {
            isInDropZone = false;
            newSprite = null;
        }
    }
}