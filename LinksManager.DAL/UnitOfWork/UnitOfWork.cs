using System;
using System.Diagnostics;
using LinksManager.DAL.Context;
using LinksManager.DAL.GenericRepository;
using LinksManager.Entities;


namespace LinksManager.DAL.UnitOfWork
{
    public class UnitOfWork: IDisposable
    {
        private readonly LinksManagerContext _context;
        private GenericRepository<Link> _linkRepository;


        public UnitOfWork()
        {
            _context = new LinksManagerContext();
        }


        public GenericRepository<Link> LinkRepository
        {
            get { return _linkRepository ?? (_linkRepository = new GenericRepository<Link>(_context)); }
        }

        public void Save()
        {
                _context.SaveChanges();
        }


        #region Implementing IDiosposable

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
