using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var rb = this.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, -0.5f)), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
