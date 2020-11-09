using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Board : MonoBehaviour
{
    public GameObject tile;
    public static Board _instance;
    public Col Turn;


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
            go.name =""+ (char)('a' + (i % 8)) + (i / 8 + 1);
            //Debug.Log(go.GetComponent<Tile>().address);
        }
    }

    void Start()
    {
        Turn = Col.White;
    }

    public Tile[] GetTiles()
    {
        return _instance.GetComponentsInChildren<Tile>();
    }

    public static Tile[] RayCast(Tile startPos, Vector2Int dir, int maxDistance, Col color)
    {
        List<Tile> ret = new List<Tile>();

        for (int i = 1; i < maxDistance; i++)
        {
            char c = (char)(startPos.address.Item1 + (char)(i * dir.x));
            int y = startPos.address.Item2 + (i * dir.y);
            Tile buff = Board._instance.GetTile(c, y);
            if(buff != null)
            {
                if (buff.onTheBoard == null) 
                {
                    ret.Add(buff);
                }
                else if (color != buff.onTheBoard.color)
                {
                    ret.Add(buff);
                    break;
                }
                else if(color == buff.onTheBoard.color)
                {
                    break;
                }

            }

        }

        return ret.ToArray();
    }

    public Tile GetTile(string address)
    {
        Tuple<char, int> buff;
        Tile ret = null;
        if(address.Length != 2)
        {
            Debug.LogError("Wrong parameter " + address);
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

    public Tile GetTile(Tuple<char, int> address)
    {
        
        Tile ret = null;
        int second;
        //TODO: optimize this loop
        foreach (Tile t in GetComponentsInChildren<Tile>())
        {
            if (address.Item1 == t.address.Item1 && address.Item2 == t.address.Item2) ret = t;
        }
        return ret;
    }

    public Tile GetTile(char c, int i)
    {

        Tile ret = null;
        int second;
        //TODO: optimize this loop
        foreach (Tile t in GetComponentsInChildren<Tile>())
        {
            if (c == t.address.Item1 && i == t.address.Item2) ret = t;
        }
        return ret;
    }
}
