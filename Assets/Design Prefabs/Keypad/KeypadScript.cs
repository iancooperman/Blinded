using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class KeypadScript : MonoBehaviour
{
    public GameObject player;
    public AudioSource audioSource;
    public List<char> keyCombo;
    private List<char> input;

    public AudioClip keypadPress;
    public AudioClip keypadSuccess;
    public AudioClip keypadWrongInput;


    private bool movementDisabled;
    private bool keypadActivated;
    


    private void Start()
    {
        movementDisabled = false;
        keypadActivated = false;
        input = new List<char>();
    }

    private void Update()
    {
        if (movementDisabled && !keypadActivated)
        {
            CheckForKey('w');
            CheckForKey('a');
            CheckForKey('s');
            CheckForKey('d');
        }


        if (keyCombo.SequenceEqual(input))
        {
            Debug.Log("Accepted!");
            PlaySound(keypadSuccess);
            keypadActivated = true;

            StartCoroutine(Delay(1));

            EnablePlayerMovement(player);
            gameObject.SetActive(false);
        }

    }


    private void CheckForKey(char c)
    {
        if (Input.GetKeyDown(c.ToString()) && input.Count < keyCombo.Count) // if the target key is down
        {
            PlaySound(keypadPress);

            if (keyCombo[input.Count] == c) // if the target key equals the corresponding part of the keycode
            {
                Debug.Log("Acceptable.");
                input.Add(c); // add the key to the taken input
            }
            else
            {
                Debug.Log("Unacceptable!");
                input.Clear(); // otherwise, erase the input

                PlaySound(keypadWrongInput);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject) // If the object that collided with the trigger is the player
        {
            DisablePlayerMovement(other.gameObject);
            movementDisabled = true;
        }
    }

    private void DisablePlayerMovement(GameObject player)
    {
        player.GetComponent<GridMovement>().enabled = false;
        movementDisabled = false;
    }

    private void EnablePlayerMovement(GameObject player)
    {
        player.GetComponent<GridMovement>().enabled = true;
    }


    public bool GetActivationState()
    {
        return keypadActivated;
    }


    private void PlaySound(AudioClip ac)
    {
        audioSource.clip = ac;
        audioSource.Play();
    }

    IEnumerator Delay(float s)
    {
        yield return new WaitForSeconds(s);
    }

}
