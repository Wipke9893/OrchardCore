using System.Collections.Generic;

namespace OrchardCore.Trees.Models
{
    public class WeatherResponse
    {
        public CoordInfo Coord { get; set; }
        public List<WeatherDetail> Weather { get; set; }
        public string Base { get; set; }
        public MainInfo Main { get; set; }
        public int Visibility { get; set; }
        public WindInfo Wind { get; set; }
        public RainInfo Rain { get; set; }
        public CloudsInfo Clouds { get; set; }
        public long Dt { get; set; }
        public SysInfo Sys { get; set; }
        public int Timezone { get; set; }
        public long Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }
    }

    public class CoordInfo
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class WeatherDetail
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class MainInfo
    {
        public double Temp { get; set; }
        public double Feels_Like { get; set; }
        public double Temp_Min { get; set; }
        public double Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }
    }

    public class WindInfo
    {
        public double Speed { get; set; }
        public int Deg { get; set; }
        public double Gust { get; set; }
    }

    public class RainInfo
    {
        public double Last1h { get; set; }
    }

    public class CloudsInfo
    {
        public int All { get; set; }
    }

    public class SysInfo
    {
        public int Type { get; set; }
        public long Id { get; set; }
        public string Country { get; set; }
        public long Sunrise { get; set; }
        public long Sunset { get; set; }
    }
}
