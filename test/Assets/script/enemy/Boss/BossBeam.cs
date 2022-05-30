using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class BossBeam : MonoBehaviour
{
    public LevelHealth LevelHealth;
    public GameObject plyr;
    public enemy_hp enemy;
    public Transform Beam;
    public float BeamRange =10f;
    public float BeamDuration = 0.05f;
    LineRenderer Laser;

    private void Awake()
    {
        Laser = GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (enemy.Health == 250)
        {
            Laser.SetPosition(0, Beam.position);
            Vector3 rayOrigin = plyr.transform.position;
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, plyr.transform.position ,out hit, BeamRange))
            {
                Laser.SetPosition(1, hit.point);
              //  LevelHealth.levelHealth -= 1;
            }
            StartCoroutine(ShootBeam());
        }
    }
    IEnumerator ShootBeam()
    {
        Laser.enabled = true;
        yield return new WaitForSeconds(BeamDuration);
        Laser.enabled = false;
    }
}
