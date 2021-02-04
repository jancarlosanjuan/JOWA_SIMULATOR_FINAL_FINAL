using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;
using System.IO;

public class FBManager : MonoBehaviour
{
    public Text uploadResultText;
    public GameObject confirmPanel;
    public GameObject uploadingPanel;
    public GameObject resultPanel;

    private void onFBInitialize()
    {
        if (FB.IsInitialized)
        {
            FB.ActivateApp();
            Debug.Log("FB initialized.");
        }
        else
        {
            Debug.Log("FB init failed.");
        }
    }

    private void onHideFB(bool shown)
    {
        if (shown)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }

    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(onFBInitialize, onHideFB);
        }
        else
        {
            FB.ActivateApp();
        }
    }

    private void FBLoginResult(ILoginResult res)
    {
        if (FB.IsLoggedIn)
        {
            Debug.Log("Logged in");
            UploadScreenshot();
        }
        else
        {
            Debug.Log("Log in failed");
        }
    }

    public void FBLogin()
    {
        if (FB.IsInitialized)
        {
            if (!FB.IsLoggedIn)
            {
                List<string> permissions = new List<string>() { "public_profile", "email" };
                FB.LogInWithReadPermissions(permissions, FBLoginResult);
            }
            else
            {
                Debug.Log("User already logged in");
                UploadScreenshot();
            }
        }
        else
        {
            Debug.Log("FB not yet initialized");
        }
    }

    private void UploadPhotoDone(IGraphResult res)
    {
        uploadingPanel.SetActive(false);
        resultPanel.SetActive(true);
        if (string.IsNullOrEmpty(res.Error))
        {
            uploadResultText.text = "Done Uploading!";
        }
        else
        {
            uploadResultText.text = "Error: " + res.Error;
        }
    }

    IEnumerator BeginUploadingScreenshot()
    {
        yield return new WaitForEndOfFrame();

        Texture2D screen = ScreenCapture.CaptureScreenshotAsTexture();
        byte[] bytes = screen.EncodeToPNG();
        File.WriteAllBytes(Application.persistentDataPath + "screenshot.png", bytes);

        WWWForm form = new WWWForm();
        form.AddBinaryData("image", bytes, "screenshot.png");
        form.AddField("caption", "My Score");
        FB.API("me/photos", HttpMethod.POST, UploadPhotoDone, form);
        uploadingPanel.SetActive(true);

        Debug.Log("Uploading Screenshot...");
    }

    public void UploadScreenshot()
    {
        if (FB.IsLoggedIn)
        {
            confirmPanel.SetActive(false);
            StartCoroutine(BeginUploadingScreenshot());
        }
        else
        {
            Debug.Log("Not logged in.");
        }
    }
}
