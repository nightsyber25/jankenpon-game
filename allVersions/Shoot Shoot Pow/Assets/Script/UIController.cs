using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    public GameObject setupScreen;
    public GameObject optionScreen;
    public TMP_Text paperAmount;
    public TMP_Text rockAmount;
    public TMP_Text scissorAmount;
    public TMP_Text specialAmount;
    public TMP_Text setupTimeCounter;
    public TMP_Text statusText;
    public TMP_Text phaseTimer;

    private float currentTime = 0f;
    private float startingTime = 5f;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        statusText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (setupScreen.activeInHierarchy)
        {      
            UpdateSetupScreen();
            currentTime -= 1 * Time.deltaTime;
            setupTimeCounter.text = currentTime.ToString("0");
            if (currentTime < 0)
            {
                currentTime = 0;
                setupScreen.SetActive(false);
                DeckController.instance.SpawnDeck();
                MatchManager.instance.state = MatchManager.GameState.Draw;
                MatchManager.instance.StateCheck();
                // MatchManager.instance.state = MatchManager.GameState.NormalCard;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ShowHideOption();
        }
        
        if(optionScreen.activeInHierarchy && Cursor.lockState != CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ShowHideOption()
    {
        if(!optionScreen.activeInHierarchy)
        {
            optionScreen.SetActive(true);
        }
        else
        {
            optionScreen.SetActive(false);
        }
    }

    public void ReturnToMainMenu()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void UpdateSetupScreen()
    {
        scissorAmount.text = DeckController.instance.numOfCardInDeck[1].ToString();
        paperAmount.text = DeckController.instance.numOfCardInDeck[2].ToString();
        rockAmount.text = DeckController.instance.numOfCardInDeck[3].ToString();
        specialAmount.text = (DeckController.instance.numOfCardInDeck[4]+
        DeckController.instance.numOfCardInDeck[5]+
        DeckController.instance.numOfCardInDeck[6]+
        DeckController.instance.numOfCardInDeck[7]+
        DeckController.instance.numOfCardInDeck[8]).ToString();
    }

    public void SetSetupScreen()
    {
        currentTime = startingTime;
        setupScreen.SetActive(true);
    }
}
