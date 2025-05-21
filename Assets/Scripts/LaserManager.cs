using System.Collections.Generic;
using UnityEngine;

public class LaserManager : MonoBehaviour
{
    #region singleton
    private static LaserManager lManager;
    public static LaserManager LM => lManager;
    private void Awake()
    {
        if (lManager != null && lManager != this) Destroy(this.gameObject);
        else lManager = this;
        DontDestroyOnLoad(this.gameObject);
    }
    #endregion

    [SerializeField] private MeshCreator mc;
    private List<Vector3> positionCollisions = new();
    [SerializeField] private GameObject laserPrefab;
    private List<GameObject> lasers = new();
    [SerializeField] private float step;


    [field: SerializeField] public int TokenNumber { get; private set; }
    public void AddTransform(Vector3 v)
    {
        positionCollisions.Add(v);
        DeleteLasers();
        ApplyLaser();
    }
    private void ApplyLaser()
    {
        if (NumberOfLasers() >= 2)
        {
            if (NumberOfLasers() > 3)
            {
                Mesh m = mc.CreateRectangle(positionCollisions[0], positionCollisions[1], positionCollisions[2], positionCollisions[3]);
                mc.CreateMesh(m);
            }
            for (int l = 0; l < NumberOfLasers() - 1; l++)
            {
                PlaceLasers(positionCollisions[l], positionCollisions[l + 1], step);
            }

            for (int i = 0; i < 10; i++)
            {
                PlaceLasers(positionCollisions[^1], positionCollisions[0], step);
            }
        }
    }
    private void PlaceLasers(Vector3 position1, Vector3 position2, float step)
    {
        for (int i = 0; i < step; i++)
        {
            float f = i / step;
            Vector3 positionLaser = Vector3.Lerp(position1, position2, f);
            lasers.Add(Instantiate(laserPrefab, positionLaser, Quaternion.identity, transform));
        }
    }
    public void DeleteLasers()
    {
        for (int i = 0; i < lasers.Count; i++) Destroy(lasers[i]);
    }
    public void RemovePositions()
    {
        positionCollisions = new();
        DeleteLasers();
        mc.DeleteMesh();
    }
    public int NumberOfLasers() => positionCollisions.Count;
}