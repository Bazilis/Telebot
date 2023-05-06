namespace Telebot.Constants
{
    public static class AirWeatherConstants
    {
        public static readonly char UP = '▲';
        public static readonly char LINE = '—';
        public static readonly char DOWN = '▼';

        public static readonly string[] AirStringParams = new string[]
        {
            "AQI --------", "NO2 -------", "SO2 --------",
            "PM2.5 ----", "PM10 -----", "O3 ----------",
            "CO ---------", "NO ---------", "NH3 -------"
        };

        public static readonly string[] WeatherStringParams = new string[]
        {
            "Temp -----", "Feels ------", "Press -----", "Humid ----",
            "Speed ----", "Direct -----", "Clouds ---", "Avg temp -----"
        };

        public static readonly string AirWeatherParamsInfo =
            "Temp ----- Temperature, celsius\n" +
            "Feels ------ Temp \"feels like\", celsius\n" +
            "Press ----- Atmospheric pressure, hPa\n" +
            "Humid --- Humidity, %\n" +
            "Speed ---- Wind speed, meter/sec\n" +
            "Direct ----- Wind direction, degrees\n" +
            "Clouds --- Cloudiness, %\n" +
            "Avg temp --- For previous day, celsius\n\n" +

            "AQI ----- 1-Good, 2-Fair, 3-Moderate\n" +
            "\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t4-Poor, 5-Very Poor\n" +
            "NO2 ---- 0-40, 40-70, 70-150, 150-200, >200\n" +
            "SO2 ----- 0-20, 20-80, 80-250, 250-350, >350\n" +
            "PM2.5 - 0-10, 10-25, 25-50, 50-75, >75\n" +
            "PM10 -- 0-20, 20-50, 50-100, 100-200, >200\n" +
            "NO ------- 0-100\n" +
            "NH3 ---- 0-200\n" +
            "O3 --- 0-60, 60-100, 100-140, 140-180, >180\n" +
            "CO -- 0-4400, 4400-9400, 9400-12400, 12400-15400, >15400\n";

        public static readonly string AvailableCities =
            "Berlin\nBialystok\nGomel\nHurghada\nIstanbul\nJizzakh\n" +
            "Kaliningrad\nKyiv\nLondon\nMadrid\nMilan\nMinsk\n" +
            "Nicosia\nOdesa\nParis\nPinsk\nRome\nSharm el Sheikh\n" +
            "Tashkent\nTbilisi\nToulon\nVilnius\nWarsaw\nWroclaw\n";
    }
}
