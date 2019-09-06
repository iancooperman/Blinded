using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public MeshRenderer meshRenderer;
    public MeshCollider meshCollider;

    private void Start() {

    }

    public void Close() {
        meshRenderer.enabled = true;
        meshCollider.enabled = true;
    }

    public void Open() {
        meshRenderer.enabled = false;
        meshCollider.enabled = false;
    }
}
