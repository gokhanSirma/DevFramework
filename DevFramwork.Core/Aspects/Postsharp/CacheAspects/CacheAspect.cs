using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramwork.Core.CrossCuttingConcerns.Caching;
using PostSharp.Aspects;

namespace DevFramwork.Core.Aspects.Postsharp
{
    [Serializable]
    public class CacheAspect:MethodInterceptionAspect
    {
        private Type _cacheType;
        private int _cacheTime;
        private ICacheManager _cacheManager;
        public CacheAspect(Type cacheType,int cacheTime=60)
        {
            _cacheTime = cacheTime;
            _cacheType = cacheType;
        }
        public override void RuntimeInitialize(MethodBase method)
        {
            if (typeof(ICacheManager).IsAssignableFrom(_cacheType)==false)//defensive doğru cachemanager göndermiş mi mem mi redis mi filan
            {
                throw new Exception("Wrong Cache type");
            }
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheType);//gönderilen type'a göre bir instance oluşturduk
            base.RuntimeInitialize(method);
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                args.Method.ReflectedType.Namespace,
                args.Method.ReflectedType.Name,
                args.Method.Name);
            var arguments = args.Arguments.ToList();
            var key = string.Format("{0}({1})", methodName,
                string.Join(",", arguments.Select(x => x != null ? x.ToString() : "<Null>")));
            if (_cacheManager.IsAdd(key))
            {
                args.ReturnValue = _cacheManager.Get<object>(key);
            }
            _cacheManager.Add(key, args.ReturnValue, _cacheTime);
            base.OnInvoke(args);
            
        }



    }
}
