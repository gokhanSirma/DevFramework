using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramwork.Core.DataAccess.NHiberNate
{
    public abstract class NhibernateHelper : IDisposable//abstract yaptık çağıran bunları doldursun
    {
        private static ISessionFactory _session;//dbcontext gibi

        protected abstract ISessionFactory InitializeFactory();//sadece implemente eden kullansın.
     
        public virtual ISessionFactory SessionFactory
        {
            get { return _session ?? (_session = InitializeFactory()); }//null ise yükle gönder
        }
        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
