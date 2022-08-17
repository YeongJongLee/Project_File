using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    public GameObject option;
    public GameObject inGameOption;
    public GameObject bgmButton;
    public GameObject clearPanel;
    public GameObject panel;
    Image image;

    [SerializeField]
    public AudioClip[] audioClips;

    public AudioSource audioSource;

    public Color playerColor = new Color(0f, 1f, 0.94f);

    private bool checkbool = false;
    public bool isClear = false;

    private float volume;
    public int deathCount = 0;

    public float Volume
    { get { return volume; } set { volume = value; } }


    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
        this.volume = volume;
    }


    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        image = panel.GetComponent<Image>();
        Volume = 1f;
        audioSource.volume = Volume;
    }
    private void Update()
    {
        if (GameObject.FindWithTag("BGM_Slider") != null)
        {
            Volume = GameObject.FindWithTag("BGM_Slider").GetComponent<Slider>().value;
            audioSource.volume = Volume;
        }
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        deathCount = 0;
        clearPanel.SetActive(false);
        audioSource.Play();
        option.transform.GetChild(0).gameObject.SetActive(false);
    }
    public IEnumerator GoToTitle()
    {
        StartCoroutine("FadeOut");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Title");
        StartCoroutine("FadeIn");
        option.transform.GetChild(0).gameObject.SetActive(false);
    }
    public IEnumerator GoToStageMenu()
    {
        StartCoroutine("FadeOut");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("StageMenu");
        StartCoroutine("FadeIn");
        option.transform.GetChild(0).gameObject.SetActive(false);
    }
    public IEnumerator GoToStageMenu2()
    {
        Time.timeScale = 1;
        StartCoroutine("FadeOut");
        audioSource.Stop();

        yield return new WaitForSeconds(0.5f);
  
        SceneManager.LoadScene("StageMenu");
        StartCoroutine("FadeIn");

        audioSource.clip = audioClips[0];
        audioSource.Play();

        clearPanel.SetActive(false);
        option.gameObject.SetActive(true);
        inGameOption.gameObject.SetActive(false);
        inGameOption.transform.GetChild(0).gameObject.SetActive(false);
    }
    public IEnumerator GoToInGame()
    {
        StartCoroutine("FadeOut");
        audioSource.Stop();

        yield return new WaitForSeconds(0.5f);

        StartCoroutine("FadeIn");
        SceneManager.LoadScene("InGame");

        audioSource.clip = audioClips[2];
        audioSource.Play();

        option.gameObject.SetActive(false);
        inGameOption.gameObject.SetActive(true);
        option.transform.GetChild(0).gameObject.SetActive(false);
        //audioSource.PlayOneShot(audioClips[0]);
    }

    public IEnumerator GoToCustom()
    {
        StartCoroutine("FadeOut");

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene("Customize");
        StartCoroutine("FadeIn");
        option.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void GoToBack()
    {
        deathCount = 0;
        StartCoroutine("GoToStageMenu2");
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void GameOptionON()
    {
        option.transform.GetChild(0).gameObject.SetActive(true);
    }
    public void GameOptionOFF()
    {
        option.transform.GetChild(0).gameObject.SetActive(false);
    }

    public void InGameOptionON()
    {
        inGameOption.transform.GetChild(0).gameObject.SetActive(true);
        Time.timeScale = 0;
        audioSource.Pause();
    }
    public void InGameOptionOFF()
    {
        inGameOption.transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
        audioSource.Play();
    }
    public void BGM_ButtonON()
    {
        bgmButton.transform.GetChild(0).gameObject.SetActive(true);
        GameObject.FindWithTag("BGM_Slider").GetComponent<Slider>().value = 0;
    }
    public void BGM_ButtonOFF()
    {
        bgmButton.transform.GetChild(0).gameObject.SetActive(false);
        GameObject.FindWithTag("BGM_Slider").GetComponent<Slider>().value = 1;
    }

    public void SkyColor()
    {
        playerColor = new Color(0f, 1f, 0.94f);
    }

    public void RedColor()
    {
        playerColor = new Color(1f, 0f, 0f);
    }

    public void BlueColor()
    {
        playerColor = new Color(0.39f, 0.39f, 0.85f);
    }

    public void GreenColor()
    {
        playerColor = new Color(0.3f, 1f, 0.3f);
    }

    public void OrangeColor()
    {
        playerColor = new Color(1f, 0.3f, 0f);
    }

    public void YellowColor()
    {
        playerColor = new Color(1f, 1f, 0f);
    }
    IEnumerator FadeOut()
    {
        panel.SetActive(true);

        float fadeCount = 0;

        while (fadeCount < 1.0f)
        {
            fadeCount += 0.05f;

            image.color = new Color(0, 0, 0, fadeCount);

            yield return new WaitForSeconds(0.001f);
        }
        yield return null; 
    }
    IEnumerator FadeIn()
    {
        float fadeCount = 1;

        while (fadeCount > 0f)
        {
            fadeCount -= 0.05f;

            image.color = new Color(0, 0, 0, fadeCount);

            yield return new WaitForSeconds(0.001f);
        }
        panel.SetActive(false);

        yield return null;
    }
}
