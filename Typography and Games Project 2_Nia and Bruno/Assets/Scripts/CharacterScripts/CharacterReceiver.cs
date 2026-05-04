using System.Collections;
using UnityEngine;

public class CharacterReceiver : MonoBehaviour
{
    public CharacterType characterType;

    private bool hasResolved = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (hasResolved) return;

        if (Input.GetMouseButtonUp(0))
        {
            // 🔥 FIX: get TicketType even if collider is on child
            TicketType ticket = other.GetComponentInParent<TicketType>();

            if (ticket != null)
            {
                hasResolved = true;
                StartCoroutine(EvaluateAndResolve(ticket, other.gameObject));
            }
        }
    }

    IEnumerator EvaluateAndResolve(TicketType ticket, GameObject ticketObj)
    {
        Debug.Log("Processing ticket...");

        bool isHuman = characterType == CharacterType.Human;
        bool isMonster = characterType == CharacterType.Monster;

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
        }

        // ✅ ONLY destroy + reset if NOT Neutral
        if (ticket.ticketKind != TicketType.TicketKind.Neutral)
        {
            Debug.Log("Destroying ticket and resetting round");

            // 🔥 Destroy the full ticket (root object)
            Destroy(ticketObj.transform.root.gameObject);

            yield return new WaitForSeconds(1f);

            FindObjectOfType<GameManager>().ResetRound();
        }
        else
        {
            Debug.Log("Neutral ticket → do nothing");
        }

        // allow interaction again next time
        hasResolved = false;
    }
}