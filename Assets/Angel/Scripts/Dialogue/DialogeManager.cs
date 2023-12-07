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
    }
    private void Update()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (playingDialogue)
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

    
}
