using iText.Layout.Borders;
using iText.Layout.Element;

namespace iTextSample.Services.Interface
{
	public interface IHelper
	{
		public Task<Table> SetTableInnerBorder(Table table, Border border, bool ClearBorder = true);

		public Task<Table> SetTableOuterBorder(Table table, Border border, bool ClearBorder = true);

		public Task<Table> SetTableAllBorder(Table table, Border border, bool ClearBorder = true);
	}
}