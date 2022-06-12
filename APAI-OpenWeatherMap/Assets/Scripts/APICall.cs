using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class APICall : MonoBehaviour
{
    //api key
    private string apiKey = "ef5dac2e052a81d1a8a4acf658516d0b";
    
    private string geoNamesURL;

    //geoNames
    private Root root;
    //openWeather
    private RootMarlene marlene;

    //UI coomponents
    public Text temp;
    public Text minMaxTemp;
    public RawImage ico;
    public Text description;

    public void callApi(InputField query)
    {
        string place = query.text.Replace(" ", "+");
        geoNamesURL = "http://api.geonames.org/geoCodeAddressJSON?q=" + query.text + "&username=waltermelion";
        Debug.Log(geoNamesURL);
        
        StartCoroutine(FetchLatLng(geoNamesURL));
    }

    IEnumerator FetchLatLng(string URL)
    {
        UnityWebRequest request = UnityWebRequest.Get(URL);
        
        yield return request.SendWebRequest();
        
        if (request.result != UnityWebRequest.Result.Success)
            Debug.Log("Erro: "+ request.error);
        else
        {
            root = new Root();
            root = JsonUtility.FromJson<Root>(request.downloadHandler.text);
            StartCoroutine(GetWeather(root.address.lat, root.address.lng));
        }
    }

    IEnumerator GetWeather(string lat, string lng)
    {
        UnityWebRequest request = UnityWebRequest.Get("https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lng + "&units=metric" + "&appid=" + apiKey);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
            Debug.Log("Erro: " + request.error);
        else
        {
            marlene = new RootMarlene();
            marlene = JsonUtility.FromJson<RootMarlene>(request.downloadHandler.text);
            temp.text = marlene.main.temp + "º";
            minMaxTemp.text = marlene.main.temp_min + "º ~ " + marlene.main.temp_max + "º";
            description.text = "“" + marlene.weather[0].description + "”";
            StartCoroutine(DownloadImage("https://openweathermap.org/img/wn/" + marlene.weather[0].icon + "@2x.png"));
        }
    }

    //coroutine to download and set weather ico
    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
            Debug.Log(request.error);
        else
            ico.texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            ico.enabled = true;
    }
}