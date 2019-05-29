using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text subtitleText;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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

    public void PlayDialogue(AudioClip voiceClip, string subtitle)
    {
        audioSource.clip = voiceClip;
        audioSource.Play();
        subtitleText.text = subtitle;
    }
}
