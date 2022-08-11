using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PybUtilities;


[RequireComponent(typeof(PlanetGenerator))]
public class PlanetTerrainGenerator : MonoBehaviour
{
    private PlanetTerrainConfig config;
    public Mesh TerrainMesh { get; private set; }

    public void Initialise(PlanetTerrainConfig _planetTerrainConfig)
    {
        this.config = _planetTerrainConfig;
    }

    public void Generate()
    {

        Mesh[] _sphereFaces = new Mesh[6]
        {
            SubDivideQuad(new Vector3(-1, 1, 1), new Vector3(1, 1, 1), new Vector3(-1, 1, -1), new Vector3(), config.Density),
            SubDivideQuad(new Vector3(1, 1, 1), new Vector3(-1, 1, 1), new Vector3(1, -1, 1), new Vector3(), config.Density),
            SubDivideQuad(new Vector3(1, 1, -1), new Vector3(1, 1, 1), new Vector3(1, -1, -1), new Vector3(), config.Density),
            SubDivideQuad(new Vector3(-1, -1, -1), new Vector3(1, -1, -1), new Vector3(-1, -1, 1), new Vector3(), config.Density),
            SubDivideQuad(new Vector3(-1, 1, 1), new Vector3(-1, 1, -1), new Vector3(-1, -1, 1), new Vector3(), config.Density),
            SubDivideQuad(new Vector3(-1, 1, -1), new Vector3(1, 1, -1), new Vector3(-1, -1, -1), new Vector3(), config.Density)
        };
        GameObject _sphereObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
        TerrainMesh = PybMesh.CombineMeshes(_sphereFaces);
        _sphereObj.GetComponent<MeshFilter>().sharedMesh = TerrainMesh;
    }


    private Mesh SubDivideQuad(Vector3 _tl, Vector3 _tr, Vector3 _bl, Vector3 _br, int _density)
    {
        Vector3 _rightVec = (_tr - _tl).normalized;
        Vector3 _upVec = (_tl - _bl).normalized;
        Vector3 _forwardVec = Vector3.Cross(_upVec, _rightVec);

        Vector3[] _verts = new Vector3[_density * _density];
        int[] _triangles = new int[(_density - 1) * (_density - 1) * 6];
        Vector3[] _normals = new Vector3[_density * _density];

        for (int y = 0; y < _density; y++)
        {
            for (int x = 0; x < _density; x++)
            {
                int _i = x + (y * _density);
                Vector3 _vert = (((x / (_density - 1f)) - 0.5f) * 2f * _rightVec) + (((y / (_density - 1f)) - 0.5f) * 2f * _upVec) + _forwardVec;
                _verts[_i] = _vert.normalized * config.Radius;
                _normals[_i] = _vert.normalized;
                if (x < _density - 1 && y < _density - 1)
                {
                    int _ti = (_i - y) * 6;
                    _triangles[_ti + 2] = _i;
                    _triangles[_ti + 1] = _i + _density + 1;
                    _triangles[_ti] = _i + _density;
                    _triangles[_ti + 5] = _i;
                    _triangles[_ti + 4] = _i + 1;
                    _triangles[_ti + 3] = _i + _density + 1;
                }

            }
        }

        Mesh _mesh = new Mesh();
        _mesh.vertices = _verts;
        _mesh.triangles = _triangles;
        _mesh.normals = _normals;
        return _mesh;
    }

}
