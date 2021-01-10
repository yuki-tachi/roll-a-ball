using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform target;

    [SerializeField]
    private float smoothTime = 2;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var targetCamPos = target.position + offset;
        // var fixPos = Vector3.Lerp(target.position, transform.position, Time.deltaTime * smoothTime) + offset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            Time.deltaTime * smoothTime
        );
        // transform.position = target.position + offset;
    }
}
