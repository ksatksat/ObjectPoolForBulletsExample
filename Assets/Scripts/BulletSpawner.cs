using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    GameObject bullet;
    public GameObject turret;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            bullet = ObjectPool.SharedInstance.GetPooledObject();
            if (bullet != null)
            {
                bullet.transform.position = turret.transform.position;
                bullet.transform.rotation = turret.transform.rotation;
                bullet.SetActive(true);
                StartCoroutine(DeactivateSpawnedObject(bullet));
            }
        }
    }
    IEnumerator DeactivateSpawnedObject(GameObject obj)
    {
        yield return new WaitForSeconds(1f);
        obj.SetActive(false);
    }
}
