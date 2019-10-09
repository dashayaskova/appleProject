using DbModels.Models;
using System;
using System.Collections.Generic;

namespace Providers
{
	public interface IDBProvider :IDisposable
	{
		IEnumerable<TObject> SelectAll<TObject>(Func<TObject, bool> query=null) where TObject :class, IDBModel;

		TObject Select<TObject>(Func<TObject, bool> query) where TObject : class, IDBModel;

		void Add<TObject>(TObject obj) where TObject : class, IDBModel;
	}
}
