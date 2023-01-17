using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {
    [SerializeField] GameObject enemyPrehab;
    private GameObject enemy;
    public const float baseSpeed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) {
            enemy = Instantiate(enemyPrehab) as GameObject;
            enemy.transform.position = new Vector3(0, 1, 0);
            float angle = Random.Range(0, 360);
            enemy.transform.Rotate(0, angle, 0);
        }
        
    }

    private void OnEnable()
    {
        Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, SetEnemySpeed);
    }
    private void OnDisable()
    {
        Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, SetEnemySpeed);
    }

    private void SetEnemySpeed(float value)
    {
        enemyPrehab.GetComponent<WanderingAI>().speed = baseSpeed * value;
    }
}
