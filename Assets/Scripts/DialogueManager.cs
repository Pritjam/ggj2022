using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentences;
    private GameObject dialogueBG;
    private GameObject continueButton;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        dialogueBG = GameObject.Find("BG");
        continueButton = GameObject.Find("Continue");
        dialogueBG.SetActive(false);
        continueButton.transform.localScale = Vector3.zero;

    }

    public void StartDialogue(Dialogue d) {
        Debug.Log("Starting conversation with " + d.name);
        dialogueBG.SetActive(true);
        continueButton.transform.localScale = Vector3.one;
        nameText.text = d.name;

        sentences.Clear();

        foreach(string item in d.sentences) {
            sentences.Enqueue(item);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;

    }

    void EndDialogue() {
        dialogueText.text = "End of conversation.";
        dialogueBG.SetActive(false);
        nameText.text = "";
        dialogueText.text = "";
        continueButton.transform.localScale = Vector3.zero;
    }
}
