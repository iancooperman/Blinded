using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text subtitleText;


    private Queue<DialogueClip> dialogues;
    private AudioSource audioSource;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogues = new Queue<DialogueClip>();
        player = GameObject.Find("Player");
        StartCoroutine("PlayDialogue");
    }

    // Update is called once per frame
    void Update()
    {
        // This should clear the subtitle text
        if (!audioSource.isPlaying)
        {
            subtitleText.text = "";
        }
        
    }

    public void DisablePlayerMovementUntilDialogueOver()
    {
        StartCoroutine("DisablePlayerMovement");
    }


    IEnumerator DisablePlayerMovement()
    {
        player.GetComponent<GridMovement>().enabled = false;
        yield return new WaitWhile(() => dialogues.Count > 0);
        player.GetComponent<GridMovement>().enabled = true;
    }

    public void AddDialogue(AudioClip voiceClip, string subtitle)
    {
        DialogueClip dialogue = new DialogueClip();
        dialogue.voiceClip = voiceClip;
        dialogue.subtitle = subtitle;
        dialogues.Enqueue(dialogue);
    }


    IEnumerator PlayDialogue()
    {
        while (true)
        {
            // Don't bother doing anything until there's actually dialogue to do
            yield return new WaitUntil(() => dialogues.Count > 0);

            // Wait until any current voice clip is done playing
            yield return new WaitWhile(() => audioSource.isPlaying);


            // Play the dialogue
            DialogueClip dialogue = dialogues.Dequeue();
            audioSource.clip = dialogue.voiceClip;
            audioSource.Play();
            subtitleText.text = dialogue.subtitle;
        }
    }
}

struct DialogueClip
{
    public AudioClip voiceClip;
    public string subtitle;
};
