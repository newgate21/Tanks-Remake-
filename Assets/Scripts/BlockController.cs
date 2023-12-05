using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    public GameObject BlockPrefab;
    List<Vector3> BlockPositions = new List<Vector3>();
    Block[] blocks;

    private void Awake()
    {
        blocks = GetComponentsInChildren<Block>();

        foreach (Block block in blocks)
        {
            BlockPositions.Add(block.transform.position);
        }

        ResetBlocks();
    }

    public void ResetBlocks()
    {
        for (int i = blocks.Length - 1; i >= 0; i--)
        {
            if (blocks[i] != null)
            {
                Destroy(blocks[i].gameObject);
            }
        }

        for (int i = 0; i < BlockPositions.Count; i++)
        {
            GameObject newBlock = GameObject.Instantiate(BlockPrefab, BlockPositions[i], Quaternion.identity, transform);
            blocks[i] = newBlock.GetComponent<Block>();
        }
    }
}
