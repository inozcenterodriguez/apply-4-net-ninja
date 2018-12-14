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
         
          IList<BusquedaInvoiceDetail> result =  oUtility.Adapter(mobjInvoiceManager.GetDetail( id));  
          return View(result);
        }



         
        public ActionResult New()
        {
                 return View("New");
        }


         [HttpPost]
         public ActionResult New(BusquedaInvoice oBusquedaInvoice)
        {
            try 
            {  
                    mobjInvoiceManager.Insert(oUtility.Adapter(oBusquedaInvoice));
                     
                   
            } 
                catch (Exception) 
             {
                    
                     
               
             }
              return View ("Index"  );
             
        }



        public ActionResult Update(long id, List<BusquedaInvoiceDetail> oListaBusquedaInvoiceDetail)
        {
             try 
            {
                    
                    mobjInvoiceManager.UpdateDetail(id,oUtility.AdapterDetail(oListaBusquedaInvoiceDetail));
                    return View (true);
            } 
                catch (Exception) 
             {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               
             }
        }




        public ActionResult Delete(int id)
        {
             try 
            {
                     mobjInvoiceManager.Delete(id);
                    return View(true);
            } 
                catch (Exception) 
             {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
               
             }
           
        }
        
        




    }
}