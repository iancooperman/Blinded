using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class KeypadScript : MonoBehaviour
{
    public GameObject player;
    public List<char> keyCombo;
    private List<char> input;


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
            keypadActivated = true;
            EnablePlayerMovement(player);
            gameObject.SetActive(false);
        }

    }


    private void CheckForKey(char c)
    {
        if (Input.GetKeyDown(c.ToString()) && input.Count < keyCombo.Count) // if the target key is down
        {
            if (keyCombo[input.Count] == c) // if the target key equals the corresponding part of the keycode
            {
                Debug.Log("Acceptable.");
                input.Add(c); // add the key to the taken input
            }
            else
            {
                Debug.Log("Unacceptable!");
                input.Clear(); // otherwise, erase the input
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
}
