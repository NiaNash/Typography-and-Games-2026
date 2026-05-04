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

    [Header("Sprites")]
    public List<Sprite> idSprites = new List<Sprite>();
    public List<Sprite> characterSprites = new List<Sprite>();

    [Header("Spawn Points")]
    public Transform ticketSpawnPoint;
    public Transform idSpawnPoint;
    public Transform characterSpawnPoint;

    [Header("Round Setup")]
    public List<CharacterType> roundCharacterTypes = new List<CharacterType>();

    private int currentRoundIndex = 0;

    private GameObject currentTicket;
    private GameObject currentID;
    private GameObject currentCharacter;

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
    }

    public void ResetRound()
    {
        Debug.Log("Resetting Round...");

        if (timer != null)
            timer.ResetTimer();

        if (energyControl != null)
            energyControl.ResetEnergy();

        if (inspectionUI != null)
            inspectionUI.ResetInspectionButtons();

        if (currentTicket != null)
            Destroy(currentTicket);

        if (currentID != null)
            Destroy(currentID);

        if (currentCharacter != null)
            Destroy(currentCharacter);

        currentRoundIndex++;

        if (currentRoundIndex >= roundCharacterTypes.Count)
            currentRoundIndex = 0;

        StartRound();
    }

    // -------------------------
    // CHARACTER SYSTEM
    // -------------------------

    void SpawnCharacter()
    {
        currentCharacter = Instantiate(characterPrefab, characterSpawnPoint.position, Quaternion.identity);

        SpriteRenderer sr = currentCharacter.GetComponent<SpriteRenderer>();

        if (sr != null && characterSprites.Count > 0)
        {
            int index = currentRoundIndex % characterSprites.Count;
            sr.sprite = characterSprites[index];
        }

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
        // Spawn Ticket
        currentTicket = Instantiate(ticketPrefab, ticketSpawnPoint.position, Quaternion.identity);

        // Spawn ID
        currentID = Instantiate(idPrefab, idSpawnPoint.position, Quaternion.identity);

        // Apply ID sprite
        SpriteRenderer idSR = currentID.GetComponent<SpriteRenderer>();

        if (idSR != null && idSprites.Count > 0)
        {
            int index = currentRoundIndex % idSprites.Count;
            idSR.sprite = idSprites[index];
        }
    }
}