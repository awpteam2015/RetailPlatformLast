using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using NHibernate;
using NHibernate.Dialect;
using NHibernate.Engine;
using NHibernate.Exceptions;
using NHibernate.Id;
using NHibernate.Type;
using IConfigurable = NHibernate.Id.IConfigurable;

namespace SyncSoft.Rom.Domain.Core.Nhibernate
{
    /// <summary>
    /// 自定义主键生成
    /// </summary>
    public class SequenceGenerator : IConfigurable, IPersistentIdentifierGenerator
    {
        #region Private Fields

        /// <summary>
        /// 参数Key
        /// </summary>
        private const string SelectKey = "SelectKey";

        /// <summary>
        /// sql语句
        /// </summary>
        private string _sql;

        /// <summary>
        /// 返回类型
        /// </summary>
        private IType _identifierType;

        /// <summary>
        /// 记录日志
        /// </summary>
		private static readonly IInternalLogger _log = LoggerProvider.LoggerFor(typeof(SequenceGenerator));

        #endregion

        #region Implementation of IConfigurable
        /// <summary>
        /// 获取配置参数
        /// </summary>
        /// <param name="type">type</param>
        /// <param name="parms">parms</param>
        /// <param name="dialect">dialect</param>
        public void Configure(IType type, IDictionary<string, string> parms, Dialect dialect)
        {
            if (parms.ContainsKey(SelectKey))
            {
                _sql = parms[SelectKey];
            }

            _identifierType = type;
        }

        #endregion

        #region Implementation of IIdentifierGenerator
        /// <summary>
        /// 获取主键
        /// </summary>
        /// <param name="session">session</param>
        /// <param name="obj">obj</param>
        /// <returns>object</returns>
        public object Generate(ISessionImplementor session, object obj)
        {
            try
            {
                IDbCommand cmd = session.Connection.CreateCommand();
                cmd.CommandText = _sql;
                IDataReader reader = null;
                try
                {
                    reader = session.Batcher.ExecuteReader(cmd);
                    try
                    {
                        reader.Read();
                        object result = IdentifierGeneratorFactory.Get(reader, _identifierType, session);
                        if (_log.IsDebugEnabled)
                        {
                            _log.Debug("Sequence identifier generated: " + result);
                        }

                        return result;
                    }
                    finally
                    {
                        reader.Close();
                    }
                }
                finally
                {
                    session.Batcher.CloseCommand(cmd, reader);
                }
            }
            catch (DbException sqle)
            {
                _log.Error("error generating sequence", sqle);
                throw ADOExceptionHelper.Convert(session.Factory.SQLExceptionConverter, sqle, "could not get next sequence value");
            }
        }

        #endregion

        #region Implementation of IPersistentIdentifierGenerator

        /// <summary>
        /// SqlCreateStrings
        /// </summary>
        /// <param name="dialect">dialect</param>
        /// <returns>string[]</returns>
        public string[] SqlCreateStrings(Dialect dialect)
        {
            return new string[0];
        }

        /// <summary>
        /// SqlDropString
        /// </summary>
        /// <param name="dialect">dialect</param>
        /// <returns>string[]</returns>
        public string[] SqlDropString(Dialect dialect)
        {
            return new string[0];
        }

        /// <summary>
        /// GeneratorKey
        /// </summary>
        /// <returns>string</returns>
        public string GeneratorKey()
        {
            return null;
        }

        #endregion
    }
}
