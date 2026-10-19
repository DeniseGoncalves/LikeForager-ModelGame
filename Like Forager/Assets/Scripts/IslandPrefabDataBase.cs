using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IslandPrefabDataBase : MonoBehaviour
{
    public ResourceLoot[]  resourceLV1;
    public List<GameObject> resourceIsland = new List<GameObject>();

   
    public void CreatIslandResource()
    {
        resourceIsland.Clear();

        if(resourceLV1.Length == 0) { return;} //Se não houver recursos no array, não faz nada

        foreach(ResourceLoot l in resourceLV1)
        {
            for(int i = 0; i < l.amount; i ++)
            {
                resourceIsland.Add(l.resource);
            }
        }

    }

    
}
