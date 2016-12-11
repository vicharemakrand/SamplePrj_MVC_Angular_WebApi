using AutoMapper;
using Sample.EntityModels;
using Sample.EntityModels.Core;
using Sample.EntityModels.Identity;
using Sample.EntityModels.Queues;
using Sample.Utility;
using Sample.ViewModels;
using Sample.ViewModels.Core;
using Sample.ViewModels.Identity.WebApi;


namespace Sample.IDomainServices.AutoMapper
{
    public class ModelAutoMapperProfiler : Profile
    {
        public ModelAutoMapperProfiler()
        {
           CreateMap<BaseEntityModel, BaseViewModel>().ReverseMap();
           CreateMap<AuditableEntityModel, AuditableViewModel>().ReverseMap();

           CreateMap<UserEntityModel, IdentityUserViewModel>().ReverseMap();
           
            //CreateMap<UserEntityModel, IdentityUserViewModel>()
            //.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId));

            //CreateMap<IdentityUserViewModel, UserEntityModel>()
            //                 .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));


            CreateMap<RoleEntityModel, IdentityRoleViewModel>()
                            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RoleId));
           CreateMap<IdentityRoleViewModel, RoleEntityModel>()
                            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Id));

           CreateMap<EmailQueueEntityModel, EmailQueueViewModel>().ReverseMap();
           CreateMap<RequestQueueEntityModel, RequestQueueViewModel>().ReverseMap();
           CreateMap<PdfQueueEntityModel, PdfQueueViewModel>().ReverseMap();


           CreateMap<ClientEntityModel, ClientViewModel>()
                .ForMember(dest => dest.ApplicationType, opt => opt.ResolveUsing<ApplicationTypeEnumResolver, int>(src => src.ApplicationType));

           CreateMap<ClientViewModel, ClientEntityModel>()
                            .ForMember(dest => dest.ApplicationType, opt => opt.ResolveUsing<ApplicationTypeIntResolver, ApplicationTypes>(src => src.ApplicationType));

           CreateMap<RefreshTokenEntityModel, RefreshTokenViewModel>().ReverseMap();

           CreateMap<ExternalLoginEntityModel, ExternalLoginViewModel>().ReverseMap();

           CreateMap<ExternalLoginEntityModel, UserLoginInfoViewModel>().ReverseMap();


        }
    }
}
