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
        /// Any verts in the same position will be treated as the same vert
        /// </summary>
        public static Mesh RemoveVertDoubles(Mesh _mesh)
        {
            throw new System.NotImplementedException();
        }


    }

}
