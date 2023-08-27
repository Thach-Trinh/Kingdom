using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public MonoUtility mono;
    public PlayerManagement player;
    public CinemachineVirtualCamera aimingCamera;
    public ThirdPersonCamera thirdPersonCamera;
    public MinimapCamera minimapCamera;
    public MinimapCompass compass;
    private void Start()
    {
        //Debug.Log("PlayerSpawner1");
        PlayerManagement myPlayer = Instantiate(player, transform.position, Quaternion.identity);
        aimingCamera.Follow = myPlayer.transform;
        thirdPersonCamera.target = myPlayer.transform;
        minimapCamera.target = myPlayer.transform;
        compass.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.movement.thirdPersonCamera = thirdPersonCamera.transform;
        myPlayer.weapon.thirdPersonCamera = thirdPersonCamera.gameObject;
        myPlayer.weapon.aimingCamera = aimingCamera.gameObject;
        mono.player = myPlayer;

        
        myPlayer.weapon.SetUp(WeaponType.Dagger);
        myPlayer.weapon.Equip(WeaponType.Dagger, WeaponType.Bow, WeaponType.SwordAndShield);
        //Debug.Log("PlayerSpawner2");
    }

}
