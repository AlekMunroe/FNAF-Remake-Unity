using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CameraFlipController : MonoBehaviour
{
    [SerializeField] private GameObject cameraFlipObject;
    [SerializeField] private GameObject[] cameraScreens;
    [SerializeField] private GameObject cameraUI;
    
    private bool _isCameraEnabled;

    public void ToggleCameras()
    {
        Animation anim = cameraFlipObject.GetComponent<Animation>();

        if (_isCameraEnabled)
        {
            //Disable camera
            _isCameraEnabled = false;

            DisableCameraScreens();
            
            anim.Play("CameraFlipDown");

            cameraUI.SetActive(false);
        }
        else
        {
            //Enable camera
            _isCameraEnabled = true;

            anim.Play("CameraFlipUp");

            StartCoroutine(ShowCamera());
        }
    }

    IEnumerator ShowCamera()
    {
        Animation anim = cameraFlipObject.GetComponent<Animation>();
        float animTime = anim.clip.length;
        yield return new WaitForSeconds(animTime);
        
        DisableCameraScreens();
        
        //Set the first camera
        if (_isCameraEnabled)
        {
            cameraScreens[0].SetActive(true);
            cameraUI.SetActive(true);
        }
    }

    void DisableCameraScreens()
    {
        //Disable every cameraScreen
        for (int i = 0; i < cameraScreens.Length; i++)
        {
            cameraScreens[i].SetActive(false);
        }
    }
}
