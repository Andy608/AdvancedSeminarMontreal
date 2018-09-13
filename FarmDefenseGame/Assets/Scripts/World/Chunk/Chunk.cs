using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
    public const int WIDTH = 16;
    public const int HEIGHT = 16;

    public Vector2 worldPosition;

    private GameObject tilePrefab;
    private GameObject[] tiles = new GameObject[WIDTH * HEIGHT];
    private TileData[] tileData = new TileData[WIDTH * HEIGHT];

    private void Awake()
    {
        Debug.Log("HELLO");
        //Move this to a resource manager.
        tilePrefab = Resources.Load<GameObject>("Terrain/Tile");
    }

    public void InitChunk(Vector2 position)
    {
        worldPosition = position;

        //Move chunk to correct position.
        transform.position = worldPosition;

        //Init tile data to grass for now
        InitTileData(Managers.TileDataManager.GRASS_TILE);

        //Create the Tile GameObjects
        InitGameTiles();
    }

    //Initializes all the tiles in the chunk to the tile given by default.
    //In the future we will generate the tiles differently.
    private void InitTileData(TileData tile)
    {
        int i = 0;
        for (; i < tileData.Length; ++i)
        {
            tileData[i] = tile;
        }
    }

    //Creates all of the tile objects from the tile data for this chunk.
    private void InitGameTiles()
    {
        Vector2 tileCoordinate = new Vector2();

        Debug.Log(tilePrefab);

        int i = 0;
        for (; i < tiles.Length; ++i)
        {
            GetCoordFromIndex(i, ref tileCoordinate);
            tiles[i] = Instantiate(tilePrefab);
            tiles[i].transform.parent = gameObject.transform;
            tiles[i].transform.localPosition = tileCoordinate;
            tiles[i].name = "Tile: [ " + tileCoordinate.x.ToString() + ", " + tileCoordinate.y.ToString() + " ]";
            tiles[i].GetComponent<Tile>().tileData = tileData[i];
        }
    }

    public int GetIndexFromCoord(Vector2Int coord)
    {
        return WIDTH * coord.y + coord.x;
    }

    public void GetCoordFromIndex(int index, ref Vector2 coord)
    {
        coord.x = index % WIDTH;
        coord.y = index / HEIGHT;
    }
}
