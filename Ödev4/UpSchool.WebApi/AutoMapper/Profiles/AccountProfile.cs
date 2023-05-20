using AutoMapper;
using UpSchool.Domain.Dtos;
using UpSchool.Domain.Entities;

namespace UpSchool.WebApi.AutoMapper.Profiles;

public class AccountProfile:Profile
{
    public AccountProfile()
    {

        CreateMap<AccountEditDto, Account>() // Birisi sana account editt dto verirse account a mapple 
            .ForMember(dest=>dest.LastModifiedOn,
                opt=>opt.MapFrom(x=>DateTimeOffset.Now));

        CreateMap<Account, AccountDto>();
        
    }
}