using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
 using  ninja.model.Manager;
 using ninja.Models;
using System.Net;
 

namespace ninja.Controllers
{
     [Authorize]
    public class InvoiceController : Controller
    {
        private InvoiceManager  mobjInvoiceManager;
        private  Utility oUtility = new Utility();

        public    InvoiceController ()
        {
           mobjInvoiceManager = new  InvoiceManager();

            

        }
        





        public ActionResult Index()
        {
          IList<BusquedaInvoice> result =  oUtility.Adapter(mobjInvoiceManager.GetAll());
          return View("Index",result);
        }




        public ActionResult Detail(int id )
        {
         
          IList<BusquedaInvoiceDetail> result =  oUtility.AdapterInverse(mobjInvoiceManager.GetDetail( id).ToList());  
          return View(result);
        }

        public ActionResult AddRow(ListaInvoiceDetail oListaInvoiceDetail)
        {
            oListaInvoiceDetail.ListaBusquedaInvoiceDetail.Add(new BusquedaInvoiceDetail()
            {
                 Amount = 1,
                  Description = "",
                   Id = oListaInvoiceDetail.ListaBusquedaInvoiceDetail.Max(x=>x.Id) + 1 ,
                    InvoiceId = oListaInvoiceDetail.ListaBusquedaInvoiceDetail.FirstOrDefault().InvoiceId,
                     TotalPrice = 0,
                      TotalPriceWithTaxes = 0,
                       UnitPrice = 0

            });

            return View("Update",oListaInvoiceDetail);
        }

         
        public ActionResult New()
        {
                 return View("New");
        }

        public ActionResult Error(string errorMsj)
        {


            return View("Error", errorMsj);
        }

         [HttpPost]
         public ActionResult New(BusquedaInvoice oBusquedaInvoice)
        { 
             if (oBusquedaInvoice.Id == 0)
            {
                return this.Error("Error en Datos");
            }

            try 
            {  
                    mobjInvoiceManager.Insert(oUtility.Adapter(oBusquedaInvoice));
                return this.Index();

            } 
                catch (Exception e) 
             {

                return this.Error(e.Message);

            }
             
             
        }



        public ActionResult Update(int id)
        {
             try 
            {
                ListaInvoiceDetail LiD = new ListaInvoiceDetail();

                 LiD.ListaBusquedaInvoiceDetail = oUtility.AdapterInverse(mobjInvoiceManager.GetDetail(id).ToList());
                   
                return View (LiD );
            } 
                catch (Exception e) 
             {
                return this.Error(e.Message);

            }
        }

       


        public ActionResult Delete(int id)
        {
             try 
            {
                     mobjInvoiceManager.Delete(id);
                return this.Index();
            } 
                catch (Exception e) 
             {
                return this.Error(e.Message);

            }
           
        }
        
        




    }
}