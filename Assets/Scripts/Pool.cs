using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pool : MonoBehaviour
{
    Stack<GameObject> coinPool = new Stack<GameObject>();
    public GameObject coinPrefab;
    public GameObject currentCoin;

    public static Pool instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

    }
    private void Start()
    {
        CoinSpawning();
    }
    public void Createpool()
    {
        coinPool.Push(Instantiate(coinPrefab));
        coinPool.Peek().SetActive(false);
        coinPool.Peek().tag = "Coin";
    }

    public void AddCoin(GameObject coinTemp)
    {
        coinPool.Push(coinTemp);
        coinPool.Peek().SetActive(false);
    }


    public void CoinSpawning()
    {
        if(coinPool.Count <=1)
        {
            Createpool();
        }
        GameObject temp = coinPool.Pop();
        if (temp.tag == "Coin")
        {
            //Debug.Log(LayerMask.LayerToName(6));
            temp.SetActive(true);
            temp.transform.position = new Vector3(Random.Range(-8f, 8f), 0.45f, Random.Range(-8f, 8f));
            currentCoin = temp;
        }
    }
}
