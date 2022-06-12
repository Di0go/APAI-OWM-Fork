[System.Serializable]
public class Root
{
    public Address address;
}


[System.Serializable]
public class Address
{
    public string adminCode2;
    public string adminCode3;
    public string adminCode1;
    public string lng;
    public string houseNumber;
    public string locality;
    public string adminCode4;
    public string adminName2;
    public string street;
    public string postalcode;
    public string countryCode;
    public string adminName1;
    public string lat;
}

//openweather
[System.Serializable]
public class Clouds
{
    public int all;
}

[System.Serializable]
public class Coord
{
    public double lon;
    public double lat;
}

[System.Serializable]
public class Main
{
    public double temp;
    public double feels_like;
    public double temp_min;
    public double temp_max;
    public int pressure;
    public int humidity;
    public int sea_level;
    public int grnd_level;
}

[System.Serializable]
public class Rain
{
    public double _1h;
}

[System.Serializable]
public class RootMarlene
{
    public Coord coord;
    public Weather[] weather;
    public string @base;
    public Main main;
    public int visibility;
    public Wind wind;
    public Rain rain;
    public Clouds clouds;
    public int dt;
    public Sys sys;
    public int timezone;
    public int id;
    public string name;
    public int cod;
}

[System.Serializable]
public class Sys
{
    public string country;
    public int sunrise;
    public int sunset;
}

[System.Serializable]
public class Weather
{
    public int id;
    public string main;
    public string description;
    public string icon;
}

[System.Serializable]
public class Wind
{
    public double speed;
    public int deg;
    public double gust;
}
