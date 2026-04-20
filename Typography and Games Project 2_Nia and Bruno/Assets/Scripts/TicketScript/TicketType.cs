using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicketType : MonoBehaviour
{
    public enum TicketKind
    {
        Neutral,
        Good,
        Bad
    }

    public TicketKind ticketKind = TicketKind.Neutral;
}