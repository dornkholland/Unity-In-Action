using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;
    
    private bool isAlive;
    [SerializeField] GameObject fireballPrefab;
    private GameObject fireball;
    // Start is called before the first frame update
    void Start() {
        isAlive = true;
    }

    // Update is called once per frame
    void Update() {
        if (isAlive) {
            this.transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, .75f, out hit)) {
                GameObject hitobject = hit.transform.gameObject;
                if (hitobject.GetComponent<PlayerCharacter>()) {
                    if (fireball == null) {
                        fireball = Instantiate(fireballPrefab) as GameObject;
                        fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        fireball.transform.rotation = transform.rotation;
                    }
                } else if (hit.distance < obstacleRange) {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
    }

    public void SetAlive(bool alive) {
        isAlive = alive;
    }
}
