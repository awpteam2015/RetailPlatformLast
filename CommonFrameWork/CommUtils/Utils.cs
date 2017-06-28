using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Compilation;

namespace CommonFrameWork.CommUtils
{
    public static class Utils
    {
      
        #region -  FindTypes  -

        public static IEnumerable<Type> FindImplTypes<TInterface>(Func<Type, bool> filter, IEnumerable<Assembly> assemblies)
        {
            foreach (var assembly in assemblies)
            {
                var query = FindImplTypes<TInterface>(filter, assembly.GetTypes());
                foreach (var type in query)
                {
                    yield return type;
                }
            }
        }

        public static IEnumerable<Type> FindImplTypes<TInterface>(Func<Type, bool> filter, IEnumerable<Type> types)
        {
            var interfaceType = typeof(TInterface);
            var query = types.Where(t => !t.IsInterface && !t.IsAbstract && interfaceType.IsAssignableFrom(t));


            //query.ToList().ForEach(p =>
            //{
            //    string t = p.FullName;
            //});

            if (null != filter)
            {
                query = query.Where(filter);
            }

            foreach (var type in query)
            {
                yield return type;
            }
        }

        #endregion

        //internal static bool IsAggregateRoot(Type type)
        //{
        //    return type.IsClass && !type.IsAbstract && typeof(IAggregateRoot).IsAssignableFrom(type);
        //}

        public static IList<Assembly> GetAllAssemblies(string assembliesPrefix)
        {
            if (null == HttpRuntime.AppDomainAppId)
            {
                return GetNonWebContextAssemblies(assembliesPrefix).ToList();
            }
            else
            {
                return GetWebContextAssemblies(assembliesPrefix);
            }
        }

        private static IEnumerable<Assembly> GetNonWebContextAssemblies(string assembliesPrefix)
        {
            var files = Directory.EnumerateFiles(BinPath(), assembliesPrefix + ".*")
                .Where(s => s.EndsWith(".dll") || s.EndsWith(".exe"));

            foreach (var file in files)
            {
                yield return Assembly.LoadFile(file);
            }
        }

        private static IList<Assembly> GetWebContextAssemblies(string assembliesPrefix)
        {
            return BuildManager.GetReferencedAssemblies().Cast<Assembly>().Where(x => x.FullName.StartsWith(assembliesPrefix)).ToList();
        }

        private static string BinPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase.Substring(8));
        }

        public static string SHA1(params Guid[] keys)
        {
            var bytes = new byte[0];
            foreach (var key in keys)
            {
                bytes = bytes.Concat(key.ToByteArray()).ToArray();
            }

            return SHA1(bytes);
        }
        private static string SHA1(byte[] bytes)
        {
            HashAlgorithm iSHA = new SHA1CryptoServiceProvider();
            bytes = iSHA.ComputeHash(bytes);
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
    }
}
