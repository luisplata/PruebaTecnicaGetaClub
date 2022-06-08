using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameplay : MonoBehaviour
{
    [SerializeField] private InputFacade inputFacade;
    [SerializeField] private GameObject explosionPrefab, firePrefab;
    [SerializeField] private GameObject player;
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
        //Ray ray = Physics.Raycast(player.transform.position, )
        
        //logica del raycast
        RaycastHit[] hits;
        // Does the ray intersect any objects excluding the player layer
        hits = Physics.RaycastAll(ray);
        foreach (var hitTarget in hits)
        {
            //Debug.Log($"{hitTarget.collider.transform.name} colisiono v2 - tag {hitTarget.collider.transform.tag}"); 
            if (!hitTarget.collider.transform.CompareTag("Explotion")) continue;
            //Debug.Log($"{hitTarget.collider.gameObject.name} colisiono");
            //CreateExplosion(hitTarget.collider.gameObject.transform,hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));
            CreateRayFromPlayer(hitTarget.point);
            return;
        }
        
        foreach (var hitTarget in hits)
        {
            //Debug.Log($"{hitTarget.collider.transform.name} colisiono v2 - tag {hitTarget.collider.transform.tag}"); 
            if (!hitTarget.collider.transform.CompareTag("Plane")) continue;
            //Debug.Log($"{hitTarget.collider.gameObject.name} colisiono");
            //CreateExplosion(hitTarget.collider.gameObject.transform,hitTarget.point, Quaternion.FromToRotation(Vector3.up, hitTarget.normal));
            CreateRayFromPlayer(hitTarget.point);
            return;
        }

    }

    private void CreateRayFromPlayer(Vector3 pointToCollision)
    {
        var position = player.transform.position;
        var raycastHits = Physics.RaycastAll(position, pointToCollision - position);
        
        foreach (var raycastHit in raycastHits)
        {
            if (!raycastHit.collider.transform.CompareTag("Explotion")) continue;
            CreateExplosion(raycastHit.collider.gameObject.transform,raycastHit.point, Quaternion.FromToRotation(Vector3.up, raycastHit.normal));
            Debug.DrawRay(position, (pointToCollision - position) * 100, Color.green);
            return;
        }
        
        foreach (var raycastHit in raycastHits)
        {
            if (!raycastHit.collider.transform.CompareTag("Plane")) continue;
            CreateExplosion(raycastHit.collider.gameObject.transform,raycastHit.point, Quaternion.FromToRotation(Vector3.up, raycastHit.normal));
            Debug.DrawRay(position, (pointToCollision - position) * 100, Color.green);
            return;
        }
    }

    private void CreateExplosion(Transform gameObjectTransform, Vector3 position, Quaternion rotation)
    {
        //explosion
        Instantiate(explosionPrefab, position, rotation, gameObjectTransform);
    }
}
