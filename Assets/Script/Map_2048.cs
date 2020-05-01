using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map_2048
{
    public Map_2048()
    {
        Mapper = new int[4, 4];
        for (int i = 0; i < Mapper.GetLength(0); i++)
        {
            for (int j = 0; j < Mapper.GetLength(1); j++)
            {
                Mapper[i, j] = 0;
            }
        }

    }


    public int[,] Mapper;

}