using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RayShooter : MonoBehaviour
{
    private Camera cam;
    [SerializeField] GameObject controller;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();

        /* Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; */
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Cursor.visible)
            {
                controller.GetComponent<CursorController>().HideCursor();
            } else
            {

            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    GameObject hitObject = hit.transform.gameObject;
                    ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                    if (target != null)
                    {
                        target.ReactToHit();
                        Messenger.Broadcast(GameEvent.ENEMY_HIT);
                    }
                    else
                    {
                        StartCoroutine(SphereIndicator(hit.point));
                    }
                }
            }
        }
    }
    public void OnGUI()
    {
        int size = 12;
        float posX = cam.pixelWidth / 2 - size / 4;
        float posY = cam.pixelHeight / 2 - size / 4;
        GUI.Label(new Rect(posX, posY, size, size), "*");

    }

    private IEnumerator SphereIndicator(Vector3 position)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = position;

        yield return new WaitForSeconds(1);
        Destroy(sphere);
    }

}
