using System;
using System.Collections.Generic;
using System.Linq;
using CommonFrameWork.Application;
using CommonFrameWork.DataMap;
using CommonFrameWork.Dependency;
using CommonFrameWork.Domain.Repositories;
using SyncSoft.Rom.Application.Dto.PermissionManager;
using SyncSoft.Rom.Application.ServiceContracts;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.Domain.Core.PermissionManager.Repositories;
using SyncSoft.Rom.Domain.Core.PermissionManager.Services;

namespace SyncSoft.Rom.Application.Implementation.PermissionManager
{
    public class PermissionServiceImpl : IPermissionService
    {
        private readonly IRepositoryContext _repositoryContext;
        private readonly IModuleRepository _moduleRepository;
        private readonly IModuleFunctionRepository _moduleFunctionRepository;
        private readonly IPermissionDomainService _permissionDomainService;
        private readonly IUserRepository _userRepository;
        private readonly IDepartmentRepository _departmentRepository;

        public PermissionServiceImpl(IRepositoryContext repositoryContext, IModuleRepository moduleRepository, IModuleFunctionRepository moduleFunctionRepository, IPermissionDomainService permissionDomainService, IUserRepository userRepository, IDepartmentRepository departmentRepository)
        {
            _repositoryContext = repositoryContext;
            _moduleRepository = moduleRepository;
            _moduleFunctionRepository = moduleFunctionRepository;
            _permissionDomainService = permissionDomainService;
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <returns></returns>
        public List<MenuDto> GetMenuList()
        {
            var menuList = new List<MenuDto>();
            var list = _moduleRepository.FindAllAndFetch(null, p => p.ModuleFunctions).ToList();
            list.ForEach(p =>
            {
                var menu = new MenuDto()
                {
                    Name = p.ModuleName,
                    Url = "",
                    RankId = p.OrderId.GetValueOrDefault()
                };

                var childMenuList = new List<MenuDto>();
                p.ModuleFunctions.ToList().ForEach(x =>
                {
                    if (x.Disabled == 1)
                    {
                        childMenuList.Add(new MenuDto()
                        {
                            Name = x.FunctionName,
                            Url = x.FunctionUrl2,
                            RankId = x.OrderId.GetValueOrDefault()
                        });
                    }
                });

                menu.ChildMenuList = childMenuList.OrderBy(x => x.RankId).ToList();
                menuList.Add(menu);
            });

            return menuList.Where(p => p.ChildMenuList.Any()).OrderBy(x => x.RankId).ToList();
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public AppProcessResult Login(LoginDto dto)
        {
            var result = _permissionDomainService.Login(dto.LoginId, dto.Password, dto.SelectDepartmentCode);
            if (result.IsSuccess)
            {
                var mapResult = DataMapper.Map<UserInfoDto>(result.Data);
                mapResult.SelectDepartmentCode = dto.SelectDepartmentCode;
                mapResult.SelectDepartmentName = _departmentRepository.FindAll().Where(p => p.DepartmentCode == dto.SelectDepartmentCode).FirstOrDefault().DepartmentName;
                result.Data = mapResult;
            }
            return result;
        }

        /// <summary>
        /// 获取登录账号的门店信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        //public AppProcessResult GetDepartmentList(string loginId)
        //{
        //    var result = _userRepository.FindAll().FirstOrDefault(p => p.LoginId == loginId);
        //    if (result!=null)
        //    {

        //      //  _userRepository.GetUserDepartmentView(loginId)

        //        return AppProcessResult.Success("不存在该账号");
        //    }
        //    else
        //    {
        //        return AppProcessResult.Error("不存在该账号");
        //    }

        //}


        //public AppProcessResult IsPageHasPermission(LoginDto dto)
        //{

            //}



        public TestDto Test(LoginDto dto)
        {
            


            var testDo=new TestDo()
            {
                TestName = "xxxxxxx"
            };

            try
            {
                var TestDto = DataMapper.Map<TestDto>(testDo);

                return TestDto;
            }
            catch (Exception e)
            {
                
                throw;
            }
          
        }

    }
}
