using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragTicket : MonoBehaviour
{
    private Vector3 offset;
    private Camera cam;

    private bool isInDropZone = false;
    //private Sprite newSprite;
    private TicketDropZone currentZone;

    private SpriteRenderer sr;
    private TicketType ticketType;

    void Start()
    {
        cam = Camera.main;
        sr = GetComponent<SpriteRenderer>();
        ticketType = GetComponent<TicketType>();
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
        if (isInDropZone && currentZone != null)
        {
            // Change sprite
            if (currentZone.newTicketSprite != null)
            {
                sr.sprite = currentZone.newTicketSprite;
            }

            // ✅ Update ticket type (THIS FIXES YOUR ISSUE)
            if (ticketType != null)
            {
                ticketType.ticketKind = currentZone.zoneTicketType;
            }

            Debug.Log("Ticket updated to: " + ticketType.ticketKind);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = transform.position.z;
        return mousePos;
    }

    // 👇 Detect entering zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DropZone"))
        {
            isInDropZone = true;
            currentZone = other.GetComponent<TicketDropZone>();
        }

          /*  // get sprite from zone
            TicketDropZone zone = other.GetComponent<TicketDropZone>();
            if (zone != null)
            {
                newSprite = zone.newTicketSprite;
            }*/
        
    }

    // 👇 Detect leaving zone
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("DropZone"))
        {
            isInDropZone = false;
            currentZone = null;
        }
    }
}