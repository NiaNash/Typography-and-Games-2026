using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReceiver : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        // Check if player released mouse
        if (Input.GetMouseButtonUp(0))
        {
            TicketType ticket = other.GetComponent<TicketType>();

            if (ticket != null)
            {
                Evaluate(ticket);

                if (ticket.ticketKind != TicketType.TicketKind.Neutral)
                { 
                    other.gameObject.SetActive(false);
                }
            }
        }
    }

    void Evaluate(TicketType ticket)
    {
        bool isHuman = CompareTag("Human");
        bool isMonster = CompareTag("Monster");

        bool correct =
            (isHuman && ticket.ticketKind == TicketType.TicketKind.Good) ||
            (isMonster && ticket.ticketKind == TicketType.TicketKind.Bad);

        if (correct)
        {
            Debug.Log("Correct ticket");
        }
        else
        {
            Debug.Log("Wrong ticket → lose heart");

            HeartsControl.health -= 1;

            if (HeartsControl.health < 0)
                HeartsControl.health = 0;

            /* if (CompareTag("Human"))
             {
                 if (ticket.ticketKind == TicketType.TicketKind.Good)
                 {
                     Debug.Log("✅ Correct ticket for HUMAN");
                 }
                 else
                 {
                     Debug.Log("❌ WRONG ticket for HUMAN");
                     // subtract health later
                 }
             }
             else if (CompareTag("Monster"))
             {
                 if (ticket.ticketKind == TicketType.TicketKind.Bad)
                 {
                     Debug.Log("✅ Correct ticket for MONSTER");
                 }
                 else
                 {
                     Debug.Log("❌ WRONG ticket for MONSTER");
                     // subtract health later
                 }

             }*/
        }
    }
}