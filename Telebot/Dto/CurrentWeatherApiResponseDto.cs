namespace Telebot.Dto
{
    internal class CurrentWeatherApiResponseDto
    {
        public int Dt { get; set; }

        public string Name { get; set; }

        public MainInfo Main { get; set; }

        public WindInfo Wind { get; set; }

        public CloudsInfo Clouds { get; set; }

        public Coordinates Coord { get; set; }
    }

    internal class MainInfo
    {
        public double Temp { get; set; }
        public double Feels_like { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    internal class WindInfo
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
    }

    internal class CloudsInfo
    {
        public int All { get; set; }
    }

    internal class Coordinates
    {
        public double Lat { get; set; }

        public double Lon { get; set; }
    }
}
