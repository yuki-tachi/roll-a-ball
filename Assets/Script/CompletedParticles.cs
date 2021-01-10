using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using UnityEngine.Events;

public class CompletedParticles : MonoBehaviour
{
    [SerializeField]
    private UnityEvent EventHandler = new UnityEvent();

    [SerializeField]
    private GameObject Particles = null;

    void OnEnable()
    {
        Debug.Log("comp par");
        StartCoroutine(ParticleWorking());
    }

    IEnumerator ParticleWorking()
    {
        var particles = this.Particles.GetComponentsInChildren<ParticleSystem>();

        yield return new WaitWhile(() => particles.Any(value => value.IsAlive()));

        // インスペクタ上ですべてのパーティクルが再生を完了した後、実行する処理を指定する
        this.EventHandler?.Invoke();
    }

    public void OnDestroyBySelf()
    {
        Debug.Log("OnDestroyBySelf CompletedParticles");
        GameObject.Destroy(this.gameObject);
    }
}
