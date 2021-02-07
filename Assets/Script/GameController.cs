using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        ready,
        play,
        damage,
        gameover,
    }

    private GameState CurrentGameState = GameState.ready;

    [SerializeField] public Text scoreLabel = null;
    [SerializeField] public Text remainLifeLabel = null;
    [SerializeField] public GameObject winnerLabelObject;
    [SerializeField] public GameObject readyLabelObject;
    [SerializeField] public GameObject puck;
    [SerializeField] public GameObject stricker;

    private int PlayerMaxLife = 3;
    private int PlayerCurrentLife = 0;

    private CancellationTokenSource cts;

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

    async void Start()
    {
        await Task.Delay(2000);
        this.cts = new CancellationTokenSource();
        _ = this.ChangeGameState(GameState.ready);
    }

    public async Task SetCurrentState(GameState state)
    {
        this.CurrentGameState = state;
        await ChangeGameState(this.CurrentGameState);
    }

    // Update is called once per frame
    void Update()
    {
        var count = GameObject.FindGameObjectsWithTag("Block").Length;
        scoreLabel.text = $"block:{count}";
        remainLifeLabel.text = $"left:{PlayerCurrentLife}";

        if (count == 0)
        {
            winnerLabelObject.SetActive(true);
        }
    }

    private async Task ChangeGameState(GameState state)
    {
        GameObject puck;
        switch (state)
        {
            case GameState.ready:

                this.PlayerCurrentLife = this.PlayerMaxLife;

                this.readyLabelObject.GetComponent<Text>().text = "Ready";
                this.readyLabelObject.SetActive(true);

                await Task.Delay(2000, this.cts.Token);
                this.readyLabelObject.GetComponent<Text>().text = "Go!!!";
                await Task.Delay(1000, this.cts.Token);

                this.readyLabelObject.SetActive(false);

                puck = Instantiate(this.puck);
                puck.transform.SetParent(this.transform, false);

                await this.ChangeGameState(GameState.play);
                break;
            case GameState.damage:
                if (this.cts.IsCancellationRequested)
                {
                    return;
                }
                this.readyLabelObject.GetComponent<Text>().text = "Retry";
                this.readyLabelObject.SetActive(true);

                await Task.Delay(2000, this.cts.Token);
                this.readyLabelObject.GetComponent<Text>().text = "Go!!!";
                await Task.Delay(1000);

                puck = Instantiate(this.puck);
                puck.transform.SetParent(this.transform, false);

                break;
            case GameState.play:

                break;
            case GameState.gameover:
                this.readyLabelObject.GetComponent<Text>().text = "game over";
                await Task.Delay(2000, this.cts.Token);
                SceneManager.LoadScene("SampleScene");
                break;
            default:
                break;
        }
    }

    public async Task AddDamage()
    {
        this.PlayerCurrentLife--;
        if (this.PlayerCurrentLife < 0)
        {
            await this.ChangeGameState(GameState.gameover);
        }

        await this.ChangeGameState(GameState.damage);
    }

    void OnDestroy()
    {
        this.cts.Cancel();
    }
}
