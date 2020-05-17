using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour {
    public Image[] imagesList;
    public StartButton startButtonInstance;
    public Canvas mainSceneButtons;
    public Canvas stimulousButtons;
    public Canvas configs;
    public Canvas scoreCanvas;
    public Text score;
    public Text repetitions;
    private int interval;
    private int stimulousQuantity;
    private int fadeSpeed;
    private int repetitionPercentage;
    private bool isRepetition = false;
    private int repeats = 0;
    private int points = 0;



    // Use this for initialization
    void Start () {
        loadConfigs();
        print(GetInterval().ToString());
        scoreCanvas.enabled = false;
        score.text = "0";
        repetitions.text = "0";
        mainSceneButtons.enabled = true;
        stimulousButtons.enabled = false;
        configs.enabled = false;

        SetGameControllerReferenceOnButtons();

        ClearBoard();
        
        //StartCoroutine(displayStimulous());
    }

    public void loadConfigs()
    {
        stimulousQuantity = PlayerPrefs.GetInt("stimulousQuantity", 5);
        fadeSpeed = PlayerPrefs.GetInt("fadeSpeed", 3);
        repetitionPercentage = PlayerPrefs.GetInt("repetitionPercentage", 50);
        interval = PlayerPrefs.GetInt("interval", 1);
    }

    public void ClearBoard()
    {
        foreach (Image image in imagesList)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        }
    }

    public void OnClick()
    {
        if (isRepetition)
        {
            points++;
            score.text = points.ToString();
            isRepetition = false;
        }   
    }

    public IEnumerator displayStimulous()
    {
        isRepetition = false;
        mainSceneButtons.enabled = false;
        stimulousButtons.enabled = true;
        scoreCanvas.enabled = true;
        score.text = "0";
        repetitions.text = "0";
        repeats = 0;
        points = 0;

        int random, lastStimulous, aux;

        random = Random.Range(0, 9);
        StartCoroutine(FadeImage(false, imagesList[random]));
        yield return new WaitForSeconds(1);
        StartCoroutine(FadeImage(true, imagesList[random]));
        lastStimulous = random;
        yield return new WaitForSeconds(interval);

        for (int i = 1; i < stimulousQuantity; i++)
        {
            aux = Random.Range(0, 99);
            if (aux <= repetitionPercentage)
            {
                random = lastStimulous;
                print("rodada " + i + "aux = " + aux+"\nREPETICAO!");
                repeats++;
                //repetitions.text = repeats.ToString();
                isRepetition = true;
            }
            else
            {
                isRepetition = false;
                do
                {
                    random = Random.Range(0, 9);
                    print("rodada " + i + "aux = " + aux+ " . Sem repeticao");
                } while (random == lastStimulous);
            }
        
            StartCoroutine(FadeImage(false, imagesList[random]));
            
            //imagesList[random].color = visibleWhite;
            yield return new WaitForSeconds(1);
            //imagesList[random].color = invisibleWhite;

            StartCoroutine(FadeImage(true, imagesList[random]));

            lastStimulous = random;

            yield return new WaitForSeconds(interval);
            repetitions.text = repeats.ToString();
        }
        mainSceneButtons.enabled = true;
        stimulousButtons.enabled = false;
        

    }

    

    IEnumerator FadeImage(bool fadeAway, Image img)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime * fadeSpeed)
            {
                // set color with i as alpha
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                yield return null;
            }
            img.color = new Color(img.color.r, img.color.g, img.color.b, 0f);
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime * fadeSpeed)
            {
                // set color with i as alpha
                img.color = new Color(img.color.r, img.color.g, img.color.b, i);
                yield return null;
            }
            img.color = new Color(img.color.r, img.color.g, img.color.b, 1f);
        }
    }

    //CONFIGS GET/SET
    public void SetGameControllerReferenceOnButtons()
    {
        startButtonInstance.SetGameControllerReference(this);
    }

    public void SetStimulousQuantity(int value)
    {
        stimulousQuantity = value;
        PlayerPrefs.SetInt("stimulousQuantity", value);
    }

    public int GetStimulousQuantity()
    {
        return stimulousQuantity;
    }

    public void SetInterval(int value)
    {
        interval = value;
        PlayerPrefs.SetInt("interval", value);
    }

    public int GetInterval()
    {
        return interval;
    }

    public void SetFadeSpeed(int value)
    {
        fadeSpeed = value;
        PlayerPrefs.SetInt("fadeSpeed", value);
    }

    public int GetFadeSpeed()
    {
        return fadeSpeed;
    }

    public void SetRepetitionPercentage(int value)
    {
        repetitionPercentage = value;
        PlayerPrefs.SetInt("repetitionPercentage", value);
    }

    public int GetRepetitionPercentage()
    {
        return repetitionPercentage;
    }
}
