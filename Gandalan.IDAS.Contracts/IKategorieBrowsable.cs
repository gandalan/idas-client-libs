using System.Collections.Generic;

namespace Gandalan.IDAS.Data.Contracts
{
	public interface IKategorieBrowsable
	{
		void AddSubItem();

		IKategorieBrowsable GetParent();

		IList<IKategorieBrowsable> GetSubItems();

		void RemoveSubItem(IKategorieBrowsable item);
	}
}
