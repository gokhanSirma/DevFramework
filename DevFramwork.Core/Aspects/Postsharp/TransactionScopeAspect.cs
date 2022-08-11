using PostSharp.Aspects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DevFramwork.Core.Aspects.Postsharp
{
    [Serializable]
    public class TransactionScopeAspect: OnMethodBoundaryAspect
    {
        private TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }
        public override void OnEntry(MethodExecutionArgs args)//try
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }
        public override void OnSuccess(MethodExecutionArgs args)//başarılı olduğunda
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            base.OnExit(args);
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }

    }
}
