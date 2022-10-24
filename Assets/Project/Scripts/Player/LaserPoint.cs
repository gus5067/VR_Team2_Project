using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPoint : MonoBehaviour
{
    public Transform shotPoint;

    private Material laserMaterial;

    public bool isOnTarget;

    public RaycastHit laserTarget;

    private Renderer renderer;

    private void Awake()
    {
        renderer = GetComponent<Renderer>();
    }
    private void Start()
    {
        laserMaterial = gameObject.GetComponent<Material>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            Laser();
        }
    }

    private void Laser()
    {
        RaycastHit hit;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 200f))
        {
            laserTarget = hit;
            Debug.Log(laserTarget.transform.name + " ¡∂¡ÿ¡ﬂ");
            ShowLaser(laserTarget);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowLaser(RaycastHit hit)
    {
        if(hit.transform.tag == "Interact")
        {
            renderer.material.color = Color.green;
        }
        else
        {
            renderer.material.color = Color.red;
        }
        transform.position = Vector3.Lerp(shotPoint.position, hit.point, 0.5f);
        transform.LookAt(hit.point);
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, hit.distance);
    }

}
