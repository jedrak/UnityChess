using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject tile;
    public static Board _instance;
    

    // Start is called before the first frame update


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        for (int i = 0; i < 64; i++)
        {
            Vector3 v = new Vector3(i % 8 - 4, i / 8 - 4);
            GameObject go = Instantiate(tile, v, Quaternion.identity);
            go.transform.parent = gameObject.transform;
            if (i % 2 == 0)
                if ((i / 8) % 2 == 0) go.GetComponent<SpriteRenderer>().color = Color.grey;
            if (i % 2 == 1)
                if ((i / 8) % 2 == 1) go.GetComponent<SpriteRenderer>().color = Color.grey;
            go.GetComponent<Tile>().address = Tuple.Create<char, int>((char)('a' + (i % 8)), i / 8 + 1);
            //Debug.Log(go.GetComponent<Tile>().address);
        }
    }

    void Start()
    {
        
    }

    public Tile[] GetTiles()
    {
        return _instance.GetComponentsInChildren<Tile>();
    }

    public Tile GetTile(string address)
    {
        Tuple<char, int> buff;
        Tile ret = null;
        if(address.Length != 2)
        {
            Debug.LogError("Wrong parameter");
            throw new ArgumentException();
        }
        int second;
        //try
        Int32.TryParse(address.Substring(1, 1), out second);
        buff = Tuple.Create<char, int>(address[0], second);
        foreach (Tile t in GetComponentsInChildren<Tile>())
        {
            if (buff.Item1 == t.address.Item1 && buff.Item2 == t.address.Item2) ret = t;
        }
        //Debug.Log(ret);
        return ret;
    }

}
