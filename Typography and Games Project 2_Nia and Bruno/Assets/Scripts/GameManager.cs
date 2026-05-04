using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [Header("Sprites - Characters")]
    public List<Sprite> characterSprites = new List<Sprite>();
    public List<Sprite> idSprites = new List<Sprite>();

    [Header("Inspection Sprites (Per Round)")]
    public List<Sprite> earsSprites = new List<Sprite>();
    public List<Sprite> eyesSprites = new List<Sprite>();
    public List<Sprite> mouthSprites = new List<Sprite>();
    public List<Sprite> handsSprites = new List<Sprite>();

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

    [Header("Inspection Popups")]
    public Image earsPopup;
    public Image eyesPopup;
    public Image teethPopup;
    public Image handsPopup;

    [Header("End Cards")]
    public GameObject winCard;
    public GameObject loseCard;

    // 🔥 ADDED: game state lock
    private bool gameEnded = false;

    void Start()
    {
        StartRound();
    }

    // -------------------------
    // ROUND CONTROL
    // -------------------------

    void StartRound()
    {
        if (gameEnded) return;

        SpawnCharacter();
        SpawnDocuments();
    }

    public void ResetRound()
    {
        if (gameEnded) return;

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
        {
            EndGame();
            return;
        }

        StartRound();
    }

    public int CurrentRoundIndex => currentRoundIndex;

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
        currentTicket = Instantiate(ticketPrefab, ticketSpawnPoint.position, Quaternion.identity);

        currentID = Instantiate(idPrefab, idSpawnPoint.position, Quaternion.identity);

        SpriteRenderer idSR = currentID.GetComponent<SpriteRenderer>();

        if (idSR != null && idSprites.Count > 0)
        {
            int index = currentRoundIndex % idSprites.Count;
            idSR.sprite = idSprites[index];
        }
    }

    // -------------------------
    // INSPECTION SYSTEM
    // -------------------------

    public void ShowEars()
    {
        if (earsPopup == null || earsSprites.Count == 0) return;

        earsPopup.gameObject.SetActive(true);
        earsPopup.sprite = earsSprites[currentRoundIndex];
    }

    public void ShowEyes()
    {
        if (eyesPopup == null || eyesSprites.Count == 0) return;

        eyesPopup.gameObject.SetActive(true);
        eyesPopup.sprite = eyesSprites[currentRoundIndex];
    }

    public void ShowTeeth()
    {
        if (teethPopup == null || mouthSprites.Count == 0) return;

        teethPopup.gameObject.SetActive(true);
        teethPopup.sprite = mouthSprites[currentRoundIndex];
    }

    public void ShowHands()
    {
        if (handsPopup == null || handsSprites.Count == 0) return;

        handsPopup.gameObject.SetActive(true);
        handsPopup.sprite = handsSprites[currentRoundIndex];
    }

    // -------------------------
    // END GAME SYSTEM (ADDED)
    // -------------------------

    void EndGame()
    {
        gameEnded = true;

        Debug.Log("Game Ended");

        if (timer != null)
            timer.enabled = false;

        if (energyControl != null)
            energyControl.enabled = false;

        if (inspectionUI != null)
            inspectionUI.gameObject.SetActive(false);

        if (currentCharacter != null)
            Destroy(currentCharacter);

        if (currentTicket != null)
            Destroy(currentTicket);

        if (currentID != null)
            Destroy(currentID);

        // 🎯 SCENE SWITCH
        if (HeartsControl.health == 3)
        {
            SceneManager.LoadScene("Win");
        }
        else
        {
            SceneManager.LoadScene("Lose");
        }
    }
}