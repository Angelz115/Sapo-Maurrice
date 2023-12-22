using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;

public class DialogeManager : MonoBehaviour
{
    public static DialogeManager Instance { get; private set; }

    [Header("Dialogue UI")]
    [SerializeField] GameObject dialoguePanel;
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Story currenStory;
    [SerializeField] bool dialogueIsPlaying;
    [SerializeField] bool playingDialogue;
    [SerializeField] KeyCode key;
    [SerializeField] GameObject[] choices;
    [SerializeField] TextMeshProUGUI[] choicesText;


    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }
    }
    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (playingDialogue && Input.GetKeyDown(key))
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON) 
    {
        currenStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

       
        playingDialogue = true;
        ContinueStory();
    }
    
    
    private IEnumerator ExitDialogueMode() 
    {
        yield return new WaitForSeconds(0.3f);
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        playingDialogue = false;
        GameManager.Instance.TerminarSocializar();
    }
    
    private void ContinueStory() 
    {
        if (currenStory.canContinue)
        {
            dialogueText.text = currenStory.Continue();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }
    private void DisplayChoices() 
    {
        List<Choice> currentChoices = currenStory.currentChoices;
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given tha the UI can support. Number of choices given" + currentChoices.Count);
        }
    }
    public void setVars(GameObject DialoguePanel, TextMeshProUGUI DialogueText) 
    {
        dialoguePanel = DialoguePanel;
        dialogueText = DialogueText;
    }
}
