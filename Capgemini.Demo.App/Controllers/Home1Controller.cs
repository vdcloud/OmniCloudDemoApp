using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Net.Http;
using Capgemini.RACE.Platform.Common;
using Newtonsoft.Json;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using Capgemini.Demo.App.Models;

using System.DirectoryServices;

namespace Capgemini.Demo.App.Controllers
{
    public partial class HomeController : Controller
    {
        string baseurl = ConfigurationManager.AppSettings["BaseTableUrl"].ToString();
        string baseQueueurl = ConfigurationManager.AppSettings["BaseQueueUrl"].ToString();
        string baseBloburl = ConfigurationManager.AppSettings["BaseBlobUrl"].ToString();
        HttpClient client;
        HttpClient Queueclient;
        HttpClient BlobClient;
        public HomeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseurl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Queueclient = new HttpClient();
            Queueclient.BaseAddress = new Uri(baseQueueurl);
            Queueclient.DefaultRequestHeaders.Accept.Clear();
            Queueclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            BlobClient = new HttpClient();
            BlobClient.BaseAddress = new Uri(baseBloburl);
            BlobClient.DefaultRequestHeaders.Accept.Clear();
            BlobClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        StockDetails stk = new StockDetails();
        public User usersession;
        public ActionResult Home()
        {
            
                ViewBag.UserName = "Vivek Desai";

            // ViewBag.UserName = UserPrincipal.Current.Surname+UserPrincipal.Current.MiddleName;
            return View();
            }
        
        //public JsonResult GetStockDetails()
        //{
        //    IList<StockDetails> stocklist = new List<StockDetails>();
        //    var stock = new List<StockViewModel>();
        //    TableEntry entity = new TableEntry();
        //    var tablelist = GetStockTableDetails(entity);
        //    if (tablelist != null)
        //        foreach (var lst in tablelist)
        //        {
        //            stocklist.Add(CommonMethods.JsonDeserialize<StockDetails>(lst.TableEntityData));
        //        }
        //    bool flag = false;
        //    StockViewModel tempObj;

        //    if (stocklist.Count > 0)
        //    {
        //        var slist = stocklist.Select(a => a.StockName.ToLowerInvariant()).Where(a => !string.IsNullOrEmpty(a)).Distinct().ToList();

        //        foreach (var obj in slist)
        //        {
        //            var results = stocklist.Where(a => a.StockName.ToLowerInvariant() == obj).OrderByDescending(a => a.CreatedDateTime).ToList();
        //            tempObj = new StockViewModel();
        //            tempObj.StockId = results[0].StockId;
        //            tempObj.StockName = results[0].StockName;
        //            tempObj.Price = results[0].Price;
        //            tempObj.Quantity = results[0].Quantity;
        //            if (results.Count() > 1)
        //            {
        //                if (results[0].Price > results[1].Price)
        //                {
        //                    var difference = results[0].Price - results[1].Price;
        //                    tempObj.Difference = difference.ToString();
        //                    var percentage = ((difference / results[0].Price) * 100);
        //                    flag = true; tempObj.Price = results[0].Price; tempObj.Quantity = results[0].Quantity;
        //                    tempObj.Percentage = Math.Round((double)percentage, 2).ToString();
        //                }
        //                else
        //                {
        //                    tempObj.Price = results[0].Price; tempObj.Quantity = results[0].Quantity;
        //                    var difference = results[0].Price - results[1].Price;
        //                    var percentage = ((difference / results[1].Price) * 100);
        //                    tempObj.Difference = difference.ToString();
        //                    tempObj.Percentage = Math.Round(percentage, 2).ToString();
        //                }
        //            }
        //            else
        //            {
        //                tempObj.Difference = "0";
        //                tempObj.Percentage = "0";
        //                flag = true;
        //            }
        //            tempObj.Flag = flag;
        //            flag = false;

        //            stock.Add(tempObj);
        //        }
        //    }

        //    IList<StockDetails> queuedata = new List<StockDetails>();
        //    var queuelist = GetQueueDetails("racequeue");
        //    StockDetails queustock = new StockDetails();
        //    if (queuelist != null)
        //        foreach (var lst in queuelist)
        //        {
        //            queustock = new StockDetails();
        //            queustock = CommonMethods.JsonDeserialize<StockDetails>(lst.Message);
        //            queustock.tempDate = Convert.ToString(queustock.CreateDateTime);
        //            queuedata.Add(queustock);

        //        }
        //    queuelist = GetQueueDetails("raceoutqueue");

        //    if (queuelist != null)
        //        foreach (var lst in queuelist)
        //        {
        //            queustock = new StockDetails();
        //            queustock = CommonMethods.JsonDeserialize<StockDetails>(lst.Message);
        //            queustock.tempDate = Convert.ToString(queustock.CreateDateTime);
        //            queuedata.Add(queustock);

        //        }
        //    queuedata = queuedata.OrderByDescending(a => a.CreatedDateTime).Take<StockDetails>(5).ToList();
        //    var bloblist = GetBlobDetails();
        //    return Json(new { stockData = stock.OrderBy(a => a.StockName), queueData = queuedata, bloblist = bloblist }, JsonRequestBehavior.AllowGet);
        //}

        public JsonResult GetTableDetails()
        {
            IList<StockDetails> stocklist = new List<StockDetails>();
            var stock = new List<StockViewModel>();
            TableEntry entity = new TableEntry();
            var tablelist = GetStockTableDetails(entity);
            if (tablelist != null)
                foreach (var lst in tablelist)
                {
                    stocklist.Add(CommonMethods.JsonDeserialize<StockDetails>(lst.TableEntityData));
                }
            bool flag = false;
            StockViewModel tempObj;

            if (stocklist.Count > 0)
            {
                var slist = stocklist.Select(a => a.StockName.ToLowerInvariant()).Where(a => !string.IsNullOrEmpty(a)).Distinct().ToList();

                foreach (var obj in slist)
                {
                    var results = stocklist.Where(a => a.StockName.ToLowerInvariant() == obj).OrderByDescending(a => a.CreatedDateTime).ToList();
                    tempObj = new StockViewModel();
                    tempObj.StockId = results[0].StockId;
                    tempObj.StockName = results[0].StockName;
                    tempObj.Price = results[0].Price;
                    tempObj.Quantity = results[0].Quantity;
                    if (results.Count() > 1)
                    {
                        if (results[0].Price > results[1].Price)
                        {
                            var difference = results[0].Price - results[1].Price;
                            tempObj.Difference = difference.ToString();
                            var percentage = ((difference / results[0].Price) * 100);
                            flag = true; tempObj.Price = results[0].Price; tempObj.Quantity = results[0].Quantity;
                            tempObj.Percentage = Math.Round((double)percentage, 2).ToString();
                        }
                        else
                        {
                            tempObj.Price = results[0].Price; tempObj.Quantity = results[0].Quantity;
                            var difference = results[0].Price - results[1].Price;
                            var percentage = ((difference / results[1].Price) * 100);
                            tempObj.Difference = difference.ToString();
                            tempObj.Percentage = Math.Round(percentage, 2).ToString();
                        }
                    }
                    else
                    {
                        tempObj.Difference = "0";
                        tempObj.Percentage = "0";
                        flag = true;
                    }
                    tempObj.Flag = flag;
                    flag = false;

                    stock.Add(tempObj);
                }
            }
            return Json(new { stockData = stock.OrderBy(a => a.StockName)}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQueueDetails()
        {
            IList<StockDetails> queuedata = new List<StockDetails>();
            var queuelist = GetQueueDetails("racequeue");
            StockDetails queustock = new StockDetails();
            if (queuelist != null)
                foreach (var lst in queuelist)
                {
                    queustock = new StockDetails();
                    queustock = CommonMethods.JsonDeserialize<StockDetails>(lst.Message);
                    queustock.tempDate = Convert.ToString(queustock.CreateDateTime);
                    queuedata.Add(queustock);

                }
            queuelist = GetQueueDetails("raceoutqueue");

            if (queuelist != null)
                foreach (var lst in queuelist)
                {
                    queustock = new StockDetails();
                    queustock = CommonMethods.JsonDeserialize<StockDetails>(lst.Message);
                    queustock.tempDate = Convert.ToString(queustock.CreateDateTime);
                    queuedata.Add(queustock);

                }
            queuedata = queuedata.OrderByDescending(a => a.CreatedDateTime).Take<StockDetails>(5).ToList();
            return Json(new {queueData = queuedata}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetBlobDetails()
        {
            var bloblist = GetBlobDetails("images");
            return Json(new {bloblist = bloblist }, JsonRequestBehavior.AllowGet);
        }


        public List<TableEntry> GetStockTableDetails(TableEntry entity)
        {
            HttpResponseMessage responseMessage = client.GetAsync(baseurl + "api/nosql/gettablerows?tablename=stocktable").Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<TableEntry>>(responseData);
            }
            return null;

        }
        public ActionResult Stock()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveStockDetails(StockDetails stock)
        {
            DateTime currendate = DateTime.UtcNow;
            string stockid = Guid.NewGuid().ToString();
            stock.CreatedDateTime = currendate;
            stock.CreateDateTime = currendate;
            TableEntry entity = new TableEntry();
            stock.StockId = stockid;
            stock.PartitionKey = stockid;
            stock.StockStatus = false;
            stock.RowKey = stock.StockName;
            entity.TableName = "stocktable";
            entity.PartitionKey = stockid;

            entity.RowKey = stock.StockName;
            entity.CreateDateTime = currendate;
            entity.TableEntityData = CommonMethods.JsonSerializer<StockDetails>(stock);
            var result = AddTable(entity);

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveStockQeueue(StockDetails stock)
        {
            DateTime currendate = DateTime.UtcNow;
            string stockid = Guid.NewGuid().ToString();
            stock.CreatedDateTime = currendate;
            stock.CreateDateTime = currendate;
            TableEntry entity = new TableEntry();
            stock.StockId = stockid;
            stock.PartitionKey = stockid;
            stock.StockStatus = false;
            stock.RowKey = stock.StockName;
            entity.TableName = "stocktable";
            entity.PartitionKey = stockid;

            entity.RowKey = stock.StockName;
            entity.CreateDateTime = currendate;
            entity.TableEntityData = CommonMethods.JsonSerializer<StockDetails>(stock);
            AddMessageToQueue(entity.TableEntityData);

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }
        private TableEntry AddTable(TableEntry entity)
        {
            // New code:
            var response = client.PostAsJsonAsync("api/nosql/addrecord", entity).Result;
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                Uri gizmoUrl = response.Headers.Location;
                entity.Status = CommonEnum.ReturnMessageStatus.Success;
            }
            else
                entity.Status = CommonEnum.ReturnMessageStatus.Failure;

            return entity;
        }

        private bool DeleteTable(string tablename, string rowkey, string partionkey)
        {
            // New code:
            var response = client.DeleteAsync("api/nosql/DeleteRowData?tablename=" + tablename + "&rowkey=" + rowkey + "&partitionkey=" + partionkey + "").Result;
            if (response.IsSuccessStatusCode)
            {
                // Get the URI of the created resource.
                Uri gizmoUrl = response.Headers.Location;
            }

            return true;
        }

        private QueueEntry AddQueueMessage(QueueEntry entity)
        {

            var response = Queueclient.PostAsJsonAsync("api/queue/addmessage", entity).Result;
            if (response.IsSuccessStatusCode)
            {
                entity.Status = CommonEnum.ReturnMessageStatus.Success;
            }
            return entity;
        }

        private void AddMessageToQueue(string message)
        { QueueEntry queue = new QueueEntry();
            queue.Message = message;
            queue.Name = "racequeue";
            var queueResult = AddQueueMessage(queue);
        }
        private List<QueueEntry> GetQueueDetails(string queuename)
        {

            var response = Queueclient.GetAsync("api/queue/getmessages?queueName=" + queuename).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<QueueEntry>>(responseData);
            }
            return null;
        }

        private List<BlobEntry> GetBlobDetails(string blobName)
        {

            var response = BlobClient.GetAsync("api/blob/getbloblist?containerName=" + blobName).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseData = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<BlobEntry>>(responseData);
            }
            return null;
        }
    }
   

}

