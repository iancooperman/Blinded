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
            case "FootstepMetal":
                GameObject.Find("Player").GetComponent<GridMovement>().PlayStepSound(GridMovement.StepSound.Metal);
                break;
            case "FootstepGrass":
                GameObject.Find("Player").GetComponent<GridMovement>().PlayStepSound(GridMovement.StepSound.Grass);
                break;
            case "FootstepWater":
                GameObject.Find("Player").GetComponent<GridMovement>().PlayStepSound(GridMovement.StepSound.Water);
                break;
            case "FootstepDirt":
                GameObject.Find("Player").GetComponent<GridMovement>().PlayStepSound(GridMovement.StepSound.Dirt);
                break;
            case "FootstepMud":
                GameObject.Find("Player").GetComponent<GridMovement>().PlayStepSound(GridMovement.StepSound.Mud);
                break;
        }
    }
}
