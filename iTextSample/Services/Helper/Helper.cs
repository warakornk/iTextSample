using iText.Layout.Borders;
using iText.Layout.Element;
using iTextSample.Services.Interface;

namespace iTextSample.Services.Helper
{
	public class Helper : IHelper
	{
		/// <summary>
		/// Set table inner border
		/// </summary>
		/// <param name="table">iText table</param>
		/// <param name="border">Border style</param>
		/// <param name="ClearBorder">Clear table border before add inner border</param>
		/// <returns>iText table with border</returns>
		public async Task<Table> SetTableInnerBorder(Table table, Border border, bool ClearBorder = true)
		{
			int tableRows = table.GetNumberOfRows();
			int tableColumns = table.GetNumberOfColumns();

			// Clear table borders
			table.SetBorder(Border.NO_BORDER);
			if (ClearBorder)
			{
				for (int i = 0; i < tableRows; i++)
				{
					for (int j = 0; j < tableColumns; j++)
					{
						Cell cell = table.GetCell(i, j);

						cell.SetBorder(Border.NO_BORDER);
					}
				}
			}

			// Set table inner borders
			for (int i = 0; i < tableRows; i++)
			{
				for (int j = 0; j < tableColumns; j++)
				{
					Cell cell = table.GetCell(i, j);

					if (i < tableRows - 1)
					{
						cell.SetBorderBottom(border);
					}
					if (j < tableColumns - 1)
					{
						cell.SetBorderRight(border);
					}
				}
			}

			return await Task.FromResult(table);
		}

		/// <summary>
		/// Set table outer border
		/// </summary>
		/// <param name="table">iText table</param>
		/// <param name="border">Border style</param>
		/// <param name="ClearBorder">Clear table border before add inner border</param>
		/// <returns>iText table with border</returns>
		public async Task<Table> SetTableOuterBorder(Table table, Border border, bool ClearBorder = true)
		{
			int tableRows = table.GetNumberOfRows();
			int tableColumns = table.GetNumberOfColumns();

			// Clear table borders
			table.SetBorder(Border.NO_BORDER);
			if (ClearBorder)
			{
				for (int i = 0; i < tableRows; i++)
				{
					for (int j = 0; j < tableColumns; j++)
					{
						Cell cell = table.GetCell(i, j);

						cell.SetBorder(Border.NO_BORDER);
					}
				}
			}

			// Set table outer borders
			for (int i = 0; i < tableRows; i++)
			{
				for (int j = 0; j < tableColumns; j++)
				{
					Cell cell = table.GetCell(i, j);

					if (i == 0)
					{
						cell.SetBorderTop(border);
					}
					if (i == tableRows - 1)
					{
						cell.SetBorderBottom(border);
					}
					if (j == 0)
					{
						cell.SetBorderLeft(border);
					}
					if (j == tableColumns - 1)
					{
						cell.SetBorderRight(border);
					}
				}
			}

			return await Task.FromResult(table);
		}

		/// <summary>
		/// Set table all border
		/// </summary>
		/// <param name="table">iText table</param>
		/// <param name="border">Border style</param>
		/// <param name="ClearBorder">Clear table border before add inner border</param>
		/// <returns>iText table with border</returns>
		public async Task<Table> SetTableAllBorder(Table table, Border border, bool ClearBorder = true)
		{
			int tableRows = table.GetNumberOfRows();
			int tableColumns = table.GetNumberOfColumns();

			// Clear table borders
			table.SetBorder(Border.NO_BORDER);
			if (ClearBorder)
			{
				for (int i = 0; i < tableRows; i++)
				{
					for (int j = 0; j < tableColumns; j++)
					{
						Cell cell = table.GetCell(i, j);

						cell.SetBorder(Border.NO_BORDER);
					}
				}
			}

			// Set table borders
			for (int i = 0; i < tableRows; i++)
			{
				for (int j = 0; j < tableColumns; j++)
				{
					Cell cell = table.GetCell(i, j);

					cell.SetBorder(border);
				}
			}

			return await Task.FromResult(table);
		}
	}
}