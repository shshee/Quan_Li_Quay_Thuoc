﻿using System;
using System.Collections.Generic;
using QuanLyQuayThuoc.DAL;
using QuanLyQuayThuoc.DTO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Windows.Forms;

namespace QuanLyQuayThuoc.BUS
{
    public class QLHoadonBUS
    {
        private static QLHoadonBUS instance;
        public static QLHoadonBUS Instance
        {
            get { if (instance == null) instance = new QLHoadonBUS(); return instance; }
            private set { instance = value; }
        }
        private QLHoadonBUS() { }
        public List<Chitietkethuoc> LoadChitiethoadonList(string id_hoadon)
        {
            List<Chitietkethuoc> ctktList = new List<Chitietkethuoc>();
            DataTable data = QLHoadonDAL.Instance.LoadChitiethoadonList(id_hoadon);
            foreach (DataRow item in data.Rows)
            {
                Chitietkethuoc ib = new Chitietkethuoc(item);
                ctktList.Add(ib);
            }
            return ctktList;
        }
        public void Themchitiethoadon(int lieuluong,string id_thuoc,string id_hoadon)
        {
            QLHoadonDAL.Instance.ThemChitiethoadon(lieuluong,id_thuoc,id_hoadon);
        }
        public void Taolaihoadon(string id_hoadon)
        {
            QLHoadonDAL.Instance.Taolaihoadon(id_hoadon);
        }
        public void Suahoadon(int id_chitietkethuoc,string id_thuoc,int lieuluong)
        {
            QLHoadonDAL.Instance.Suahoadon(id_chitietkethuoc, id_thuoc, lieuluong);
        }
        public void Xoahoadon(int id_chitietkethuoc,string id_thuoc,int lieuluong)
        {
            QLHoadonDAL.Instance.Xoahoadon(id_chitietkethuoc,id_thuoc,lieuluong);
        }
        //public DataTable LoadRevenueList(string month,string year)
        //{
        //    return RevenueDAL.Instance.LoadRevenueList(month, year);
        //}
        //    public void ExportDataTableToPdf(DataGridView dtblTable, String strPdfPath, string strHeader, string Month, string Year)
        //    {
        //        System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.Read);
        //        Document document = new Document();
        //        document.SetPageSize(iTextSharp.text.PageSize.A4);
        //        PdfWriter writer = PdfWriter.GetInstance(document, fs);
        //        document.Open();
        //        string working = Environment.CurrentDirectory;
        //        string ARIALUNI_TFF = Path.Combine(System.IO.Directory.GetParent(working).Parent.FullName, "ARIALUNI.TTF");

        //        BaseFont bf = BaseFont.CreateFont(ARIALUNI_TFF, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        //        Font fontNormal = new Font(bf, 12, Font.NORMAL);

        //        //Report Header
        //        Font fntHead = new Font(bf, 16, Font.NORMAL);
        //        Paragraph prgHeading = new Paragraph();
        //        prgHeading.Alignment = Element.ALIGN_CENTER;
        //        prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
        //        document.Add(prgHeading);

        //        //Author
        //        Paragraph prgAuthor = new Paragraph();
        //        BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
        //        Font fntAuthor = new Font(bf, 8, Font.NORMAL);
        //        prgAuthor.Alignment = Element.ALIGN_RIGHT;
        //        prgAuthor.Add(new Chunk("\n Ngày xuất : " + DateTime.Now.ToShortDateString(), fntAuthor));
        //        document.Add(prgAuthor);

        //        //Add a line seperation
        //        Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.GRAY, Element.ALIGN_LEFT, 1)));
        //        document.Add(p);

        //        //Add line break
        //        document.Add(new Chunk("\n", fntHead));

        //        //Write the table
        //        PdfPTable pdfTable = new PdfPTable(dtblTable.Columns.Count);
        //        //Table header
        //        pdfTable.DefaultCell.Padding = 3;
        //        pdfTable.WidthPercentage = 100;
        //        pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
        //        Font fntCell = new Font(bf, 10, Font.NORMAL);
        //        foreach (DataGridViewColumn column in dtblTable.Columns)
        //        {
        //            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fntCell));
        //            pdfTable.AddCell(cell);
        //        }

        //        DataTable dataTable = LoadRevenueList(Month, Year);

        //        for (int i = 0; i < dataTable.Rows.Count; i++)
        //        {
        //            for (int j = 0; j < dataTable.Columns.Count; j++)
        //            {
        //                pdfTable.AddCell(dataTable.Rows[i][j].ToString());
        //            }
        //        }
        //        document.Add(pdfTable);
        //        document.Close();
        //        writer.Close();
        //        fs.Close();
        //    }
    }
}
