using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;
    private TextMeshProUGUI sentenceText;
    private TextMeshProUGUI nameText;
    private Animator animator;
    private PlayerRPGCore playerData;

    private void Awake()
    {
        playerData = GameObject.FindWithTag("Player").GetComponent<PlayerRPGCore>();
        sentenceText = GameObject.Find("SentenceText").GetComponent<TextMeshProUGUI>();
        nameText = GameObject.Find("NameText").GetComponent<TextMeshProUGUI>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        nameText.text = dialogue.name;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        playerData.busy = true;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        Debug.Log(sentence);
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        sentenceText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            sentenceText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        playerData.busy = false;
    }

    private void Update()
    {
        if (playerData.busy && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }
}
