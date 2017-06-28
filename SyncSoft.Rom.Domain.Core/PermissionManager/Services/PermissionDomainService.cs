using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonFrameWork.Application;
using CommonFrameWork.Dependency;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Domain.Repositories;
using CommonFrameWork.Specifications;
using SyncSoft.Rom.Domain.Core.OrderManager.Repositories;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.Domain.Core.PermissionManager.Repositories;

namespace SyncSoft.Rom.Domain.Core.PermissionManager.Services
{
    public class PermissionDomainService : IPermissionDomainService
    {
        #region
        private readonly IModuleRepository _moduleRepository;
        private readonly IUserRepository _userRepository;
        private readonly IModuleFunctionRepository _moduleFunctionRepository;
        private readonly IDepartmentRepository _departmentRepository;


        public PermissionDomainService(
                IModuleRepository moduleRepository,
                IUserRepository userRepository,
                IModuleFunctionRepository moduleFunctionRepository,
                IDepartmentRepository departmentRepository
            )
        {
            _moduleRepository = moduleRepository;
            _userRepository = userRepository;
            _moduleFunctionRepository = moduleFunctionRepository;
            _departmentRepository = departmentRepository;


            //_moduleRepository = ObjectContainer.Resolve<moduleRepository>(parameter);
            //_moduleFunctionRepository = ObjectContainer.Resolve<moduleFunctionRepository>(parameter);
            //_userRepository = ObjectContainer.Resolve<userRepository>(parameter);
            //_departmentRepository = ObjectContainer.Resolve<departmentRepository>(parameter);


            //var parameter = new ObjectContainerParameter()
            //{
            //    Name = "context",
            //    Value = context
            //};

            //_repositoryContext = context;
            //_moduleRepository = ObjectContainer.Resolve<moduleRepository>(parameter);
            //_moduleFunctionRepository = ObjectContainer.Resolve<moduleFunctionRepository>(parameter);
            //_userRepository = ObjectContainer.Resolve<userRepository>(parameter);
            //_departmentRepository = ObjectContainer.Resolve<departmentRepository>(parameter);
        }

        #endregion


        #region  公有方法






        public AppProcessResult GetUserList(User where, int skipResults, int maxResults)
        {
            Expression<Func<User, bool>> specExpression;
            if (where == null)
                specExpression = p => p.LoginId == "";
            // ReSharper restore ImplicitlyCapturedClosure
            else
                specExpression = p => p.LoginId == "11";
           // var categorization = _userRepository.Find(Specification<User>.Eval(specExpression));

            //var categorization2 = _userRepository.FindAll(Specification<User>.Eval(specExpression), p => p.LoginId, OrderBy.Ascending, 1, 20);



           // return AppProcessResult.NormalReturn(categorization);
            return null;
        }



        /// <summary>
        /// 账号登录
        /// </summary>
        /// <param name="loginId"></param>
        /// <param name="password"></param>
        /// <param name="selectDepartmentCode"></param>
        public AppProcessResult Login(string loginId, string password, string selectDepartmentCode)
        {
            var xxt = _userRepository.GetByKey("777773");
            var xxt2 = _userRepository.GetByKey("777773");
            Thread t = new Thread(new ThreadStart(aaa));//注意ThreadStart委托的定义形式
            t.Start();

            //var userDepartmentList = this.GetDepartmentList(loginId);

            //var list = _userRepository.GetUserFunctionList("");

            ////ISpecification <User> spec = Specification<User>.Eval(p => p.LoginId == loginId && p.Password == password);
            ////  var user = _userRepository.Find(spec);

            //var userInfo = _userRepository.FindAll().FirstOrDefault(p => p.LoginId == loginId && p.Password == password);
            //if (userInfo != null && ((List<UserDepartmentView>)userDepartmentList.Data).Any(p => p.DepartmentCode == selectDepartmentCode))
            //{

            //    return AppProcessResult.Success(userInfo);
            //}
            //else
            //{
            //    return AppProcessResult.Error("用户名或者密码错误");
            //}
            return AppProcessResult.Error("用户名或者密码错误");
        }


        public void aaa()
        {
            var xxt2 = _userRepository.GetByKey("777773");
            var xxt = _userRepository.GetByKey("911385");
        }

        ///// <summary>
        ///// 获取用户对应的部门信息
        ///// </summary>
        ///// <param name="loginId"></param>
        ///// <returns></returns>
        //public AppProcessResult GetUserDepartmentView(string loginId)
        //{
        //    return new AppProcessResult()
        //    {
        //        Data = _userRepository.GetUserDepartmentView(loginId)
        //    };
        //}

        /// <summary>
        /// 获取用户对应的部门信息
        /// </summary>
        /// <param name="loginId"></param>
        /// <returns></returns>
        public AppProcessResult GetDepartmentList(string loginId)
        {
            var result = _userRepository.FindAll().FirstOrDefault(p => p.LoginId == loginId);
            if (result != null)
            {
                var allDepartmentList = _departmentRepository.FindAll().ToList();
                var newDepartmentList = new List<UserDepartmentView>();

                var departmentList = _userRepository.GetUserDepartmentView(loginId).ToList().OrderBy(p => p.Rank).ToList();

                departmentList.ForEach(p =>
                {
                    var temp = allDepartmentList.FirstOrDefault(x => x.DepartmentCode == p.DepartmentCode);
                    DepartmentRecursive(allDepartmentList, newDepartmentList, temp, 1);
                });

                return AppProcessResult.Success(newDepartmentList, result.DepartmentCodeDefault, "");
            }
            else
            {
                return AppProcessResult.Error("不存在该账号");
            }

        }


        #endregion



        #region 私有方法
        private void DepartmentRecursive(List<Department> allDepartmentList, List<UserDepartmentView> newDepartmentList, Department parentDepartment, int rank)
        {
            var newChar = "".PadLeft((rank - 1) * 3, '_');
            if (newDepartmentList.All(x => x.DepartmentCode != parentDepartment.DepartmentCode))
            {
                newDepartmentList.Add(new UserDepartmentView()
                {
                    DepartmentCode = parentDepartment.DepartmentCode,
                    DepartmentName = newChar + parentDepartment.DepartmentName,
                    Rank = parentDepartment.Rank.GetValueOrDefault()
                });
            }

            var temp = allDepartmentList.FirstOrDefault(x => x.DepartmentCode == parentDepartment.DepartmentCode);
            if (temp == null)
                return;

            temp.ChildDepartmentList.ToList().ForEach(p =>
            {
                DepartmentRecursive(allDepartmentList, newDepartmentList, p, rank + 1);
            });
        }


        #endregion


    }
}
