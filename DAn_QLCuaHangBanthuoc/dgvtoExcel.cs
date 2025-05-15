using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using ClosedXML.Excel;

namespace DAn_QLCuaHangBanthuoc
{
    public class DataGridViewToExcelExporter
    {
        public void ExportToExcelWithClosedXML(DataGridView dgv, string filePath, string worksheetName = "Sheet1", string[] customHeaders = null)
        {
            try
            {
                // Check if DataGridView has data
                if (dgv == null || dgv.Rows.Count == 0)
                {
                    MessageBox.Show("No data to export!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (var workbook = new XLWorkbook())
                {
                    // Use the provided worksheet name, default to "Sheet1" if not specified
                    var worksheet = workbook.Worksheets.Add(worksheetName);

                    // Write column headers
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        // Use custom headers if provided, otherwise use DataGridView headers
                        string header = (customHeaders != null && i < customHeaders.Length) ? customHeaders[i] : dgv.Columns[i].HeaderText;
                        worksheet.Cell(1, i + 1).Value = header;
                        worksheet.Cell(1, i + 1).Style.Font.Bold = true; // Bold the headers
                    }

                    // Write data rows from DataGridView
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        if (!dgv.Rows[i].IsNewRow) // Skip the new row (if any)
                        {
                            for (int j = 0; j < dgv.Columns.Count; j++)
                            {
                                worksheet.Cell(i + 2, j + 1).Value = dgv.Rows[i].Cells[j].Value?.ToString() ?? "";
                            }
                        }
                    }

                    // Auto-adjust column widths for better appearance
                    worksheet.Columns().AdjustToContents();

                    // Save the Excel file
                    workbook.SaveAs(filePath);
                    MessageBox.Show($"Excel file exported successfully at: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Open the Excel file (optional)
                    Process.Start(filePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}