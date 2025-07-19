

public class UserProfile:Profile
{
    public UserProfile()
    {
        CreateMap<RegisterViewModel,ApplicationUser>()
            .ForMember(dest => dest.UserName,opt => opt.MapFrom(src => src.Email));
    }
}
