using System.Collections;
using System.Collections.Generic;
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
    }

    void Start()
    {
        for (int i = 0; i < 64; i++)
        {
            Vector3 v = new Vector3(i % 8 - 4, i / 8 - 4);
            GameObject go = Instantiate(tile, v, Quaternion.identity);
            go.transform.parent = gameObject.transform;
            if (i % 2 == 0)
                if ((i / 8) % 2 == 0) go.GetComponent<SpriteRenderer>().color = Color.grey;
            if (i % 2 == 1)
                if ((i / 8) % 2 == 1) go.GetComponent<SpriteRenderer>().color = Color.grey;
        }
    }

    public Tile[] GetTiles()
    {
        return _instance.GetComponentsInChildren<Tile>();
    }

}
