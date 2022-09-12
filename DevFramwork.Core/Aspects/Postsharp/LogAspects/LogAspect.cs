using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DevFramwork.Core.CrossCuttingConcerns.Logging;
using DevFramwork.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Extensibility;

namespace DevFramwork.Core.Aspects.Postsharp.LogAspects
{
    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method,TargetExternalMemberAttributes =MulticastAttributes.Instance)]//classın tepesine yazdığımızda constructorda çalışmasın classın tepesine de attribute yapabiliriz.(loglama olduğundan öyle bir ihtiyaç doğabilir.
    public class LogAspect:OnMethodBoundaryAspect
    {
        private Type _loggerType; //databse mi console mu text mi vs.
        private LoggerService _loggerService;//log işlemi yapacağımız servis instance alıp işi yapacağız.

        public LogAspect(Type LoggerType)
        {
            _loggerType = LoggerType;
        }
        public override void RuntimeInitialize(MethodBase method)//methoda başladığı anda instance üretecek şartlar tamamsa
        {
            if (_loggerType.BaseType!=typeof(LoggerService))//verilen tip loggerservicetekilerden biri mi?
            {
                throw new Exception("Wrong Logger Type");
            }
            _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);//logger type'a göre Instance oluştur.
            base.RuntimeInitialize(method);
        }
        public override void OnEntry(MethodExecutionArgs args)//methodun başında çalıştıracağımızı varsaydık. orada da Method bilgilerini kullanacağız
        {
            if (!_loggerService.IsInfoEnabled)//method içi bilgileri
            {
                return;
            }
            try
            {
                var logParameters = args.Method.GetParameters().Select((t, i) => new LogParameter //t type i de iterasyon ör 0. eleman sehir string
                {
                    Name = t.Name,
                    Type = t.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();//parametreleri listeye çekip aşağıda kullanıyoruz.

                var logDetail = new LogDetail
                {
                    FullName = args.Method.DeclaringType == null ? null : args.Method.DeclaringType.Name,
                    MethodName = args.Method.Name,
                    Parameters = logParameters
                };
                _loggerService.Info(logDetail);
            }
            catch (Exception)
            {

                
            }
           

            
        }

    }
}
