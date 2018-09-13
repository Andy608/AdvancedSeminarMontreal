using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    //Responsible for converting valid chunk data to chunk GameObjects and load them in the world.
    public class WorldChunkManager : Singleton<WorldChunkManager>
    {
        //Eventually hold a quadtree of chunk data.

        //For now hold a list.
        private List<Chunk> chunksInWorld = new List<Chunk>();

        private GameObject chunkPrefab;

        private void Start()
        {
            chunkPrefab = Resources.Load<GameObject>("Terrain/Chunk");

            //This is going to change. Just some really crude generation right now.
            for (int i = -1; i < 1; ++i)
            {
                for (int j = -1; j < 1; ++j)
                {
                    Chunk chunk = Instantiate(chunkPrefab).GetComponent<Chunk>();
                    chunk.InitChunk(new Vector2(i * Chunk.WIDTH, j * Chunk.HEIGHT));
                    chunk.name = "Chunk [ " + i + ", " + j + " ]";

                    chunksInWorld.Add(chunk.GetComponent<Chunk>());
                }
            }
        }
    }
}
