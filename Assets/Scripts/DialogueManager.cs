using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;
    private string[] sentences;
    private string currentSentence;
    private int sentenceIndex;
    public char divider = '|';
    public float typeDelay = 0.2f;
    private bool isTyping;
    public UnityEvent OnDialogueEnd;

    private bool HasNextSentence
    {
        get
        {
            return sentenceIndex < sentences.Length - 1;
        }
    }

    private void Awake()
    {
        dialogueBox.SetActive(false);
    }

    public void StartDialogue(TextAsset textAsset)
    {
        dialogueBox.SetActive(true);
        dialogueText.text = "";
        sentences = textAsset.text.Split(divider);
        sentenceIndex = 0;
        currentSentence = sentences[sentenceIndex];
        StartCoroutine(TypeSentence(currentSentence));
    }

    private IEnumerator TypeSentence(string sentence)
    {
        bool richText = false;
        isTyping = true;
        dialogueText.text = "";
        foreach (char letter in sentence)
        {
            if (letter == '<')
            {
                richText = true;
            }
            else if (letter == '>')
            {
                richText = false;
            }
            dialogueText.text += letter;
            if (!richText)
            {
                yield return new WaitForSeconds(typeDelay);
            }
        }
        isTyping = false;
    }

    public void AdvanceDialogue()
    {
        if (isTyping)
        {
            StopAllCoroutines();
            dialogueText.text = currentSentence;
            isTyping = false;
            return;
        }

        if (HasNextSentence)
        {
            sentenceIndex++;
            currentSentence = sentences[sentenceIndex];
            StopAllCoroutines();
            StartCoroutine(TypeSentence(sentences[sentenceIndex]));
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueBox.SetActive(false);
        StopAllCoroutines();
        isTyping = false;
        OnDialogueEnd?.Invoke();
    }
}
