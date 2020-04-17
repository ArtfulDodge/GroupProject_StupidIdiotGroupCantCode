using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestructionDelegate : MonoBehaviour
{
    public delegate void TreeDelegate(GameObject enemy);
    public TreeDelegate treeDelegate;

    void OnDestroy()
    {
        if (treeDelegate != null)
        {
            treeDelegate(gameObject);
        }
    }
}
