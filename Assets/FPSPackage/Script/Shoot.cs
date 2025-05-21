using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Camera startShoot;
    private RaycastHit hit;
    [SerializeField] private GameObject collisionGameObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ShootProjectile();
        if (Input.GetKeyDown(KeyCode.Backspace)) RemoveProjectiles();
    }
    private void ShootProjectile()
    {
        Physics.Raycast(startShoot.transform.position, startShoot.transform.forward, out hit, 500f);
        if (LaserManager.LM.TokenNumber > LaserManager.LM.NumberOfLasers())
        {
            Instantiate(collisionGameObject, hit.point, Quaternion.identity);
            LaserManager.LM.AddTransform(hit.point);
        }
    }
    private void RemoveProjectiles() => LaserManager.LM.RemovePositions();
}
