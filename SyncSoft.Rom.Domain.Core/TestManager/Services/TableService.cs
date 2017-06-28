using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CommonFrameWork.CommUtils;
using CommonFrameWork.Domain.Entities;
using CommonFrameWork.Specifications;
using SyncSoft.Rom.Domain.Core.PermissionManager.Model;
using SyncSoft.Rom.Domain.Core.TestManager.Model;
using SyncSoft.Rom.Domain.Core.TestManager.Repositories;
using SyncSoft.Rom.Domain.Core.Trans;

namespace SyncSoft.Rom.Domain.Core.TestManager.Services
{

    public class TableService : ITableService
    {
        private readonly ITableMainRepository _tableMainRepository;

        public TableService(ITableMainRepository tableMainRepository)
        {
            _tableMainRepository = tableMainRepository;
        }


        public void TransactionTest()
        {

            _tableMainRepository.Add(new TableMain()
            {
                AAName = "5555"
            });

            _tableMainRepository.Add(new TableMain()
            {
                AAName = "999999999999999999999999999999999999999999999999999999999999999"
            });

        }

        /// <summary>
        /// 多线程
        /// </summary>

        public void MunThread()
        {
            using (var tran2 = TransactionHelper.BeginTransaction())
            {
                try
                {
                    _tableMainRepository.Add(new TableMain()
                    {
                        AAName = "5555"
                    });

                    Thread t = new Thread(new ThreadStart(aaa));//注意ThreadStart委托的定义形式
                    t.Start();
                    tran2.Commit();
                }
                catch (Exception e)
                {
                    tran2.Rollback();
                    throw e;
                }
            }

        }

        private void aaa()
        {
            using (var tran2 = TransactionHelper.BeginTransaction())
            {
                try
                {
                    _tableMainRepository.Add(new TableMain()
                    {
                        AAName = "999999999999999999999999999999999999999999999999999999999999999"
                    });
                    tran2.Commit();
                }
                catch (Exception e)
                {
                    tran2.Rollback();
                    throw e;
                }
            }
        }



        public void Add()
        {
            using (var tran2 = TransactionHelper.BeginTransaction())
            {
                try
                {
                    _tableMainRepository.Add(new TableMain()
                    {
                        AAName = "5555"
                    });

                    using (var tran = TransactionHelper.BeginTransaction())
                    {
                        try
                        {
                            _tableMainRepository.Add(new TableMain()
                            {
                                AAName = "999999999999999999999999999999999999999999999999999999999999999"
                            });
                            tran.Commit();
                        }
                        catch (Exception e)
                        {
                            tran.Rollback();
                            throw e;
                        }
                    }

                    tran2.Commit();
                }
                catch (Exception e)
                {
                    tran2.Rollback();
                    throw e;
                }
            }
        }

        public void Del()
        {
            //  _tableMainRepository.Context
            _tableMainRepository.Remove(_tableMainRepository.GetByKey(1));
        }


        public void Update()
        {

        }


        public void Get()
        {

        }

        public void GetList()
        {

            var specExpression = PredicateBuilder.True<TableMain>();
            specExpression = p => p.AAName == "5555";
            var list = _tableMainRepository.FindAll(specExpression).ToList();




            //var categorization = _tableMainRepository.Find(Specification<TableMain>.Eval(specExpression));

            //var categorization2 = _tableMainRepository.FindAll(Specification<TableMain>.Eval(specExpression), p => p.AAName, OrderBy.Ascending, 1, 20);
        }

    }
}
