namespace Telebot.Dto
{
    internal class CurrentAirPollutionApiResponseDto
    {
        public AirInfo[] List { get; set; }
    }

    internal class AirInfo
    {
        public int Dt { get; set; }

        public MainIndex Main { get; set; }

        public ComponentsInfo Components { get; set; }
    }

    internal class MainIndex
    {
        public int Aqi { get; set; }
    }

    internal class ComponentsInfo
    {
        public double Co { get; set; }
        public double No { get; set; }
        public double No2 { get; set; }
        public double O3 { get; set; }
        public double So2 { get; set; }
        public double Pm2_5 { get; set; }
        public double Pm10 { get; set; }
        public double Nh3 { get; set; }
    }
}
