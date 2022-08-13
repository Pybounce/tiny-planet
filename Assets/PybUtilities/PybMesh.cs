using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PybUtilities
{
    public class PybMesh
    {

        /// <summary>
        /// All meshes will be merged into 1 mesh
        /// </summary>
        public static Mesh CombineMeshes(Mesh[] _meshes)
        {
            Mesh _newMesh = new Mesh();
            Vector3[] _verts = new Vector3[0];
            Vector3[] _normals = new Vector3[0];
            int[] _triangles = new int[0];

            foreach (Mesh _mesh in _meshes)
            {
                int _vertIndexOffset = _verts.Length;    //The index of verts added to the new mesh will be offset by how many are already in the mesh
                int[] _meshTriangles = new int[_mesh.triangles.Length];
                for (int triIndex = 0; triIndex < _mesh.triangles.Length; triIndex++)
                {
                    _meshTriangles[triIndex] = _mesh.triangles[triIndex] + _vertIndexOffset;
                }
                _verts = PybArray.Concat(_verts, _mesh.vertices);
                _normals = PybArray.Concat(_normals, _mesh.normals);
                _triangles = PybArray.Concat(_triangles, _meshTriangles);

            }
            _newMesh.vertices = _verts;
            _newMesh.normals = _normals;
            _newMesh.triangles = _triangles;
            return _newMesh;
        }

        /// <summary>
        /// Any verts in the same position will be treated as the same vert. Removes any doubled verts.
        /// </summary>
        public static Mesh RemoveVertDuplicates(Mesh _mesh)
        {
            int yeet = 0;
            int currentActualVertIndex = 0;

            Dictionary<Vector3, int> _vertDuplicates = new Dictionary<Vector3, int>();

            List<Vector3> _verts = new List<Vector3>();
            List<Vector3> _normals = new List<Vector3>();
            List<int> _triangles = new List<int>();

            for (int i = 0; i < _mesh.vertices.Length; i++)
            { 
                Vector3 _vert = _mesh.vertices[i];
                if (_vertDuplicates.ContainsKey(_vert))
                {
                    //dupe found
                    yeet += 1;
                }
                else
                {
                    _vertDuplicates.Add(_vert, currentActualVertIndex);
                    currentActualVertIndex += 1;
                    _verts.Add(_vert);
                    _normals.Add(_mesh.normals[i]);

                }
            }

            for (int i = 0; i < _mesh.triangles.Length; i++)
            {
                Vector3 _vert = _mesh.vertices[_mesh.triangles[i]];
                int _newVertIndex = _vertDuplicates[_vert];
                _triangles.Add(_newVertIndex);
            }

            Mesh _returnMesh = new Mesh();
            _returnMesh.vertices = _verts.ToArray();
            _returnMesh.triangles = _triangles.ToArray();
            _returnMesh.normals = _normals.ToArray();
            return _returnMesh;

        }


    }

}
