using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramwork.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace DevFramwork.Core.Aspects.Postsharp.CacheAspects
{
    [Serializable]
    public class CacheRemoveAspect:OnMethodBoundaryAspect
    {
        private Type _cacheType;
        private string _pattern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(Type CacheType)
        {
            _cacheType = CacheType;
        }
        public CacheRemoveAspect(string pattern,Type CacheType)
        {
            _pattern = pattern;
            _cacheType = CacheType;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)
            {
                throw new Exception("Wrong Cache Manager");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);
            base.RuntimeInitialize(method);
        }
        public override void OnSuccess(MethodExecutionArgs args)//ekleme update neyse başarılı olduğunda çalışsın
        {
            _cacheManager.RemoveByPattern(string.IsNullOrEmpty(_pattern) ? string.Format("{0}.{1}.*",//pattern yoksa o namespace ve classtaki herşeyi sil
            args.Method.ReflectedType.Namespace, args.Method.ReflectedType.Name):
            _pattern);//pattern varsa
            base.OnSuccess(args);
        }



    }
}
