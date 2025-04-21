using AutoMapper;
using TMom.Application.Dto;
using TMom.Application.Dto.Sys;
using TMom.Domain.Model.Entity;

namespace TMom.Application.Ext
{
    public class CustomProfile : Profile
    {
        /// <summary>
        /// 配置构造函数，用来创建关系映射
        /// </summary>
        public CustomProfile()
        {
            #region Sys

            CreateMap<SysUser, userInfoDto>();

            #endregion Sys
        }
    }
}