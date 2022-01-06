using AutoMapper;

namespace ProvaCandidato.Mappers
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntidadeToViewModelMapping>();
                x.AddProfile<ViewModelToEntidadeMapping>();
            });
        }
    }
}