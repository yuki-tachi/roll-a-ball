using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text scoreLabel = null;
    public Text remainLifeLabel = null;
    public GameObject winnerLabelObject;

    private int PlayerMaxLife = 3;
    private int PlayerCurrentLife = 0;

    private static GameController _instance = null;
    public static GameController Instance
    {
        get
        {
            return _instance;
        }
        private set
        {

        }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        this.PlayerCurrentLife = this.PlayerMaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        var count = GameObject.FindGameObjectsWithTag("Block").Length;
        scoreLabel.text = $"block:{count.ToString()}";
        remainLifeLabel.text = $"left:{PlayerCurrentLife.ToString()}";
        if (count == 0)
        {
            winnerLabelObject.SetActive(true);
        }
    }

    public void AddDamage()
    {
        this.PlayerCurrentLife--;
    }
}
