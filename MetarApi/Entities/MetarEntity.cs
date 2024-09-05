using AutoMapper;
using MetarSharp;

namespace MetarApi.Entities
{
    public class MetarEntity
    {
        private readonly IMapper _mapper;

        public MetarEntity(IMapper mapper)
        {
            _mapper = mapper;
        }

        public static MetarEntity Create(Metar metar)
        {
            return new MetarEntity()
            {

                AdditionalInformation = metar.AdditionalInformation,
                Airport = metar.Airport,
                Clouds = metar.Clouds,
                IsAutomatedReport = metar.IsAutomatedReport,
                MetarRaw = metar.MetarRaw,
                Pressure = metar.Pressure,
                ReadableReport = metar.ReadableReport,
                ReportingTime = metar.ReportingTime,
                RunwayConditions = metar.RunwayConditions,
                RunwayVisibilities = metar.RunwayVisibilities,
                Temperature = metar.Temperature,
                Trends = metar.Trends,
                Visibility = metar.Visibility,
                Weather = metar.Weather,
                Wind = metar.Wind,


            };
        }
        public MetarEntity()
        {
            
        }
        public int Id { get; set; }
        public string? MetarRaw { get; set; } = "";

        public string Airport { get; set; } = "AAAA";

        public ReportingTime ReportingTime { get; set; } = new();

        public bool IsAutomatedReport { get; set; } = false;

        public Wind Wind { get; set; } = new();

        public Visibility Visibility { get; set; } = new();

        public List<RunwayVisibility>? RunwayVisibilities { get; set; }

        public Weather? Weather { get; set; }

        public List<Cloud> Clouds { get; set; }= new();

        public Temperature Temperature { get; set; }=new();

        public Pressure Pressure { get; set; }= new();

        public List<Trend> Trends { get; set; }=new();

        public List<RunwayCondition>? RunwayConditions { get; set; }

        public AdditionalInformation AdditionalInformation { get; set; } = new();

        public string? ReadableReport { get; set; }

    }
}
