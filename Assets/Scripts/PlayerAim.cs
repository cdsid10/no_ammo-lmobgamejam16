using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    private Audio _audio;
    private PlayerSaber _playerSaber;
    
    public GameObject crosshair;
    public GameObject player;
    private Vector3 target;
    [SerializeField] private Transform playerTarget;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        _audio = FindObjectOfType<Audio>();
        _playerSaber = FindObjectOfType<PlayerSaber>();
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        target = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0,0, rotationZ);
    }
    
    
}
