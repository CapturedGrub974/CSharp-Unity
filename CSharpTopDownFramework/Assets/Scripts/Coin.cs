using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value;

    public Transform objTrans;
    private float delay = 0;
    private float pasttime = 0;
    private float when = 1f;
    private Vector3 off;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (when >= delay)
        {
            pasttime = Time.deltaTime;
            objTrans.position += off * Time.deltaTime;
            delay += pasttime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            CoinCounter.instance.IncreaseCoins(value);
        }
    }

    private void Awake()
    {
        off = new Vector3(Random.Range(-3, 3), off.y, off.z);
        off = new Vector3(off.x, Random.Range(-3, 3), off.z);
    }
}