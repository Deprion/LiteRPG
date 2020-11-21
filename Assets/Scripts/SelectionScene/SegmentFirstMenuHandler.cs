using UnityEngine;

public class SegmentFirstMenuHandler : MonoBehaviour
{
    public Material material;
    void Start()
    {
        Vector3[] vertices = new Vector3[4] 
        { new Vector2(0, 0), new Vector2(1, 0), new Vector2(0, 1), new Vector2(1, 1) };
        int[] triangles = new int[6] { 0, 2, 1, 1, 2, 3 };

        GameObject gameObject = new GameObject("Mesh", typeof(MeshFilter), typeof(MeshRenderer));
        gameObject.transform.localPosition = new Vector2(-2, 0);
        gameObject.transform.localScale = new Vector2(4, 0.02f);

        Mesh mesh = new Mesh
        {
            vertices = vertices,
            triangles = triangles
        };

        gameObject.GetComponent<MeshFilter>().mesh = mesh;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }
}
