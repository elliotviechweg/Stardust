using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class updateVerts : MonoBehaviour {
	public Color[] newColors;

	void Update () {
		Mesh mesh = GetComponent<MeshFilter> ().sharedMesh;
		//Vector3[] vertices = mesh.vertices;

		// create new colors array where the colors will be created.
		Color[] colors = new Color[mesh.vertices.Length];

		for(int i = 0; i < mesh.subMeshCount; i++) {
			int[] t = mesh.GetTriangles(i);
			for (int j = 0; j < t.Length; j++) {
				colors[t[j]] = newColors[i];
			}
		}
		// assign the array of colors to the Mesh.
		mesh.colors = colors;
	}
}