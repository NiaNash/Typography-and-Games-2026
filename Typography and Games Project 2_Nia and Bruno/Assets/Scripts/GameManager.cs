using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Core Systems")]
    public Timer timer;
    public EnergyControl energyControl;
    public VisualInspectionButtonInteract inspectionUI;

    [Header("Prefabs")]
    public GameObject ticketPrefab;
    public GameObject idPrefab;
    public GameObject characterPrefab;

    [Header("Spawn Points")]
    public Transform ticketSpawnPoint;
    public Transform idSpawnPoint;
    public Transform characterSpawnPoint;

    [Header("Round Setup (Inspector)")]
    public List<CharacterType> roundCharacterTypes = new List<CharacterType>();

    private int currentRoundIndex = 0;

    private GameObject currentTicket;
    private GameObject currentID;
    public GameObject currentCharacter;

    void Start()
    {
        StartRound();
    }

    // -------------------------
    // ROUND CONTROL
    // -------------------------

    void StartRound()
    {
        SpawnCharacter();
        SpawnDocuments();
        ApplyCharacterType();
    }

    public void ResetRound()
    {
        Debug.Log("Resetting Round...");

        // Timer reset
        if (timer != null)
            timer.ResetTimer();

        // Energy reset
        if (energyControl != null)
            energyControl.ResetEnergy();

        // Button reset
        if (inspectionUI != null)
            inspectionUI.ResetInspectionButtons();

        // Destroy old objects
        if (currentTicket != null)
            Destroy(currentTicket);

        if (currentID != null)
            Destroy(currentID);

        if (currentCharacter != null)
            Destroy(currentCharacter);

        // Move to next round
        currentRoundIndex++;

        if (currentRoundIndex >= roundCharacterTypes.Count)
        {
            currentRoundIndex = 0; // loop back (or replace with end game later)
        }

        // Start next round
        StartRound();
    }

    // -------------------------
    // CHARACTER SYSTEM
    // -------------------------

    void SpawnCharacter()
    {
        currentCharacter = Instantiate(characterPrefab, characterSpawnPoint.position, Quaternion.identity);
    }

    void ApplyCharacterType()
    {
        if (currentCharacter == null) return;

        CharacterReceiver receiver = currentCharacter.GetComponent<CharacterReceiver>();

        if (receiver != null && roundCharacterTypes.Count > 0)
        {
            receiver.characterType = roundCharacterTypes[currentRoundIndex];
        }
    }

    // -------------------------
    // DOCUMENT SYSTEM
    // -------------------------

    void SpawnDocuments()
    {
        currentTicket = Instantiate(ticketPrefab, ticketSpawnPoint.position, Quaternion.identity);
        currentID = Instantiate(idPrefab, idSpawnPoint.position, Quaternion.identity);
    }
}