using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathTest : MonoBehaviour
{
    public float speed;

    private void Update() {

        Vector3 direction = new Vector3(-1, -1, 0);
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
