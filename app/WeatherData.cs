namespace WeatherBit.Data
{
    public class WeatherData
    {
        public int count { get; set; }
        public Datum[]? data { get; set; }
    }

    public class Datum
    {
        public float app_temp { get; set; }
        public int aqi { get; set; }
        public string? city_name { get; set; }
        public int clouds { get; set; }
        public string? country_code { get; set; }
        public string? datetime { get; set; }
        public float dewpt { get; set; }
        public int dhi { get; set; }
        public int dni { get; set; }
        public float elev_angle { get; set; }
        public int ghi { get; set; }
        public float gust { get; set; }
        public int h_angle { get; set; }
        public float lat { get; set; }
        public float lon { get; set; }
        public string? ob_time { get; set; }
        public string? pod { get; set; }
        public int precip { get; set; }
        public float pres { get; set; }
        public int rh { get; set; }
        public float slp { get; set; }
        public int snow { get; set; }
        public int solar_rad { get; set; }
        public string[]? sources { get; set; }
        public string? state_code { get; set; }
        public string? station { get; set; }
        public string? sunrise { get; set; }
        public string? sunset { get; set; }
        public float temp { get; set; }
        public string? timezone { get; set; }
        public int ts { get; set; }
        public int uv { get; set; }
        public int vis { get; set; }
        public Weather? weather { get; set; }
        public string? wind_cdir { get; set; }
        public string? wind_cdir_full { get; set; }
        public int wind_dir { get; set; }
        public float wind_spd { get; set; }
    }

    public class Weather
    {
        public string? description { get; set; }
        public int code { get; set; }
        public string? icon { get; set; }
    }
}