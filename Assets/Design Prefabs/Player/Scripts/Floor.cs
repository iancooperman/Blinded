using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private BoxCollider coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider>();
    }

    public void PlayStepSound()
    {
        switch (tag)
        {
            case "FootstepSnow":
                GameObject.Find("Player").GetComponent<GridMovement>().PlayStepSound(GridMovement.StepSound.Snow);
                break;
            case "FootstepWood":
                GameObject.Find("Player").GetComponent<GridMovement>().PlayStepSound(GridMovement.StepSound.Wood);
                break;
        }
    }
}
