using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Vector2 FieldSize;

    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var x = Input.GetAxis("Horizontal");
        var z = Input.GetAxis("Vertical");
        var rigidbody = GetComponent<Rigidbody>();
        var posX = Mathf.Clamp(rigidbody.position.x + (x * speed * Time.deltaTime), -FieldSize.x / 2f, FieldSize.x / 2f);
        var posZ = Mathf.Clamp(rigidbody.position.z + (z * speed * Time.deltaTime), -FieldSize.y / 2f, 0);

        rigidbody.MovePosition(new Vector3(posX, 0, posZ));
    }
}
