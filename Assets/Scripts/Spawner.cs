using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    private Vector3 mousePos;
    private float cooldown = 0;
    private float currentBomb = 0;
	
	void Update () {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        mousePos = Input.mousePosition;
        mousePos.z = 10f;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBomb = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBomb = 1;
        }

        if (Input.GetMouseButtonDown(0) && (cooldown <= 0))
        {
            if (currentBomb == 0)
            {
                Instantiate(Resources.Load("Bomb"), mousePos, transform.rotation);
                cooldown = 2.5f;
            }
            if (currentBomb == 1)
            {
                Instantiate(Resources.Load("ClusterBomb"), mousePos, transform.rotation);
                cooldown = 2.5f;
            }
        }
    }
}