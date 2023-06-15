using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public Animator coinAnimator;
    public Animator coinPowerAnimator;
    // public bool isDash = false;

    private void Awake()
    {
        

        if (instance == null)
        {

            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }

    #region PowerSelector Methods
    public enum PowerChoice
    {

        Dash,
        GrapplingHook
    }

    public PowerChoice chosenPower;

    public event Action<PowerChoice> OnPowerSelection;

    public void ChooseRandomPower()
    {

        chosenPower = (UnityEngine.Random.value < .5f) ? PowerChoice.GrapplingHook : PowerChoice.Dash;
        Debug.Log(chosenPower);

        OnPowerSelection?.Invoke(chosenPower);
    }

    public void ActivatePower(PowerChoice chosenPower)
    {

        switch (chosenPower)
        {

            case PowerChoice.Dash:
                Debug.Log("Elecci�n Dash");
                // isDash = true;
                break;

            case PowerChoice.GrapplingHook:
                Debug.Log("Elecci�n Hook");
                // isDash = false;
                break;
        }
    }

    public void HandlePowerSelection(GameManager.PowerChoice chosenPower)
    {

        if (chosenPower == GameManager.PowerChoice.Dash)
        {

            coinPowerAnimator.SetTrigger("isD");
        }

        else if (chosenPower == GameManager.PowerChoice.GrapplingHook)
        {

            coinPowerAnimator.SetTrigger("isH");
        }
    }
    #endregion

    #region WeaponSelector Methods
    public enum WeaponChoice
    {

        ThunderGun,
        Shotgun
    }

    public WeaponChoice chosenWeapon;

    public event Action<WeaponChoice> OnWeaponSelection;

    public void ChooseRandomWeapon()
    {

        chosenWeapon = (UnityEngine.Random.value < .5f) ? WeaponChoice.Shotgun : WeaponChoice.ThunderGun;
        Debug.Log(chosenWeapon);

        OnWeaponSelection?.Invoke(chosenWeapon);
    }

    public void ActivateWeapon(WeaponChoice chosenWeapon)
    {

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null) { Debug.Log("Encontr� player"); }

        Transform joint = player.transform.Find("Joint");
        if (joint != null) { Debug.Log("Encontr� joint"); }

        Transform playerCamera = joint.Find("PlayerCamera");
        if (playerCamera != null) { Debug.Log("Encontr� playerCamera"); }

        Transform thunderGun = playerCamera.Find("ThunderGun");
        if (thunderGun != null) { Debug.Log("Encontr� thunderGun"); }

        Transform shotgun = playerCamera.Find("Shotgun");
        if (shotgun != null) { Debug.Log("Encotr� Shotgun"); }

        switch (chosenWeapon)
        {

            case WeaponChoice.ThunderGun:
                thunderGun.gameObject.SetActive(true);
                if (thunderGun.gameObject.activeSelf) { Debug.Log("thundeGun activada"); }

                shotgun.gameObject.SetActive(false);
                break;

            case WeaponChoice.Shotgun:
                shotgun.gameObject.SetActive(true);
                if (shotgun.gameObject.activeSelf) { Debug.Log("shotgun activada"); }


                thunderGun.gameObject.SetActive(false);
                break;
        }
    }

    public void HandleWeaponSelection(GameManager.WeaponChoice chosenWeapon)
    {

        if (chosenWeapon == GameManager.WeaponChoice.Shotgun)
        {

            coinAnimator.SetTrigger("isS");
            StartCoroutine(CambiarEscena());
        }

        else if (chosenWeapon == GameManager.WeaponChoice.ThunderGun)
        {

            coinAnimator.SetTrigger("isT");
            StartCoroutine(CambiarEscena());
        }

    }
    #endregion

    IEnumerator CambiarEscena()
    {

        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Demo");

        yield return null; // Espera un frame, esto sirve para que el c�digo se reproduzca tras el cambio de escena. Sin esta linea, lo dem�s de la corrutina no funciona

        string activeSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(activeSceneName);

        if (SceneManager.GetActiveScene().name == "Demo")
        {

            GameManager.instance.ActivateWeapon(GameManager.instance.chosenWeapon);
            GameManager.instance.ActivatePower(GameManager.instance.chosenPower);
        }
    }

}



