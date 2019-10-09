
using System;
using System.Collections.Generic;
using System.Linq;
using appleTimer.DbProject;
using DbModels.Models;

namespace Providers
{
	public class EFDBProvider : IDBProvider
	{
		private TimerContext _context;
		private bool _isDisposed;

		public EFDBProvider()
		{
			_context = new TimerContext();
		}

		public void Add<TObject>(TObject obj) where TObject :class, IDBModel
		{
			if(_context.Set<TObject>().Any(o => o.Id == obj.Id))
			{
				return;
			}

			_context.Set<TObject>().Add(obj);
			_context.SaveChanges();
		}

		public void Dispose()
		{
			Dispose(true);
		}

		private void Dispose(bool isDisposing)
		{
			if (_isDisposed)
			{
				return;
			}

			if (isDisposing)
			{
				_context?.Dispose();
			}

			_isDisposed = true;
		}

		public TObject Select<TObject>(Func<TObject, bool> query) where TObject :class, IDBModel
		{
			return ((query != null) ? _context.Set<TObject>().Where(query) : _context.Set<TObject>()).FirstOrDefault();
		}

		public IEnumerable<TObject> SelectAll<TObject>(Func<TObject, bool> query = null) where TObject :class, IDBModel
		{
			return (query != null) ? _context.Set<TObject>().Where(query) : _context.Set<TObject>();
		}
	}
}
