using UnityEngine;
using System.Collections;
using OLDE;

public class MonkeyHoleBrush : CompoundBrush {
	
	public Mesh monkeyMesh;
	
	public override CSG GenerateCSG ()
	{
//		CSG cube = new CSG.Cube().Generate(Vector3.zero, Vector3.one, Quaternion.identity);
		CSG monkey = CSG.FromPolygons(MeshToCSGPolygons(monkeyMesh, transform.position));
		
//		return cube.Subtract(monkey);
		return monkey;
	}
	
	Polygon[] MeshToCSGPolygons(Mesh mesh, Vector3 position) {
		Polygon[] polygons = new Polygon[mesh.triangles.Length / 3];
		
		for(int i=0; i<polygons.Length; i++) {
			polygons[i] = new Polygon(VerticesFromMesh(mesh, new int[] {mesh.triangles[i*3],mesh.triangles[i*3+1],mesh.triangles[i*3+2]}, position));
		}
		
		return polygons;
	}
	
	Vertex[] VerticesFromMesh(Mesh mesh, int[] vertexIndices, Vector3 position) {
		Vertex[] vertices = new Vertex[vertexIndices.Length];
		for(int i=0; i<vertices.Length; i++) {
			vertices[i] = new Vertex(mesh.vertices[vertexIndices[i]] + position, Vector3.zero, Vector2.zero);
		}
		return vertices;
	}
}
