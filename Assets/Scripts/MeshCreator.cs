using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR;

public class MeshCreator : MonoBehaviour
{
    [SerializeField] private GameObject mesh2;

    public Mesh CreateTriangle(Vector3 posA, Vector3 posB, Vector3 posC)
    {
        //création du mesh
        Mesh mesh = new Mesh();
        mesh.name = "Procedural Quad";

        // Définir les sommets
        Vector3[] t = { posA, posB, posC };
        Vector3[] vertices = t;
        mesh.vertices = vertices;

        // Définir les triangles
        int[] triangles = new int[]
        {
            0, 2, 1, // Premier triangle
        };
        mesh.triangles = triangles;

        // Définir les UVs
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(posA.x, posA.y), // Bas gauche
            new Vector2(posB.x, posB.y), // Bas droit
            new Vector2(posC.x, posC.y), // Haut gauche
        };
        mesh.uv = uvs;

        // Recalculer les normales pour l'éclairage
        mesh.RecalculateNormals();
        return mesh;
    }
    
    public Mesh CreateRectangle2(Vector3 posA, Vector3 posB, Vector3 posC, Vector3 posD)
    {
        //création du mesh
        Mesh mesh = new Mesh();
        mesh.name = "Procedural Quad";

        // Définir les sommets
        Vector3[] t = { posA, posB, posC, posD };
        Vector3[] vertices = t;
        mesh.vertices = vertices;

        // Définir les triangles
        int[] triangles = new int[]
        {
            0, 2, 1, // Premier triangle
            2, 0, 3, // Deuxieme triangle
        };
        mesh.triangles = triangles;

        // Définir les UVs
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(posB.x, posB.y), // Bas gauche
            new Vector2(posA.x, posA.y), // Bas droit
            new Vector2(posD.x, posD.y), // Haut gauche
            new Vector2(posC.x, posC.y), // Haut droit
        };
        mesh.uv = uvs;

        // Recalculer les normales pour l'éclairage
        mesh.RecalculateNormals();
        return mesh;
    }
    
    public Mesh CreateRectangle(Vector3 posA, Vector3 posB, Vector3 posC, Vector3 posD)
    {
        //création du mesh
        Mesh mesh = new Mesh();
        mesh.name = "Procedural Quad";

        // Définir les sommets
        Vector3[] t = { posA, posB, posC, posD };
        Vector3[] vertices = t;
        mesh.vertices = vertices;

        // Définir les triangles
        int[] triangles = new int[]
        {
            0, 2, 1, // Premier triangle
            2, 0, 3, // Deuxieme triangle
        };
        mesh.triangles = triangles;

        // Définir les UVs
        Vector2[] uvs = new Vector2[]
        {
            new Vector2(posA.x, posA.y), // Bas gauche
            new Vector2(posB.x, posB.y), // Bas droit
            new Vector2(posC.x, posC.y), // Haut gauche
            new Vector2(posD.x, posD.y), // Haut droit
        };
        mesh.uv = uvs;

        // Recalculer les normales pour l'éclairage
        mesh.RecalculateNormals();
        return mesh;
    }

    public Mesh CreateCube(Vector3 posA, Vector3 posB, Vector3 posC, Vector3 posD)
    {
        Vector3 posE = posA + Vector3.up;
        Vector3 posF = posB + Vector3.up;
        Vector3 posG = posC + Vector3.up;
        Vector3 posH = posD + Vector3.up;

        Mesh mesh1 = new Mesh();
        Mesh mesh2 = new Mesh();
        Mesh newMesh = new Mesh();

        mesh1 = CreateRectangle(posA, posB, posC, posD);
        mesh2 = CreateRectangle(posA, posB, posC, posD);
        newMesh.vertices = new Vector3[mesh1.vertices.Length + mesh2.vertices.Length];
        for (int i = 0; i < mesh1.vertices.Length; i++)
        {
            newMesh.vertices[i] = mesh1.vertices[i];
        }
        for (int i = 0; i < mesh2.vertices.Length; i++)
        {
            newMesh.vertices[i + mesh1.vertices.Length] = mesh2.vertices[i];
        }

        return newMesh;
    }
    

    public void DeleteMesh()
    {
        GetComponent<MeshFilter>().mesh.Clear();
    }

    public void CreateMesh(Mesh mesh)
    {
        // Assignation du mesh au MeshFilter
        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
