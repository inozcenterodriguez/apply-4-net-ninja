using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ninja.model.Entity;

namespace ninja.Models
    {

    public class ListaInvoiceDetail
    {
      public   List<BusquedaInvoiceDetail> ListaBusquedaInvoiceDetail { get; set; }


     public    ListaInvoiceDetail()
        {
            this.ListaBusquedaInvoiceDetail = new List<BusquedaInvoiceDetail>();
        }
    }



    public class BusquedaInvoice
        {
        public long Id { get; set; }
        public string Type { get; set; }



        }

    public class BusquedaInvoiceDetail
        {




        public long InvoiceId { get; set; }
        public long Id { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double TotalPriceWithTaxes { get; set; }

        }


    public class Utility
        {
        public Invoice Adapter(BusquedaInvoice oBusquedaInvoice)
            {

            Invoice result = new Invoice() {
                Id = oBusquedaInvoice.Id,
                Type = oBusquedaInvoice.Type

                };





            return result;

            }

        public  List<BusquedaInvoiceDetail> AdapterInverse(List<InvoiceDetail> oListInvoiceDetail)
            {
                var result = new List<BusquedaInvoiceDetail>();
                foreach( InvoiceDetail item in oListInvoiceDetail)
                {
                       result.Add(new BusquedaInvoiceDetail()
                       {
                        Amount = item.Amount,
                         Description = item.Description,
                          Id = item.Id,
                           InvoiceId = item.InvoiceId,
                            TotalPrice = item.TotalPrice,
                             TotalPriceWithTaxes = item.TotalPriceWithTaxes,
                              UnitPrice = item.UnitPrice
                       
                       
                       
                       
                       
                       });
                
                }
           
                return result;
            }



        public List<InvoiceDetail> AdapterDetail(List<BusquedaInvoiceDetail> oListaBusquedaInvoiceDetail)
            {
            List<InvoiceDetail> result = new List<InvoiceDetail>();
            foreach (BusquedaInvoiceDetail item in oListaBusquedaInvoiceDetail) {
                result.Add(new InvoiceDetail() {

                    Amount = item.Amount,
                    Description = item.Description,
                    Id = item.Id,
                    InvoiceId = item.InvoiceId,
                    UnitPrice = item.UnitPrice





                    });



                }


            return result;






            }

        internal IList<BusquedaInvoice> Adapter(IList<Invoice> oInvoiceList)
            {
               var result  = new List<BusquedaInvoice>();
               
               foreach(Invoice Item in oInvoiceList)
                {
                    result.Add(new BusquedaInvoice()
                    {
                         Id = Item.Id,
                          Type = Item.Type
                    
                    
                    
                    
                    });

                }

                return result;
            }
        }



    }
