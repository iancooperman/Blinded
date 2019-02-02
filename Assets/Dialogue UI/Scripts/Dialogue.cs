using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public TextAsset dialogueFile;
    public GameObject dialogueUI;

    
    Queue<string> sentences = new Queue<string>();


    Text nameText;
    Text sentenceText;

    // Start is called before the first frame update
    void Start()
    {
        dialogueUI.SetActive(false);

        nameText = dialogueUI.transform.GetChild(0).gameObject.GetComponent<Text>();
        sentenceText = dialogueUI.transform.GetChild(1).gameObject.GetComponent<Text>();

        ParseFile();
    }

    void Update() {
        if (Input.GetKeyDown("return") && dialogueUI.activeSelf == true) { // Pressing enter loads the next sentence, but only if the dialogue UI is visible
            LoadSentence();
        }
    }

    void ParseFile() {
        string text = dialogueFile.ToString();
        
        string[] lines = text.Split('\n');
        nameText.text = lines[0]; // Set name from file

        for (int i = 1; i < lines.Length; i++) { // Put sentences from file into sentence Queue.
            sentences.Enqueue(lines[i]);
        }
    }

    public void StartDialogue() { // Activate the dialogue UI and Load the first sentence.
        dialogueUI.SetActive(true);
        LoadSentence();
    }

    public void EndDialogue() { // Deactivate the dialogue UI.
        dialogueUI.SetActive(false);
    }

    void LoadSentence() { // Load the next sentence.
        if (sentences.Count == 0) {
            EndDialogue();
        }
        else {
            string sentence = sentences.Dequeue();
            StartCoroutine(TypeSentence(sentence));
        }
    }

    public void ResetDialogue() {
        sentences.Clear();
        ParseFile();
    }

    IEnumerator TypeSentence(string sentence) { // Make the text typing-out possible.
        sentenceText.text = "";
        foreach (char letter in sentence.ToCharArray()) {
            sentenceText.text += letter;
            yield return null;
        }
    }
}
