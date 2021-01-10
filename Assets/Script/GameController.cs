using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreLabel = null;
    public GameObject winnerLabelObject;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var count = GameObject.FindGameObjectsWithTag("Item").Length;
        scoreLabel.text = count.ToString();
        if (count == 0)
        {
            winnerLabelObject.SetActive(true);
        }
    }
}
