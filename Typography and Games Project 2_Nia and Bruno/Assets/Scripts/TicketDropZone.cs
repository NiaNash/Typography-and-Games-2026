using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*public class TicketDropZone : MonoBehaviour
{
    public Sprite newTicketSprite; // assign in inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ticket"))
        {
            SpriteRenderer sr = other.GetComponent<SpriteRenderer>();

            if (sr != null)
            {
                sr.sprite = newTicketSprite;
            }
        }
    }
}*/

public class TicketDropZone : MonoBehaviour
{
    public Sprite newTicketSprite;
    public TicketType.TicketKind zoneTicketType;

}