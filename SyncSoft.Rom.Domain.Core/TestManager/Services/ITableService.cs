using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SyncSoft.Rom.Domain.Core.TestManager.Services
{
    public interface ITableService
    {
        void TransactionTest();
        void MunThread();
        void Add();
        void Del();
        void Update();
        void Get();
        void GetList();
    }
}
