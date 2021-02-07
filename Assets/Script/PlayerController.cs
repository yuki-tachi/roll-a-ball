using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 FieldSize;
    [SerializeField] Joystick Joystick;
    [SerializeField] public float speed = 20;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var rb = GetComponent<Rigidbody>();
        Vector3 direction = Vector3.forward * Joystick.Vertical + Vector3.right * Joystick.Horizontal;
        // this.gameObject.transform.position += direction * speed * Time.fixedDeltaTime;

        var posX = Mathf.Clamp(rb.position.x + (direction.x * speed * Time.fixedDeltaTime), -FieldSize.x / 2f, FieldSize.x / 2f);
        var posZ = Mathf.Clamp(rb.position.z + (direction.z * speed * Time.fixedDeltaTime), -FieldSize.y / 2f, 0);
        rb.MovePosition(new Vector3(posX, 0, posZ));
        // rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
    }
}
