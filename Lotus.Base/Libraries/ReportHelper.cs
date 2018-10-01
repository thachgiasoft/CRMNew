using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;

namespace Lotus
{
    public static class ReportHelper
    {
        public static void CreateReportTemplate(this ColumnView view, string reportName)
        {
            CreateReportTemplate(view, reportName, true, true, PaperKind.A4, false);
        }
        public static void CreateReportTemplate_old(this ColumnView view, string reportName, bool showSTT, bool showFooter
           , PaperKind paperKind, bool landscape)
        {
            XtraReport r = new XtraReport();
            r.PaperKind = paperKind;
            r.Landscape = landscape;
            r.Margins.Left = 70; //thamso
            r.Margins.Right = 50; //thamso

            r.DataSource = view.DataSource;

            float width = r.PageSize.Width - r.Margins.Left - r.Margins.Right;


            // ADD HEDER
            var headerBand = new ReportHeaderBand();
            XRLabel lbReporName = new XRLabel();
            lbReporName.Text = reportName.ToUpper();
            lbReporName.WidthF = width;
            lbReporName.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            lbReporName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            headerBand.Controls.Add(lbReporName);

            XRTable rtableHeader = new XRTable();
            var rRowHeader = new XRTableRow();
            XRTableCell cellHeader = null;

            if (showSTT)
            {
                cellHeader = new XRTableCell();
                cellHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                cellHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom
                     | DevExpress.XtraPrinting.BorderSide.Top
                    )));

                cellHeader.Text = "STT";
                rRowHeader.Cells.Add(cellHeader);
            }
            foreach (GridColumn c in view.VisibleColumns)
            {
                cellHeader = new XRTableCell();
                cellHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                cellHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom
                     | DevExpress.XtraPrinting.BorderSide.Top
                    )));

                cellHeader.Text = c.Caption == string.Empty ? c.FieldName : c.Caption;
                rRowHeader.Cells.Add(cellHeader);
            }

            cellHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                | DevExpress.XtraPrinting.BorderSide.Bottom
                 | DevExpress.XtraPrinting.BorderSide.Right
                  | DevExpress.XtraPrinting.BorderSide.Top
                )));

            rtableHeader.Rows.Add(rRowHeader);
            rRowHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            rtableHeader.WidthF = width;
            rtableHeader.LocationF = new PointF(0, lbReporName.HeightF + 20);
            headerBand.HeightF = 0;
            headerBand.Controls.Add(rtableHeader);
            r.Bands.Add(headerBand);

            // ADD GROUP
            for (int i = view.GroupedColumns.Count - 1; i >= 0; i--)
            {
                GridColumn c = view.GroupedColumns[i];
                GroupHeaderBand groupBand = new GroupHeaderBand();
                groupBand.GroupFields.Add(new GroupField(c.FieldName));
                XRLabel lbGroup = new XRLabel();
                lbGroup.DataBindings.Add("Text", r.DataSource, c.FieldName);
                lbGroup.WidthF = width;
                lbGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);

                lbGroup.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                | DevExpress.XtraPrinting.BorderSide.Bottom
                 | DevExpress.XtraPrinting.BorderSide.Right
                )));

                lbGroup.BackColor = Color.Honeydew;
                lbGroup.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 0, 0, 0);
                lbGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;

                groupBand.Controls.Add(lbGroup);
                groupBand.HeightF = 0;
                r.Bands.Add(groupBand);

                // TODO: ADD SUM GROUP CHO NAY TIEP
                // LAM SAU
            }


            // ADD DETAIL TABLE
            XRTable rtable = new XRTable();
            var rRow = new XRTableRow();
            XRTableCell cell = null;
            if (showSTT)
            {
                cell = new XRTableCell();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                cell.Summary.Func = SummaryFunc.RecordNumber;
                if (view.GroupedColumns.Count > 0 && showSTT)
                    cell.Summary.Running = SummaryRunning.Group;
                else
                    cell.Summary.Running = SummaryRunning.Report;

                rRow.Cells.Add(cell);
            }
            foreach (GridColumn c in view.VisibleColumns)
            {
                cell = new XRTableCell();
                if (c.ColumnType == typeof(decimal) || c.ColumnType == typeof(int))
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                else
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                cell.DataBindings.Add("Text", r.DataSource, c.FieldName);
                cell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0);
                rRow.Cells.Add(cell);
            }
            cell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                | DevExpress.XtraPrinting.BorderSide.Bottom
                 | DevExpress.XtraPrinting.BorderSide.Right
                )));

            rtable.Rows.Add(rRow);

            rtable.WidthF = width;
            var detailBand = new DetailBand();
            detailBand.HeightF = rtable.HeightF;
            detailBand.Controls.Add(rtable);
            r.Bands.Add(detailBand);

            // ADD SUM FOOTER
            if (showFooter)
            {
                var reportFooter = new ReportFooterBand();
                XRTable rtableFooter = new XRTable();
                var rRowFooter = new XRTableRow();
                XRTableCell cellFooter = null;

                if (showSTT)
                {
                    cellFooter = new XRTableCell();
                    cellFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    cellFooter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                    cellFooter.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Bottom
                        )));

                    rRowFooter.Cells.Add(cellFooter);
                }

                for (int i = 0; i < view.VisibleColumns.Count; i++)
                {
                    var c = view.VisibleColumns[i];
                    cellFooter = new XRTableCell();
                    cellFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    cellFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0);
                    cellFooter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                    cellFooter.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Bottom
                        )));

                    if (c.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                    {
                        cellFooter.Summary.Func = ConvertToSummaryFunc(c.SummaryItem.SummaryType);
                        cellFooter.Summary.FormatString = c.SummaryItem.DisplayFormat;
                        cellFooter.DataBindings.Add("Text", r.DataSource, c.FieldName);

                        cellFooter.Summary.Running = SummaryRunning.Report;
                    }
                    rRowFooter.Cells.Add(cellFooter);
                }

                cellFooter.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom
                     | DevExpress.XtraPrinting.BorderSide.Right
                    )));

                rtableFooter.WidthF = width;
                rRowFooter.BackColor = Color.LightYellow;
                rtableFooter.Rows.Add(rRowFooter);
                reportFooter.Controls.Add(rtableFooter);
                r.Bands.Add(reportFooter);
            }


            r.CreateDocument();
            r.ShowDesignerDialog();
        }

        public static void CreateReportTemplate(this ColumnView view, string reportName, bool showSTT, bool showFooter
            , PaperKind paperKind, bool landscape)
        {
            XtraReport r = new XtraReport();
            r.PaperKind = paperKind;
            r.Landscape = landscape;

            r.Margins.Top = 50;
            r.Margins.Bottom = 50;
            r.Margins.Left = 70; //thamso
            r.Margins.Right = 70; //thamso

            r.DataSource = view.DataSource;

            float width = r.PageSize.Width - r.Margins.Left - r.Margins.Right;


            // ADD HEDER
            var headerBand = new ReportHeaderBand();
            XRLabel lbReporName = new XRLabel();
            lbReporName.Text = reportName.ToUpper();
            lbReporName.WidthF = width;
            lbReporName.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Bold);
            lbReporName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            headerBand.Controls.Add(lbReporName);

            
            XRTable rtableHeader = new XRTable();
            var rRowHeader = new XRTableRow();
            XRTableCell cellHeader = null;

            if (showSTT)
            {
                cellHeader = new XRTableCell();
                cellHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                cellHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom
                     | DevExpress.XtraPrinting.BorderSide.Top
                    )));

                cellHeader.Text = "STT";
                rRowHeader.Cells.Add(cellHeader);
            }
            foreach (GridColumn c in view.VisibleColumns)
            {
                cellHeader = new XRTableCell();
                cellHeader.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cellHeader.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                cellHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom
                     | DevExpress.XtraPrinting.BorderSide.Top
                    )));

                cellHeader.Text = c.Caption == string.Empty ? c.FieldName : c.Caption;
                rRowHeader.Cells.Add(cellHeader);
            }

            cellHeader.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                | DevExpress.XtraPrinting.BorderSide.Bottom
                 | DevExpress.XtraPrinting.BorderSide.Right
                  | DevExpress.XtraPrinting.BorderSide.Top
                )));

            rtableHeader.Rows.Add(rRowHeader);
            rRowHeader.BackColor = System.Drawing.Color.WhiteSmoke;
            rtableHeader.WidthF = width;
            rtableHeader.LocationF = new PointF(0, lbReporName.HeightF + 20);
            headerBand.HeightF = 0;
            headerBand.Controls.Add(rtableHeader);
            r.Bands.Add(headerBand);



            // ve band

            if (view is BandedGridView)
            {
                headerBand.HeightF = 250; // xac dinh sau
                rtableHeader.LocationF = new PointF(0, headerBand.HeightF - rtableHeader.HeightF);

                var l = new XRLabel();
                var bandView = (BandedGridView)view;

                List<GridBand> listLevel0 = new List<GridBand>();
                List<GridBand> listLevel1 = new List<GridBand>();
                List<GridBand> listLevel2 = new List<GridBand>();
                List<GridBand> listLevel3 = new List<GridBand>();

                List<GridBand> listLast = null;

                foreach (GridBand b in bandView.Bands)
                {
                    if (b.BandLevel == 0)
                        listLevel0.Add(b);
                    foreach (GridBand b1 in b.Children)
                    {
                        if (b1.BandLevel == 1)
                            listLevel1.Add(b1);
                        foreach (GridBand b2 in b1.Children)
                        {
                            if (b2.BandLevel == 2)
                                listLevel2.Add(b2);
                            foreach (GridBand b3 in b2.Children)
                            {
                                if (b3.BandLevel == 3)
                                    listLevel3.Add(b3);

                            }
                        }
                    }
                }
                if (listLevel3.Count > 0) listLast = listLevel3;
                else if (listLevel2.Count > 0) listLast = listLevel2;
                else if (listLevel1.Count > 0) listLast = listLevel1;

                XRTableCell xrCell = null;

                if (showSTT)
                {
                    xrCell = rRowHeader.Cells[0];

                    l.Name = "lbSTT";
                    l.Text = "STT";
                    l.WidthF = xrCell.WidthF;
                    l.HeightF = 50; // xac dinh sau

                    l.LocationF = new PointF(xrCell.LocationF.X, headerBand.HeightF - xrCell.HeightF - l.HeightF);

                    l.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                                            | DevExpress.XtraPrinting.BorderSide.Top)));
                    l.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                    l.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    l.BackColor = Color.WhiteSmoke;
                    headerBand.Controls.Add(l);
                }

                List<GridBand> listBand1 = new List<GridBand>(); // luu nhung thang có cha

                string labelName = string.Empty;
                for (int i = 0; i < bandView.VisibleColumns.Count; i++)
                {

                    BandedGridColumn c = (BandedGridColumn)bandView.VisibleColumns[i];
                    if (c.OwnerBand != null)
                    {
                        xrCell = showSTT ? rRowHeader.Cells[i + 1] : rRowHeader.Cells[i];

                        labelName = string.Format("lb{0}", c.OwnerBand.Caption);
                        l = headerBand.FindControl(labelName, true) as XRLabel;
                        if (l == null)
                        {
                            l = new XRLabel();
                            l.Name = labelName;
                            l.Text = c.OwnerBand.Caption;
                            l.WidthF = xrCell.WidthF;
                            l.HeightF = 50; // xac dinh sau

                            l.LocationF = new PointF(xrCell.LocationF.X, headerBand.HeightF - xrCell.HeightF - l.HeightF);

                            l.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                                                    | DevExpress.XtraPrinting.BorderSide.Top)));

                            l.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                            l.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                            l.BackColor = Color.WhiteSmoke;

                            headerBand.Controls.Add(l);
                        }
                        else
                        {
                            l.WidthF += xrCell.WidthF;
                        }
                    }
                }
                l.Borders |= ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right)));

                foreach (GridBand b in listLevel2)
                {
                    if (b.Columns.Count > 0) continue;

                    labelName = string.Format("lb{0}", b.Caption);
                    l = headerBand.FindControl(labelName, true) as XRLabel;
                    if (l == null)
                    {
                        l = new XRLabel();
                        l.Name = labelName;
                        l.Text = b.Caption;
                        l.WidthF = 0;
                        l.HeightF = 50; // xac dinh sau

                        bool t = false;
                        foreach (GridBand bChild in b.Children)
                        {
                            labelName = string.Format("lb{0}", bChild.Caption);
                            var lchild = headerBand.FindControl(labelName, true) as XRLabel;
                            if (lchild != null)
                            {
                                l.WidthF += lchild.WidthF;
                                if (t == false)
                                {
                                    l.LocationF = new PointF(lchild.LocationF.X, lchild.LocationF.Y - l.HeightF);
                                    t = true;
                                }
                            }

                        }

                        l.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                                                | DevExpress.XtraPrinting.BorderSide.Top)));

                        l.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                        l.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        l.BackColor = Color.WhiteSmoke;

                        headerBand.Controls.Add(l);
                    }
                }


                foreach (GridBand b in listLevel1)
                {
                    if (b.Columns.Count > 0) continue;

                    labelName = string.Format("lb{0}", b.Caption);
                    l = headerBand.FindControl(labelName, true) as XRLabel;
                    if (l == null)
                    {
                        l = new XRLabel();
                        l.Name = labelName;
                        l.Text = b.Caption;
                        l.WidthF = 0;
                        l.HeightF = 50; // xac dinh sau

                        bool t = false;
                        foreach (GridBand bChild in b.Children)
                        {
                            labelName = string.Format("lb{0}", bChild.Caption);
                            var lchild = headerBand.FindControl(labelName, true) as XRLabel;
                            if (lchild != null)
                            {
                                l.WidthF += lchild.WidthF;
                                if (t == false)
                                {
                                    l.LocationF = new PointF(lchild.LocationF.X, lchild.LocationF.Y - l.HeightF);
                                    t = true;
                                }
                            }

                        }

                        l.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                                                | DevExpress.XtraPrinting.BorderSide.Top)));

                        l.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                        l.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        l.BackColor = Color.WhiteSmoke;

                        headerBand.Controls.Add(l);
                    }
                }


                foreach (GridBand b in listLevel0)
                {
                    labelName = string.Format("lb{0}", b.Caption);
                    l = headerBand.FindControl(labelName, true) as XRLabel;
                    if (l == null)
                    {
                        l = new XRLabel();
                        l.Name = labelName;
                        l.Text = b.Caption;
                        l.WidthF = 0;
                        l.HeightF = 50; // xac dinh sau

                        bool t = false;


                        foreach (GridBand bChild in b.Children)
                        {
                            labelName = string.Format("lb{0}", bChild.Caption);
                            var lchild = headerBand.FindControl(labelName, true) as XRLabel;
                            if (lchild != null)
                            {
                                l.WidthF += lchild.WidthF;
                                if (t == false)
                                {
                                    l.LocationF = new PointF(lchild.LocationF.X, lchild.LocationF.Y - l.HeightF);
                                    t = true;
                                }
                                if (l.LocationF.Y < lchild.LocationF.Y)
                                    l.LocationF = new PointF(l.LocationF.X, lchild.LocationF.Y - l.HeightF);

                            }

                        }
                        l.WidthF -= 2;

                        l.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                                                | DevExpress.XtraPrinting.BorderSide.Top)));

                        l.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                        l.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                        l.BackColor = Color.WhiteSmoke;

                        headerBand.Controls.Add(l);
                    }

                    if (b.Columns.Count > 0)
                    {
                        int max = listLast.Max(z => z.BandLevel);

                        l.HeightF += max * 50;
                        l.LocationF = new PointF(l.LocationF.X, l.LocationF.Y - max * 50);
                    }
                }
                l.Borders |= ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right)));

                for (int i = 0; i < rRowHeader.Cells.Count; i++)
                {
                    rRowHeader.Cells[i].Text = (i + 1).ToString();
                }

                rtableHeader.ConvertToControls();
                var stt = headerBand.FindControl("lbSTT", true);
                if (stt != null)
                {
                    stt.HeightF += 50;
                    stt.LocationF = new PointF(stt.LocationF.X, stt.LocationF.Y - 50);
                }
                headerBand.HeightF = 0;
            }




            // ADD GROUP
            for (int i = view.GroupedColumns.Count - 1; i >= 0; i--)
            {
                GridColumn c = view.GroupedColumns[i];
                GroupHeaderBand groupBand = new GroupHeaderBand();
                groupBand.GroupFields.Add(new GroupField(c.FieldName));
                XRLabel lbGroup = new XRLabel();
                lbGroup.DataBindings.Add("Text", r.DataSource, c.FieldName);
                lbGroup.WidthF = width;
                lbGroup.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);

                lbGroup.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                | DevExpress.XtraPrinting.BorderSide.Bottom
                 | DevExpress.XtraPrinting.BorderSide.Right
                )));

                lbGroup.BackColor = Color.Honeydew;
                lbGroup.Padding = new DevExpress.XtraPrinting.PaddingInfo(20, 0, 0, 0);
                lbGroup.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;

                groupBand.Controls.Add(lbGroup);
                groupBand.HeightF = 0;
                r.Bands.Add(groupBand);

                // TODO: ADD SUM GROUP CHO NAY TIEP
                // LAM SAU
            }


            // ADD DETAIL TABLE
            XRTable rtable = new XRTable();
            var rRow = new XRTableRow();
            XRTableCell cell = null;
            if (showSTT)
            {
                cell = new XRTableCell();
                cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                cell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                cell.Summary.Func = SummaryFunc.RecordNumber;
                if (view.GroupedColumns.Count > 0 && showSTT)
                    cell.Summary.Running = SummaryRunning.Group;
                else
                    cell.Summary.Running = SummaryRunning.Report;

                rRow.Cells.Add(cell);
            }
            foreach (GridColumn c in view.VisibleColumns)
            {
                cell = new XRTableCell();
                if(c.ColumnType == typeof(decimal) || c.ColumnType == typeof(int))
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                else
                    cell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
                cell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom)));
                cell.DataBindings.Add("Text", r.DataSource, c.FieldName);
                cell.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0);
                rRow.Cells.Add(cell);
            }
            cell.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                | DevExpress.XtraPrinting.BorderSide.Bottom
                 | DevExpress.XtraPrinting.BorderSide.Right
                )));

            rtable.Rows.Add(rRow);

            rtable.WidthF = width;
            var detailBand = new DetailBand();
            detailBand.HeightF = rtable.HeightF;
            detailBand.Controls.Add(rtable);
            r.Bands.Add(detailBand);

            // ADD SUM FOOTER
            if (showFooter)
            {
                var reportFooter = new ReportFooterBand();
                XRTable rtableFooter = new XRTable();
                var rRowFooter = new XRTableRow();
                XRTableCell cellFooter = null;

                if (showSTT)
                {
                    cellFooter = new XRTableCell();
                    cellFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
                    cellFooter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                    cellFooter.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Bottom
                        )));

                    rRowFooter.Cells.Add(cellFooter);
                }

                for (int i = 0; i < view.VisibleColumns.Count; i++)
                {
                    var c = view.VisibleColumns[i];
                    cellFooter = new XRTableCell();
                    cellFooter.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
                    cellFooter.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0);
                    cellFooter.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
                    cellFooter.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                        | DevExpress.XtraPrinting.BorderSide.Bottom
                        )));

                    if (c.SummaryItem.SummaryType != DevExpress.Data.SummaryItemType.None)
                    {
                        cellFooter.Summary.Func = ConvertToSummaryFunc(c.SummaryItem.SummaryType);
                        cellFooter.Summary.FormatString = c.SummaryItem.DisplayFormat;
                        cellFooter.DataBindings.Add("Text", r.DataSource, c.FieldName);

                        cellFooter.Summary.Running = SummaryRunning.Report;
                    }
                    rRowFooter.Cells.Add(cellFooter);
                }

                cellFooter.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left
                    | DevExpress.XtraPrinting.BorderSide.Bottom
                     | DevExpress.XtraPrinting.BorderSide.Right
                    )));

                rtableFooter.WidthF = width;
                rRowFooter.BackColor = Color.LightYellow;
                rtableFooter.Rows.Add(rRowFooter);
                reportFooter.Controls.Add(rtableFooter);
                r.Bands.Add(reportFooter);
            }


            r.CreateDocument();
            r.ShowDesignerDialog();
        }


   


        private static SummaryFunc ConvertToSummaryFunc(DevExpress.Data.SummaryItemType t)
        {
            SummaryFunc s = SummaryFunc.Sum;
            switch (t)
            {
                case DevExpress.Data.SummaryItemType.Average:
                    s = SummaryFunc.Avg;
                    break;
                case DevExpress.Data.SummaryItemType.Count:
                    s = SummaryFunc.Count;
                    break;
                case DevExpress.Data.SummaryItemType.Max:
                    s = SummaryFunc.Max;
                    break;
                case DevExpress.Data.SummaryItemType.Min:
                    s = SummaryFunc.Min;
                    break;
                case DevExpress.Data.SummaryItemType.Sum:
                    s = SummaryFunc.Sum;
                    break;
            }
            return s;
        }
    }
}
