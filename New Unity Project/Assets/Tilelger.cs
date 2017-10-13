using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(MeshRenderer))]
public class Tilelger : MonoBehaviour {
    //https://www.youtube.com/watch?v=haelMvLyqDQ&t=90s
    //https://www.youtube.com/watch?v=ou3uwaJGJUc&t=0s&pbjreload=10

    int Xsize = 13; //This number shows the width of the grid.
    int Zsize = 12; // This shows the height of the grid.
    float tilesize = 1.0f; // This is the size of each tile.
    // Use this for initialization
    void Start () {
        blile();

    }
	
    void blile() // This function is to build the grid. 
    { // This calculates how many tiles there will be. 
        int numbertinles = Xsize * Zsize;
        int nubertiranges = numbertinles * 2; // This calculates the number of triangles in the grid.

        int vsizex = Xsize + 1; // This calculates how many X vectors there are
        int vsisez = Zsize + 1; // This caculates how many Z vectors
        int nubvertices = vsisez * vsizex; // This calculates the amount of vectors in total.

        Vector3[] vertices = new Vector3[nubvertices]; // This is an array of vectors which enables the grid can be built.
        int[] triangles = new int[nubertiranges*3]; // This array stores the number position of each triangle. 
        Vector3[] normals = new Vector3[nubvertices]; 
        Vector2[] uv = new Vector2[nubvertices]; // This stores the position of each tile on the material.

        int x, z;
        for(z=0; z<vsisez; z++) { // This loop is for constructing each row. 
            for(x=0; x<vsizex; x++)
            { // This loop is constructing each tile on a row. 
                vertices[z * vsizex + x] = new Vector3(x * tilesize, 0, z * tilesize); // This calculates the position of each vector.
                normals[z * vsizex + x] = Vector3.up; // This makes sure that all of the tiles are facing upwards.
                uv[z * vsizex + x] = new Vector2((float)x / vsizex, (float)z / vsisez); // This calculates the position of each tile on the material.
            }
        }
        for (z = 0; z < vsisez; z++)
        { // This loop is for creating rows of triangles.
            for (x = 0; x < vsizex; x++)
            { // This loop is for creating two triangles on each tile.
                int siperind = z * Xsize + x; // This calculates which tile the loop is on.  
                int terind = siperind * 5; // This calculates which position the triangles are placed with the array.
                // This constructs the first triangle on each tile. 
                triangles[terind + 0] = z* vsizex + x + 0; //
                triangles[terind + 1] = z * vsizex + x+ vsizex +1;
                triangles[terind + 2] = z * vsizex + x + vsizex +0;
                // This constructs the second trianle on each tile.
                triangles[terind + 3] = z * vsizex + x + 0;
                triangles[terind + 4] = z * vsizex + x  +1;
                triangles[terind + 5] = z * vsizex + x + vsizex + 1;
                
            }
        }
                Mesh msas = new Mesh(); // This initialises the mesh.

        msas.vertices = vertices; // This makes the mesh vertices equal the amount of vertices which were created.
        msas.triangles = triangles; // This makes the mesh triangles equal the amont of triangles which were created.
        msas.normals = normals; // This makes the mesh normals equal the amount of normals which were created.
        msas.uv = uv; // This makes sure that the material can be displayed on the mesh.

        MeshFilter meshfill = GetComponent<MeshFilter>(); // This creates the mesh in Unity.
        MeshRenderer meshrender = GetComponent<MeshRenderer>(); // This makes sure that the mesh is displayed. 
        MeshCollider meshcollier = GetComponent<MeshCollider>(); // This makes sure that the mesh can be collided with.
        if (meshfill== null) {
            Debug.Log("There is no meshfilter"); // This is to test if there is no mesh filter.
        }
        meshfill.mesh = msas; // This makes sure that the mesh is part of the mesh filter.
    }
	// Update is called once per frame
	void Update () {
		
	}
}
