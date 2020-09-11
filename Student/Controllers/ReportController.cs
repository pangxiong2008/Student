using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Reporting.WebForms;
using Student.Models;

namespace Student.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        public ActionResult Index()
        {
            LocalReport localReport = new LocalReport();
            localReport.ReportPath = Server.MapPath("~/Report/ReportStPa.rdlc");
            using (TritonEntities EFDbContext = new TritonEntities())
            {
                var ViewData = from ViewTable in EFDbContext.StudenParents

                               select ViewTable;
                if (ViewData.Any())
                {
                    ReportDataSource ReportData = new ReportDataSource("DataSet1", ViewData.ToList());
                    localReport.DataSources.Add(ReportData);
                    string reportType = "PDF";
                    string mimeType;
                    string encoding;
                    string fileNameExtension;
                    string deviceInfo =
                    "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                    "  <PageWidth>8.5in</PageWidth>" +
                    "  <PageHeight>11in</PageHeight>" +
                    "  <MarginTop>0.5in</MarginTop>" +
                    "  <MarginLeft>1in</MarginLeft>" +
                    "  <MarginRight>1in</MarginRight>" +
                    "  <MarginBottom>0.5in</MarginBottom>" +
                    "</DeviceInfo>";
                    Warning[] warnings;
                    string[] streams;
                    byte[] renderedBytes;
                    renderedBytes = localReport.Render(
                        reportType,
                        deviceInfo,
                        out mimeType,
                        out encoding,
                        out fileNameExtension,
                        out streams,
                        out warnings);
                    return File(renderedBytes, mimeType);
                }
                return View();
            }
        }
    }
}