using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.Models
{
	public interface IDBModel
	{
		Guid Id { get; set; }
	}
}
