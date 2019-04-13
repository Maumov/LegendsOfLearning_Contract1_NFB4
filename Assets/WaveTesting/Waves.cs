﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{
    //Public Properties
    public int Dimension = 10;
    public float UVScale = 2f;
    public Octave[] Octaves;

    //mesh
    protected MeshFilter MeshFilter;

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter = gameObject.GetComponent<MeshFilter>();
        //MeshFilter.mesh Setup

        MeshFilter.mesh.Clear();
        MeshFilter.mesh.vertices = GenerateVerts();
        MeshFilter.mesh.triangles = GenerateTries();
        MeshFilter.mesh.uv = GenerateUVs();
        MeshFilter.mesh.RecalculateNormals();
        MeshFilter.mesh.RecalculateBounds();

        GetComponent<MeshCollider>().sharedMesh = MeshFilter.mesh;
        transform.position = new Vector3(-(transform.localScale.x * Dimension) / 2, transform.position.y, -(transform.localScale.z * Dimension) / 2);
    }

    

    private Vector3[] GenerateVerts()
    {
        var verts = new Vector3[(Dimension + 1) * (Dimension + 1)];

        //equaly distributed verts
        for(int x = 0; x <= Dimension; x++)
            for(int z = 0; z <= Dimension; z++)
                verts[index(x, z)] = new Vector3(x, 0, z);

        return verts;
    }

    private int[] GenerateTries()
    {
        var tries = new int[MeshFilter.mesh.vertices.Length * 6];

        //two triangles are one tile
        for(int x = 0; x < Dimension; x++)
        {
            for(int z = 0; z < Dimension; z++)
            {
                tries[index(x, z) * 6 + 0] = index(x, z);
                tries[index(x, z) * 6 + 1] = index(x + 1, z + 1);
                tries[index(x, z) * 6 + 2] = index(x + 1, z);
                tries[index(x, z) * 6 + 3] = index(x, z);
                tries[index(x, z) * 6 + 4] = index(x, z + 1);
                tries[index(x, z) * 6 + 5] = index(x + 1, z + 1);
            }
        }

        return tries;
    }

    private Vector2[] GenerateUVs()
    {
        var uvs = new Vector2[MeshFilter.mesh.vertices.Length];

        //always set one uv over n tiles than flip the uv and set it again
        for (int x = 0; x <= Dimension; x++)
        {
            for (int z = 0; z <= Dimension; z++)
            {
                var vec = new Vector2((x / UVScale) % 2, (z / UVScale) % 2);
                uvs[index(x, z)] = new Vector2(vec.x <= 1 ? vec.x : 2 - vec.x, vec.y <= 1 ? vec.y : 2 - vec.y);
            }
        }

        return uvs;
    }

    private int index(int x, int z)
    {
        return x * (Dimension + 1) + z;
    }

    private int index(float x, float z)
    {
        return index((int)x, (int)z);
    }

    // Update is called once per frame
    void Update()
    {
        var verts = MeshFilter.mesh.vertices;
        for (int x = 0; x <= Dimension; x++)
        {
            for (int z = 0; z <= Dimension; z++)
            {
                var y = 0f;
                for (int o = 0; o < Octaves.Length; o++)
                {
                    if (Octaves[o].alternate)
                    {
                        var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x) / Dimension, (z * Octaves[o].scale.y) / Dimension) * Mathf.PI * 2f;
                        y += Mathf.Cos(perl + Octaves[o].speed.magnitude * Time.time) * Octaves[o].height;
                    }
                    else
                    {
                        var perl = Mathf.PerlinNoise((x * Octaves[o].scale.x + Time.time * Octaves[o].speed.x) / Dimension, (z * Octaves[o].scale.y + Time.time * Octaves[o].speed.y) / Dimension) - 0.5f;
                        y += perl * Octaves[o].height;
                    }
                }

                verts[index(x, z)] = new Vector3(x, y, z);
            }
        }
        MeshFilter.mesh.vertices = verts;
        MeshFilter.mesh.RecalculateNormals();
    }

    [Serializable]
    public struct Octave
    {
        public Vector2 speed;
        public Vector2 scale;
        public float height;
        public bool alternate;
    }
}
