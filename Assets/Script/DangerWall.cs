using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DangerWall : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionObj = null;

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("Puck"))
        {

            var hitPos = hit.contacts[0].point;
            var instance = Instantiate(this.explosionObj, hitPos, Quaternion.identity);
            Destroy(gameObject);
            // explosionObj.transform.position = hitPos;
            // instance.SetActive(true);
            // Debug.Log(hit.contacts);
            // Destroy(this.gameObject);
        }
    }

    // void OnTriggerEnter(Collider hit)
    // {
    //     if (hit.CompareTag("Puck"))
    //     {
    //         Destroy(gameObject);
    //     }
    // }

    public void OnDestroyBySelf()
    {
        Debug.Log("OnDestroyBySelf");
        GameObject.Destroy(this);
    }

    private void retry()
    {
        var sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
