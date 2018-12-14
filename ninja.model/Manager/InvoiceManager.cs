using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ninja.model.Entity;
using ninja.model.Mock;

namespace ninja.model.Manager
    {

    public class InvoiceManager
        {

        private InvoiceMock _mock;

        public InvoiceManager()
            {

            this._mock = InvoiceMock.GetInstance();

            }

        public IList<Invoice> GetAll()
            {


            var query = this._mock.GetAll();
            var result = new List<Invoice>();



            foreach (Invoice oInvoice in query) {

                result.Add(new Invoice() {
                    Id = oInvoice.Id,
                    Type = oInvoice.Type
                    });
                }

            return result;
            }

        public Invoice GetById(long id)
            {

            return this._mock.GetById(id);





            }

        public void Insert(Invoice item)
            {

            this._mock.Insert(item);

            }

        public void Delete(long id)
            {

            Invoice invoice = this.GetById(id);
            this._mock.Delete(invoice);

            }

        public Boolean Exists(long id)
            {

            return this._mock.Exists(id);

            }

        public IList<InvoiceDetail> GetDetail(int id)
            {
            Invoice oInvoice = this._mock.GetById(id);
            var result = new List<InvoiceDetail>();
            foreach (InvoiceDetail detail in oInvoice.GetDetail()) {
                result.Add(new InvoiceDetail() {
                    Amount = detail.Amount,
                    Description = detail.Description,
                    Id = detail.Id,
                    InvoiceId = detail.InvoiceId,

                    UnitPrice = detail.UnitPrice

                    });


                }

            return result;




            }


        public void UpdateDetail(long id, IList<InvoiceDetail> detail)
            {

            /*
              Este método tiene que reemplazar todos los items del detalle de la factura
              por los recibidos por parámetro
             */

            #region Escribir el código dentro de este bloque

            this._mock.UpdateDetail(id, detail);

            #endregion Escribir el código dentro de este bloque

            }

        }

    }