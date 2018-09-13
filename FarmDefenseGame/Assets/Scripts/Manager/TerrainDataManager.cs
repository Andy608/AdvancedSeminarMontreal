using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    //Responsible for managing chunk data.
    public class TerrainDataManager : Singleton<TerrainDataManager>
    {
        //Eventually hold a quadtree of chunk data.

        //For now hold a list.
        //private List<ChunkData> chunkDataInWorld = new List<ChunkData>();

        //private void Start()
        //{
            //Lets create one chunk at 0, 0 that is all Grass for now.
        //    chunkDataInWorld.Add(new ChunkData(new Vector2(0, 0), Managers.TileDataManager.GRASS_TILE));
        //}
    }
}
