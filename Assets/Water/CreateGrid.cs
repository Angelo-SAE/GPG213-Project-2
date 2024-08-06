using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateGrid : MonoBehaviour
{
    [SerializeField] private bool usingHeightMap, usingColors;
    [SerializeField] private int maxHeight;
    [SerializeField] private Texture2D heightMap;
    [SerializeField] private int gridSizeX, gridSizeZ;
    private Vector3[] gridVertices;
    private int[] gridIndicies;
    private Color[] gridColors;

    private MeshRenderer meshRenderer;
    private MeshFilter meshFilter;
    private Material material;

    private void OnValidate()
    {
      //find a way to hide height map or grid when using height map is active
      if(usingHeightMap)
      {
        if(heightMap is not null)
        {
          CheckVerticieCount(heightMap.width, heightMap.height);
        }
      } else {
        CheckVerticieCount(gridSizeX, gridSizeZ);
      }

    }

    private void CheckVerticieCount(int x, int z)
    {
      if(x * z > 65536)
      {
        if(usingHeightMap)
        {
          Debug.LogWarning("The height map provided is larger than the max grid size. Edges may be missing.");
        } else {
          Debug.LogWarning("The grid width and height provided are larger than the max grid size.");
        }
      }
    }

    private void Start()
    {
      if(heightMap.width < 250)
      {
        gridSizeX = heightMap.width;
      } else {
        gridSizeX = 250;
      }
      if(heightMap.height < 250)
      {
        gridSizeZ = heightMap.height;
      } else {
        gridSizeZ = 250;
      }
      meshFilter = gameObject.AddComponent<MeshFilter>();
      meshRenderer = gameObject.AddComponent<MeshRenderer>();
      material = new Material(Shader.Find("Particles/Standard Surface"));
    }

    private void Update()
    {
      if(Input.GetKeyDown(KeyCode.G))
      {
        GenerateGridVertices();
        GenerateGridIndicies();
        if(usingColors)
        {
          GenerateGridColors();
        }
      }
      if(Input.GetKeyDown(KeyCode.F))
      {
        GenerateGrid();
      }
      if(Input.GetKeyDown(KeyCode.S))
      {
        AssetDatabase.CreateAsset(meshFilter.mesh, "Assets/SavedMesh.asset");
      }
    }

    private void GenerateGridVertices()
    {
      gridVertices = new Vector3[(gridSizeX + 1) * (gridSizeZ + 1)];
      for(int a = 0; a < gridSizeZ + 1; a++)
      {
        for(int b = 0; b < gridSizeX + 1; b++)
        {
          Color color = heightMap.GetPixel(b,a);
          gridVertices[(a * (gridSizeX + 1)) + b] = new Vector3(b, color.r * maxHeight, a);
        }
      }
    }

    private void GenerateGridIndicies()
    {
      gridIndicies = new int[(gridSizeX  * gridSizeZ) * 6];
      for(int a = 0; a < gridSizeZ; a++)
      {
        for(int b = 0; b < gridSizeX; b++)
        {
          gridIndicies[((a * gridSizeX) * 6) + (b * 6)] = (a * (gridSizeX + 1)) + b;
          gridIndicies[((a * gridSizeX) * 6) + (b * 6) + 1] = ((a + 1) * (gridSizeX + 1)) + b;
          gridIndicies[((a * gridSizeX) * 6) + (b * 6) + 2] = (a * (gridSizeX + 1)) + b + 1;
          gridIndicies[((a * gridSizeX) * 6) + (b * 6) + 3] = ((a + 1) * (gridSizeX + 1)) + b;
          gridIndicies[((a * gridSizeX) * 6) + (b * 6) + 4] = ((a + 1) * (gridSizeX + 1)) + b + 1;
          gridIndicies[((a * gridSizeX) * 6) + (b * 6) + 5] = (a * (gridSizeX + 1)) + b + 1;
        }
      }
    }

    private void GenerateGridColors()
    {
      gridColors = new Color[(gridSizeX + 1) * (gridSizeZ + 1)];
      for(int a = 0; a < gridSizeZ + 1; a++)
      {
        for(int b = 0; b < gridSizeX + 1; b++)
        {
          Color color = heightMap.GetPixel(b,a);
          if(color.r > 0.7f)
          {
            gridColors[(a * (gridSizeX + 1)) + b] = new Color(1f,1f,1f);
          } else if(color.r > 0.1f)
          {
            gridColors[(a * (gridSizeX + 1)) + b] = new Color(0.3f,0.3f,0.3f);
          } else {
            gridColors[(a * (gridSizeX + 1)) + b] = new Color(color.r,color.r + 0.05f,color.r);
          }

        }
      }
    }

    private void GenerateGrid()
    {
      meshFilter.mesh.vertices = gridVertices;
      meshFilter.mesh.triangles = gridIndicies;
      meshRenderer.material = material;
      meshFilter.mesh.colors = gridColors;
      meshFilter.mesh.RecalculateNormals();
    }
}
