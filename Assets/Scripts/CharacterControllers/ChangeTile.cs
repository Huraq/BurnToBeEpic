using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChangeTile : MonoBehaviour
{

    public TileBase tile;
    public Tilemap tilemap;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            tilemap.SetTile(new Vector3Int(-9, 0, 0), tile);
    }
}