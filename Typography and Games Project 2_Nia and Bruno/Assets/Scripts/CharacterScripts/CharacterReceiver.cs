using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReceiver : MonoBehaviour
{
    // Assigned by GameManager each round
    public CharacterType characterType;

    private bool hasEvaluated = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (hasEvaluated) return;

        // Only evaluate when player releases mouse
        if (Input.GetMouseButtonUp(0))
        {
            TicketType ticket = other.GetComponent<TicketType>();

            if (ticket != null)
            {
                Evaluate(ticket);

                // Prevent multiple evaluations in same frame
                hasEvaluated = true;

                // Only destroy + reset if ticket was actually used
                if (ticket.ticketKind != TicketType.TicketKind.Neutral)
                {
                    Destroy(other.gameObject);

                    FindObjectOfType<GameManager>().ResetRound();
                }
            }
        }
    }

    void Evaluate(TicketType ticket)
    {
        bool correct =
            (characterType == CharacterType.Human && ticket.ticketKind == TicketType.TicketKind.Good) ||
            (characterType == CharacterType.Monster && ticket.ticketKind == TicketType.TicketKind.Bad);

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
        }
    }

    // Reset this when a new character/round starts
    public void ResetState()
    {
        hasEvaluated = false;
    }
}