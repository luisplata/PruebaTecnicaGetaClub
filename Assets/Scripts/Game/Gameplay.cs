using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private InputFacade inputFacade;
    [SerializeField] private GameObject explosionPrefab, firePrefab;
    private Vector2 pointToMouse;
    // Start is called before the first frame update
    void Start()
    {
        inputFacade.OnFire += OnFire;
        inputFacade.OnMovement += OnMovement;
    }

    private void OnMovement(Vector2 obj)
    {
        //Debug.Log("Movement: " + obj);//Ok
        pointToMouse = obj;
    }

    private void OnFire()
    {
        Ray ray = Camera.main.ScreenPointToRay(pointToMouse);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red);
        
        //logica del raycast
        RaycastHit[] hits;
        // Does the ray intersect any objects excluding the player layer
        hits = Physics.RaycastAll(ray);
        foreach (var hitTarget in hits)
        {
            //Debug.Log($"{hitTarget.collider.transform.name} colisiono v2 - tag {hitTarget.collider.transform.tag}"); 
            if (!hitTarget.collider.transform.CompareTag("Explotion")) continue;
            Debug.Log($"{hitTarget.collider.gameObject.name} colisiono");
            CreateExplosion(hitTarget.collider.gameObject.transform,hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));
            return;
        }
        
        foreach (var hitTarget in hits)
        {
            //Debug.Log($"{hitTarget.collider.transform.name} colisiono v2 - tag {hitTarget.collider.transform.tag}"); 
            if (!hitTarget.collider.transform.CompareTag("Plane")) continue;
            Debug.Log($"{hitTarget.collider.gameObject.name} colisiono");
            CreateExplosion(hitTarget.collider.gameObject.transform,hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));
            return;
        }

    }

    private void CreateExplosion(Transform gameObjectTransform, Vector3 position, Quaternion rotation)
    {
        //explosion
        Instantiate(explosionPrefab, position, rotation, gameObjectTransform);
        //fire
        //Instantiate(firePrefab, position, rotation, gameObjectTransform);
    }
}
